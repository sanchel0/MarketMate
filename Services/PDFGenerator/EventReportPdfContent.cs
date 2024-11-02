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
    public class EventReportPdfContent : IPdfContent
    {
        private List<Evento> _eventos;
        private bool _isSingle;

        public EventReportPdfContent(List<Evento> eventos)
        {
            _eventos = eventos;
            _isSingle = _eventos.Count == 1;
        }

        public EventReportPdfContent(Evento evento)
        {
            _eventos = new List<Evento> { evento };
            _isSingle = true;
        }

        public void GeneratePdfContent(Document document)
        {
            if (_isSingle)
            {
                GenerateSingleEventContent(document);
            }
            else
            {
                GenerateMultipleEventsContent(document);
            }
        }

        private void GenerateSingleEventContent(Document document)
        {
            var evento = _eventos[0];
            Font fontTitle = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f); 
            document.Add(new Paragraph("Event Report (Single Event)", fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            });
            document.Add(new Paragraph($"User: {evento.Usuario.Username}"));
            document.Add(new Paragraph($"Date: {evento.Fecha.ToShortDateString()}"));
            document.Add(new Paragraph($"Hour: {evento.Hora.ToShortTimeString()}"));
            document.Add(new Paragraph($"Module: {evento.Modulo}"));
            document.Add(new Paragraph($"Operation: {evento.Operacion}"));
            document.Add(new Paragraph($"Criticality: {evento.Criticidad}"));
        }

        private void GenerateMultipleEventsContent(Document document)
        {
            Font fontTitle = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f); 
            document.Add(new Paragraph("Event Report (Multiple Events)", fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            });

            PdfPTable table = new PdfPTable(6);
            table.AddCell("User");
            table.AddCell("Date");
            table.AddCell("Hour");
            table.AddCell("Module");
            table.AddCell("Operation");
            table.AddCell("Criticality");

            foreach (var evento in _eventos)
            {
                table.AddCell(evento.Usuario.Username);
                table.AddCell(evento.Fecha.ToShortDateString());
                table.AddCell(evento.Hora.ToShortTimeString());
                table.AddCell(evento.Modulo.ToString());
                table.AddCell(evento.Operacion.ToString());
                table.AddCell(evento.Criticidad.ToString());
            }

            document.Add(table);
        }
        /*public void GeneratePdfContent(Document document, string currencySymbol, Dictionary<string, string> translations)
        {
            PdfPTable table = new PdfPTable(6);
            table.AddCell("User");
            table.AddCell("Date");
            table.AddCell("Hour");
            table.AddCell("Module");
            table.AddCell("Operation");
            table.AddCell("Criticality");

            foreach (var evento in _eventos)
            {
                table.AddCell(evento.Usuario.Username);
                table.AddCell(evento.Fecha.ToShortDateString());
                table.AddCell(evento.Hora.ToShortTimeString());
                table.AddCell(evento.Modulo.ToString());
                table.AddCell(evento.Operacion.ToString());
                table.AddCell(evento.Criticidad.ToString());
            }

            document.Add(table);
        }*/
    }
}
