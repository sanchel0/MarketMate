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
        private static SessionManager instance;
        private static UsuarioBE user;

        private SessionManager() { }

        public static SessionManager GetInstance()
        {
            if (instance == null)
            {
                instance = new SessionManager();
            }
            return instance;
        }

        public static UsuarioBE GetUser()
        {
            return user;
        }

        public static void Login(UsuarioBE pUsuario)
        {
            user = pUsuario;
        }

        public static void Logout()
        {
            user = null;
        }

        public static bool IsLogged()
        {
            return user != null;
        }

        public static bool IsInRole(Rol pRol)
        {
            if (user == null) return false;

            if(user.Rol == pRol) return true;
            else return false;
        }
    }
}
