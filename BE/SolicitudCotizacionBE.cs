using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class SolicitudCotizacionBE
    {
        public int NumeroSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public List<ProveedorBE> Proveedores { get; set; }
        public List<DetalleSolicitudBE> Detalles { get; set; }
    }
}
