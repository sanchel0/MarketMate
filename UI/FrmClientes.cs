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

namespace UI
{
    public partial class FrmClientes : Form
    {
        ClienteBLL _clienteBLL;
        List<ClienteBE> _clientes;
        Modo _modoActual;
        public FrmClientes()
        {
            InitializeComponent();
            _clienteBLL = new ClienteBLL();
            //_clientes = _clienteBLL.GetAll();
        }

        private void FrmClientes_Load(object sender, EventArgs e)
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

        private void CambiarModo(Modo nuevoModo)
        {
            _modoActual = nuevoModo;
            switch (_modoActual)
            {
                case Modo.Consulta:
                    UpdateGrid();
                    ControlHelper.EnableControls(btnAgregar, btnModificar, btnEliminar);
                    ControlHelper.DisableControls(btnAplicar, btnCancelar, grpDatosCliente);//Siempre estará habilitado el boton Aplicar
                    ControlHelper.SetLabelMessage(lblModo, "Consulta");
                    ControlHelper.ClearTextBoxes(grpDatosCliente);
                    ControlHelper.UpdateGrid(dgvClientes, _clientes);
                    break;
                case Modo.Agregar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosCliente);
                    ControlHelper.DisableControls(btnModificar, btnEliminar);
                    ControlHelper.ClearTextBoxes(grpDatosCliente);
                    ControlHelper.SetLabelMessage(lblModo, "Agregar");
                    break;
                case Modo.Modificar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar, grpDatosCliente);
                    ControlHelper.DisableControls(btnAgregar, btnEliminar, txtDni);
                    ControlHelper.SetLabelMessage(lblModo, "Modificar");
                    break;
                case Modo.Eliminar:
                    ControlHelper.EnableControls(btnCancelar, btnAplicar);
                    ControlHelper.DisableControls(btnAgregar, btnModificar);
                    ControlHelper.SetLabelMessage(lblModo, "Eliminar");
                    break;
            }
        }

        private void AplicarAgregar()
        {
            /*if (string.IsNullOrWhiteSpace(txtDni.Text) || string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Por favor complete todos los campos.", "Campos Incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }*/
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

                _clienteBLL.Update(cli);

                txtDni.Enabled = true;
            }
            else
            {
                throw new Exception("Seleccione un cliente de la grilla.");
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
                throw new Exception("Seleccione un cliente de la grilla.");
            }
        }

        /*private void AplicarConsulta()
        {
            var resultados = _clientes;

            if (!string.IsNullOrEmpty(txtDni.Text))
                resultados = resultados.Where(u => u.Dni == txtDni.Text).ToList();

            if (!string.IsNullOrEmpty(txtNombre.Text))
                resultados = resultados.Where(u => u.Nombre == txtNombre.Text).ToList();

            if (!string.IsNullOrEmpty(txtApellido.Text))
                resultados = resultados.Where(u => u.Apellido == txtApellido.Text).ToList();

            if (!string.IsNullOrEmpty(txtCorreo.Text))
                resultados = resultados.Where(u => u.Correo == txtCorreo.Text).ToList();

            if (!string.IsNullOrEmpty(txtTel.Text))
                resultados = resultados.Where(u => u.Telefono == int.Parse(txtTel.Text)).ToList();

            UpdateGridConFiltro(resultados);
        }*/

        /*private void UpdateGridConFiltro(List<ClienteBE> datos = null)
        {
            List<ClienteBE> datosFiltrados = new List<ClienteBE>();

            if (datos == null)
            {
                datosFiltrados = _clientes;
            }
            else
            {
                datosFiltrados = datos;
            }

            ControlHelper.UpdateGrid(dgvClientes, datosFiltrados);
        }*/

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
        }
    }
}
