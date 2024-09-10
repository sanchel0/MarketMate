using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class ProductoC
    {
        public ProductoC(DateTime pFecha, DateTime pHora, string pNombre, int pStock, bool pAct, ProductoBE pProd)
        {
            Fecha = pFecha;
            Hora = pHora;   
            Nombre = pNombre;
            Stock = pStock;
            Act = pAct;
            Producto = pProd;
        }
        public int ID { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime Hora { get; set; }
        public string Nombre { get; set; }
        public int Stock { get; set; }
        public bool Act { get; set; }
        public ProductoBE Producto { get; set; }
    }
}
