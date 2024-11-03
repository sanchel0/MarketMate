using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface ISolicitudCotizacionDAL : ICrud<SolicitudCotizacionBE>
    {
        void InsertarDetallesSolicitud(int numeroSolicitud, List<DetalleSolicitudBE> detalles);
        void InsertarProveedoresSolicitud(int numeroSolicitud, List<ProveedorBE> proveedores);
        List<int> GetAllIds();
    }
}
