using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;

namespace Services
{
    public class TicketPdfContent : IPdfContent
    {
        private List<TicketBE> tickets;
        private bool _isSingle;

        public TicketPdfContent(List<TicketBE> ordenes)
        {
            tickets = ordenes;
            _isSingle = tickets.Count == 1;
        }

        public TicketPdfContent(TicketBE orden)
        {
            tickets = new List<TicketBE> { orden };
            _isSingle = true;
        }

        public void GeneratePdfContent(Document document)
        {
            if (_isSingle)
            {
                GenerateSingleTicketContent(document);
            }
            else
            {
                GenerateMultipleTicketsContent(document);
            }
        }

        private void GenerateSingleTicketContent(Document document)
        {
            var _ticket = tickets[0];
            Font fontTitle = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f);
            Paragraph title = new Paragraph("Ticket Report", fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            document.Add(title);

            // Información del ticket
            document.Add(new Paragraph($"Número de Ticket: {_ticket.NumeroTicket}"));
            if (_ticket.NumeroTransaccion.HasValue)
                document.Add(new Paragraph($"Número de Transacción: {_ticket.NumeroTransaccion}"));
            document.Add(new Paragraph($"Método de Pago: {_ticket.MetodoPago}"));
            if (_ticket.TipoTarjeta.HasValue)
                document.Add(new Paragraph($"Tipo de Tarjeta: {_ticket.TipoTarjeta}"));
            if (_ticket.NumeroTarjeta.HasValue)
                document.Add(new Paragraph($"Número de Tarjeta: ************{_ticket.NumeroTarjeta}"));
            if (!string.IsNullOrEmpty(_ticket.AliasMP))
                document.Add(new Paragraph($"Alias de Medio de Pago: {_ticket.AliasMP}"));
            document.Add(new Paragraph($"Fecha: {_ticket.Fecha.ToString("d")}"));
            document.Add(new Paragraph($"Monto: {_ticket.Monto:C}"));
            document.Add(new Paragraph("\n"));

            // Información del cliente
            document.Add(new Paragraph("Datos del Cliente"));
            document.Add(new Paragraph($"Nombre: {_ticket.Cliente.Nombre}"));
            document.Add(new Paragraph($"Apellido: {_ticket.Cliente.Apellido}"));
            document.Add(new Paragraph($"Correo: {_ticket.Cliente.Correo}"));
            document.Add(new Paragraph($"Teléfono: {_ticket.Cliente.Telefono}"));
            document.Add(new Paragraph("\n"));

            document.Add(new Paragraph("Detalles de los Productos:") { Alignment = Element.ALIGN_LEFT, SpacingBefore = 10f });

            // Crear una tabla para los detalles de la venta
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;

            table.AddCell("Producto");
            table.AddCell("Cantidad");
            table.AddCell("Precio Unitario");
            table.AddCell("Subtotal");

            foreach (var detalle in _ticket.Detalles)
            {
                table.AddCell(detalle.Producto.Nombre);
                table.AddCell(detalle.Cantidad.ToString());
                table.AddCell($"{detalle.PrecioUnitario:C}");
                table.AddCell($"{detalle.SubTotal:C}");
            }

            document.Add(table);
        }

        private void GenerateMultipleTicketsContent(Document document)
        {
            document.Add(new Paragraph("Tickets Report (Multiple tickets)", FontFactory.GetFont(FontFactory.TIMES, 16, BaseColor.BLACK)));

            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100;

            table.AddCell("Ticket Number");
            table.AddCell("Transaction Number");
            table.AddCell("Payment Method");
            table.AddCell("Date");
            table.AddCell("Amount");

            foreach (var ticket in tickets)
            {
                table.AddCell(ticket.NumeroTicket.ToString());
                table.AddCell(ticket.NumeroTransaccion.HasValue ? ticket.NumeroTransaccion.ToString() : "N/A");
                table.AddCell(ticket.MetodoPago.ToString());
                table.AddCell(ticket.Fecha.ToShortDateString());
                table.AddCell(ticket.Monto.ToString("C"));
            }

            document.Add(table);
        }
    }
}
