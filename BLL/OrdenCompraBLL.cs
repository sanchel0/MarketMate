using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrdenCompraBLL : BaseBLL<OrdenCompraBE>
    {
        private IOrdenCompraDAL _ordenDAL;
        ProductoBLL productoBLL;

        public OrdenCompraBLL() : base(new OrdenCompraDAL())
        {
            _ordenDAL = (IOrdenCompraDAL)Crud;
            productoBLL = new ProductoBLL();
            TableName = "OrdenesCompra";
        }

        protected override Modulo EventoModulo => Modulo.Compras;
        protected override Operacion EventoOperacion { get; set; }

        public override void Insert(OrdenCompraBE orden)
        {
            decimal total = 0;

            foreach (var detalle in orden.Detalles)
            {
                total += detalle.SubTotal;
            }
            orden.Total = total;

            orden.Estado = "Pendiente";
            orden.FechaEmision = DateTime.Now;
            EventoOperacion = Operacion.GenerarOrdenCompra;
            base.Insert(orden);
            InsertDetalles(orden);
        }

        public override void Update(OrdenCompraBE orden)
        {
            EventoOperacion = Operacion.ModificarOrdenCompra;
            base.Update(orden);
        }

        /*public OrdenCompraBE GetById(string id)
        {
            return ordenDAL.GetById(id);
        }

        public List<OrdenCompraBE> GetAll()
        {
            return ordenDAL.GetAll();
        }*/

        public List<OrdenCompraBE> GetAllPendientes()
        {
            return _ordenDAL.GetAllPendientes();
        }

        public void InsertDetalles(OrdenCompraBE orden)
        {
            TableName = "DetallesOrdenCompra";
            EventoOperacion = Operacion.RegistrarDetallesOrden;
            _ordenDAL.InsertarDetallesOrdenCompra(orden.NumeroOrden, orden.Detalles);
            InsertEventAndUpdateDV();
            TableName = "OrdenesCompra";
        }

        public void UpdateCantidadRecibidaDetalle(int numOrden, DetalleOrdenBE detalle)
        {
            TableName = "DetallesOrdenCompra";
            EventoOperacion = Operacion.ModificarDetallesOrden;
            _ordenDAL.UpdateCantidadRecibidaDetalle(numOrden, detalle);
            InsertEventAndUpdateDV();
            TableName = "OrdenesCompra";
        }

        public void VerificarYActualizar(OrdenCompraBE orden)
        {
            if (TodosLosProductosRecibidos(orden))
            {
                orden.Estado = "Completo";
                Update(orden);
            }
        }

        private bool TodosLosProductosRecibidos(OrdenCompraBE orden)
        {
            foreach (var detalle in orden.Detalles)
            {
                if (detalle.CantidadSolicitada > detalle.CantidadRecibida)
                {
                    return false; // No todos los productos han sido recibidos
                }
            }
            return true; // Todos los productos han sido recibidos
        }

        public void AsignarNumeroTransferencia(OrdenCompraBE orden, int numTransferencia)
        {
            orden.NumeroTransferencia = numTransferencia;
        }

        public void AsignarDetalles(OrdenCompraBE orden, List<DetalleOrdenBE> detalles)
        {
            orden.Detalles = detalles;
        }

        public void AsignarProveedor(OrdenCompraBE orden, ProveedorBE proveedor)
        {
            orden.Proveedor = proveedor;
        }

        public void AgregarProductoADetalles(ProductoBE producto, string precioText, string cantidadText, string ivaText, BindingList<DetalleOrdenBE> detalles)
        {
            int cant = productoBLL.ValidarCantidad(cantidadText);

            if (string.IsNullOrWhiteSpace(precioText) || !decimal.TryParse(precioText, out decimal precio) || precio <= 0)
                throw new ArgumentException("El precio debe ser un valor numérico mayor que cero.");

            if (!decimal.TryParse(ivaText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal iva) || iva < 0 || iva > 100)
            {
                throw new Exception("Por favor, ingrese un porcentaje de IVA válido entre 0 y 100.");
            }

            if (detalles.Any(d => d.Producto.Codigo == producto.Codigo))
            {
                throw new Exception("El producto ya está seleccionado.");
            }

            DetalleOrdenBE detalle = new DetalleOrdenBE
            (
                producto,
                cant,
                precio,
                iva
            );
            CalcularValores(detalle);

            detalles.Add(detalle);
        }

        public void CalcularValores(DetalleOrdenBE detalle)
        {
            detalle.SubTotal = detalle.CantidadSolicitada * detalle.PrecioUnitario;
            detalle.TotalConIVA = detalle.SubTotal * (1 + (detalle.PorcentajeIVA / 100));
        }

        public void QuitarProductoDeDetalles(DetalleOrdenBE detalle, BindingList<DetalleOrdenBE> detalles)
        {
            ProductoBE productoEnLista = detalle.Producto;

            if (productoEnLista == null)
            {
                throw new Exception("Producto no encontrado en la lista.");
            }

            detalles.Remove(detalle);
        }

        public void AsignarDatos(OrdenCompraBE orden, SolicitudCotizacionBE solicitud, int numCoti, List<DetalleOrdenBE> list, ProveedorBE prov, DateTime dateTime)
        {
            orden.FechaLimiteEntrega = dateTime;
            orden.SolicitudCotizacion = solicitud;
            orden.NumeroCotizacion = numCoti;
            AsignarDetalles(orden, list);
            AsignarProveedor(orden, prov);
            Insert(orden);
        }

        public void GenerarReporteDeOrdenes(List<OrdenCompraBE> ordenesSeleccionadas)
        {
            if (ordenesSeleccionadas == null || ordenesSeleccionadas.Count == 0)
            {
                throw new ArgumentException("Debe seleccionar al menos una orden para generar el reporte.");
            }

            PDFGenerator pdfGenerator = new PDFGenerator();

            IPdfContent pdfContent;
            string namePdf = string.Empty;

            if (ordenesSeleccionadas.Count == 1)
            {
                pdfContent = new OrdenCompraPdfContent(ordenesSeleccionadas[0]);
                namePdf = "Orden.pdf";
            }
            else
            {
                pdfContent = new OrdenCompraPdfContent(ordenesSeleccionadas);
                namePdf = "Ordenes.pdf";
            }

            pdfGenerator.GeneratePDF(pdfContent, namePdf);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Reportes, Operacion.GenerarReporte2));
        }
    }
}
