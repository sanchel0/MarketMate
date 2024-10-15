using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Services;

namespace BLL
{
    public class UsuarioBLL : BaseBLL<UsuarioBE>
    {
        private IUsuarioDAL usuarioDal;
        public UsuarioBLL() : base(new UsuarioDAL())
        {
            usuarioDal = (IUsuarioDAL)Crud;
        }

        /*public override void Insert(UsuarioBE pUsuario)
        {
            Crud.Insert(pUsuario);
        }*/

        /*public void Update(UsuarioBE pUsuario)
        {
            int rowsAffected = crud.Update(pUsuario);
            if (rowsAffected == 0)
            {
                throw new Exception("Hubo un problema. No se pudo actualizar el registro en la base de datos.");
            }
        }

        public void Delete(string pId)
        {
            int rowsAffected = crud.Delete(pId);
            if (rowsAffected == 0)
            {
                throw new Exception("Hubo un problema. No se pudo eliminar el registro de la base de datos.");
            }
        }*/

        /*public UsuarioBE GetById(string pId)
        {
            return crud.GetById(pId);
        }

        public List<UsuarioBE> GetAll()
        {
            return crud.GetAll();
        }*/
        public bool IsAdmin(string username)
        {
            return usuarioDal.IsAdmin(username);
        }

        public UsuarioBE GetByUsername(string pUsername)
        {
            return usuarioDal.GetByUsername(pUsername);
        }

        public void Bloquear(string pUsername)
        {
            usuarioDal.Block(pUsername);
        }

        public void Desbloquear(UsuarioBE pUsuario)
        {
            pUsuario.Bloqueo = false;
            GeneratePassword(pUsuario);
            Crud.Update(pUsuario);
        }

        public void Activar(UsuarioBE pUsuario)
        {
            pUsuario.Activo = true;
            Crud.Update(pUsuario);
        }

        public bool Login(string pUsername, string pPassword)
        {
            if (SessionManager.IsLogged())
            {
                throw new LoginException(LoginErrorType.SessionAlreadyStarted);
            }

            var user = usuarioDal.GetByUsername(pUsername) ?? throw new LoginException(LoginErrorType.InvalidUsername);
            
            if (user.Bloqueo == true)
            {
                throw new LoginException(LoginErrorType.UserBlocked);
            }

            if (user.Activo == false)
            {
                throw new LoginException(LoginErrorType.UserInactive);
            }

            if (!CryptoManager.HashPassword(pPassword).Equals(user.Password))
            {
                throw new LoginException(LoginErrorType.InvalidPassword);
            }
            
            else
            {
                SessionManager.Login(user);
                return true;
            }
        }

        public void Logout()
        {
            if (!SessionManager.IsLogged())
                throw new Exception("No hay sesión iniciada");//Este nunca sucederá realmente
            
            SessionManager.Logout();
        }

        public void VerificarDni(List<UsuarioBE> list, string dni)
        {
            bool result = list.Any(u => u.Dni == dni);
            if (result)
            {
                throw new ValidationException(ValidationErrorType.DuplicateDni);
            }
        }

        public bool VerificarPassword(string pInputPassword, string pStoredPassword)
        {
            return pInputPassword == pStoredPassword;
        }

        public string GenerateUsername(UsuarioBE pUsuario)
        {
            return pUsuario.Dni + pUsuario.Nombre;
        }

        public string GeneratePassword(UsuarioBE pUsuario)
        {
            string password = pUsuario.Dni + pUsuario.Apellido;
            return CryptoManager.HashPassword(password);
        }
    }
}
