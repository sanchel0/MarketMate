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
        private ITicketDAL ticketDAL;
        public TicketBLL() : base(new TicketDAL())
        {
            ticketDAL = (ITicketDAL)crud;
        }
        public void AsignarCliente(TicketBE pTicket, ClienteBE pCliente)
        {
            pTicket.Cliente = pCliente;
        }

        public void AgregarDetalleVenta(TicketBE pTicket, DetalleVentaBE pDetalleVenta)
        {
            pTicket.Detalles.Add(pDetalleVenta);
        }

        public void AsignarDatosPago(TicketBE pTicket, int? pNumeroTransaccion, MetodoPago pMetodoPago, TipoTarjeta? pTipoTarjeta, int? pNumeroTarjeta, string pAliasMP, DateTime pFecha)
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
            int ultimoNumero = ticketDAL.GetLastTransactionNumber();
            return ultimoNumero + 1;
        }
    }
}
