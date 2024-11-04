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
    public partial class FrmProveedores : Form
    {
        ProveedorBLL proveedorBLL;
        List<ProveedorBE> proveedores;
        ModoHandler _modoHandler;

        public FrmProveedores()
        {
            InitializeComponent();
            proveedorBLL = new ProveedorBLL();
            proveedores = new List<ProveedorBE>();
            //CambiarModo(Modo.Consulta);
            _modoHandler = new ModoHandler(btnAgregar, btnModificar, btnEliminar, btnAplicar, btnCancelar, grpDatos, lblModo);
            _modoHandler.CambiarModo(Modo.Consulta);
            UpdateGrid();
            //_operationHandler = new OperationHandler<ProveedorBE>(new ProveedorBLL());
        }

        private void FrmProveedores_Load(object sender, EventArgs e)
        {
            cboTipoCuenta.DataSource = Enum.GetValues(typeof(TipoCuenta));
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            _modoHandler.CambiarModo(Modo.Agregar);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            _modoHandler.CambiarModo(Modo.Modificar);
            txtCBU.Enabled = false;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            _modoHandler.CambiarModo(Modo.Eliminar);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_modoHandler.modoActual)
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
                //MessageBox.Show(mensaje);
            }
            /*catch (ValidationException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (DatabaseException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }*/
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally 
            { 
                _modoHandler.CambiarModo(Modo.Consulta);
                UpdateGrid();
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            _modoHandler.CambiarModo(Modo.Consulta);
            /*ControlHelper.EnableControls(btnAgregar, btnModificar, btnEliminar);
            ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatos);
            ControlHelper.ClearTextBoxes(grpDatos);*/
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*private void CambiarModo(Modo nuevoModo)
        {
            _modoActual = nuevoModo;
            lblModo.Text = Translation.GetEnumTranslation(_modoActual);
            switch (_modoActual)
            {
                case Modo.Consulta:
                    UpdateGrid();
                    ControlHelper.EnableControls(btnAgregar, btnModificar, btnEliminar);
                    ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatos);
                    ControlHelper.ClearTextBoxes(grpDatos);
                    break;
                case Modo.Agregar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatos);
                    ControlHelper.DisableControls(btnModificar, btnEliminar);
                    ControlHelper.ClearTextBoxes(grpDatos);
                    break;
                case Modo.Modificar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatos);
                    ControlHelper.DisableControls(btnAgregar, btnEliminar);
                    break;
                case Modo.Eliminar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(btnAgregar, btnModificar);
                    break;
            }
        }*/

        private void AplicarAgregar()
        {
            ControlHelper.ValidateNotEmpty(txtCUIT, txtNombre, txtRS, txtCorreo, txtDir);

            ProveedorBE p = new ProveedorBE(txtCUIT.Text, txtNombre.Text, txtRS.Text, Convert.ToInt32(txtTel.Text), txtCorreo.Text);

            if (txtDir.Text != string.Empty)
            {
                ControlHelper.ValidateNotEmpty(txtDir, cboTipoCuenta, txtNumCuenta, txtCBU, txtAlias);

                p.Direccion = txtDir.Text;
                p.TipoCuenta = (TipoCuenta?)cboTipoCuenta.SelectedItem;
                p.NumCuenta = txtNumCuenta.Text;
                p.CBU = txtCBU.Text;
                p.Alias = txtAlias.Text;
            }
            
            proveedorBLL.Insert(p);            
        }

        private void AplicarModificar()
        {
            ControlHelper.TryGetSelectedRow(dgvProveedores, out ProveedorBE p);
            ControlHelper.ValidateNotEmpty(txtCUIT, txtNombre, txtRS, txtCorreo, txtDir);
            //CBU no se modifica
            p.Nombre = txtNombre.Text;
            p.RazonSocial = txtRS.Text;
            p.Telefono = Convert.ToInt32(txtTel.Text);
            p.Correo = txtCorreo.Text;
            p.Direccion = txtDir.Text;

            if (txtDir.Text != string.Empty)
            {
                ControlHelper.ValidateNotEmpty(txtDir, cboTipoCuenta, txtNumCuenta, txtCBU, txtAlias);

                p.Direccion = txtDir.Text;
                p.TipoCuenta = (TipoCuenta?)cboTipoCuenta.SelectedItem;
                p.NumCuenta = txtNumCuenta.Text;
                p.CBU = txtCBU.Text;
                p.Alias = txtAlias.Text;
            }
            /*int selectedIndex = dgvClientes.SelectedRows[0].Index;
            ClienteBE original = _clientes[selectedIndex];

            _clientes[selectedIndex] = TranslateToSpanish(cli, original);
            _clienteBLL.Update(_clientes[selectedIndex]);*/
            
            proveedorBLL.Update(p);

            txtCBU.Enabled = true;
        }

        private void AplicarEliminar()
        {
            ControlHelper.TryGetSelectedRow(dgvProveedores, out ProveedorBE p);
            proveedorBLL.Delete(p.CUIT);
        }

        private void UpdateGrid()
        {
            try
            {
                ControlHelper.UpdateGrid(dgvProveedores, proveedorBLL.GetAll());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProveedores_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.TryGetSelectedRow(dgvProveedores, out ProveedorBE p);

                txtCUIT.Text = p.CUIT;
                txtNombre.Text = p.Nombre;
                txtRS.Text = p.RazonSocial;
                txtTel.Text = p.Telefono.ToString();
                txtCorreo.Text = p.Correo;
                txtDir.Text = p.Direccion;
                txtBanco.Text = p.Banco;
                cboTipoCuenta.SelectedItem = p.TipoCuenta;
                txtNumCuenta.Text = p.NumCuenta;
                txtCBU.Text = p.CBU;
                txtAlias.Text = p.Alias;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
