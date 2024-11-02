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
    public class RecepcionBLL
    {
        RecepcionDAL recepcionDAL;
        ProductoBLL productoBLL;

        public RecepcionBLL()
        {
            recepcionDAL = new RecepcionDAL();
            productoBLL = new ProductoBLL();
        }

        public void Insert(RecepcionBE recepcion)
        {
            recepcionDAL.Insert(recepcion);
            ActualizarDetallesOrden(recepcion);
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Compras, Operacion.RegistrarRecepcion));
        }

        public void Update(RecepcionBE recepcion)
        {
            recepcionDAL.Update(recepcion);
        }

        public RecepcionBE GetById(int id)
        {
            return recepcionDAL.GetById(id);
        }

        public List<RecepcionBE> GetAll()
        {
            return recepcionDAL.GetAll();
        }

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
        }

        public void AsignarDetalles(RecepcionBE recepcion, List<DetalleRecepcionBE> pDetalles)
        {
            recepcion.Detalles = pDetalles;
        }
    }
}
