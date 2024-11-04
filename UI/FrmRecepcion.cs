using BE;
using BLL;
using Services;
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
    public partial class FrmRecepcion : Form
    {
        List<OrdenCompraBE> ordenesPendientes;
        BindingList<DetalleRecepcionBE> _detallesRecep;
        RecepcionBLL recepcionBLL;
        public FrmRecepcion()
        {
            InitializeComponent();
            ordenesPendientes = new List<OrdenCompraBE>();
            _detallesRecep = new BindingList<DetalleRecepcionBE>();
            recepcionBLL = new RecepcionBLL();
        }

        private void FrmRecepcion_Load(object sender, EventArgs e)
        {
            ordenesPendientes = new OrdenCompraBLL().GetAllPendientes();
            ControlHelper.UpdateGrid(dgvOrdenes, ordenesPendientes);
            LoadDgvProdsOrden();
            LoadDgvProdsRecibidos();
        }

        private void btnSeleccionarProd_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProdsOrden, out DetalleOrdenBE detalleOrden);
                recepcionBLL.AgregarProductoADetalles(detalleOrden.Producto, txtCant.Text, _detallesRecep);
                dgvProdsRecibidos.DataSource = _detallesRecep;
                txtCant.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProdsRecibidos, out DetalleRecepcionBE detalle);
                recepcionBLL.QuitarProductoDeDetalles(detalle, _detallesRecep);
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
                ControlHelper.TryGetSelectedRow(dgvOrdenes, out OrdenCompraBE orden);
                recepcionBLL.FinalizarRecepcion(orden, dtpFechaEntrega.Value, Convert.ToInt32(txtNumFact.Text), Convert.ToDecimal(txtMontoFact.Text), dtpFact.Value, _detallesRecep.ToList());
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

        private void LoadDgvProdsOrden()
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
                Name = "CantidadRecibida",
                HeaderText = "Cantidad Recibida",
                DataPropertyName = "CantidadRecibida"
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

        private void LoadDgvProdsRecibidos()
        {
            dgvProdsRecibidos.AutoGenerateColumns = false;

            dgvProdsRecibidos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "CodigoProducto",
                HeaderText = "Código Producto"
            });

            dgvProdsRecibidos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "NombreProducto",
                HeaderText = "Nombre Producto"
            });

            dgvProdsRecibidos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Cantidad",
                HeaderText = "Cantidad Recibida",
                DataPropertyName = "CantidadRecibida"
            });

            dgvProdsRecibidos.Columns.Add(new DataGridViewTextBoxColumn()
            {
                Name = "Marca",
                HeaderText = "Marca"
            });

            dgvProdsRecibidos.CellFormatting += dgvProdsRecibidos_CellFormatting;
        }

        private void dgvProdsRecibidos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var detalle = dgvProdsRecibidos.Rows[e.RowIndex].DataBoundItem as DetalleRecepcionBE;
            if (detalle == null) return;

            switch (dgvProdsRecibidos.Columns[e.ColumnIndex].Name)
            {
                case "CodigoProducto":
                    e.Value = detalle.Producto.Codigo;
                    break;
                case "NombreProducto":
                    e.Value = detalle.Producto.Nombre;
                    break;
                case "Marca":
                    e.Value = detalle.Producto.Marca;
                    break;
            }
        }

        private void dgvProdsOrden_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

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

        private void dgvOrdenes_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (ControlHelper.TryGetSelectedRowWithoutException(dgvOrdenes, out OrdenCompraBE orden))
                    dgvProdsOrden.DataSource = orden.Detalles;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
