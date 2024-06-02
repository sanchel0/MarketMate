using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class PersonaBE//SI HAY ERROR, PONERLA EN PUBLIC
    {
        /*private string dni;
        private string nombre;
        private string apellido;
        private string correo;*/

        public PersonaBE(string pDni, string pNombre, string pApellido, string pCorreo)
        {
            Dni = pDni;
            Nombre = pNombre;
            Apellido = pApellido;
            Correo = pCorreo;
        }

        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
    }
}
