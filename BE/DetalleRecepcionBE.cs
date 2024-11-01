using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class DetalleRecepcionBE
    {
        public DetalleRecepcionBE(int cant, ProductoBE prod)
        {
            CantidadRecibida = cant;
            Producto = prod;
        }

        public int CantidadRecibida { get; set; }
        public ProductoBE Producto { get; set; }
    }
}
