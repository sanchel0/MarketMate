using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class TicketBLL : BaseBLL<TicketBE>
    {
        private ITicketDAL _ticketDAL;
        public TicketBLL() : base(new TicketDAL())
        {
            _ticketDAL = (ITicketDAL)Crud;
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
                    total += detalle.SubTotal;
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

        public void ActualizarStockPorTicket(TicketBE ticket)
        {
            ProductoBLL productoBLL = new ProductoBLL();

            foreach (DetalleVentaBE detalle in ticket.Detalles)
            {
                ProductoBE producto = detalle.Producto;
                int cantidadVendida = detalle.Cantidad;

                productoBLL.Update(producto);
            }
            _ticketDAL.InsertDetallesVenta(ticket);
        }
    }
}
