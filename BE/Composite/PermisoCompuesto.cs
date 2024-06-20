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

        public PermisoCompuesto(string pNombre, TipoPermiso pTipo) : base(pNombre, pTipo)
        {
            _hijos = new List<Permiso>();
        }
        public override void Add(Permiso pPermiso)
        {
            _hijos.Add(pPermiso);
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
