using BE;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.TabStop;

namespace Services
{
    public class SolicitudCotizacionPdfContent : BasePdfContent
    {
        private SolicitudCotizacionBE _solicitudCotizacion;
        private ProveedorBE _proveedor;

        public SolicitudCotizacionPdfContent(SolicitudCotizacionBE solicitudCotizacion, ProveedorBE proveedor)
        {
            _solicitudCotizacion = solicitudCotizacion;
            _proveedor = proveedor;
        }

        public override void GeneratePdfContent(Document document)
        {
            Paragraph title = new Paragraph(GetTranslation("SolicitudCotizacionTitle"), fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            document.Add(title);

            document.Add(new Paragraph($"{GetTranslation("SolicitudCotizacionNumeroSolicitud")}: {_solicitudCotizacion.NumeroSolicitud}"));
            document.Add(new Paragraph($"{GetTranslation("SolicitudCotizacionFechaSolicitud")}: {_solicitudCotizacion.FechaSolicitud:dd/MM/yyyy}"));

            document.Add(new Paragraph(new Phrase(GetTranslation("ProveedorData"), fontSubTitle)) { Alignment = Element.ALIGN_LEFT, SpacingBefore = 10f, SpacingAfter = 10f });
            document.Add(new Paragraph($"{GetTranslation("ProveedorCUIT")}: {_proveedor.CUIT}"));
            document.Add(new Paragraph($"{GetTranslation("ProveedorNombre")}: {_proveedor.Nombre}"));
            document.Add(new Paragraph($"{GetTranslation("ProveedorRazonSocial")}: {_proveedor.RazonSocial}"));
            document.Add(new Paragraph($"{GetTranslation("ProveedorTelefono")}: {_proveedor.Telefono}"));
            document.Add(new Paragraph($"{GetTranslation("ProveedorCorreo")}: {_proveedor.Correo}"));

            document.Add(new Paragraph(new Phrase(GetTranslation("CotizacionDetails"), fontSubTitle)) { Alignment = Element.ALIGN_LEFT, SpacingBefore = 10f, SpacingAfter = 10f });

            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;

            table.AddCell(GetTranslation("Producto"));
            table.AddCell(GetTranslation("CantidadSolicitada"));

            foreach (var detalle in _solicitudCotizacion.Detalles)
            {
                table.AddCell(GetTranslation(detalle.Producto.Nombre));
                table.AddCell(detalle.Cantidad.ToString());
            }

            document.Add(table);
        }
    }
}
