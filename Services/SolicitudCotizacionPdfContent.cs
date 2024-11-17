using BE;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SolicitudCotizacionPdfContent : IPdfContent
    {
        private SolicitudCotizacionBE _solicitudCotizacion;
        private ProveedorBE _proveedor;

        public SolicitudCotizacionPdfContent(SolicitudCotizacionBE solicitudCotizacion, ProveedorBE proveedor)
        {
            _solicitudCotizacion = solicitudCotizacion;
            _proveedor = proveedor;
        }

        public void GeneratePdfContent(Document document)
        {
            Font fontTitle = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f);
            Paragraph title = new Paragraph($"Solicitud de Cotización", fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            document.Add(title);

            document.Add(new Paragraph($"Número de Solicitud: {_solicitudCotizacion.NumeroSolicitud}"));
            document.Add(new Paragraph($"Fecha de Solicitud: {_solicitudCotizacion.FechaSolicitud:dd/MM/yyyy}"));
            document.Add(new Paragraph("\n"));

            document.Add(new Paragraph("Datos del Proveedor"));
            document.Add(new Paragraph($"CUIT: {_proveedor.CUIT}"));
            document.Add(new Paragraph($"Nombre: {_proveedor.Nombre}"));
            document.Add(new Paragraph($"Razón Social: {_proveedor.RazonSocial}"));
            document.Add(new Paragraph($"Teléfono: {_proveedor.Telefono}"));
            document.Add(new Paragraph($"Correo: {_proveedor.Correo}"));
            document.Add(new Paragraph("\n"));

            document.Add(new Paragraph("Detalles de la Solicitud de Cotización"));
            PdfPTable table = new PdfPTable(2);
            table.WidthPercentage = 100;

            table.AddCell("Producto");
            table.AddCell("Cantidad Solicitada");

            foreach (var detalle in _solicitudCotizacion.Detalles)
            {
                table.AddCell(detalle.Producto.Nombre);
                table.AddCell(detalle.Cantidad.ToString());
            }

            document.Add(table);
        }
    }
}
