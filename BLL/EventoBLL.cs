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
            //new DigitoVerificadorBLL().Update("Eventos");
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
                throw new Exception("Fecha de Inicio es mayor que la Fecha de Fin.");
            }
        }

        public void ValidarParametros(Modulo? modulo, Operacion? operacion, int? criticidad)
        {
            if (modulo == null || operacion == null || criticidad == null)
            {
                throw new Exception("Por favor, seleccione un Módulo, una Operación y un Nivel de Criticidad.");
            }
        }
    }
}
