using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProveedorBE
    {
        public int CUIT { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public string Banco { get; set; } //nullable?
        public string CBU { get; set; } //nullable?
    }
}
