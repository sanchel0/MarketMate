using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IRecepcionDAL : ICrud<RecepcionBE>
    {
        void InsertarDetallesRecepcion(int numeroRecepcion, List<DetalleRecepcionBE> detalles);
    }
}
