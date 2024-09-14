using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProveedorBE
    {
        public ProveedorBE(string cuit, string nombre, string razonSocial, int telefono, string correo)
        {
            CUIT = cuit;
            Nombre = nombre;
            RazonSocial = razonSocial;
            Telefono = telefono;
            Correo = correo;
        }

        public string CUIT { get; set; }
        public string Nombre { get; set; }
        public string RazonSocial { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }//nullable
        public string Banco { get; set; } //nullable
        public string TipoCuenta { get; set; } //nullable
        public string NumCuenta { get; set; }//nullable
        public string CBU { get; set; } //nullable
        public string Alias { get; set; }//nullable
    }
}
