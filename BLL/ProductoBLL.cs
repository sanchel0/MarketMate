using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BE;
using System.Text.RegularExpressions;
using Services;
using System.ComponentModel;

namespace BLL
{
    public class ProductoBLL : BaseBLL<ProductoBE>
    {
        private IProductoDAL productoDAL;
        /*CategoriaBLL _categoriaBLL;
        MarcaBLL _marcaBLL;*/

        public ProductoBLL() : base(new ProductoDAL())
        {
            productoDAL = (IProductoDAL)Crud;
        }

        /*public override List<ProductoBE> GetAll()
        {
            List<CategoriaBE> categorias = _categoriaBLL.GetAll();
            List<MarcaBE> marcas = _marcaBLL.GetAll();
            List<ProductoBE> productos = Crud.GetAll();
            
            foreach(ProductoBE p in productos)
            {

            }

            return productos;
        }*/

        public override void Insert(ProductoBE entity)
        {
            Existe(entity.Nombre);

            base.Insert(entity);
            new DigitoVerificadorBLL();
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Inventario, Operacion.RegistrarProducto));
        }

        public override void Update(ProductoBE entity)
        {
            Existe(entity.Nombre);

            base.Update(entity);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Inventario, Operacion.EliminarProducto));
        }

        public override void Delete(string pId)
        {
            base.Delete(pId);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Inventario, Operacion.EliminarProducto));
        }

        public override List<ProductoBE> GetAll()
        {
            List<ProductoBE> productos = Crud.GetAll();

            return productos;
        }

        public List<ProductoBE> GetProductosActivos()
        {
            List<ProductoBE> productos = productoDAL.GetProductosActivos();

            return productos;
        }

        /*public void AgregarProductoADetalle(ProductoBE producto, string cantidadText, BindingList<DetalleVentaBE> detallesVenta)
        {
            ValidarCantidadParaVenta(producto, cantidadText, out int cantidadADescontar);

            if (detallesVenta.Any(d => d.Producto.Codigo == producto.Codigo))
            {
                throw new Exception("El producto ya está seleccionado.");
            }

            DescontarStock(producto, cantidadADescontar);

            detallesVenta.Add(new DetalleVentaBE(producto, cantidadADescontar, producto.Precio));
        }

        public void QuitarProductoDeDetalles(DetalleVentaBE detalle, BindingList<DetalleVentaBE> detallesVenta, BindingList<ProductoBE> productos)
        {
            ProductoBE productoEnLista = productos.FirstOrDefault(p => p.Codigo == detalle.Producto.Codigo);

            if (productoEnLista == null)
            {
                throw new Exception("Producto no encontrado en la lista.");
            }

            RestaurarStock(productoEnLista, detalle.Cantidad);

            detallesVenta.Remove(detalle);

        }*/

        public void DescontarStock(ProductoBE pProducto, int pCantidadADescontar)
        {
            if (pProducto.Stock >= pCantidadADescontar)
            {
                pProducto.Stock -= pCantidadADescontar;
            }
            else
            {
                throw new Exception("No hay suficiente stock disponible para descontar.");
            }
        }

        public void RestaurarStock(ProductoBE producto, int cantidad)
        {
            producto.Stock += cantidad;
        }

        public void Existe(string nombre)
        {
            List<ProductoBE> list = new List<ProductoBE>();
            list = GetAll();

            bool result =  list.Any(p => p.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (result)
            {
                throw new ValidationException(ValidationErrorType.DuplicateName);
            }
        }

        public List<ProductoBE> GetProductosConStockMinimo()
        {
            List<ProductoBE> productos = productoDAL.GetProductosConStockMinimo();

            return productos;
        }

        public void ValidarCantidadParaVenta(ProductoBE producto, string cantidad, out int cantidadADescontar)
        {
            cantidadADescontar = ValidarCantidad(cantidad);

            if (producto.Stock - cantidadADescontar < 0)
            {
                throw new InvalidOperationException("No hay suficiente stock disponible para completar la venta.");
            }
            /*if (producto.Stock - cantidad < producto.StockMinimo)
            {
                throw new InvalidOperationException($"La cantidad solicitada de '{producto.Nombre}' no puede ser mayor que el stock disponible menos el stock mínimo.");
            }*/
        }

        public void ValidarCantidadParaSolicitud(ProductoBE producto, string cantidad, out int cantidadASolicitar)
        {
            cantidadASolicitar = ValidarCantidad(cantidad);

            if (producto.Stock + cantidadASolicitar < producto.StockMinimo)
                throw new Exception($"La cantidad solicitada para '{producto.Nombre}' es insuficiente para el stock mínimo.");
        }

        public int ValidarCantidad(string input)
        {
            if (string.IsNullOrWhiteSpace(input) || !int.TryParse(input, out int cantidad))
            {
                throw new Exception("Por favor ingrese una cantidad válida.");
            }
            if (cantidad <= 0)
                throw new Exception("La cantidad debe ser mayor que cero.");

            return cantidad;
        }
    }
}
