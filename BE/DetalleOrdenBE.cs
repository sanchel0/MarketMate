using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DetalleOrdenBE
    {
        public DetalleOrdenBE(ProductoBE pProducto, int pCantidad, decimal pPrecioUnitario, decimal pIva)
        {
            Producto = pProducto;
            CantidadSolicitada = pCantidad;
            PrecioUnitario = pPrecioUnitario;
            //SubTotal = CantidadSolicitada * PrecioUnitario;
            PorcentajeIVA = pIva;
            //TotalConIVA = SubTotal * (1 + (PorcentajeIVA / 100));
        }
        public ProductoBE Producto { get; set; }
        public int CantidadSolicitada { get; set; }
        public int CantidadRecibida { get; set; } //Acumulativa
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
        public decimal PorcentajeIVA { get; set; }
        public decimal TotalConIVA { get; set; }
    }
}
