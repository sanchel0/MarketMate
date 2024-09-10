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

        public EventReportPdfContent(List<Evento> eventos)
        {
            _eventos = eventos;
        }

        public void GeneratePdfContent(Document document/*, string currencySymbol, Dictionary<string, string> translations*/)
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
        }
    }
}
