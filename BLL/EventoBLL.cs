using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class EventoBLL
    {
        private EventoDAL _eventoDAL;
        public static void Insert(Evento entity)
        {
            new EventoDAL().Insert(entity);
        }

        public List<Evento> GetEventosFiltrados(string username, DateTime? fechaInicio, DateTime? fechaFin, string modulo, string operacion, int? criticidad)
        {
            List<Evento> eventos = new List<Evento>();
            _eventoDAL = new EventoDAL();
            eventos = _eventoDAL.GetEventosFiltrados(username, fechaInicio, fechaFin, modulo, operacion, criticidad);
            return eventos;
        }

        public void ValidarFechas(DateTime inicio, DateTime fin)
        {
            if (inicio > fin)
            {
                throw new ValidationException(ValidationErrorType.InvalidDateRange);
            }
        }

        public void ValidarParametros(Modulo? modulo, Operacion? operacion, int? criticidad)
        {
            if (modulo == null || operacion == null || criticidad == null)
            {
                throw new ValidationException(ValidationErrorType.IncompleteFields);
            }
        }

        public void GenerarReporteDeEventos(List<Evento> eventosSeleccionados)
        {
            if (eventosSeleccionados == null || eventosSeleccionados.Count == 0)
            {
                throw new ValidationException(ValidationErrorType.NoSelection);
            }

            PDFGenerator pdfGenerator = new PDFGenerator();

            BasePdfContent pdfContent;
            string namePdf = string.Empty;

            if (eventosSeleccionados.Count == 1)
            {
                pdfContent = new EventReportPdfContent(eventosSeleccionados[0]);
                namePdf = "Evento.pdf";
            }
            else
            {
                pdfContent = new EventReportPdfContent(eventosSeleccionados);
                namePdf = "Eventos.pdf";
            }

            pdfGenerator.GeneratePDF(pdfContent, namePdf);
        }
    }
}
