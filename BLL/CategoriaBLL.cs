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

        public override void Insert(CategoriaBE categoria)
        {
            Existe(categoria.Nombre);

            base.Insert(categoria);
        }

        public override void Update(CategoriaBE categoria)
        {
            Existe(categoria.Nombre);

            base.Update(categoria);
        }

        public void Existe(string nombre)
        {
            List<CategoriaBE> list = new List<CategoriaBE>();
            list = GetAll();
            bool result = list.Any(c => c.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if(result)
            {
                throw new ValidationException(ValidationErrorType.DuplicateName);
            }
        }
    }
}
