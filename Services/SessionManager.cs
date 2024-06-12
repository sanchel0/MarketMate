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
        private static string _language;

        private SessionManager() { }

        public static SessionManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new SessionManager();
            }
            return _instance;
        }

        public static string Language
        {
            get { return _language; }
            set
            {
                _language = value;
                LanguageSubject.Instance.ChangeLanguage(value);
            }
        }

        public static UsuarioBE GetUser()
        {
            return _user;
        }

        public static void Login(UsuarioBE pUsuario)
        {
            _user = pUsuario;
        }

        public static void Logout()
        {
            _user = null;
        }

        public static bool IsLogged()
        {
            return _user != null;
        }

        public static bool IsInRole(Rol pRol)
        {
            if (_user == null) return false;

            if(_user.Rol == pRol) return true;
            else return false;
        }

        /*public static bool IsInRole(string roleName)
        {
            if (_user == null)

            
            return _user.Rol.Nombre == roleName;
        }*/
    }
}
