using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class MarcaBE
    {
        public MarcaBE(string pNombre)
        {
            Nombre = pNombre;
        }

        //Copy Constructor
        public MarcaBE(MarcaBE marca)
        {
            this.Codigo = marca.Codigo;
            this.Nombre = marca.Nombre;
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
