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
    }
}
