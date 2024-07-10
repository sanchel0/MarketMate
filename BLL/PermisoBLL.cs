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

        /*public bool Existe(Permiso p, int cod)
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
        }*/
        /*public bool Existe(List<Permiso> list, string cod)
        {
            return true;
        }*/
        public bool Existe(List<PermisoCompuesto> list, string nombre)
        {
            return list.Any(compuesto => compuesto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
        }
        /*public List<Permiso> GetAll()
        {
            return _permiso.GetAll();
        }*/

        public List<PermisoSimple> GetAllPatentes()
        {
            return _permiso.GetAllPatentes();
        }

        public List<PermisoCompuesto> GetAllFamilias()
        {
            /*List<Permiso> allPermisos = _permiso.GetAllFamilias();
            List<PermisoCompuesto> familias = new List<PermisoCompuesto>();

            foreach (Permiso permiso in allPermisos)
            {
                if (permiso is PermisoCompuesto)
                {
                    familias.Add(permiso as PermisoCompuesto);
                }
            }

            return familias.OrderBy(p => p.Nombre).ToList();*/
            return _permiso.GetAllFamilias();
        }

        public List<PermisoCompuesto> GetAllRoles()//hacer un RolBLL, que implemente BaseBLL, y agregar metodos especificos de Rol, como Fill
        {//No usar GetPermisosByFamilia, en vez de eso usar Fill, para RolBLL y PermisoBLL
            /*List<Rol> list = new List<Rol>();
            foreach(var rol in list)
            {
                GetPermisosByRol(rol);
            }
            return list;*/
            return _permiso.GetAllRoles();
        }

        public void Create(PermisoCompuesto permisoCompuesto)
        {
            _permiso.Create(permisoCompuesto);
        }

        /*public void CreateRol(Rol rol)
        {
            _permiso.CreateRol(rol);
        }*/
        public void Update(PermisoCompuesto permisoCompuesto)
        {
            _permiso.Update(permisoCompuesto);
        }

        public void Delete(PermisoCompuesto permisoCompuesto)
        {
            _permiso.Delete(permisoCompuesto.Codigo);
        }

        public PermisoCompuesto GetById(int pId)
        {
            PermisoCompuesto permiso = _permiso.GetById(pId);
            return permiso;
        }
        //Se pasan por referencia las instancias al metodo como parametro, esto hace que cualquier cambio realizado en el objeto dentro del método afecte al objeto original.
        public void GetPermisosByRol(PermisoCompuesto pRol)
        {
            List<Permiso> permisos = _permiso.GetPermisosByRol(pRol.Codigo);
            foreach (var p in permisos)
            {
                pRol.Add(p);
            }
        }

        /*public void QuitarPermiso(PermisoCompuesto permisoCompuesto, Permiso permiso)
        {
            permisoCompuesto.Remove(permiso);
        }*/

        public void AsignarPermiso(PermisoCompuesto permisoCompuesto, Permiso permiso)
        {
            permisoCompuesto.Add(permiso);
        }
    }
}
