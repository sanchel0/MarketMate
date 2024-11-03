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
            TableName = "Categorias";
        }

        protected override Modulo EventoModulo => Modulo.Inventario;
        protected override Operacion EventoOperacion { get;  set; }

        public override void Insert(CategoriaBE categoria)
        {
            Existe(categoria.Nombre);
            EventoOperacion = Operacion.RegistrarCategoria;
            base.Insert(categoria);
        }

        public override void Update(CategoriaBE categoria)
        {
            Existe(categoria.Nombre);
            EventoOperacion = Operacion.ModificarCategoria;
            base.Update(categoria);
        }

        public override void Delete(string pId)
        {
            EventoOperacion = Operacion.EliminarCategoria;
            base.Delete(pId);
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
