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

        public PermisoCompuesto(PermisoCompuesto otroPermisoCompuesto) : base(otroPermisoCompuesto.Nombre, otroPermisoCompuesto.Tipo)
        {
            _hijos = new List<Permiso>(otroPermisoCompuesto._hijos.Count);
            foreach (var hijo in otroPermisoCompuesto._hijos)
            {
                if (hijo is PermisoCompuesto permisoCompuestoHijo)
                {
                    _hijos.Add(new PermisoCompuesto(permisoCompuestoHijo));
                }
                else if(hijo is PermisoSimple patenteHijo)
                {
                    _hijos.Add(patenteHijo);
                }
            }
            Codigo = otroPermisoCompuesto.Codigo;
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
