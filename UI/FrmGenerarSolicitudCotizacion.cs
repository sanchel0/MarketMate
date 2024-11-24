using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmGenerarSolicitudCotizacion : BaseFormObserver
    {
        SolicitudCotizacionBLL solicitudBLL;
        SolicitudCotizacionBE _solicitudBE;
        ProductoBLL productoBLL;
        BindingList<DetalleSolicitudBE> _detalles;
        ProveedorBLL proveedorBLL;
        BindingList<ProveedorBE> _proveedores;
        List<ProductoBE> _productos;
        public FrmGenerarSolicitudCotizacion()
        {
            InitializeComponent();
            solicitudBLL = new SolicitudCotizacionBLL();
            _solicitudBE = new SolicitudCotizacionBE();
            productoBLL = new ProductoBLL();
            _detalles = new BindingList<DetalleSolicitudBE>();
            proveedorBLL = new ProveedorBLL();
            _proveedores = new BindingList<ProveedorBE>();
            _productos = new List<ProductoBE>();
            _productos = productoBLL.GetAll();
            dgvProductosSeleccionados.AllowUserToAddRows = false;
        }

        private void FrmGenerarSolicitudCotizacion_Load(object sender, EventArgs e)
        {
            TranslateEntityList(_productos, Translation);
            ControlHelper.UpdateGrid(dgvProductos, _productos);
            dgvProductosSeleccionados.DataSource = _detalles;
            ControlHelper.UpdateGrid(dgvProveedores, proveedorBLL.GetAll(), "Direccion", "Banco", "TipoCuenta", "NumCuenta", "CBU", "Alias");
            ControlHelper.UpdateGrid(dgvProveedoresSeleccionados, _proveedores, "Direccion", "Banco", "TipoCuenta", "NumCuenta", "CBU", "Alias");
            //dgvProveedoresSeleccionados.DataSource = _proveedores;
        }

        private void btnSeleccionarProd_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProductos, out ProductoBE productoSeleccionado);
                
                solicitudBLL.AgregarProductoADetalles(productoSeleccionado, txtCant.Text, _detalles);

                ControlHelper.ClearTextBoxes(txtCant);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuitarProd_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (dgvProductosSeleccionados.SelectedRows.Count > 0)
                {
                    DetalleSolicitudBE detalle = (DetalleSolicitudBE)dgvProductosSeleccionados.SelectedRows[0].DataBoundItem;
                    _detalles.Remove(detalle);
                }
                else
                {
                    MessageBox.Show("Seleccione un producto de la grilla de Productos Seleccionados.");
                }*/
                ControlHelper.QuitarSeleccion(dgvProductosSeleccionados, _detalles);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnRegistroInicial_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmRegistrarProveedor f = new FrmRegistrarProveedor(null))
                {
                    f.ShowDialog();
                }
                ControlHelper.UpdateGrid(dgvProveedores, proveedorBLL.GetAll(), "Direccion", "Banco", "TipoCuenta", "NumCuenta", "CBU", "Alias");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                solicitudBLL.FinalizarSolicitud(_solicitudBE, _detalles.ToList(), _proveedores.ToList());
                solicitudBLL.GenerarReporteDeSolicitud(_solicitudBE);

                ControlHelper.ClearGrid(dgvProductosSeleccionados);
                ControlHelper.ClearGrid(dgvProveedoresSeleccionados);
                txtCant.Text = string.Empty;
                MessageBox.Show(GetTranslation(SuccessType.OperationSuccess));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSeleccionarProv_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProveedores, out ProveedorBE proveedorSeleccionado);
                proveedorBLL.AgregarProveedor(proveedorSeleccionado, _proveedores);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuitarProv_Click(object sender, EventArgs e)
        {
            try
            {
                /*if (dgvProveedoresSeleccionados.SelectedRows.Count > 0)
                {
                    ProveedorBE provSelect = (ProveedorBE)dgvProveedoresSeleccionados.SelectedRows[0].DataBoundItem;
                    _proveedores.Remove(provSelect);
                }
                else
                {
                    MessageBox.Show("Seleccione un proveedor de la grilla de Proveedores Seleccionados.");
                }*/
                ControlHelper.QuitarSeleccion(dgvProveedoresSeleccionados, _proveedores);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
