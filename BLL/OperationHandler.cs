using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OperationHandler<T>
    {
        private readonly BaseBLL<T> _bll;

        public OperationHandler(BaseBLL<T> bll)
        {
            _bll = bll;
        }

        public void AplicarAgregar(T entity)
        {
            _bll.Insert(entity);
        }

        public void AplicarModificar(T entity)
        {
            _bll.Update(entity);
        }

        public void AplicarEliminar(string id)
        {
            _bll.Delete(id);
        }
    }
}
