using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using DAL;
using Services;

namespace BLL
{
    public abstract class BaseBLL<T>
    {
        private ICrud<T> _crud;
        protected ICrud<T> Crud => _crud;

        public BaseBLL(ICrud<T> pCrud)
        {
            _crud = pCrud;
        }
        
        protected abstract Modulo EventoModulo { get; }
        protected abstract Operacion EventoOperacion { get; set; }
        protected string TableName { get; set; } = string.Empty;

        public virtual void Insert(T entity)
        {
            _crud.Insert(entity);
            InsertEventAndUpdateDV();
        }

        public virtual void Update(T entity)
        {
            _crud.Update(entity);
            InsertEventAndUpdateDV();
        }

        public virtual void Delete(string pId)
        {
            _crud.Delete(pId);
            InsertEventAndUpdateDV();
        }

        public virtual T GetById(string pId)
        {
            T obj = _crud.GetById(pId);
            return obj == null ? throw new DatabaseException(DatabaseErrorType.ExecuteReaderError) : obj;
        }

        public virtual List<T> GetAll()
        {
            return _crud.GetAll();
        }

        private void InsertEvento()
        {
            var evento = new Evento(SessionManager.GetUser(), EventoModulo, EventoOperacion);
            EventoBLL.Insert(evento);
        }

        private void UpdateDigitoVerificador()
        {
            if (TableName != string.Empty)
                new DigitoVerificadorBLL().Update(TableName);
        }

        protected void InsertEventAndUpdateDV()
        {
            InsertEvento();
            UpdateDigitoVerificador();
        }
    }
}
