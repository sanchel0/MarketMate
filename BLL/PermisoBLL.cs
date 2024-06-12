using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class PermisoBLL
    {
        PermisoDAL _permiso;

        public PermisoBLL()
        {
            _permiso = new PermisoDAL();
        }

        public bool Existe(Permiso p, int cod)
        {
            bool existe = false;

            if (p.Codigo.Equals(cod))
                existe = true;
            else

                foreach (var item in p.Hijos)
                {

                    existe = Existe(item, cod);
                    if (existe) return true;
                }

            return existe;
        }


    }
}
