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
        public void Insert(Evento entity)
        {
            _eventoDAL = new EventoDAL();
            _eventoDAL.Insert(entity);
        }

        public List<Evento> GetEventosFiltrados(string username, DateTime? fechaInicio, DateTime? fechaFin, string modulo, string operacion, int? criticidad)
        {
            List<Evento> eventos = new List<Evento>();
            _eventoDAL = new EventoDAL();
            eventos = _eventoDAL.GetEventosFiltrados(username, fechaInicio, fechaFin, modulo, operacion, criticidad);
            return eventos;
        }
    }
}
