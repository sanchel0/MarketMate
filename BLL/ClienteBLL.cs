using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace BLL
{
    public class ClienteBLL : BaseBLL<ClienteBE>
    {
        public ClienteBLL() : base(new ClienteDAL())
        {

        }

        public override void Insert(ClienteBE entity)
        {
            VerificarDni(entity.Dni);
            entity.Correo = CryptoManager.Encrypt(entity.Correo);
            base.Insert(entity);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Clientes, Operacion.RegistrarCliente));
        }

        public override void Update(ClienteBE entity)
        {
            base.Update(entity);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Clientes, Operacion.ModificarCliente));
        }

        public override void Delete(string pId)
        {
            base.Delete(pId);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Clientes, Operacion.EliminarCliente));
        }

        public override ClienteBE GetById(string pId)
        {
            ClienteBE cli = Crud.GetById(pId);
            return cli == null ? throw new ValidationException(ValidationErrorType.NotFound) : cli;
        }

        public void VerificarDni(string dni)
        {
            List<ClienteBE> list = new List<ClienteBE>();
            list = GetAll();
            bool result = list.Any(u => u.Dni == dni);
            if (result)
            {
                throw new ValidationException(ValidationErrorType.DuplicateDni);
            }
        }
    }
}
