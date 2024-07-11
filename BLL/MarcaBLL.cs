using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MarcaBLL : BaseBLL<MarcaBE>
    {
        public MarcaBLL() : base(new MarcaDAL())
        {
        }

        public void Existe(List<MarcaBE> list, string nombre)
        {
            bool result = list.Any(m => m.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (result)
            {
                throw new ValidationException(ValidationErrorType.DuplicateName);
            }
        }
    }
}
