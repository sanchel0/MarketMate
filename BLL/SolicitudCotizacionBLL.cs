using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SolicitudCotizacionBLL : BaseBLL<SolicitudCotizacionBE>
    {
        private ISolicitudCotizacionDAL _solicitudDAL;
        private ProductoBLL productoBLL;

        public SolicitudCotizacionBLL() : base(new SolicitudCotizacionDAL())
        {
            _solicitudDAL = (ISolicitudCotizacionDAL)Crud;
            productoBLL = new ProductoBLL();
            TableName = "SolicitudesCotizacion";
        }

        protected override Modulo EventoModulo => Modulo.Compras;
        protected override Operacion EventoOperacion { get; set; }

        public override void Insert(SolicitudCotizacionBE solicitud)
        {
            solicitud.FechaSolicitud = DateTime.Now;
            EventoOperacion = Operacion.GenerarSolicitudCotizacion;
            _solicitudDAL.Insert(solicitud);
            InsertEventAndUpdateDV();
            InsertDetalles(solicitud);
            InsertarProveedoresSolicitud(solicitud);
        }

        public void InsertDetalles(SolicitudCotizacionBE solicitud)
        {
            TableName = "DetallesOrdenCompra";
            EventoOperacion = Operacion.RegistrarDetallesSolicitud;
            _solicitudDAL.InsertarDetallesSolicitud(solicitud.NumeroSolicitud, solicitud.Detalles);
            InsertEventAndUpdateDV();
            TableName = "SolicitudesCotizacion";
        }

        public void InsertarProveedoresSolicitud(SolicitudCotizacionBE solicitud)
        {
            TableName = "ProveedoresSolicitudes";
            EventoOperacion = Operacion.RegistrarProveedoresSolicitud;
            _solicitudDAL.InsertarProveedoresSolicitud(solicitud.NumeroSolicitud, solicitud.Proveedores);
            InsertEventAndUpdateDV();
            TableName = "SolicitudesCotizacion";
        }
        /*public SolicitudCotizacionBE GetById(int id)
        {
            var solicitud = solicitudDAL.GetById(id);

            return solicitudDAL.GetById(id);
        }*/

        /*public List<SolicitudCotizacionBE> GetAll(int id)
        {
            return solicitudDAL.GetAll();
        }*/

        public List<int> GetAllIds()
        {
            return _solicitudDAL.GetAllIds();
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

        public void GenerarReporteDeSolicitud(SolicitudCotizacionBE solicitudCotizacion)
        {
            string folder = $"Solicitud_{solicitudCotizacion.NumeroSolicitud}";
            Directory.CreateDirectory(folder);

            PDFGenerator pdfGenerator = new PDFGenerator();

            foreach (var proveedor in solicitudCotizacion.Proveedores)
            {
                var pdfContent = new SolicitudCotizacionPdfContent(solicitudCotizacion, proveedor);

                string filePath = Path.Combine(folder, $"SolicitudCotizacion_{proveedor.CUIT}.pdf");

                pdfGenerator.GeneratePDF(pdfContent, filePath);
            }
        }
    }
}
