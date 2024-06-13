using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BaseBLL<T>// : ICrud<T>
    {
        private ICrud<T> _crud;
        protected ICrud<T> Crud => _crud;

        public BaseBLL(ICrud<T> pCrud)
        {
            _crud = pCrud;
        }

        public void Insert(T entity)
        {
            _crud.Insert(entity);
        }

        public void Update(T entity)
        {
            _crud.Update(entity);
        }

        public void Delete(string pId)
        {
            _crud.Delete(pId);
        }

        public virtual T GetById(string pId)
        {
            T obj = _crud.GetById(pId);
            return obj == null ? throw new Exception("Hubo un error. No se pudo obtener la entidad solicitada.") : obj;
        }

        public virtual List<T> GetAll()
        {
            return _crud.GetAll();
        }
    }
}
