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
    public class ProveedorBLL : BaseBLL<ProveedorBE>
    {
        public ProveedorBLL() : base(new ProveedorDAL())
        {

        }

        public override ProveedorBE GetById(string pId)
        {
            ProveedorBE p = Crud.GetById(pId);
            return p == null ? throw new ValidationException(ValidationErrorType.NotFound) : p;
        }
    }
}
