using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrdenCompraDAL : ICrud<OrdenCompraBE>
    {
        void UpdateCantidadRecibidaDetalle(int numOrden, DetalleOrdenBE detalle);
        void InsertarDetallesOrdenCompra(int numeroOrden, List<DetalleOrdenBE> detalles);
        List<OrdenCompraBE> GetAllPendientes();
    }
}
