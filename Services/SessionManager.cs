using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SessionManager
    {
        private static SessionManager _instance;
        private static UsuarioBE _user;
        private static Language _language;
        private static Modulo _currentModule;
        private SessionManager() { }

        public static SessionManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SessionManager();
            }
            return _instance;
        }

        public static Language Language
        {
            get { return _language; }
            set
            {
                _language = value;
                _user.Idioma = value;
                LanguageSubject.Instance.ChangeLanguage(value);
            }
        }

        public static Modulo CurrentModule
        {
            get { return _currentModule; }
            set
            {
                _currentModule = value;
            }
        }

        public static UsuarioBE GetUser()
        {
            return _user;
        }

        public static void Login(UsuarioBE pUsuario)
        {
            _user = pUsuario;
            Language = pUsuario.Idioma;
        }

        public static void Logout()
        {
            _user = null;
        }

        public static bool IsLogged()
        {
            return _user != null;
        }

        /*public static bool IsInRole(Rol pRol)
        {
            if (_user == null) return false;

            if(_user.Rol == pRol) return true;
            else return false;
        }*/

        /*public static bool IsInRole(string roleName)
        {
            if (_user == null)

            
            return _user.Rol.Nombre == roleName;
        }*/
        private bool IsInRoleRecursive(PermisoCompuesto c, Patente permiso, bool existe)
        {
            if (NormalizeName(c.Nombre).Equals(NormalizeName(permiso.ToString()), StringComparison.InvariantCultureIgnoreCase))
            {
                return true;
            }

            foreach (var item in c.Hijos)
            {
                if (item is PermisoCompuesto compuesto)
                {
                    existe = IsInRoleRecursive(compuesto, permiso, existe);
                    if (existe) return true;
                }
                else if (NormalizeName(item.Nombre).Equals(NormalizeName(permiso.ToString()), StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }

            return existe;
        }

        public bool IsInRole(Patente permiso)
        {
            foreach (var item in _user.Rol.Hijos)
            {
                if (item is PermisoCompuesto compuesto)
                {
                    if (IsInRoleRecursive(compuesto, permiso, false))
                    {
                        return true;
                    }
                }
                else if (NormalizeName(item.Nombre).Equals(NormalizeName(permiso.ToString()), StringComparison.InvariantCultureIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private string NormalizeName(string name)
        {
            return name.Replace(" ", string.Empty);
        }
    }
}
