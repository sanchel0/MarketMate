using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PermisoSimple : Permiso
    {
        public PermisoSimple(string pNombre, TipoPermiso pTipo) : base(pNombre, pTipo)
        {
        }

        public override List<Permiso> Hijos
        {
            get
            {
                return new List<Permiso>();
            }
        }
    }
}
