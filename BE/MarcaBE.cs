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

        public int Codigo { get; set; }
        public string Nombre { get; set; }
    }
}
