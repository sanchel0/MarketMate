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

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmClientes : BaseFormObserver
    {
        ClienteBLL _clienteBLL;
        List<ClienteBE> _clientes;
        //List<ClienteBE> _clientesParaMostrar;
        Modo _modoActual;
        public FrmClientes()
        {
            InitializeComponent();
            _clienteBLL = new ClienteBLL();
            CambiarModo(Modo.Consulta);
        }

        private void FrmClientes_Load(object sender, EventArgs e)
        {
            //CambiarModo(Modo.Consulta);
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
            ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatosCliente);
            ControlHelper.ClearTextBoxes(grpDatosCliente);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
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
                    ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatosCliente);
                    ControlHelper.ClearTextBoxes(grpDatosCliente);
                    break;
                case Modo.Agregar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosCliente);
                    ControlHelper.DisableControls(btnModificar, btnEliminar);
                    ControlHelper.ClearTextBoxes(grpDatosCliente);
                    break;
                case Modo.Modificar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosCliente);
                    ControlHelper.DisableControls(btnAgregar, btnEliminar);
                    break;
                case Modo.Eliminar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(btnAgregar, btnModificar);
                    break;
            }
        }

        private void AplicarAgregar()
        {
            ControlHelper.ValidateNotEmpty(txtDni, txtNombre, txtApellido, txtCorreo, txtTel);
            _clienteBLL.VerificarDni(_clientes, txtDni.Text);

            ClienteBE cli = new ClienteBE(txtDni.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, int.Parse(txtTel.Text));
            _clienteBLL.Insert(cli);
        }

        private void AplicarModificar()
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                ControlHelper.ValidateNotEmpty(txtNombre, txtApellido, txtCorreo);

                ClienteBE cli = (ClienteBE)dgvClientes.SelectedRows[0].DataBoundItem;

                cli.Nombre = txtNombre.Text;
                cli.Apellido = txtApellido.Text;
                cli.Correo = txtCorreo.Text;
                cli.Telefono = int.Parse(txtTel.Text);

                /*int selectedIndex = dgvClientes.SelectedRows[0].Index;
                ClienteBE original = _clientes[selectedIndex];

                _clientes[selectedIndex] = TranslateToSpanish(cli, original);
                _clienteBLL.Update(_clientes[selectedIndex]);*/
                _clienteBLL.Update(cli);

                txtDni.Enabled = true;
            }
            else
            {
                throw new ValidationException(ValidationErrorType.NoSelection);
            }
        }

        private void AplicarEliminar()
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                ClienteBE cli = (ClienteBE)dgvClientes.SelectedRows[0].DataBoundItem;
                _clienteBLL.Delete(cli.Dni);
            }
            else
            {
                throw new ValidationException(ValidationErrorType.NoSelection);
            }
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvClientes.SelectedRows[0];
                ClienteBE cli = (ClienteBE)selectedRow.DataBoundItem;

                txtDni.Text = cli.Dni;
                txtNombre.Text = cli.Nombre;
                txtApellido.Text = cli.Apellido;
                txtCorreo.Text = cli.Correo;
                txtTel.Text = cli.Telefono.ToString();
            }
        }

        private void UpdateGrid()
        {
            _clientes = _clienteBLL.GetAll();
            ControlHelper.UpdateGrid(dgvClientes, _clientes);

            /*_clientes = _clienteBLL.GetAll();
            _clientesParaMostrar = _clientes.Select(c => new ClienteBE(c)).ToList();

            TranslateEntityList(_clientesParaMostrar, Translation.Entities);

            ControlHelper.UpdateGrid(dgvClientes, _clientesParaMostrar);*/
        }

        /*public ClienteBE TranslateToSpanish(ClienteBE entity, ClienteBE originalEntity)
        {
            var c = new ClienteBE(
                originalEntity.Dni,
                entity.Nombre,
                originalEntity.Apellido,
                originalEntity.Correo,
                originalEntity.Telefono
                );
            return c;
        }*/
    }
}
