using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrdenCompraBLL
    {
        OrdenCompraDAL ordenDAL;

        public OrdenCompraBLL()
        {
            ordenDAL = new OrdenCompraDAL();
        }

        public void Insert(OrdenCompraBE orden)
        {
            decimal total = 0;

            foreach (var detalle in orden.Detalles)
            {
                total += detalle.SubTotal;
            }
            orden.Total = total;

            ordenDAL.Insert(orden);
        }

        public void Update(OrdenCompraBE orden)
        {
            ordenDAL.Update(orden);
        }

        public OrdenCompraBE GetById(int id)
        {
            return ordenDAL.GetById(id);
        }

        public List<OrdenCompraBE> GetAll(int id)
        {
            return ordenDAL.GetAll();
        }

        public void AsignarNumeroTransferencia(OrdenCompraBE orden, int numTransferencia)
        {
            orden.NumeroTransferencia = numTransferencia;
        }

        public void AsignarDetalles(OrdenCompraBE orden, List<DetalleOrdenBE> detalles)
        {
            orden.Detalles = detalles;
        }

        public void AsignarProveedor(OrdenCompraBE orden, ProveedorBE proveedor)
        {
            orden.Proveedor = proveedor;
        }
    }
}
