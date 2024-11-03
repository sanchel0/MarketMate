using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class FamiliaBLL
    {
        PermisoDAL _permiso;

        public FamiliaBLL()
        {
            _permiso = new PermisoDAL();
        }
        public void Existe(TipoPermiso tipo, string nombre)
        {
            List<PermisoCompuesto> list = new List<PermisoCompuesto>();
            if (tipo is TipoPermiso.Familia)
                list = GetAllFamilias();
            else
                list = GetAllRoles();
            if (list.Any(compuesto => compuesto.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase)))
                throw new ValidationException(ValidationErrorType.DuplicateName);
        }

        public List<PermisoCompuesto> GetAllFamilias()
        {
            return _permiso.GetAllFamilias();
        }

        public List<PermisoCompuesto> GetAllRoles()
        {
            return _permiso.GetAllRoles();
        }

        public void Create(PermisoCompuesto permisoCompuesto)
        {
            Existe(permisoCompuesto.Tipo, permisoCompuesto.Nombre);
            _permiso.Create(permisoCompuesto);
        }

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
        public void GetPermisosByRol(PermisoCompuesto pRol)
        {
            List<Permiso> permisos = _permiso.GetPermisosByRol(pRol.Codigo);
            foreach (var p in permisos)
            {
                pRol.Add(p);
            }
        }

        public void AsignarPermiso(PermisoCompuesto permisoCompuesto, Permiso permiso)
        {
            permisoCompuesto.Add(permiso);
        }
    }
}
