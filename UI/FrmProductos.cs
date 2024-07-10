using BE;
using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace UI
{
    public partial class FrmProductos : Form
    {
        ProductoBLL _productoBLL;
        CategoriaBLL _categoriaBLL;
        MarcaBLL _marcaBLL;
        List<ProductoBE> _productos;
        List<CategoriaBE> _categorias;
        List<MarcaBE> _marcas;
        Modo _modoActual;
        Tipo _tipoActual;
        DataGridView _dgvActual = null;
        public FrmProductos()
        {
            InitializeComponent();
            _productoBLL = new ProductoBLL();
            _categoriaBLL = new CategoriaBLL();
            _marcaBLL = new MarcaBLL();

            /*_productos = _productoBLL.GetAll();
            _categorias = _categoriaBLL.GetAll();
            _marcas = _marcaBLL.GetAll();*/
            //UpdateGrids();

            rdoProducto.CheckedChanged += radioButton_CheckedChanged;
            rdoCat.CheckedChanged += radioButton_CheckedChanged;
            rdoMarca.CheckedChanged += radioButton_CheckedChanged;
            dgvProductos.CellFormatting += dgvProd_CellFormatting;

            rdoProducto.Checked = true;
        }

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                if (((RadioButton)sender) == rdoProducto)
                {
                    _dgvActual = dgvProductos;
                    _tipoActual = Tipo.Producto;
                    ControlHelper.ClearTextBoxes(grpDatosCategoria);
                    ControlHelper.ClearTextBoxes(grpDatosMarca);
                    ControlHelper.EnableControls(pnlProducto);
                    ControlHelper.DisableControls(pnlCategoria, pnlMarca);
                }
                else if (((RadioButton)sender) == rdoCat)
                {
                    _dgvActual = dgvCategorias;
                    _tipoActual = Tipo.Categoria;
                    ControlHelper.ClearTextBoxes(grpDatosProducto);
                    ControlHelper.ClearTextBoxes(grpDatosMarca);
                    ControlHelper.EnableControls(pnlCategoria);
                    ControlHelper.DisableControls(pnlProducto, pnlMarca);
                }
                else if (((RadioButton)sender) == rdoMarca)
                {
                    _dgvActual = dgvMarcas;
                    _tipoActual = Tipo.Marca;
                    ControlHelper.ClearTextBoxes(grpDatosProducto);
                    ControlHelper.ClearTextBoxes(grpDatosCategoria);
                    ControlHelper.EnableControls(pnlMarca);
                    ControlHelper.DisableControls(pnlProducto, pnlCategoria);
                }
            }
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            CambiarModo(Modo.Consulta);
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Agregar);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Modificar);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Eliminar);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                string mensaje = "Operación realizada con éxito";
                switch (_modoActual)
                {
                    case Modo.Agregar:
                        AplicarAgregar();
                        break;
                    case Modo.Modificar:
                        AplicarModificar();
                        break;
                    case Modo.Eliminar:
                        AplicarEliminar();
                        break;
                }
                MessageBox.Show(mensaje);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { CambiarModo(Modo.Consulta); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Consulta);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AplicarAgregar()
        {
            /*if (string.IsNullOrWhiteSpace(txtRol.Text) && string.IsNullOrWhiteSpace(txtFamilia.Text))
                throw new Exception("Por favor complete el campo.");*/

            switch (_tipoActual)
            {
                case Tipo.Producto:
                    ControlHelper.ValidateNotEmpty(txtNombreProd, txtStock, cboCategorias, cboMarcas, txtCosto, txtPrecio);
                    _productoBLL.Existe(_productos, txtNombreProd.Text);

                    ProductoBE p = new ProductoBE(txtNombreProd.Text, int.Parse(txtStock.Text), (CategoriaBE)cboCategorias.SelectedItem, (MarcaBE)cboMarcas.SelectedItem, decimal.Parse(txtCosto.Text), decimal.Parse(txtPrecio.Text));
                    _productoBLL.Insert(p);
                    //UpdateGridProducto();
                    break;

                case Tipo.Categoria:
                    ControlHelper.ValidateNotEmpty(txtNombreCat, txtDesc);
                    _categoriaBLL.Existe(_categorias, txtNombreCat.Text);

                    CategoriaBE c = new CategoriaBE(txtNombreCat.Text, txtDesc.Text);
                    _categoriaBLL.Insert(c);
                    //UpdateGridCategoria();
                    break;

                case Tipo.Marca:
                    ControlHelper.ValidateNotEmpty(txtNombreMarca);
                    _marcaBLL.Existe(_marcas, txtNombreMarca.Text);

                    MarcaBE m = new MarcaBE(txtNombreMarca.Text);
                    _marcaBLL.Insert(m);
                    //UpdateGridMarca();
                    break;
            }
        }

        private void AplicarModificar()
        {
            switch (_tipoActual)
            {
                case Tipo.Producto:
                    ControlHelper.ValidateNotEmpty(txtNombreProd, txtStock, cboCategorias, cboMarcas, txtCosto, txtPrecio);
                    _productoBLL.Existe(_productos, txtNombreProd.Text);

                    ProductoBE p = (ProductoBE)dgvProductos.SelectedRows[0].DataBoundItem;
                    p.Nombre = txtNombreProd.Text;
                    p.Stock = int.Parse(txtStock.Text);
                    p.Categoria = (CategoriaBE)cboCategorias.SelectedItem;
                    p.Marca = (MarcaBE)cboMarcas.SelectedItem;
                    p.Costo = decimal.Parse(txtCosto.Text);
                    p.Precio = decimal.Parse(txtPrecio.Text);
                    _productoBLL.Update(p);
                    break;

                case Tipo.Categoria:
                    ControlHelper.ValidateNotEmpty(txtNombreCat, txtDesc);
                    _categoriaBLL.Existe(_categorias, txtNombreCat.Text);

                    CategoriaBE c = (CategoriaBE)dgvCategorias.SelectedRows[0].DataBoundItem;
                    c.Nombre = txtNombreCat.Text;
                    c.Descripcion = txtDesc.Text;
                    _categoriaBLL.Update(c);
                    break;

                case Tipo.Marca:
                    ControlHelper.ValidateNotEmpty(txtNombreMarca);
                    _marcaBLL.Existe(_marcas, txtNombreMarca.Text);

                    MarcaBE m = (MarcaBE)dgvMarcas.SelectedRows[0].DataBoundItem;
                    m.Nombre = txtNombreMarca.Text;
                    _marcaBLL.Update(m);
                    break;
            }
        }

        private void AplicarEliminar()
        {
            if (_dgvActual.SelectedRows.Count > 0)
            {
                switch (_tipoActual)
                {
                    case Tipo.Producto:
                        ProductoBE p = (ProductoBE)dgvProductos.SelectedRows[0].DataBoundItem;
                        _productoBLL.Delete(p.Codigo);
                        break;

                    case Tipo.Categoria:
                        CategoriaBE c = (CategoriaBE)dgvCategorias.SelectedRows[0].DataBoundItem;
                        _categoriaBLL.Delete(c.Codigo);
                        break;

                    case Tipo.Marca:
                        MarcaBE m = (MarcaBE)dgvMarcas.SelectedRows[0].DataBoundItem;
                        _marcaBLL.Delete(m.Codigo);
                        break;
                }
            }
            else
            {
                throw new Exception("Seleccione un elemento del combobox.");
            }
        }

        private void CambiarModo(Modo nuevoModo)
        {
            _modoActual = nuevoModo;
            switch (_modoActual)
            {
                case Modo.Consulta:
                    UpdateGrids();
                    ControlHelper.EnableControls(pnlRdos, btnAgregar, btnModificar, btnEliminar);
                    ControlHelper.DisableControls(btnCancelar, btnAplicar, grpDatosProducto, grpDatosCategoria, grpDatosMarca);
                    ControlHelper.SetLabelMessage(lblModo, "Consulta");
                    ControlHelper.ClearTextBoxes(grpDatosMarca);
                    ControlHelper.ClearTextBoxes(grpDatosProducto);
                    ControlHelper.ClearTextBoxes(grpDatosCategoria);
                    ControlHelper.LoadComboBox(cboCategorias, _categorias);
                    ControlHelper.LoadComboBox(cboMarcas, _marcas);
                    break;
                case Modo.Agregar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosProducto, grpDatosCategoria, grpDatosMarca);
                    ControlHelper.DisableControls(pnlRdos, btnModificar, btnEliminar);
                    ControlHelper.SetLabelMessage(lblModo, "Agregar");
                    break;
                case Modo.Modificar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosProducto, grpDatosCategoria, grpDatosMarca);
                    ControlHelper.DisableControls(pnlRdos, btnAgregar, btnEliminar);
                    ControlHelper.SetLabelMessage(lblModo, "Modificar");
                    break;
                case Modo.Eliminar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(pnlRdos, btnAgregar, btnModificar);
                    ControlHelper.SetLabelMessage(lblModo, "Eliminar");
                    break;
            }
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvProductos.SelectedRows[0];
                ProductoBE p = (ProductoBE)selectedRow.DataBoundItem;

                txtNombreProd.Text = p.Nombre;
                txtStock.Text = p.Stock.ToString();
                txtCosto.Text = p.Costo.ToString();
                txtPrecio.Text = p.Precio.ToString();
                cboCategorias.SelectedItem = p.Categoria;
                cboMarcas.SelectedItem = p.Marca;

                foreach (CategoriaBE categoria in cboCategorias.Items)
                {
                    if (categoria.Codigo == p.Categoria.Codigo)
                    {
                        cboCategorias.SelectedItem = categoria;
                        break;
                    }
                }

                foreach (MarcaBE marca in cboMarcas.Items)
                {
                    if (marca.Codigo == p.Marca.Codigo)
                    {
                        cboMarcas.SelectedItem = marca;
                        break;
                    }
                }
            }
        }

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCategorias.SelectedRows[0];
                CategoriaBE c = (CategoriaBE)selectedRow.DataBoundItem;

                txtNombreCat.Text = c.Nombre;
                txtDesc.Text = c.Descripcion;
            }
        }

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMarcas.SelectedRows[0];
                MarcaBE m = (MarcaBE)selectedRow.DataBoundItem;

                txtNombreMarca.Text = m.Nombre;
            }
        }

        private void UpdateGrids()
        {
            UpdateGridProducto();
            UpdateGridCategoria();
            UpdateGridMarca();
        }

        private void UpdateGridProducto()
        {
            _productos = _productoBLL.GetAll();
            ControlHelper.UpdateGrid(dgvProductos, _productos, "Codigo");
        }

        private void UpdateGridCategoria()
        {
            _categorias = _categoriaBLL.GetAll();
            ControlHelper.UpdateGrid(dgvCategorias, _categorias, "Codigo");
        }

        private void UpdateGridMarca()
        {
            _marcas = _marcaBLL.GetAll();
            ControlHelper.UpdateGrid(dgvMarcas, _marcas, "Codigo");
        }

        private void dgvProd_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                var columnName = dataGridView.Columns[e.ColumnIndex].Name;

                if (columnName == "Categoria" || columnName == "Marca" || columnName == "Producto")
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
                }
            }
        }

        private void dgvMarcas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
