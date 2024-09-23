using BE;
using BLL;
using Services;
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
    [DesignerCategory("Form")]
    public partial class FrmProductos : BaseFormObserver
    {
        ProductoBLL _productoBLL;
        CategoriaBLL _categoriaBLL;
        MarcaBLL _marcaBLL;
        List<ProductoBE> _productos;
        List<ProductoBE> _productosParaMostrar;
        List<CategoriaBE> _categorias;
        //List<CategoriaBE> _categoriasParaMostrar;
        List<MarcaBE> _marcas;
        //List<MarcaBE> _marcasParaMostrar;
        Modo _modoActual;

        public FrmProductos()
        {
            InitializeComponent();
            _productoBLL = new ProductoBLL();
            _categoriaBLL = new CategoriaBLL();
            _marcaBLL = new MarcaBLL();

            _categorias = _categoriaBLL.GetAll();
            _marcas = _marcaBLL.GetAll();
            CambiarModo(Modo.Consulta);
            dgvProductos.CellFormatting += dgvProd_CellFormatting;
        }

        private void FrmProductos_Load(object sender, EventArgs e)
        {
            AdjustDataGridViewWidth(dgvProductos);
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
                string mensaje = Translation.GetEnumTranslation(SuccessType.OperationSuccess);
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
            catch (ValidationException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (DatabaseException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { CambiarModo(Modo.Consulta); }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _modoActual = Modo.Consulta;
            ControlHelper.EnableControls(btnAgregar, btnModificar, btnEliminar);
            ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatosProducto);
            ControlHelper.ClearTextBoxes(grpDatosProducto);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AplicarAgregar()
        {
            ControlHelper.ValidateNotEmpty(txtNombre, txtStock, txtMin, txtMax, cboCategorias, cboMarcas, txtPrecio);
            _productoBLL.Existe(_productos, txtNombre.Text);

            ProductoBE p = new ProductoBE(txtNombre.Text, int.Parse(txtStock.Text), int.Parse(txtMin.Text), int.Parse(txtMax.Text), (CategoriaBE)cboCategorias.SelectedItem, (MarcaBE)cboMarcas.SelectedItem, decimal.Parse(txtPrecio.Text));
            _productoBLL.Insert(p);
        }

        private void AplicarModificar()
        {
            ControlHelper.ValidateNotEmpty(txtNombre, txtStock, txtMin, txtMax, cboCategorias, cboMarcas, txtPrecio);
            //_productoBLL.Existe(_productos, txtNombre.Text);

            ProductoBE productoModificado = (ProductoBE)dgvProductos.SelectedRows[0].DataBoundItem;
            productoModificado.Nombre = txtNombre.Text;
            productoModificado.Stock = int.Parse(txtStock.Text);
            productoModificado.StockMinimo = int.Parse(txtMin.Text);
            productoModificado.StockMaximo = int.Parse(txtMax.Text);
            productoModificado.Categoria = (CategoriaBE)cboCategorias.SelectedItem;
            productoModificado.Marca = (MarcaBE)cboMarcas.SelectedItem;
            productoModificado.Precio = decimal.Parse(txtPrecio.Text);

            int selectedIndex = dgvProductos.SelectedRows[0].Index;
            ProductoBE productoOriginal = _productos[selectedIndex];

            _productos[selectedIndex] = TranslateToSpanish(productoModificado, productoOriginal);
            _productoBLL.Update(_productos[selectedIndex]);
        }

        private void AplicarEliminar()
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                ProductoBE p = (ProductoBE)dgvProductos.SelectedRows[0].DataBoundItem;
                _productoBLL.Delete(p.Codigo);
            }
            else
            {
                throw new ValidationException(ValidationErrorType.NoSelection);
            }
        }

        private void CambiarModo(Modo nuevoModo)
        {
            _modoActual = nuevoModo;
            lblModo.Text = Translation.GetEnumTranslation(_modoActual);

            switch (_modoActual)
            {
                case Modo.Consulta:
                    UpdateGrid();
                    ControlHelper.EnableControls(btnAgregar, btnModificar, btnEliminar);
                    ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatosProducto);
                    ControlHelper.ClearTextBoxes(grpDatosProducto);
                    LoadComboBox();
                    break;
                case Modo.Agregar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosProducto);
                    ControlHelper.DisableControls(btnModificar, btnEliminar);
                    ControlHelper.ClearTextBoxes(grpDatosProducto);
                    break;
                case Modo.Modificar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosProducto);
                    ControlHelper.DisableControls(btnAgregar, btnEliminar);
                    break;
                case Modo.Eliminar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(btnAgregar, btnModificar);
                    break;
            }
        }

        private void LoadComboBox()
        {
            //_categoriasParaMostrar = _categorias.Select(c => new CategoriaBE(c)).ToList();
            TranslateEntityList(_categorias, Translation.Entities);
            ControlHelper.LoadComboBox(cboCategorias, _categorias);

            //_marcasParaMostrar = _marcas.Select(m => new MarcaBE(m)).ToList();
            TranslateEntityList(_marcas, Translation.Entities);
            ControlHelper.LoadComboBox(cboMarcas, _marcas);
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvProductos.SelectedRows[0];
                ProductoBE p = (ProductoBE)selectedRow.DataBoundItem;

                txtNombre.Text = p.Nombre;
                txtStock.Text = p.Stock.ToString();
                txtMin.Text = p.StockMinimo.ToString();
                txtMax.Text = p.StockMaximo.ToString();
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

        private void UpdateGrid()
        {
            _productos = _productoBLL.GetAll();
            _productosParaMostrar = _productos.Select(p => new ProductoBE(p)).ToList();

            TranslateEntityList(_productosParaMostrar, Translation.Entities);

            ControlHelper.UpdateGrid(dgvProductos, _productosParaMostrar, "Codigo");
        }

        /*protected override void TranslateGrid(DataGridView dgv)
        {
            if (SessionManager.Language == Language.es)
            {
                Translation translation = Translation;
                //UpdateGridLanguage<ProductoBE>(dgv, translation);
            }
        }*/

        public ProductoBE TranslateToSpanish(ProductoBE entity, ProductoBE originalEntity)
        {
            var p = new ProductoBE(
                entity.Nombre,
                entity.Stock,
                entity.StockMinimo,
                entity.StockMaximo,
                originalEntity.Categoria,
                originalEntity.Marca,
                entity.Precio
            );
            p.Codigo = originalEntity.Codigo;
            return p;
        }

        private void AdjustDataGridViewWidth(DataGridView dgv)
        {
            int totalWidth = dgv.RowHeadersWidth;

            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (column.Visible)
                {
                    totalWidth += column.Width;
                }
            }
            totalWidth += SystemInformation.VerticalScrollBarWidth;
            dgv.Width = totalWidth + 2;
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
    }
}
