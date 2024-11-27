using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProveedorBLL : BaseBLL<ProveedorBE>
    {
        public ProveedorBLL() : base(new ProveedorDAL())
        {
            TableName = "Proveedores";
        }

        protected override Modulo EventoModulo => Modulo.Proveedores;
        protected override Operacion EventoOperacion { get; set; }

        public override void Insert(ProveedorBE entity)
        {
            VerifyCUIT(entity.CUIT);
            EventoOperacion = Operacion.RegistrarCliente;
            base.Insert(entity);
        }
        
        public override void Update(ProveedorBE entity)
        {
            EventoOperacion = Operacion.ModificarCliente;
            base.Update(entity);
        }
        
        public override void Delete(string pId)
        {
            EventoOperacion = Operacion.EliminarCliente;
            base.Delete(pId);
        }

        public override ProveedorBE GetById(string pId)
        {
            ProveedorBE p = Crud.GetById(pId);
            return p == null ? throw new ValidationException(ValidationErrorType.NotFound) : p;
        }

        public void VerifyCUIT(string cuit)
        {
            List<ProveedorBE> list = new List<ProveedorBE>();
            list = GetAll();
            bool result = list.Any(u => u.CUIT == cuit);
            if (result)
            {
                throw new ValidationException(ValidationErrorType.DuplicateCUIT);
            }
        }

        public void CompleteRegistration(ProveedorBE p, string direc, string banco, TipoCuenta tipoCuenta, string numCuenta, string alias, string cbu)
        {
            p.Direccion = direc;
            p.Banco = banco;
            p.TipoCuenta = tipoCuenta;
            p.NumCuenta = numCuenta;
            p.Alias = alias;
            p.CBU = cbu;
            Update(p);
            //EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Proveedores, Operacion.CompletarRegistroCliente));
        }

        public void AgregarProveedor(ProveedorBE prov, BindingList<ProveedorBE> provs)
        {
            ValidarProveedorNoDuplicado(provs.ToList(), prov);

            provs.Add(prov);
        }

        public void ValidarProveedorNoDuplicado(List<ProveedorBE> proveedores, ProveedorBE nuevoProveedor)
        {
            if (proveedores.Any(p => p.CUIT == nuevoProveedor.CUIT))
                throw new ValidationException(ValidationErrorType.DuplicateProvider);
        }

        public bool RequiereRegistroCompleto(ProveedorBE P)
        {
            return string.IsNullOrEmpty(P.Direccion) ||
                   string.IsNullOrEmpty(P.Banco) ||
                   string.IsNullOrEmpty(P.CBU);
        }
    }
}
