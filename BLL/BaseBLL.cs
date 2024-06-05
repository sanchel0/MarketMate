using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;

namespace BLL
{
    public class BaseBLL<T> : ICrud<T>
    {
        protected ICrud<T> crud;

        public BaseBLL(ICrud<T> pCrud)
        {
            crud = pCrud;
        }

        public void Insert(T entity)
        {
            crud.Insert(entity);
        }

        public void Update(T entity)
        {
            crud.Update(entity);
        }

        public void Delete(string pId)
        {
            crud.Delete(pId);
        }

        public T GetById(string pId)
        {
            return crud.GetById(pId);
        }

        public List<T> GetAll()
        {
            return crud.GetAll();
        }
    }
}
