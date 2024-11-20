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
using UI;

namespace UI
{
    public partial class FrmSeleccionarProductos : Form
    {
        ProductoBLL productoBLL = new ProductoBLL();
        private BindingList<ProductoBE> _productos;
        private BindingList<ProductoBE> _productosFiltrados;
        TicketBLL ticketBLL;
        public BindingList<DetalleVentaBE> DetallesVenta { get; private set; } = new BindingList<DetalleVentaBE>();

        public FrmSeleccionarProductos()
        {
            InitializeComponent();
            productoBLL = new ProductoBLL();
            dgvProductos.CellFormatting += dgvProd_CellFormatting;
            dgvProductosSeleccionados.CellFormatting += dgvProd_CellFormatting;
            txtCod.TextChanged += txtCodigo_TextChanged;
            _productos = new BindingList<ProductoBE>(productoBLL.GetProductosActivos());
            _productosFiltrados = new BindingList<ProductoBE>(_productos);
            ticketBLL = new TicketBLL();
        }

        private void SeleccionarProductos_Load(object sender, EventArgs e)
        {
            //dgvProductos.DataSource = _productos;
            dgvProductos.DataSource = _productosFiltrados;
            dgvProductosSeleccionados.DataSource = DetallesVenta;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string filterText = txtCod.Text.Trim();

                if (string.IsNullOrEmpty(filterText))
                {
                    _productosFiltrados = new BindingList<ProductoBE>(_productos);
                }
                else
                {
                    int codigo;
                    if (int.TryParse(filterText, out codigo))
                    {
                        var filteredList = _productos.Where(p => p.Codigo == codigo.ToString()).ToList();
                        _productosFiltrados = new BindingList<ProductoBE>(filteredList);
                    }
                }

                dgvProductos.DataSource = _productosFiltrados;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProductos, out ProductoBE producto);
                //productoBLL.AgregarProductoADetalle(producto, txtCant.Text, DetallesVenta);
                ticketBLL.AgregarProductoADetalles(producto, txtCant.Text, DetallesVenta);
                ActualizarBindingLists();
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
                ControlHelper.TryGetSelectedRow(dgvProductosSeleccionados, out DetalleVentaBE detalle);
                ticketBLL.QuitarProductoDeDetalles(detalle, DetallesVenta, _productos);
                ActualizarBindingLists();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void dgvProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                var columnName = dataGridView.Columns[e.ColumnIndex].Name;

                Dictionary<string, Type> columnMapping = new Dictionary<string, Type>()
                {
                    { "Categoria", typeof(CategoriaBE) },
                    { "Producto", typeof(ProductoBE) }
                };

                if (columnMapping.ContainsKey(columnName))
                {
                    var cellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (cellValue != null && columnMapping[columnName].IsInstanceOfType(cellValue))
                    {
                        dynamic obj = Convert.ChangeType(cellValue, columnMapping[columnName]);
                        e.Value = obj.Nombre;
                    }
                }
            }
        }

        private void ActualizarBindingLists()
        {
            _productos.ResetBindings();
            _productosFiltrados.ResetBindings();
        }
    }
}
