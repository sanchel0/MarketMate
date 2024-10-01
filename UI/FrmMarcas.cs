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
    [DesignerCategory("Form")]
    public partial class FrmMarcas : BaseFormObserver
    {
        MarcaBLL _marcaBLL;
        List<MarcaBE> _marcas;
        List<MarcaBE> _marcasParaMostrar;
        Modo _modoActual;

        public FrmMarcas()
        {
            InitializeComponent();
            _marcaBLL = new MarcaBLL();
            CambiarModo(Modo.Consulta);
        }

        private void FrmMarcas_Load(object sender, EventArgs e)
        {
            AdjustDataGridViewWidth(dgvMarcas);
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
                        EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Inventario, Operacion.RegistrarMarca));
                        break;
                    case Modo.Modificar:
                        AplicarModificar();
                        EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Inventario, Operacion.RegistrarMarca));
                        break;
                    case Modo.Eliminar:
                        AplicarEliminar();
                        EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Inventario, Operacion.RegistrarMarca));
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
            ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatosMarca);
            ControlHelper.ClearTextBoxes(grpDatosMarca);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AplicarAgregar()
        {
            ControlHelper.ValidateNotEmpty(txtNombre);
            _marcaBLL.Existe(_marcas, txtNombre.Text);

            MarcaBE m = new MarcaBE(txtNombre.Text);

            _marcaBLL.Insert(m);
        }

        private void AplicarModificar()
        {
            ControlHelper.ValidateNotEmpty(txtNombre);
            _marcaBLL.Existe(_marcasParaMostrar, txtNombre.Text);

            MarcaBE marcaModificada = (MarcaBE)dgvMarcas.SelectedRows[0].DataBoundItem;

            marcaModificada.Nombre = txtNombre.Text;

            int selectedIndex = dgvMarcas.SelectedRows[0].Index;
            MarcaBE marcaOriginal = _marcas[selectedIndex];

            _marcas[selectedIndex] = TranslateToSpanish(marcaModificada, marcaOriginal);
            _marcaBLL.Update(_marcas[selectedIndex]);
        }

        private void AplicarEliminar()
        {
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                MarcaBE m = (MarcaBE)dgvMarcas.SelectedRows[0].DataBoundItem;
                _marcaBLL.Delete(m.Codigo);
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
                    ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatosMarca);//Siempre estará habilitado el boton Aplicar
                    ControlHelper.ClearTextBoxes(grpDatosMarca);
                    break;
                case Modo.Agregar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosMarca);
                    ControlHelper.DisableControls(btnModificar, btnEliminar);
                    ControlHelper.ClearTextBoxes(grpDatosMarca);
                    break;
                case Modo.Modificar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosMarca);
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
            _marcas = _marcaBLL.GetAll();
            _marcasParaMostrar = _marcas.Select(m => new MarcaBE(m)).ToList();

            TranslateEntityList(_marcasParaMostrar, Translation.Entities);
            
            ControlHelper.UpdateGrid(dgvMarcas, _marcasParaMostrar, "Codigo");
        }

        /*protected override void TranslateGrid(DataGridView dgv)
        {
            if (SessionManager.Language == Language.es)
            {
                Translation translation = Translation;
                //UpdateGridLanguage<MarcaBE>(dgv, translation);
            }
        }*/

        private void dgvMarcas_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvMarcas.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvMarcas.SelectedRows[0];
                MarcaBE m = (MarcaBE)selectedRow.DataBoundItem;

                txtNombre.Text = m.Nombre;
            }
        }

        public MarcaBE TranslateToSpanish(MarcaBE entity, MarcaBE originalEntity)
        {
            var m = new MarcaBE(
                entity.Nombre
                );
            m.Codigo = originalEntity.Codigo;
            return m;
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
    }
}
