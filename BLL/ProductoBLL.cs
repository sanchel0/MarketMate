using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Text.RegularExpressions;

namespace BLL
{
    public class ProductoBLL : BaseBLL<ProductoBE>
    {
        /*CategoriaBLL _categoriaBLL;
        MarcaBLL _marcaBLL;*/

        public ProductoBLL() : base(new ProductoDAL())
        {
            /*_categoriaBLL = new CategoriaBLL();
            _marcaBLL = new MarcaBLL();*/
        }

        /*public override List<ProductoBE> GetAll()
        {
            List<CategoriaBE> categorias = _categoriaBLL.GetAll();
            List<MarcaBE> marcas = _marcaBLL.GetAll();
            List<ProductoBE> productos = Crud.GetAll();
            
            foreach(ProductoBE p in productos)
            {

            }

            return productos;
        }*/

        public override List<ProductoBE> GetAll()
        {
            /*List<CategoriaBE> categorias = _categoriaBLL.GetAll();
            List<MarcaBE> marcas = _marcaBLL.GetAll();*/
            List<ProductoBE> productos = Crud.GetAll();

            return productos;
        }

        public void DescontarStock(ProductoBE pProducto, int pCantidadADescontar)
        {
            if (pProducto.Stock >= pCantidadADescontar)
            {
                pProducto.Stock -= pCantidadADescontar;
            }
            else
            {
                throw new InvalidOperationException("No hay suficiente stock disponible para descontar.");
            }
        }

        public void Existe(List<ProductoBE> list, string nombre)
        {
            bool result =  list.Any(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (result)
            {
                throw new Exception("Ya existe un Producto con el mismo nombre.");
            }
        }
    }
}
