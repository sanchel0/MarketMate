using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmGenerarSolicitudCotizacion : Form
    {
        SolicitudCotizacionBLL solicitudBLL;
        SolicitudCotizacionBE _solicitudBE;
        ProductoBLL productoBLL;
        BindingList<DetalleSolicitudBE> _detalles;
        ProveedorBLL proveedorBLL;
        BindingList<ProveedorBE> _proveedores;
        public FrmGenerarSolicitudCotizacion()
        {
            InitializeComponent();
            solicitudBLL = new SolicitudCotizacionBLL();
            _solicitudBE = new SolicitudCotizacionBE();
            productoBLL = new ProductoBLL();
            _detalles = new BindingList<DetalleSolicitudBE>();
            proveedorBLL = new ProveedorBLL();
            _proveedores = new BindingList<ProveedorBE>();
        }

        private void FrmGenerarSolicitudCotizacion_Load(object sender, EventArgs e)
        {
            ControlHelper.UpdateGrid(dgvProductos, productoBLL.GetProductosConStockMinimo());
            dgvProductosSeleccionados.DataSource = _detalles;
            ControlHelper.UpdateGrid(dgvProveedores, proveedorBLL.GetAll());
            dgvProveedoresSeleccionados.DataSource= _proveedores;
        }

        private void btnSeleccionarProd_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                ProductoBE productoSeleccionado = (ProductoBE)dgvProductos.SelectedRows[0].DataBoundItem;
                if (!_detalles.Any(d => d.Producto.Codigo == productoSeleccionado.Codigo))
                {
                    int cant = int.Parse(txtCant.Text);
                    if (cant <= 0 || txtCant.Text == string.Empty)
                        MessageBox.Show("La cantidad debe ser mayor que cero.");
                    else
                    {
                        if ((productoSeleccionado.Stock + cant) < productoSeleccionado.StockMinimo)
                            MessageBox.Show($"La cantidad solicitada para el producto '{productoSeleccionado.Nombre}' es insuficiente para cumplir con el stock mínimo.");
                        else
                        {
                            _detalles.Add(new DetalleSolicitudBE
                            {
                                Producto = productoSeleccionado,
                                Cantidad = cant
                            });
                            ControlHelper.ClearTextBoxes(txtCant);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El producto seleccionado ya está en la lista.");
                }
            }
            {
                MessageBox.Show("No seleccionó ningún producto.");
            }
        }

        private void btnQuitarProd_Click(object sender, EventArgs e)
        {
            if (dgvProductosSeleccionados.SelectedRows.Count > 0)
            {
                DetalleSolicitudBE detalle = (DetalleSolicitudBE)dgvProductosSeleccionados.SelectedRows[0].DataBoundItem;
                _detalles.Remove(detalle);
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la grilla de Productos Seleccionados.");
            }
        }

        private void btnRegistroInicial_Click(object sender, EventArgs e)
        {
            FrmRegistrarProveedor f = new FrmRegistrarProveedor(null);
            f.Show();
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            solicitudBLL.AsignarDetalles(_solicitudBE, _detalles.ToList());
            solicitudBLL.AsignarProveedores(_solicitudBE, _proveedores.ToList());
            solicitudBLL.Insert(_solicitudBE);
            ControlHelper.ClearGrid(dgvProductosSeleccionados);
            ControlHelper.ClearGrid(dgvProveedoresSeleccionados);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSeleccionarProv_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                ProveedorBE provSelect = (ProveedorBE)dgvProveedores.SelectedRows[0].DataBoundItem;
                if (!_proveedores.Any(p => p.CUIT == provSelect.CUIT))
                {
                    _proveedores.Add(provSelect);
                }
                else
                {
                    MessageBox.Show("El proveedor seleccionado ya está en la lista.");
                }
            }
            {
                MessageBox.Show("No seleccionó ningún proveedor.");
            }
        }

        private void btnQuitarProv_Click(object sender, EventArgs e)
        {
            if (dgvProveedoresSeleccionados.SelectedRows.Count > 0)
            {
                ProveedorBE provSelect = (ProveedorBE)dgvProveedoresSeleccionados.SelectedRows[0].DataBoundItem;
                _proveedores.Remove(provSelect);
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor de la grilla de Proveedores Seleccionados.");
            }
        }
    }
}
