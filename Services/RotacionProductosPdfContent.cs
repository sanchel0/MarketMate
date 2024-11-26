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
    public class RotacionProductosPdfContent : BasePdfContent
    {
        private Dictionary<ProductoBE, int> productos;
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

        public override void GeneratePdfContent(Document document)
        {
            string rotacion = esMayorRotacion ? GetTranslation("MayorRotacion") : GetTranslation("MenorRotacion");

            // Título del reporte con fechas
            Paragraph title = new Paragraph($"{GetTranslation("ReporteProductos")} {rotacion}\n{GetTranslation("Fecha")}: {fechaInicio.ToShortDateString()} - {fechaFin.ToShortDateString()}", fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 10
            };
            document.Add(title);

            PdfPTable table = new PdfPTable(9);
            table.WidthPercentage = 100;
            table.SpacingBefore = 10;

            // Encabezados de la tabla con traducción
            table.AddCell(GetTranslation("Codigo"));
            table.AddCell(GetTranslation("Nombre"));
            table.AddCell(GetTranslation("Stock"));
            table.AddCell(GetTranslation("StockMinimo"));
            table.AddCell(GetTranslation("StockMaximo"));
            table.AddCell(GetTranslation("Categoria"));
            table.AddCell(GetTranslation("Marca"));
            table.AddCell(GetTranslation("Precio"));
            table.AddCell(GetTranslation("CantidadVendida"));

            foreach (var entry in productos)
            {
                ProductoBE producto = entry.Key;
                int totalVendido = entry.Value;

                table.AddCell(producto.Codigo);
                table.AddCell(GetTranslation(producto.Nombre));
                table.AddCell(producto.Stock.ToString());
                table.AddCell(producto.StockMinimo.ToString());
                table.AddCell(producto.StockMaximo.ToString());
                table.AddCell(GetTranslation(producto.Categoria.Nombre));
                table.AddCell(GetTranslation(producto.Marca));
                table.AddCell(producto.Precio.ToString("C"));
                table.AddCell(totalVendido.ToString());
            }

            document.Add(table);

            Paragraph footer = new Paragraph($"{GetTranslation("ReporteGeneradoEl")} {DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}")
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingBefore = 20
            };
            document.Add(footer);
        }
    }
}
