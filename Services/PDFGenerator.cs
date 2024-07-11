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
        public void GenerateTicketPDF(TicketBE ticket, string filePath)
        {
            // Crear el documento
            Document document = new Document();

            try
            {
                // Crear instancia de PdfWriter para escribir en el archivo
                PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create));

                // Abrir el documento para escritura
                document.Open();

                // Agregar contenido al documento
                Paragraph title = new Paragraph("Detalle de Ticket", FontFactory.GetFont(FontFactory.TIMES, 18f, BaseColor.BLACK));
                title.Alignment = Element.ALIGN_CENTER;
                document.Add(title);
                document.Add(new Chunk("\n\n"));

                // Agregar los detalles del ticket
                document.Add(new Paragraph($"Número de Ticket: {ticket.NumeroTicket}"));
                document.Add(new Paragraph($"Número de Transacción: {ticket.NumeroTransaccion}"));
                document.Add(new Paragraph($"Método de Pago: {ticket.MetodoPago}"));
                document.Add(new Paragraph($"Tipo de Tarjeta: {ticket.TipoTarjeta}"));
                document.Add(new Paragraph($"Número de Tarjeta: {ticket.NumeroTarjeta}"));
                document.Add(new Paragraph($"Alias de Medio de Pago: {ticket.AliasMP}"));
                document.Add(new Paragraph($"Fecha: {ticket.Fecha}"));
                document.Add(new Paragraph($"Monto: {ticket.Monto}"));
                document.Add(new Paragraph("\n"));

                // Agregar detalles del cliente
                document.Add(new Paragraph("Datos del Cliente:"));
                document.Add(new Paragraph($"Nombre: {ticket.Cliente.Nombre}"));
                document.Add(new Paragraph($"Apellido: {ticket.Cliente.Apellido}"));
                document.Add(new Paragraph($"Correo: {ticket.Cliente.Correo}"));
                document.Add(new Paragraph($"Teléfono: {ticket.Cliente.Telefono}"));
                document.Add(new Paragraph("\n"));

                // Agregar detalles de la venta
                document.Add(new Paragraph("Detalles de Venta:"));
                foreach (var detalle in ticket.Detalles)
                {
                    document.Add(new Paragraph($"Producto: {detalle.Producto.Nombre}, Cantidad: {detalle.Cantidad}, Precio Unitario: {detalle.PrecioUnitario}, Subtotal: {detalle.SubTotal}"));
                }

                // Cerrar el documento
                document.Close();

                // Mostrar mensaje de éxito
                Console.WriteLine($"PDF generado exitosamente en: {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al generar el PDF: {ex.Message}");
            }
        }
    }
}
