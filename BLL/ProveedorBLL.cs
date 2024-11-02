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

        }

        public override void Insert(ProveedorBE entity)
        {
            base.Insert(entity);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Proveedores, Operacion.RegistrarCliente));
        }
        
        public override void Update(ProveedorBE entity)
        {
            base.Update(entity);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Proveedores, Operacion.ModificarCliente));
        }
        
        public override void Delete(string pId)
        {
            base.Delete(pId);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Proveedores, Operacion.EliminarCliente));
        }

        public override ProveedorBE GetById(string pId)
        {
            ProveedorBE p = Crud.GetById(pId);
            return p == null ? throw new ValidationException(ValidationErrorType.NotFound) : p;
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
                throw new Exception("El proveedor seleccionado ya está en la lista.");
        }

        public bool RequiereRegistroCompleto(ProveedorBE P)
        {
            return string.IsNullOrEmpty(P.Direccion) ||
                   string.IsNullOrEmpty(P.Banco) ||
                   string.IsNullOrEmpty(P.CBU);
        }
    }
}
