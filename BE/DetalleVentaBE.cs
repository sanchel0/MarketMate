using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DetalleVentaBE
    {
        public DetalleVentaBE(ProductoBE pProducto, int pCantidad, decimal pPrecioUnitario)
        {
            Producto = pProducto;
            Cantidad = pCantidad;
            PrecioUnitario = pPrecioUnitario;
            ///CalcularSubTotal();
        }

        public ProductoBE Producto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalConIVA { get; set; }

        /*private void CalcularSubTotal()
        {
            SubTotal = Cantidad * PrecioUnitario;
        }*/
    }
}
