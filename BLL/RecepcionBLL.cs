using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class RecepcionBLL
    {
        RecepcionDAL recepcionDAL;

        public RecepcionBLL()
        {
            recepcionDAL = new RecepcionDAL();
        }

        public void Insert(RecepcionBE recepcion)
        {
            recepcionDAL.Insert(recepcion);
        }

        public void Update(RecepcionBE recepcion)
        {
            recepcionDAL.Update(recepcion);
        }

        public RecepcionBE GetById(int id)
        {
            return recepcionDAL.GetById(id);
        }

        public List<RecepcionBE> GetAll()
        {
            return recepcionDAL.GetAll();
        }

        public void AsignarDetalles(RecepcionBE recepcion, List<DetalleRecepcionBE> detalles)
        {
            recepcion.Detalles = detalles;
        }

        public void AsignarOrdenCompra(RecepcionBE recepcion, OrdenCompraBE orden)
        {
            recepcion.Orden = orden;
        }
    }
}
