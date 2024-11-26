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
    public class EventReportPdfContent : BasePdfContent
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

        public override void GeneratePdfContent(Document document)
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
            document.Add(new Paragraph(GetTranslation("EventReportSingleEvent"), fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            });
            document.Add(new Paragraph($"{GetTranslation("User")}: {evento.Usuario.Username}"));
            document.Add(new Paragraph($"{GetTranslation("Date")}: {evento.Fecha.ToShortDateString()}"));
            document.Add(new Paragraph($"{GetTranslation("Hour")}: {evento.Hora.ToShortTimeString()}"));
            document.Add(new Paragraph($"{GetTranslation("Module")}: {GetTranslation(evento.Modulo.ToString())}"));
            document.Add(new Paragraph($"{GetTranslation("Operation")}: {GetTranslation(evento.Operacion.ToString())}"));
            document.Add(new Paragraph($"{GetTranslation("Criticality")}: {GetTranslation(evento.Criticidad.ToString())}"));
        }

        private void GenerateMultipleEventsContent(Document document)
        {
            Font fontTitle = FontFactory.GetFont(FontFactory.TIMES_BOLD, 18f); 
            document.Add(new Paragraph(GetTranslation("EventReportMultipleEvents"), fontTitle)
            {
                Alignment = Element.ALIGN_CENTER,
                SpacingAfter = 20f
            });

            PdfPTable table = new PdfPTable(6);
            table.AddCell(GetTranslation("User"));
            table.AddCell(GetTranslation("Date"));
            table.AddCell(GetTranslation("Hour"));
            table.AddCell(GetTranslation("Module"));
            table.AddCell(GetTranslation("Operation"));
            table.AddCell(GetTranslation("Criticality"));

            foreach (var evento in _eventos)
            {
                table.AddCell(evento.Usuario.Username);
                table.AddCell(evento.Fecha.ToShortDateString());
                table.AddCell(evento.Hora.ToShortTimeString());
                table.AddCell(GetTranslation(evento.Modulo.ToString()));
                table.AddCell(GetTranslation(evento.Operacion.ToString()));
                table.AddCell(GetTranslation(evento.Criticidad.ToString()));
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
