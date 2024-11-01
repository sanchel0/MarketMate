using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SolicitudCotizacionBLL
    {
        SolicitudCotizacionDAL solicitudDAL;
        private ProductoBLL productoBLL;

        public SolicitudCotizacionBLL()
        {
            solicitudDAL = new SolicitudCotizacionDAL();
            productoBLL = new ProductoBLL();
        }

        public void Insert(SolicitudCotizacionBE solicitud)
        {
            solicitud.FechaSolicitud = DateTime.Now;
            solicitudDAL.Insert(solicitud);
        }

        public SolicitudCotizacionBE GetById(int id)
        {
            var solicitud = solicitudDAL.GetById(id);

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

        public void FinalizarSolicitud(SolicitudCotizacionBE solicitud, List<DetalleSolicitudBE> detalles, List<ProveedorBE> proveedores)
        {
            AsignarDetalles(solicitud, detalles);
            AsignarProveedores(solicitud, proveedores);
            Insert(solicitud);
        }

        public void AgregarProductoADetalles(ProductoBE producto, string cantidadText, BindingList<DetalleSolicitudBE> detalles)
        {
            productoBLL.ValidarCantidadParaSolicitud(producto, cantidadText, out int cantidadASolicitar);

            if (detalles.Any(d => d.Producto.Codigo == producto.Codigo))
            {
                throw new Exception("El producto ya está seleccionado.");
            }

            detalles.Add(new DetalleSolicitudBE
            {
                Producto = producto,
                Cantidad = cantidadASolicitar
            });
        }
    }
}
