using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BLL
{
    public class CategoriaBLL : BaseBLL<CategoriaBE>
    {
        public CategoriaBLL() : base(new CategoriaDAL())
        {
        }

        public void Existe(List<CategoriaBE> list, string nombre)
        {
            bool result = list.Any(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if(result)
            {
                throw new ValidationException(ValidationErrorType.DuplicateName);
            }
        }
    }
}
