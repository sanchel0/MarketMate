using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class CategoriaBE
    {
        public CategoriaBE(string nombre, string descripcion)
        {
            Nombre = nombre;
            Descripcion = descripcion;
        }

        //Copy Constructor
        public CategoriaBE(CategoriaBE categoria)
        {
            this.Codigo = categoria.Codigo;
            this.Nombre = categoria.Nombre;
            this.Descripcion = categoria.Descripcion;
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}
