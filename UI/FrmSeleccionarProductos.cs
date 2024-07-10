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

namespace GUI
{
    public partial class FrmSeleccionarProductos : Form
    {
        ProductoBLL productoBLL = new ProductoBLL();
        private BindingList<ProductoBE> _productos;
        private BindingList<ProductoBE> _productosFiltrados;
        public BindingList<DetalleVentaBE> DetallesVenta { get; private set; } = new BindingList<DetalleVentaBE>();

        public FrmSeleccionarProductos()
        {
            InitializeComponent();
            productoBLL = new ProductoBLL();
            dgvProductos.CellFormatting += dgvProd_CellFormatting;
            dgvProductosSeleccionados.CellFormatting += dgvProd_CellFormatting;
            txtCod.TextChanged += txtCodigo_TextChanged;
            _productos = new BindingList<ProductoBE>(productoBLL.GetAll());
            _productosFiltrados = new BindingList<ProductoBE>(_productos);
        }

        private void SeleccionarProductos_Load(object sender, EventArgs e)
        {
            //dgvProductos.DataSource = _productos;
            dgvProductos.DataSource = _productosFiltrados;
            dgvProductosSeleccionados.DataSource = DetallesVenta;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvProductos.SelectedRows[0];

                ProductoBE producto = (ProductoBE)filaSeleccionada.DataBoundItem;

                if (string.IsNullOrWhiteSpace(txtCant.Text) || !int.TryParse(txtCant.Text, out int cantidadADescontar))
                {
                    MessageBox.Show("Por favor ingrese una cantidad válida de stock a descontar.");
                    return;
                }

                try
                {
                    if (DetallesVenta.Any(d => d.Producto.Codigo == producto.Codigo))
                    {
                        MessageBox.Show("El producto ya está seleccionado.");
                        return;
                    }
                    productoBLL.DescontarStock(producto, cantidadADescontar);
                    _productos.ResetBindings();
                    _productosFiltrados.ResetBindings();
                    DetalleVentaBE detalleVenta = new DetalleVentaBE(producto, cantidadADescontar, producto.Precio);
                    DetallesVenta.Add(detalleVenta);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la grilla Productos.");
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvProductosSeleccionados.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvProductosSeleccionados.SelectedRows[0];
                DetalleVentaBE detalleVenta = (DetalleVentaBE)filaSeleccionada.DataBoundItem;

                DetallesVenta.Remove(detalleVenta);

                ProductoBE producto = detalleVenta.Producto;
                ProductoBE productoEnLista = _productos.FirstOrDefault(p => p.Codigo == producto.Codigo);
                if (productoEnLista != null)
                {
                    productoEnLista.Stock += detalleVenta.Cantidad;
                    _productos.ResetBindings();
                    _productosFiltrados.ResetBindings();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto de la grilla Productos Seleccionados.");
            }
        }
        /*private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvProductos.SelectedRows[0];

                ProductoBE producto = (ProductoBE)filaSeleccionada.DataBoundItem;

                if (string.IsNullOrWhiteSpace(txtCant.Text) || !int.TryParse(txtCant.Text, out int cantidadADescontar))
                {
                    MessageBox.Show("Por favor ingrese una cantidad válida de stock a descontar.");
                    return;
                }

                try
                {
                    if (DetallesVenta.Any(d => d.Producto.Codigo == producto.Codigo))
                    {
                        MessageBox.Show("El producto ya está seleccionado.");
                        return;
                    }
                    productoBLL.DescontarStock(producto, cantidadADescontar);
                    _productos.ResetBindings();
                    //En el caso de agregar o eliminar elementos individuales de la lista, no necesitas llamar a ResetBindings().
                    DetalleVentaBE detalleVenta = new DetalleVentaBE(producto, cantidadADescontar, producto.Precio);
                    DetallesVenta.Add(detalleVenta);
                }
                catch (InvalidOperationException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto en el DataGridView Productos.");
            }
        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {
            if (dgvProductosSeleccionados.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvProductosSeleccionados.SelectedRows[0];
                DetalleVentaBE detalleVenta = (DetalleVentaBE)filaSeleccionada.DataBoundItem;

                DetallesVenta.Remove(detalleVenta);

                ProductoBE producto = detalleVenta.Producto;
                ProductoBE productoEnLista = _productos.FirstOrDefault(p => p.Codigo == producto.Codigo);
                if (productoEnLista != null)
                {
                    productoEnLista.Stock += detalleVenta.Cantidad;
                    _productos.ResetBindings();
                }
            }
            else
            {
                MessageBox.Show("Seleccione un producto en el DataGridView de Productos Seleccionados.");
            }
        }*/

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

                /*if (columnName == "Categoria" || columnName == "Marca" || columnName == "Producto")
                {
                    var cellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (cellValue != null && cellValue is CategoriaBE categoria)
                    {
                        e.Value = categoria.Nombre;
                    }
                    else if (cellValue != null && cellValue is MarcaBE marca)
                    {
                        e.Value = marca.Nombre;
                    }
                    switch (cellValue)
                    {
                        case is CategoriaBE categoria:
                            break;
                    }
                }*/
                Dictionary<string, Type> columnMapping = new Dictionary<string, Type>()
                {
                    { "Categoria", typeof(CategoriaBE) },
                    { "Marca", typeof(MarcaBE) },
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
    }
}
