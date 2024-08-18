using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Evento
    {
        public UsuarioBE Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public Modulo Modulo { get; set; }
        public int Criticidad { get; set; }
    }
}
