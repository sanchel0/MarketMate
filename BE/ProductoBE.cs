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

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public CategoriaBE Categoria { get; set; }
        public MarcaBE Marca { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
    }
}
