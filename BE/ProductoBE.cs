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
            this.StockMaximo = producto.StockMaximo;
            this.StockMinimo = producto.StockMinimo;
            this.PorcentajeIVA = producto.PorcentajeIVA;
            this.ActB = producto.ActB;
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
        public bool ActB { get; set; }

        public override string ToString()
        {
            return Nombre + " " + Marca;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            ProductoBE other = (ProductoBE)obj;
            return Codigo == other.Codigo;
        }

        public override int GetHashCode()
        {
            return Codigo.GetHashCode();
        }
    }
}
