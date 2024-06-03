using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class TicketBE
    {
        public int NumeroTicket { get; set; }
        public int NumeroTransaccionBancaria { get; set; }
        public MetodoPago MetodoPago { get; set; }
        public TipoTarjeta TipoTarjeta { get; set; } //nullable
        public int NumeroTargeta { get; set; }//últimos 4 digitos - nullable
        public string AliasMP { get; set; } //nullable
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public ClienteBE Cliente { get; set; }
        public List<DetalleVentaBE> Detalles { get; set; }
    }
}
