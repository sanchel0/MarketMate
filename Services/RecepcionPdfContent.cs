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
    public class RecepcionPdfContent : IPdfContent
    {
        private RecepcionBE _recepcion;

        public RecepcionPdfContent(RecepcionBE recepcion)
        {
            _recepcion = recepcion;
        }

        public void GeneratePdfContent(Document document)
        {
            Font fontTitle = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f);
            Paragraph title = new Paragraph($"Recepción", fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            document.Add(title);

            document.Add(new Paragraph($"Número de Recepción: {_recepcion.NumeroRecepcion}"));
            document.Add(new Paragraph($"Fecha de Recepción: {_recepcion.FechaRecepcion:dd/MM/yyyy}"));
            document.Add(new Paragraph($"Número de Factura: {_recepcion.NumeroFactura}"));
            document.Add(new Paragraph($"Monto de Factura: {_recepcion.MontoFactura:C}"));
            document.Add(new Paragraph($"Fecha de Factura: {_recepcion.FechaFactura:dd/MM/yyyy}"));
            document.Add(new Paragraph("\n"));

            document.Add(new Paragraph("Datos de la Orden de Compra"));
            document.Add(new Paragraph($"Número de Orden: {_recepcion.Orden.NumeroOrden}"));
            document.Add(new Paragraph("\n"));

            document.Add(new Paragraph("Detalles de la Recepción"));
            PdfPTable table = new PdfPTable(3);
            table.WidthPercentage = 100;

            table.AddCell("Producto");
            table.AddCell("Cantidad Solicitada");
            table.AddCell("Cantidad Recibida");

            foreach (var detalle in _recepcion.Detalles)
            {
                var detalleOrdenCompra = _recepcion.Orden.Detalles
                .FirstOrDefault(d => d.Producto.Codigo == detalle.Producto.Codigo);

                int cantidadSolicitada = detalleOrdenCompra != null ? detalleOrdenCompra.CantidadSolicitada : 0;

                table.AddCell(detalle.Producto.Nombre);
                table.AddCell(cantidadSolicitada.ToString());
                table.AddCell(detalle.CantidadRecibida.ToString());
            }

            document.Add(table);
        }
    }
}
