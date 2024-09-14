using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DetalleOrdenBE
    {
        public DetalleOrdenBE(ProductoBE pProducto, int pCantidad, decimal pPrecioUnitario)
        {
            Producto = pProducto;
            CantidadSolicitada = pCantidad;
            PrecioUnitario = pPrecioUnitario;
            SubTotal = CantidadSolicitada * PrecioUnitario;
        }
        public ProductoBE Producto { get; set; }
        public int CantidadSolicitada { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
    }
}
