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

        public UsuarioBE(string pDni, string pNombre, string pApellido, string pCorreo, PermisoCompuesto pRol, bool pBloqueo, bool pActivo)
            : base(pDni, pNombre, pApellido, pCorreo)
        {
            Rol = pRol;
            Bloqueo = pBloqueo;
            Activo = pActivo;
        }

        public UsuarioBE(UsuarioBE u) : base(u.Dni, u.Nombre, u.Apellido, u.Correo)
        {
            this.Username = u.Username;
            this.Password = u.Password;
            this.Idioma = u.Idioma;
            this.Rol = u.Rol;
            this.Bloqueo = u.Bloqueo;
            this.Activo = u.Activo;
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public Language Idioma { get; set; }
        public PermisoCompuesto Rol { get; set; }
        public bool Bloqueo { get; set; }
        public bool Activo { get; set; }
    }
}
