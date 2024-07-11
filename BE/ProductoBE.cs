using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductoBE
    {
        public ProductoBE(string pNombre, int pStock, CategoriaBE pCategoria, MarcaBE pMarca, decimal pCosto, decimal pPrecio)
        {
            Nombre = pNombre;
            Stock = pStock;
            Categoria = pCategoria;
            Marca = pMarca;
            Costo = pCosto;
            Precio = pPrecio;
        }

        public ProductoBE(ProductoBE producto)
        {
            this.Codigo = producto.Codigo;
            this.Nombre = producto.Nombre;
            this.Stock = producto.Stock;
            this.Categoria = new CategoriaBE(producto.Categoria);
            this.Marca = new MarcaBE(producto.Marca);
            this.Costo = producto.Costo;
            this.Precio = producto.Precio;
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public CategoriaBE Categoria { get; set; }
        public MarcaBE Marca { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
    }
}
