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
        public int? NumeroTransferencia { get; set; } //nullable
        public int NumeroCotizacion { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaLimiteEntrega { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public SolicitudCotizacionBE SolicitudCotizacion { get; set; }
        public ProveedorBE Proveedor { get; set; }
        public List<DetalleOrdenBE> Detalles { get; set; }
    }
}
