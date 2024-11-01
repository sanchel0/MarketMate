using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class OrdenCompraBLL
    {
        OrdenCompraDAL ordenDAL;
        ProductoBLL productoBLL;

        public OrdenCompraBLL()
        {
            ordenDAL = new OrdenCompraDAL();
            productoBLL = new ProductoBLL();
        }

        public void Insert(OrdenCompraBE orden)
        {
            decimal total = 0;

            foreach (var detalle in orden.Detalles)
            {
                total += detalle.SubTotal;
            }
            orden.Total = total;

            orden.Estado = "Pendiente";
            orden.FechaEmision = DateTime.Now;

            ordenDAL.Insert(orden);
        }

        public void Update(OrdenCompraBE orden)
        {
            ordenDAL.Update(orden);
        }

        public OrdenCompraBE GetById(int id)
        {
            return ordenDAL.GetById(id);
        }

        public List<OrdenCompraBE> GetAll(int id)
        {
            return ordenDAL.GetAll();
        }

        public List<OrdenCompraBE> GetAllPendientes()
        {
            return ordenDAL.GetAllPendientes();
        }

        public void UpdateCantidadRecibidaDetalle(int numOrden, DetalleOrdenBE detalle)
        {
            ordenDAL.UpdateCantidadRecibidaDetalle(numOrden, detalle);
        }

        public void VerificarYActualizar(OrdenCompraBE orden)
        {
            if (TodosLosProductosRecibidos(orden))
            {
                orden.Estado = "Completo";
                Update(orden);
            }
        }

        private bool TodosLosProductosRecibidos(OrdenCompraBE orden)
        {
            foreach (var detalle in orden.Detalles)
            {
                if (detalle.CantidadSolicitada > detalle.CantidadRecibida)
                {
                    return false; // No todos los productos han sido recibidos
                }
            }
            return true; // Todos los productos han sido recibidos
        }

        public void AsignarNumeroTransferencia(OrdenCompraBE orden, int numTransferencia)
        {
            orden.NumeroTransferencia = numTransferencia;
        }

        public void AsignarDetalles(OrdenCompraBE orden, List<DetalleOrdenBE> detalles)
        {
            orden.Detalles = detalles;
        }

        public void AsignarProveedor(OrdenCompraBE orden, ProveedorBE proveedor)
        {
            orden.Proveedor = proveedor;
        }

        public void AgregarProductoADetalles(ProductoBE producto, string precioText, string cantidadText, string ivaText, BindingList<DetalleOrdenBE> detalles)
        {
            int cant = productoBLL.ValidarCantidad(cantidadText);

            if (string.IsNullOrWhiteSpace(precioText) || !decimal.TryParse(precioText, out decimal precio) || precio <= 0)
                throw new ArgumentException("El precio debe ser un valor numérico mayor que cero.");

            if (!decimal.TryParse(ivaText, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal iva) || iva < 0 || iva > 100)
            {
                throw new Exception("Por favor, ingrese un porcentaje de IVA válido entre 0 y 100.");
            }

            if (detalles.Any(d => d.Producto.Codigo == producto.Codigo))
            {
                throw new Exception("El producto ya está seleccionado.");
            }

            DetalleOrdenBE detalle = new DetalleOrdenBE
            (
                producto,
                cant,
                precio,
                iva
            );
            CalcularValores(detalle);

            detalles.Add(detalle);
        }

        public void CalcularValores(DetalleOrdenBE detalle)
        {
            detalle.SubTotal = detalle.CantidadSolicitada * detalle.PrecioUnitario;
            detalle.TotalConIVA = detalle.SubTotal * (1 + (detalle.PorcentajeIVA / 100));
        }

        public void QuitarProductoDeDetalles(DetalleOrdenBE detalle, BindingList<DetalleOrdenBE> detalles)
        {
            ProductoBE productoEnLista = detalle.Producto;

            if (productoEnLista == null)
            {
                throw new Exception("Producto no encontrado en la lista.");
            }

            detalles.Remove(detalle);
        }

        public void AsignarDatos(OrdenCompraBE orden, SolicitudCotizacionBE solicitud, int numCoti, List<DetalleOrdenBE> list, ProveedorBE prov, DateTime dateTime)
        {
            orden.FechaLimiteEntrega = dateTime;
            orden.SolicitudCotizacion = solicitud;
            orden.NumeroCotizacion = numCoti;
            AsignarDetalles(orden, list);
            AsignarProveedor(orden, prov);
            Insert(orden);
        }
    }
}
