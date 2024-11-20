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
using System.IO;

namespace BLL
{
    public class ProductoBLL : BaseBLL<ProductoBE>
    {
        private IProductoDAL _productoDAL;

        public ProductoBLL() : base(new ProductoDAL())
        {
            _productoDAL = (IProductoDAL)Crud;
            TableName = "Productos";
        }

        protected override Modulo EventoModulo => Modulo.Inventario;
        protected override Operacion EventoOperacion { get; set; }

        public override void Insert(ProductoBE entity)
        {
            Existe(entity.Nombre);
            EventoOperacion = Operacion.RegistrarProducto;
            base.Insert(entity);
        }

        public override void Update(ProductoBE entity)
        {
            //Existe(entity.Nombre);
            EventoOperacion = Operacion.ModificarProducto;
            base.Update(entity);
        }

        public override void Delete(string pId)
        {
            EventoOperacion = Operacion.EliminarProducto;
            base.Delete(pId);
        }

        public override List<ProductoBE> GetAll()
        {
            List<ProductoBE> productos = Crud.GetAll();

            return productos;
        }

        public List<ProductoBE> GetProductosActivos()
        {
            List<ProductoBE> productos = _productoDAL.GetProductosActivos();

            return productos;
        }

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
            List<ProductoBE> productos = _productoDAL.GetProductosConStockMinimo();

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

        public void GenerarReporteRotacion(DateTime fechaInicio, DateTime fechaFin, bool esMayorRotacion)
        {
            string fechaActual = DateTime.Now.ToString("yyyyMMdd");
            string tipoRotacion = esMayorRotacion ? "Mayor" : "Menor";

            string fileName = $"RotacionProductos_{tipoRotacion}_{fechaActual}.pdf";

            string filePath = Path.Combine("Ruta/Donde/Guardar", fileName);

            Dictionary<ProductoBE, int> prods = _productoDAL.GetProductosConMayorMenorRotacion(fechaInicio, fechaFin, esMayorRotacion);

            var pdfContent = new RotacionProductosPdfContent(prods, fechaInicio, fechaFin, esMayorRotacion);

            PDFGenerator pdfGenerator = new PDFGenerator();

            pdfGenerator.GeneratePDF(pdfContent, filePath);
        }
    }
}
