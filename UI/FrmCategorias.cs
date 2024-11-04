using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmCategorias : BaseFormObserver
    {
        CategoriaBLL _categoriaBLL;
        List<CategoriaBE> _categorias;
        List<CategoriaBE> _categoriasParaMostrar;
        Modo _modoActual;

        public FrmCategorias()
        {
            InitializeComponent();
            
            _categoriaBLL = new CategoriaBLL();
            CambiarModo(Modo.Consulta);
        }
        
        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            AdjustDataGridViewWidth(dgvCategorias);
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
            //CambiarModo(Modo.Consulta);

            _modoActual = Modo.Consulta;
            ControlHelper.EnableControls(btnAgregar, btnModificar, btnEliminar);
            ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatosCategoria);
            ControlHelper.ClearTextBoxes(grpDatosCategoria);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AplicarAgregar()
        {
            ControlHelper.ValidateNotEmpty(txtNombre, txtDescripcion);

            CategoriaBE c = new CategoriaBE(txtNombre.Text, txtDescripcion.Text);

            _categoriaBLL.Insert(c);
        }

        private void AplicarModificar()
        {
            ControlHelper.ValidateNotEmpty(txtNombre, txtDescripcion);

            CategoriaBE categoriaModificada = (CategoriaBE)dgvCategorias.SelectedRows[0].DataBoundItem;

            categoriaModificada.Nombre = txtNombre.Text;
            categoriaModificada.Descripcion = txtDescripcion.Text;
            
            int selectedIndex = dgvCategorias.SelectedRows[0].Index;
            CategoriaBE categoriaOriginal = _categorias[selectedIndex];

            _categorias[selectedIndex] = TranslateToSpanish(categoriaModificada, categoriaOriginal);
            _categoriaBLL.Update(_categorias[selectedIndex]);
        }

        private void AplicarEliminar()
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                CategoriaBE c = (CategoriaBE)dgvCategorias.SelectedRows[0].DataBoundItem;
                _categoriaBLL.Delete(c.Codigo);
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
                    ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatosCategoria);//Siempre estará habilitado el boton Aplicar
                    ControlHelper.ClearTextBoxes(grpDatosCategoria);
                    break;
                case Modo.Agregar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosCategoria);
                    ControlHelper.DisableControls(btnModificar, btnEliminar);
                    ControlHelper.ClearTextBoxes(grpDatosCategoria);
                    break;
                case Modo.Modificar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosCategoria);
                    ControlHelper.DisableControls(btnAgregar, btnEliminar);
                    break;
                case Modo.Eliminar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(btnAgregar, btnModificar);
                    break;
            }
        }

        private void UpdateGrid()
        {
            try
            {
                _categorias = _categoriaBLL.GetAll();
                _categoriasParaMostrar = _categorias.Select(c => new CategoriaBE(c)).ToList();

                TranslateEntityList(_categoriasParaMostrar, Translation.Entities);

                ControlHelper.UpdateGrid(dgvCategorias, _categoriasParaMostrar, "Codigo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /*protected override void TranslateGrid(DataGridView dgv)
        {
            if (SessionManager.Language == Language.es)
            {
                Translation translation = Translation;
                //UpdateGridLanguage<CategoriaBE>(dgv, translation);
            }
        }*/

        private void dgvCategorias_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCategorias.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvCategorias.SelectedRows[0];
                CategoriaBE c = (CategoriaBE)selectedRow.DataBoundItem;

                txtNombre.Text = c.Nombre;
                txtDescripcion.Text = c.Descripcion;
            }
        }

        /*public CategoriaBE TranslateToEnglish(CategoriaBE categoria)
        {

            return new CategoriaBE(
                GetTranslatedValue("Categoria", "Nombre", categoria.Nombre),
                GetTranslatedValue("Categoria", "Descripcion", categoria.Descripcion)
                );
        }*/

        public CategoriaBE TranslateToSpanish(CategoriaBE entity, CategoriaBE originalEntity)
        {
            /*var nombre = entity.Nombre != originalEntity.Nombre
            ? translation.GetTranslatedValueFromEntity("Producto", "Nombre", entity.Nombre)
            : entity.Nombre;*/
            var c = new CategoriaBE(
                entity.Nombre,
                originalEntity.Descripcion
                ); 
            c.Codigo = originalEntity.Codigo;
            return c;
        }

        private void AdjustDataGridViewWidth(DataGridView dgv)
        {
            int totalWidth = dgv.RowHeadersWidth; // Incluir el ancho del encabezado de las filas.

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
    }
}
