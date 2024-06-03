using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductoBE
    {
        public ProductoBE(string pNombre, string pDescripcion, int pStock, decimal pCosto, decimal pPrecio)
        {
            Nombre = pNombre;
            Descripcion = pDescripcion;
            Stock = pStock;
            Costo = pCosto;
            Precio = pPrecio;
        }

        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int Categoria { get; set; }
        public decimal Costo { get; set; }
        public decimal Precio { get; set; }
    }
}
