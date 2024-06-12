using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class PermisoCompuesto : Permiso
    {
        private List<Permiso> _hijos;

        public PermisoCompuesto(string pNombre) : base(pNombre)
        {
        }

        public override List<Permiso> Hijos
        {
            get
            {
                return _hijos;
            }

        }
    }
}
