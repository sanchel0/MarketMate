using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SolicitudCotizacionBLL
    {
        SolicitudCotizacionDAL solicitudDAL;

        public SolicitudCotizacionBLL()
        {
            solicitudDAL = new SolicitudCotizacionDAL();
        }

        public void Insert(SolicitudCotizacionBE solicitud)
        {
            solicitudDAL.Insert(solicitud);
        }

        public SolicitudCotizacionBE GetById(int id)
        {
            return solicitudDAL.GetById(id);
        }

        public List<SolicitudCotizacionBE> GetAll(int id)
        {
            return solicitudDAL.GetAll();
        }

        public List<int> GetAllIds()
        {
            return solicitudDAL.GetAllIds();
        }

        public void AsignarDetalles(SolicitudCotizacionBE pSolicitud, List<DetalleSolicitudBE> pDetalles)
        {
            pSolicitud.Detalles = pDetalles;
        }

        public void AsignarProveedores(SolicitudCotizacionBE pSolicitud, List<ProveedorBE> pProveedores)
        {
            pSolicitud.Proveedores = pProveedores;
        }
    }
}
