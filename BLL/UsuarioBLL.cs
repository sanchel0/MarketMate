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

        protected override Modulo EventoModulo => Modulo.Usuario;
        protected override Operacion EventoOperacion { get; set; }

        public override void Insert(UsuarioBE pUsuario)
        {
            VerificarDni(pUsuario.Dni);
            
            pUsuario.Username = GenerateUsername(pUsuario);
            pUsuario.Password = GeneratePassword(pUsuario);
            pUsuario.Idioma = Language.es;

            EventoOperacion = Operacion.RegistrarUsuario;
            base.Insert(pUsuario);
        }

        public override void Update(UsuarioBE entity)
        {
            EventoOperacion = Operacion.ModificarUsuario;
            base.Update(entity);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.ModificarUsuario));
        }

        public override void Delete(string pId)
        {
            EventoOperacion = Operacion.DesactivarUsuario;
            base.Delete(pId);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.DesactivarUsuario));
        }

        public void DesactivarUsuario(UsuarioBE usuario)
        {
            if (!usuario.Activo)
                throw new ValidationException(ValidationErrorType.UserAlreadyDeactivated);

            Delete(usuario.Dni);
        }

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
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.BloquearUsuario));
        }

        public void DesbloquearUsuario(UsuarioBE usuario)
        {
            if (!usuario.Bloqueo)
                throw new ValidationException(ValidationErrorType.UserNotBlocked);

            usuario.Bloqueo = false;
            GeneratePassword(usuario); 
            Crud.Update(usuario);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.DesbloquearUsuario));
        }

        public void ActivarUsuario(UsuarioBE usuario)
        {
            if (usuario.Activo)
                throw new ValidationException(ValidationErrorType.UserAlreadyActivated);

            usuario.Activo = true;
            Crud.Update(usuario);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.ActivarUsuario));
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
                EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.Login));
                return true;
            }
        }

        public void Logout()
        {
            if (!SessionManager.IsLogged())
                throw new Exception("No hay sesión iniciada");//Este nunca sucederá realmente
            
            SessionManager.Logout();
        }

        public void VerificarDni(string dni)
        {
            List<UsuarioBE> list = new List<UsuarioBE>();
            list = GetAll();

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
