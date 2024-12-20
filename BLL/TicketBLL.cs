﻿using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TicketBLL : BaseBLL<TicketBE>
    {
        private ITicketDAL _ticketDAL;
        ProductoBLL productoBLL;
        public TicketBLL() : base(new TicketDAL())
        {
            _ticketDAL = (ITicketDAL)Crud;
            productoBLL = new ProductoBLL();
            TableName = "Tickets";
        }

        protected override Modulo EventoModulo => Modulo.Ventas;
        protected override Operacion EventoOperacion { get; set; }

        public override void Insert(TicketBE entity)
        {
            CalcularMontoTotal(entity);
            EventoOperacion = Operacion.GenerarTicket;
            base.Insert(entity);
        }

        public override void Update(TicketBE entity)
        {
            EventoOperacion = Operacion.ModificarTicket;
            base.Update(entity);
        }

        public void AsignarCliente(TicketBE pTicket, ClienteBE pCliente)
        {
            pTicket.Cliente = pCliente;
        }

        public void AgregarDetallesVenta(TicketBE pTicket, List<DetalleVentaBE> pDetalles)
        {
            pTicket.Detalles = pDetalles;
        }

        public void CalcularMontoTotal(TicketBE pTicket)
        {
            decimal total = 0;

            if (pTicket.Detalles != null)
            {
                foreach (var detalle in pTicket.Detalles)
                {
                    total += detalle.TotalConIVA;
                }
            }

            pTicket.Monto = total;
        }

        public void AsignarDatosPago(TicketBE pTicket, int? pNumeroTransaccion, MetodoPago pMetodoPago, TipoTarjeta? pTipoTarjeta, long? pNumeroTarjeta, string pAliasMP, DateTime pFecha)
        {
            pTicket.NumeroTransaccion = pNumeroTransaccion;
            pTicket.MetodoPago = pMetodoPago;
            pTicket.TipoTarjeta = pTipoTarjeta;
            
            if(pNumeroTarjeta != null)
            {
                string numeroTarjetaStr = pNumeroTarjeta.ToString();
                pTicket.NumeroTarjeta = int.Parse(numeroTarjetaStr.Substring(numeroTarjetaStr.Length - 4));
            }

            pTicket.AliasMP = pAliasMP;
            pTicket.Fecha = pFecha;
        }

        public int GetLastTransactionNumber()
        {
            int ultimoNumero = _ticketDAL.GetLastTransactionNumber();
            return ultimoNumero + 1;
        }

        public void FinalizarTicket(TicketBE ticket)
        {
            Update(ticket);
            InsertDetallesAndUpdateStock(ticket);
        }

        public void InsertDetallesAndUpdateStock(TicketBE ticket)
        {
            ProductoBLL productoBLL = new ProductoBLL();

            foreach (DetalleVentaBE detalle in ticket.Detalles)
            {
                ProductoBE producto = detalle.Producto;
                int cantidadVendida = detalle.Cantidad;

                productoBLL.Update(producto);
            }

            _ticketDAL.InsertDetallesVenta(ticket);

            EventoOperacion = Operacion.RegistrarDetallesTicket;
            TableName = "DetallesVenta";
            InsertEventAndUpdateDV();
            TableName = "Tickets";
        }

        public void AgregarProductoADetalles(ProductoBE producto, string cantidadText, BindingList<DetalleVentaBE> detalles)
        {
            productoBLL.ValidarCantidadParaVenta(producto, cantidadText, out int cantidadADescontar);

            if (detalles.Any(d => d.Producto.Codigo == producto.Codigo))
            {
                throw new ValidationException(ValidationErrorType.DuplicateProduct);
            }

            DetalleVentaBE detalle = new DetalleVentaBE
            (
                producto,
                cantidadADescontar,
                producto.Precio
            );
            CalcularValores(detalle);
            
            productoBLL.DescontarStock(producto, cantidadADescontar);

            detalles.Add(detalle);
        }

        private void CalcularValores(DetalleVentaBE detalle)
        {
            detalle.SubTotal = detalle.Cantidad * detalle.PrecioUnitario;
            detalle.TotalConIVA = detalle.SubTotal * (1 + (detalle.Producto.PorcentajeIVA / 100));
        }

        public void QuitarProductoDeDetalles(DetalleVentaBE detalle, BindingList<DetalleVentaBE> detallesVenta, BindingList<ProductoBE> productos)
        {
            ProductoBE productoEnLista = productos.FirstOrDefault(p => p.Codigo == detalle.Producto.Codigo);

            if (productoEnLista == null)
            {
                throw new ValidationException(ValidationErrorType.ProductNotFound);
            }

            productoBLL.RestaurarStock(productoEnLista, detalle.Cantidad);

            detallesVenta.Remove(detalle);
        }

        public void GenerarReporteDeTickets(List<TicketBE> ticketsSeleccionados)
        {
            if (ticketsSeleccionados == null || ticketsSeleccionados.Count == 0)
            {
                throw new ValidationException(ValidationErrorType.NoSelection);
            }

            PDFGenerator pdfGenerator = new PDFGenerator();

            BasePdfContent pdfContent;
            string namePdf = string.Empty;

            if (ticketsSeleccionados.Count == 1)
            {
                pdfContent = new TicketPdfContent(ticketsSeleccionados[0]);
                namePdf = "Ticket.pdf";
            }
            else
            {
                pdfContent = new TicketPdfContent(ticketsSeleccionados);
                namePdf = "Tickets.pdf";
            }

            pdfGenerator.GeneratePDF(pdfContent, namePdf);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Reportes, Operacion.GenerarReporte1));
        }
    }
}
