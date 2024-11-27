using BE;
using DAL;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductoCBLL
    {
        ProductoCDAL _productoCDAL;
        public void Insert(ProductoC entity)
        {
            _productoCDAL = new ProductoCDAL();
            _productoCDAL.Insert(entity);
        }

        public void Activate(ProductoC entity)
        {
            _productoCDAL = new ProductoCDAL();
            _productoCDAL.Activate(entity.ID);
        }

        public List<ProductoC> GetCambiosFiltrados(int? codProd, DateTime? fechaInicio, DateTime? fechaFin, string nombre)
        {
            List<ProductoC> cambios = new List<ProductoC>();
            _productoCDAL = new ProductoCDAL();
            cambios = _productoCDAL.GetCambiosFiltrados(codProd, fechaInicio, fechaFin, nombre);
            return cambios;
        }

        public void ValidarFechas(DateTime inicio, DateTime fin)
        {
            if (inicio > fin)
            {
                throw new ValidationException(ValidationErrorType.InvalidDateRange);
            }
        }

        public void ActivarCambio(ProductoC cambio)
        {
            if (!cambio.Act)
            {
                Activate(cambio);
                EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.CambiosProductos, Operacion.RestaurarEstadoProducto));
            }
            else
            {
                throw new ValidationException(ValidationErrorType.AlreadyActivatedChange);
            }
        }
    }
}
