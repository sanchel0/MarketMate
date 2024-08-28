using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    internal class EventConfigMap
    {
        public static readonly Dictionary<Operacion, int> EventosCriticidad = new Dictionary<Operacion, int>
        {
            { Operacion.Login, 1 },
            { Operacion.Logout, 1 },
            { Operacion.BloquearUsuario, 1 },
            { Operacion.DesbloquearUsuario, 1 },
            { Operacion.ActivarUsuario, 1 },
            { Operacion.DesactivarUsuario, 1 },
            { Operacion.CambiarClave, 1 },
            { Operacion.CambiarIdioma, 1 }
        };

        public static int ObtenerCriticidad(Operacion nombreEvento)
        {
            return EventosCriticidad.ContainsKey(nombreEvento)
                ? EventosCriticidad[nombreEvento]
                : 5;
        }
    }
}
