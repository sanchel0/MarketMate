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
        public Evento(UsuarioBE pUser, Modulo pModulo, Operacion pOp)
        {
            Usuario = pUser;
            Fecha = DateTime.Now;
            Hora = DateTime.Now;
            Modulo = pModulo;
            Operacion = pOp;

            Criticidad = EventConfigMap.ObtenerCriticidad(pOp);

            ModuloE = Modulo.ToString();
            OperacionE = Operacion.ToString();
        }

        public UsuarioBE Usuario { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public Modulo Modulo { get; set; }
        public string ModuloE { get; set; }
        public Operacion Operacion { get; set; }
        public string OperacionE { get; set; }
        public int Criticidad { get; set; }
    }
}
