using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ClienteBE : PersonaBE
    {
        public ClienteBE(string pDni, string pNombre, string pApellido, string pCorreo, int telefono) : base(pDni, pNombre, pApellido, pCorreo)
        {
            Telefono = telefono;
        }

        public int Telefono { get; set; }

        public override string ToString()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}
