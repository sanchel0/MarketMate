using BE;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace Services
{
    public class RotacionProductosPdfContent : IPdfContent
    {
        private Dictionary<ProductoBE, int> productos;
        private int totalVendido;
        private DateTime fechaInicio;
        private DateTime fechaFin;
        private bool esMayorRotacion;

        public RotacionProductosPdfContent(Dictionary<ProductoBE, int> dict, DateTime fechaInicio, DateTime fechaFin, bool esMayorRotacion)
        {
            this.productos = dict;
            this.fechaInicio = fechaInicio;
            this.fechaFin = fechaFin;
            this.esMayorRotacion = esMayorRotacion;
        }

        public void GeneratePdfContent(Document document)
        {
            string rotacion = esMayorRotacion ? "Mayor Rotación" : "Menor Rotación";
            Paragraph title = new Paragraph($"Reporte de Productos con {rotacion}\nFecha: {fechaInicio.ToShortDateString()} - {fechaFin.ToShortDateString()}")
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 10
            };
            document.Add(title);

            PdfPTable table = new PdfPTable(9);
            table.WidthPercentage = 100;
            table.SpacingBefore = 10;

            table.AddCell("Código");
            table.AddCell("Nombre");
            table.AddCell("Stock");
            table.AddCell("Stock Mínimo");
            table.AddCell("Stock Máximo");
            table.AddCell("Categoría");
            table.AddCell("Marca");
            table.AddCell("Precio");
            table.AddCell("Cantidad Vendida");

            foreach (var entry in productos)
            {
                ProductoBE producto = entry.Key;
                int totalVendidos = entry.Value;

                table.AddCell(producto.Codigo);
                table.AddCell(producto.Nombre);
                table.AddCell(producto.Stock.ToString());
                table.AddCell(producto.StockMinimo.ToString());
                table.AddCell(producto.StockMaximo.ToString());
                table.AddCell(producto.Categoria.Nombre);
                table.AddCell(producto.Marca);
                table.AddCell(producto.Precio.ToString("C"));
                table.AddCell(totalVendido.ToString());
            }

            document.Add(table);

            Paragraph footer = new Paragraph($"Reporte generado el {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}")
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingBefore = 20
            };
            document.Add(footer);
        }
    }
}
