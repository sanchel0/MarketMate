using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public abstract class Permiso
    {
        public Permiso(string pNombre, TipoPermiso pTipo)
        {
            Nombre = pNombre;
            Tipo = pTipo;
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public TipoPermiso Tipo { get; set; }
        public abstract List<Permiso> Hijos { get; }

        public virtual void Add(Permiso p)
        {

        }
        public void Remove(Permiso p)
        {

        }
    }
}
