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
            entity.Correo = CryptoManager.Encrypt(entity.Correo);
            base.Insert(entity);
        }

        public override ClienteBE GetById(string pId)
        {
            ClienteBE cli = Crud.GetById(pId);
            return cli == null ? throw new ValidationException(ValidationErrorType.NotFound) : cli;
        }

        public void VerificarDni(List<ClienteBE> list, string dni)
        {
            bool result = list.Any(u => u.Dni == dni);
            if (result)
            {
                throw new ValidationException(ValidationErrorType.DuplicateDni);
            }
        }
    }
}
