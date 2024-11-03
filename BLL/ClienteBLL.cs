using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace BLL
{
    public class ClienteBLL : BaseBLL<ClienteBE>
    {
        public ClienteBLL() : base(new ClienteDAL())
        {
            TableName = "Clientes";
        }

        protected override Modulo EventoModulo => Modulo.Clientes;
        protected override Operacion EventoOperacion { get; set; }
        //Cuando defines una propiedad como abstracta con solo un método get, estás obligando a las subclases a proporcionar su propio valor, pero no les estás permitiendo que modifiquen el valor de la propiedad después de que haya sido asignado.

        public override void Insert(ClienteBE entity)
        {
            VerificarDni(entity.Dni);
            entity.Correo = CryptoManager.Encrypt(entity.Correo);
            EventoOperacion = Operacion.RegistrarCliente;
            base.Insert(entity);
        }

        public override void Update(ClienteBE entity)
        {
            EventoOperacion = Operacion.ModificarCliente;
            base.Update(entity);
        }

        public override void Delete(string pId)
        {
            EventoOperacion = Operacion.EliminarCliente;
            base.Delete(pId);
        }

        public override ClienteBE GetById(string pId)
        {
            ClienteBE cli = Crud.GetById(pId);
            return cli == null ? throw new ValidationException(ValidationErrorType.NotFound) : cli;
        }

        public void VerificarDni(string dni)
        {
            List<ClienteBE> list = new List<ClienteBE>();
            list = GetAll();
            bool result = list.Any(u => u.Dni == dni);
            if (result)
            {
                throw new ValidationException(ValidationErrorType.DuplicateDni);
            }
        }
    }
}
