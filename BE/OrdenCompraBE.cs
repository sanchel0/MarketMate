using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class OrdenCompraBE
    {
        public int NumeroOrden { get; set; }
        public int? NumeroTransaccion { get; set; } //nullable
        public MetodoPago MetodoPago { get; set; }
        public TipoTarjeta? TipoTarjeta { get; set; } //nullable
        public int? NumeroTarjeta { get; set; }//últimos 4 digitos - nullable
        public string AliasMP { get; set; } //nullable
        public string Banco { get; set; } //nullable
        public string CBU { get; set; } //nullable
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public SolicitudCotizacionBE Cotizacion { get; set; }
        public ProveedorBE Proveedor { get; set; }
        public List<DetalleVentaBE> Detalles { get; set; }
    }
}
