using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ClienteBLL : BaseBLL<ClienteBE>
    {
        public ClienteBLL() : base(new ClienteDAL())
        {

        }

        public override ClienteBE GetById(string pId)
        {
            ClienteBE cli = Crud.GetById(pId);
            return cli == null ? throw new Exception("Cliente no registrado.") : cli;
        }
    }
}
