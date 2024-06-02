using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class UsuarioBE : PersonaBE
    {
        /*private string username;
        private string password;
        private Rol rol;
        private bool bloqueo;
        private bool activo;*/

        public UsuarioBE(string pDni, string pNombre, string pApellido, string pCorreo, Rol pRol, bool pBloqueo, bool pActivo)
            : base(pDni, pNombre, pApellido, pCorreo)
        {
            Rol = pRol;
            Bloqueo = pBloqueo;
            Activo = pActivo;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public Rol Rol { get; set; }
        public bool Bloqueo { get; set; }
        public bool Activo { get; set; }
    }
}
