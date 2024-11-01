using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductoBE
    {
        public ProductoBE(string pNombre, int pStock, int pMin, int pMax, CategoriaBE pCategoria, string pMarca, decimal pPrecio, decimal pIva)
        {
            Nombre = pNombre;
            Stock = pStock;
            StockMinimo = pMin;
            StockMaximo = pMax;
            Categoria = pCategoria;
            Marca = pMarca;
            Precio = pPrecio;
            PorcentajeIVA = pIva;
        }

        public ProductoBE(ProductoBE producto)
        {
            this.Codigo = producto.Codigo;
            this.Nombre = producto.Nombre;
            this.Stock = producto.Stock;
            this.Categoria = new CategoriaBE(producto.Categoria);
            this.Marca = producto.Marca;
            this.Precio = producto.Precio;
        }

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int StockMaximo { get; set; }
        public CategoriaBE Categoria { get; set; }
        public string Marca { get; set; }
        public decimal Precio { get; set; }
        public decimal PorcentajeIVA { get; set; }

        public override string ToString()
        {
            return Nombre + " " + Marca;
        }
    }
}
