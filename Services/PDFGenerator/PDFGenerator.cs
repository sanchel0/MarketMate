using BE;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PDFGenerator
    {
        private Dictionary<string, string> _translations = new Dictionary<string, string>();

        public PDFGenerator(/*Dictionary<string, string> t*/)
        {
            //_translations = t;
        }

        /*public void GenerateTicketPDF(TicketBE ticket, string filePath)
        {
            string currencySymbol = SessionManager.Language == Language.en ? "€" : "$";

            Document document = new Document();

            try
            {
                // Crear instancia de PdfWriter para escribir en el archivo
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                // Abrir el documento para escritura
                document.Open();

                // Agregar contenido al documento
                Paragraph title = new Paragraph(GetTranslation("Title"), FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK));
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Chunk("\n\n"));

                // Agregar los detalles del ticket
                document.Add(new Paragraph($"{GetTranslation("TicketNumber")}: {ticket.NumeroTicket}"));
                if (ticket.NumeroTransaccion != null)
                    document.Add(new Paragraph($"{GetTranslation("TransactionNumber")}: {ticket.NumeroTransaccion}"));
                document.Add(new Paragraph($"{GetTranslation("PaymentMethod")}: {ticket.MetodoPago}"));
                if (ticket.TipoTarjeta != null)
                    document.Add(new Paragraph($"{GetTranslation("CardType")}: {ticket.TipoTarjeta}"));
                if (ticket.NumeroTarjeta != null)
                    document.Add(new Paragraph($"{GetTranslation("CardNumber")}: ************{ticket.NumeroTarjeta}"));
                if (ticket.AliasMP != null)
                    document.Add(new Paragraph($"{GetTranslation("PaymentAlias")}: {ticket.AliasMP}"));
                document.Add(new Paragraph($"{GetTranslation("Date")}: {ticket.Fecha.ToString("d")}"));
                document.Add(new Paragraph($"{GetTranslation("Amount")}: {currencySymbol}{ticket.Monto}"));
                document.Add(new Paragraph("\n"));

                // Agregar detalles del cliente
                document.Add(new Paragraph(GetTranslation("CustomerData")));
                document.Add(new Paragraph($"{GetTranslation("FirstName")}: {ticket.Cliente.Nombre}"));
                document.Add(new Paragraph($"{GetTranslation("LastName")}: {ticket.Cliente.Apellido}"));
                document.Add(new Paragraph($"{GetTranslation("Email")}: {ticket.Cliente.Correo}"));
                document.Add(new Paragraph($"{GetTranslation("Phone")}: {ticket.Cliente.Telefono}"));
                document.Add(new Paragraph("\n"));

                // Agregar detalles de la venta
                PdfPTable table = new PdfPTable(4); // Número de columnas
                table.WidthPercentage = 100; // Ancho de la tabla en porcentaje del ancho de la página

                // Agregar encabezados de la tabla
                table.AddCell(GetTranslation("Product"));
                table.AddCell(GetTranslation("Quantity"));
                table.AddCell(GetTranslation("UnitPrice"));
                table.AddCell(GetTranslation("Subtotal"));

                // Agregar los detalles de venta como filas de la tabla
                foreach (var detalle in ticket.Detalles)
                {
                    table.AddCell(detalle.Producto.Nombre);
                    table.AddCell(detalle.Cantidad.ToString());
                    table.AddCell($"{currencySymbol}{detalle.PrecioUnitario}");
                    table.AddCell($"{currencySymbol}{detalle.SubTotal}");
                }

                // Agregar la tabla al documento
                document.Add(table);

                // Cerrar el documento
                document.Close();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar el PDF: {ex.Message}");
            }
        }*/

        public void GeneratePDF(IPdfContent pdfContent, string filePath)
        {
            //string currencySymbol = SessionManager.Language == Language.en ? "€" : "$";

            Document document = new Document();

            try
            {
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));
                document.Open();

                AddHeader(document);

                pdfContent.GeneratePdfContent(document/*, currencySymbol, _translations*/);

                document.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar el PDF: {ex.Message}");
                document.Close();
            }
        }

        private void AddHeader(Document document)
        {
            try
            {
                // Obtener el logotipo desde Recursos
                string logoPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logo.png");

                // Cargar el logotipo en iTextSharp
                Image logo = Image.GetInstance(logoPath);
                logo.ScaleToFit(50f, 50f); // Ajustar tamaño del logotipo
                logo.Alignment = Image.ALIGN_LEFT;

                // Crear el título con el nombre de la empresa
                Font fontTitle = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16f, BaseColor.BLACK);
                Phrase title = new Phrase("MarketMate", fontTitle);

                // Crear tabla para organizar el encabezado
                PdfPTable headerTable = new PdfPTable(2);
                headerTable.WidthPercentage = 100;
                headerTable.SetWidths(new float[] { 1f, 4f }); // Ajustar proporciones

                // Celda del logotipo
                PdfPCell logoCell = new PdfPCell(logo)
                {
                    Border = PdfPCell.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };

                // Celda del título
                PdfPCell titleCell = new PdfPCell(new Paragraph(title))
                {
                    Border = PdfPCell.NO_BORDER,
                    HorizontalAlignment = Element.ALIGN_LEFT,
                    VerticalAlignment = Element.ALIGN_MIDDLE
                };

                // Agregar celdas a la tabla
                headerTable.AddCell(logoCell);
                headerTable.AddCell(titleCell);

                // Agregar la tabla al documento
                document.Add(headerTable);

                // Espaciado después del encabezado
                document.Add(new Paragraph("\n"));
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al agregar el encabezado al PDF.", ex);
            }
        }

        public string GetTranslation(string key)
        {
            return _translations.ContainsKey(key) ? _translations[key] : key;
        }
    }
}
