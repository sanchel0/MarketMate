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
    public class RecepcionBLL : BaseBLL<RecepcionBE>
    {
        private IRecepcionDAL _recepcionDALL;
        ProductoBLL productoBLL;

        public RecepcionBLL() : base(new RecepcionDAL())
        {
            _recepcionDALL = (IRecepcionDAL)Crud;
            productoBLL = new ProductoBLL();
            TableName = "Recepciones";
        }

        protected override Modulo EventoModulo => Modulo.Compras;
        protected override Operacion EventoOperacion { get; set; }

        public override void Insert(RecepcionBE recepcion)
        {
            EventoOperacion = Operacion.RegistrarRecepcion; 
            base.Insert(recepcion);
            InsertDetalles(recepcion);
            ActualizarDetallesOrden(recepcion);
        }

        /*public void Update(RecepcionBE recepcion)
        {
            EventoOperacion = Operacion.ModificarRecepcion;
            base.Update(recepcion);
        }*/

        public void InsertDetalles(RecepcionBE recepcion)
        {
            TableName = "DetallesRecepcion";
            EventoOperacion = Operacion.RegistrarDetallesOrden;
            _recepcionDALL.InsertarDetallesRecepcion(recepcion.NumeroRecepcion, recepcion.Detalles);
            InsertEventAndUpdateDV();
            TableName = "Recepciones";
            foreach (var detalle in recepcion.Detalles)
            {
                ProductoBLL prodBLL = new ProductoBLL();
                prodBLL.RestaurarStock(detalle.Producto, detalle.CantidadRecibida);
                prodBLL.Update(detalle.Producto);
            }
        }

        /*public RecepcionBE GetById(int id)
        {
            return recepcionDAL.GetById(id);
        }

        public List<RecepcionBE> GetAll()
        {
            return recepcionDAL.GetAll();
        }*/

        private void ActualizarDetallesOrden(RecepcionBE recepcion)
        {
            OrdenCompraBE ordenCompra = recepcion.Orden;

            List<DetalleOrdenBE> detallesOrden = ordenCompra.Detalles;

            OrdenCompraBLL ordenCompraBLL = new OrdenCompraBLL();

            foreach (var detalleRecepcion in recepcion.Detalles)
            {
                var detalleOrden = detallesOrden.FirstOrDefault(d => d.Producto.Codigo == detalleRecepcion.Producto.Codigo);

                if (detalleOrden != null)
                {
                    detalleOrden.CantidadRecibida += detalleRecepcion.CantidadRecibida;
                    ordenCompraBLL.UpdateCantidadRecibidaDetalle(ordenCompra.NumeroOrden, detalleOrden);
                }
            }

            ordenCompraBLL.VerificarYActualizar(recepcion.Orden);
        }

        public void AgregarProductoADetalles(ProductoBE producto, string cantidadText, BindingList<DetalleRecepcionBE> detalles)
        {
            int cant = productoBLL.ValidarCantidad(cantidadText);

            if (detalles.Any(d => d.Producto.Codigo == producto.Codigo))
            {
                throw new Exception("El producto ya está seleccionado.");
            }

            DetalleRecepcionBE detalle = new DetalleRecepcionBE
            (
                cant,
                producto
            );

            detalles.Add(detalle);
        }

        public void QuitarProductoDeDetalles(DetalleRecepcionBE detalle, BindingList<DetalleRecepcionBE> detalles)
        {
            ProductoBE productoEnLista = detalle.Producto;

            if (productoEnLista == null)
            {
                throw new Exception("Producto no encontrado en la lista.");
            }

            detalles.Remove(detalle);
        }

        public void FinalizarRecepcion(OrdenCompraBE orden, DateTime fechaR, int numFact, decimal montoFact, DateTime fechaFact, List<DetalleRecepcionBE> detalles)
        {
            RecepcionBE recepcion = new RecepcionBE
                (
                    orden,
                    fechaR,
                    numFact,
                    montoFact,
                    fechaFact
                );

            AsignarDetalles(recepcion, detalles);
            Insert(recepcion);
            GenerarReporteDeRecepcion(recepcion);
        }

        public void AsignarDetalles(RecepcionBE recepcion, List<DetalleRecepcionBE> pDetalles)
        {
            recepcion.Detalles = pDetalles;
        }

        public List<RecepcionBE> ObtenerRecepcionesPorOrden(int numeroOrden)
        {
            if (numeroOrden <= 0)
                throw new Exception("Error en bd.");

            return _recepcionDALL.GetRecepcionesPorOrden(numeroOrden);
        }

        public void GenerarReporteDeRecepcion(RecepcionBE recepcion)
        {
            PDFGenerator pdfGenerator = new PDFGenerator();

            IPdfContent pdfContent;
            string namePdf = string.Empty;

            pdfContent = new RecepcionPdfContent(recepcion);
            namePdf = $"Recepcion_{recepcion.NumeroRecepcion}.pdf";

            pdfGenerator.GeneratePDF(pdfContent, namePdf);
        }
    }
}
