using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using static iTextSharp.text.TabStop;

namespace Services
{
    public class TicketPdfContent : BasePdfContent
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

        public override void GeneratePdfContent(Document document)
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

            Paragraph title = new Paragraph(GetTranslation("TicketReportTitle"), fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            };
            document.Add(title);

            // Información del ticket
            document.Add(new Paragraph($"{GetTranslation("NumeroTicket")}: {_ticket.NumeroTicket}"));
            if (_ticket.NumeroTransaccion.HasValue)
                document.Add(new Paragraph($"{GetTranslation("NumeroTransaccion")}: {_ticket.NumeroTransaccion}"));
            document.Add(new Paragraph($"{GetTranslation("MetodoPago")}: {_ticket.MetodoPago}"));
            if (_ticket.TipoTarjeta.HasValue)
                document.Add(new Paragraph($"{GetTranslation("TipoTarjeta")}: {_ticket.TipoTarjeta}"));
            if (_ticket.NumeroTarjeta.HasValue)
                document.Add(new Paragraph($"{GetTranslation("NumeroTarjeta")}: ************{_ticket.NumeroTarjeta}"));
            if (!string.IsNullOrEmpty(_ticket.AliasMP))
                document.Add(new Paragraph($"{GetTranslation("AliasMP")}: {_ticket.AliasMP}"));
            document.Add(new Paragraph($"{GetTranslation("Fecha")}: {_ticket.Fecha.ToString("d")}"));
            document.Add(new Paragraph($"{GetTranslation("Monto")}: {_ticket.Monto:C}"));

            // Información del cliente
            document.Add(new Paragraph(new Phrase(GetTranslation("ClienteDatos"), fontSubTitle)) { Alignment = Element.ALIGN_LEFT, SpacingBefore = 10f, SpacingAfter = 10f });
            document.Add(new Paragraph($"{GetTranslation("Nombre")}: {_ticket.Cliente.Nombre}"));
            document.Add(new Paragraph($"{GetTranslation("Apellido")}: {_ticket.Cliente.Apellido}"));
            document.Add(new Paragraph($"{GetTranslation("Correo")}: {_ticket.Cliente.Correo}"));
            document.Add(new Paragraph($"{GetTranslation("Telefono")}: {_ticket.Cliente.Telefono}"));

            document.Add(new Paragraph(new Phrase(GetTranslation("DetallesProductos"), fontSubTitle)) { Alignment = Element.ALIGN_LEFT, SpacingBefore = 10f, SpacingAfter = 10f });

            // Crear una tabla para los detalles de la venta
            PdfPTable table = new PdfPTable(4);
            table.WidthPercentage = 100;

            table.AddCell(GetTranslation("Producto"));
            table.AddCell(GetTranslation("Cantidad"));
            table.AddCell(GetTranslation("PrecioUnitario"));
            table.AddCell(GetTranslation("Subtotal"));

            foreach (var detalle in _ticket.Detalles)
            {
                table.AddCell(GetTranslation(detalle.Producto.Nombre));
                table.AddCell(detalle.Cantidad.ToString());
                table.AddCell($"{detalle.PrecioUnitario:C}");
                table.AddCell($"{detalle.SubTotal:C}");
            }

            document.Add(table);
        }

        private void GenerateMultipleTicketsContent(Document document)
        {
            document.Add(new Paragraph(GetTranslation("TicketsReportMultiple"), FontFactory.GetFont(FontFactory.TIMES, 16, BaseColor.BLACK)));

            PdfPTable table = new PdfPTable(5);
            table.WidthPercentage = 100;

            table.AddCell(GetTranslation("TicketNumber"));
            table.AddCell(GetTranslation("TransactionNumber"));
            table.AddCell(GetTranslation("PaymentMethod"));
            table.AddCell(GetTranslation("Date"));
            table.AddCell(GetTranslation("Amount"));

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
