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
    public class RecepcionPdfContent : BasePdfContent
    {
        private RecepcionBE _recepcion;

        public RecepcionPdfContent(RecepcionBE recepcion)
        {
            _recepcion = recepcion;
        }

        public override void GeneratePdfContent(Document document)
        {
            Font fontTitle = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f);
            Paragraph title = new Paragraph(GetTranslation("RecepcionTitle"), fontTitle)  // Traducción del título
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            document.Add(title);

            document.Add(new Paragraph($"{GetTranslation("RecepcionNumeroRecepcion")}: {_recepcion.NumeroRecepcion}"));
            document.Add(new Paragraph($"{GetTranslation("RecepcionFechaRecepcion")}: {_recepcion.FechaRecepcion:dd/MM/yyyy}"));
            document.Add(new Paragraph($"{GetTranslation("RecepcionNumeroFactura")}: {_recepcion.NumeroFactura}"));
            document.Add(new Paragraph($"{GetTranslation("RecepcionMontoFactura")}: {_recepcion.MontoFactura:C}"));
            document.Add(new Paragraph($"{GetTranslation("RecepcionFechaFactura")}: {_recepcion.FechaFactura:dd/MM/yyyy}"));

            document.Add(new Paragraph(new Phrase(GetTranslation("OrdenCompraData"), fontSubTitle))  // Título de la sección de la orden
            {
                Alignment = Element.ALIGN_LEFT,
                SpacingBefore = 10f,
                SpacingAfter = 10f
            });
            document.Add(new Paragraph($"{GetTranslation("RecepcionNumeroOrden")}: {_recepcion.Orden.NumeroOrden}"));

            document.Add(new Paragraph(new Phrase(GetTranslation("RecepcionDetalles"), fontSubTitle))  // Título de la sección de detalles
            {
                Alignment = Element.ALIGN_LEFT,
                SpacingBefore = 10f,
                SpacingAfter = 10f
            });

            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;

            table.AddCell(GetTranslation("Producto"));
            table.AddCell(GetTranslation("CantidadSolicitada"));
            table.AddCell(GetTranslation("CantidadRecibida"));

            foreach (var detalle in _recepcion.Detalles)
            {
                var detalleOrdenCompra = _recepcion.Orden.Detalles
                .FirstOrDefault(d => d.Producto.Codigo == detalle.Producto.Codigo);

                int cantidadSolicitada = detalleOrdenCompra != null ? detalleOrdenCompra.CantidadSolicitada : 0;

                table.AddCell(GetTranslation(detalle.Producto.Nombre));
                table.AddCell(cantidadSolicitada.ToString());
                table.AddCell(detalle.CantidadRecibida.ToString());
            }

            document.Add(table);
        }
    }
}
