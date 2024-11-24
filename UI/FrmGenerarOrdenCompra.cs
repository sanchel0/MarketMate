using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Services;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmGenerarOrdenCompra : BaseFormObserver
    {
        OrdenCompraBE ordenBE;
        SolicitudCotizacionBE solicitud;
        SolicitudCotizacionBLL solicitudBLL;
        OrdenCompraBLL ordenCompraBLL;
        BindingList<DetalleSolicitudBE> _detallesSoli;
        BindingList<DetalleOrdenBE> _detallesOrden;
        public FrmGenerarOrdenCompra()
        {
            InitializeComponent();
            ordenBE = new OrdenCompraBE();
            solicitudBLL = new SolicitudCotizacionBLL();
            ordenCompraBLL = new OrdenCompraBLL();
            _detallesSoli = new BindingList<DetalleSolicitudBE>();
            _detallesOrden = new BindingList<DetalleOrdenBE>();
            cboNumSoli.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboNumSoli.AutoCompleteSource = AutoCompleteSource.ListItems;

            txtIVA.TextChanged += ControlHelper.FormatDecimalTextChanged;
            txtIVA.KeyPress += ControlHelper.FormatDecimalKeyPress;
            txtIVA.Leave += ControlHelper.FormatDecimalLeave;
        }

        private void btnRegistrarProv_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvProvs.SelectedRows.Count > 0)
                {
                    ProveedorBE p = (ProveedorBE)dgvProvs.SelectedRows[0].DataBoundItem;
                    FrmRegistrarProveedor f = new FrmRegistrarProveedor(p);
                    {
                        f.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionarProd_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProdsSoli, out DetalleSolicitudBE detalleSoli);
                ordenCompraBLL.AgregarProductoADetalles(detalleSoli.Producto, txtPrecio.Text, txtCant.Text, txtIVA.Text, _detallesOrden);
                TranslateEntityList(_detallesOrden.ToList(), Translation); 
                dgvProdsOrden.DataSource = _detallesOrden;
                txtPrecio.Text = string.Empty;
                txtCant.Text = string.Empty;
                txtIVA.Text = string.Empty;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProdsOrden, out DetalleOrdenBE detalle);

                ordenCompraBLL.QuitarProductoDeDetalles(detalle, _detallesOrden);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnProcesarPago_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProvs, out ProveedorBE prov);
                ordenCompraBLL.AsignarDatos(ordenBE, solicitud, Convert.ToInt32(txtNumCoti.Text), _detallesOrden.ToList(), prov, dtpFechaEntrega.Value);

                FrmProcesarPago f = new FrmProcesarPago(ordenBE);
                if (f.ShowDialog() == DialogResult.OK)
                {
                    ordenCompraBLL.AsignarNumeroTransferencia(ordenBE, f.NumTransferencia);
                }
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
                ordenCompraBLL.Update(ordenBE);
                ordenCompraBLL.GenerarReporteDeOrden(ordenBE);
                ControlHelper.ClearGrid(dgvProvs);
                ControlHelper.ClearGrid(dgvProdsSoli);
                ControlHelper.ClearGrid(dgvProdsOrden);
                MessageBox.Show("Orden realizada con exito.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProvs_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvProvs.SelectedRows.Count > 0)
                {
                    ProveedorBE p = (ProveedorBE)dgvProvs.SelectedRows[0].DataBoundItem;
                    txtProvSelect.Text = $"CUIT: {p.CUIT}";
                    if (new ProveedorBLL().RequiereRegistroCompleto(p))
                        btnRegistrarProv.Enabled = true;
                    else
                        btnRegistrarProv.Enabled = false;
                }
                else
                    txtProvSelect.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionarSoli_Click(object sender, EventArgs e)
        {
            if (cboNumSoli.SelectedItem != null)
            {
                int numeroSolicitud = (int)cboNumSoli.SelectedItem;
                try
                {
                    solicitud = solicitudBLL.GetById(numeroSolicitud.ToString());

                    if (solicitud != null)
                    {
                        UpdateGridProvs(solicitud.Proveedores);
                        _detallesSoli = new BindingList<DetalleSolicitudBE>(solicitud.Detalles);
                        TranslateEntityList(_detallesSoli.ToList(),Translation);
                        dgvProdsSoli.DataSource = _detallesSoli;
                    }
                    else
                    {
                        MessageBox.Show("No se encontró la solicitud de cotización.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al obtener la solicitud de cotización: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cboNumSoli_SelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }

        private void UpdateGridProvs(List<ProveedorBE> list)
        {
            ControlHelper.UpdateGrid(dgvProvs, list, "Direccion", "Banco", "TipoCuenta", "NumCuenta", "CBU", "Alias", "ActB");
        }
        private void FrmGenerarOrdenCompra_Load(object sender, EventArgs e)
        {
            try
            {
                LoadDgvProdsSoli();
                LoadDgvProdsOrden();
                List<int> solicitudes = solicitudBLL.GetAllIds();
                cboNumSoli.Items.Clear();
                foreach (var solicitud in solicitudes)
                {
                    cboNumSoli.Items.Add(solicitud);
                }
                UpdateGridProvs(new List<ProveedorBE>());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadDgvProdsSoli()
        {
            dgvProdsSoli.AutoGenerateColumns = false;

            dgvProdsSoli.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProducto",
                HeaderText = "Código Producto"
            });

            dgvProdsSoli.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreProducto",
                HeaderText = "Nombre Producto"
            });

            dgvProdsSoli.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Cantidad",
                HeaderText = "Cantidad Requerida",
                DataPropertyName = "Cantidad"
            });

            dgvProdsSoli.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Categoria",
                HeaderText = "Categoria"
            });

            dgvProdsSoli.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Marca",
                HeaderText = "Marca"
            });

            //dgvProdsSoli.DataSource = _detallesSoli;
            dgvProdsSoli.CellFormatting += dgvProdsSoli_CellFormatting;
        }

        private void LoadDgvProdsOrden(/*OrdenCompraBE orden*/)
        {
            dgvProdsOrden.AutoGenerateColumns = false;

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProducto",
                HeaderText = "Codigo Producto",
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreProducto",
                HeaderText = "Nombre Producto",
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CantidadSolicitada",
                HeaderText = "Cantidad Solicitada",
                DataPropertyName = "CantidadSolicitada"
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "PrecioUnitario",
                HeaderText = "Precio Unitario",
                DataPropertyName = "PrecioUnitario"
            });

            dgvProdsOrden.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "IVA",
                HeaderText = "IVA",
                DataPropertyName = "PorcentajeIVA"
            });

            dgvProdsOrden.CellFormatting += dgvProdsOrden_CellFormatting;
        }

        private void dgvProdsSoli_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var detalle = dgvProdsSoli.Rows[e.RowIndex].DataBoundItem as DetalleSolicitudBE;
            if (detalle == null) return;

            switch (dgvProdsSoli.Columns[e.ColumnIndex].Name)
            {
                case "CodigoProducto":
                    e.Value = detalle.Producto.Codigo;
                    break;
                case "NombreProducto":
                    e.Value = detalle.Producto.Nombre;
                    break;
                case "Categoria":
                    e.Value = detalle.Producto.Categoria?.Nombre;
                    break;
                case "Marca":
                    e.Value = detalle.Producto.Marca;
                    break;
            }
        }

        private void dgvProdsOrden_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return; // Ignora los encabezados de columna

            var detalle = dgvProdsOrden.Rows[e.RowIndex].DataBoundItem as DetalleOrdenBE;
            if (detalle == null) return;

            switch (dgvProdsOrden.Columns[e.ColumnIndex].Name)
            {
                case "CodigoProducto":
                    e.Value = detalle.Producto.Codigo;
                    break;
                case "NombreProducto":
                    e.Value = detalle.Producto.Nombre;
                    break;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*private void ActualizarDataGridView<T>(DataGridView dgv, BindingList<T> list)
        {
            if (list == null || list.Count == 0)
            {
                dgv.DataSource = null;
            }
            else
            {
                dgv.DataSource = list;
            }
        }*/
    }
}
