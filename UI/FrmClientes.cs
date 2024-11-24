using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmClientes : BaseFormObserver
    {
        ClienteBLL _clienteBLL;
        List<ClienteBE> _clientes;
        XmlSerializer serializer;
        //List<ClienteBE> _clientesParaMostrar;
        Modo _modoActual;
        public FrmClientes()
        {
            InitializeComponent();
            _clienteBLL = new ClienteBLL();
            serializer = new XmlSerializer(typeof(List<ClienteBE>));
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
                string mensaje = GetTranslation(SuccessType.OperationSuccess);
                switch (_modoActual)
                {
                    case Modo.Agregar:
                        AplicarAgregar();
                        //EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Clientes, Operacion.RegistrarCliente));
                        break;
                    case Modo.Modificar:
                        AplicarModificar();
                        //EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Clientes, Operacion.ModificarCliente));
                        break;
                    case Modo.Eliminar:
                        AplicarEliminar();
                        //EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Clientes, Operacion.RegistrarCliente));
                        break;
                }
                MessageBox.Show(mensaje);
            }
            catch (ValidationException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (DatabaseException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
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
            lblModo.Text = GetTranslation(_modoActual);
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
            try
            {
                _clientes = _clienteBLL.GetAll();
                ControlHelper.UpdateGrid(dgvClientes, _clientes);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            /*_clientes = _clienteBLL.GetAll();
            _clientesParaMostrar = _clientes.Select(c => new ClienteBE(c)).ToList();

            TranslateEntityList(_clientesParaMostrar, Translation.Entities);

            ControlHelper.UpdateGrid(dgvClientes, _clientesParaMostrar);*/
        }

        private void btnSerializar_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                saveFileDialog.DefaultExt = "xml";

                List<ClienteBE> clientes = ObtenerClientesDeGrilla();

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = saveFileDialog.FileName;

                    if (!filePath.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("El archivo debe tener la extensión .xml", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string[] lines = XmlDataSerializer.Serialize(clientes, filePath);
                    /*XmlSerializer serializer = new XmlSerializer(typeof(List<ClienteBE>));
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        serializer.Serialize(writer, clientes);
                    }

                    string[] lines = File.ReadAllLines(filePath);*/

                    lstClientes.Items.Clear();
                    foreach (string line in lines)
                    {
                        lstClientes.Items.Add(line);
                    }
                    EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Serializacion, Operacion.Serializar));

                    txtRuta.Text = $"Ruta: {filePath}";

                    MessageBox.Show("Datos serializados exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "XML Files (*.xml)|*.xml|All Files (*.*)|*.*";
                openFileDialog.DefaultExt = "xml";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;

                    if (!filePath.EndsWith(".xml", StringComparison.OrdinalIgnoreCase))
                    {
                        MessageBox.Show("El archivo debe tener la extensión .xml", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    List<ClienteBE> clientes = XmlDataSerializer.Deserialize<ClienteBE>(filePath);
                    /*using (StreamReader reader = new StreamReader(filePath))
                    {
                        List<ClienteBE> clientes = (List<ClienteBE>)serializer.Deserialize(reader);
                        ControlHelper.UpdateGrid(dgvClientes, clientes);
                        lstClientes.Items.Clear();
                        LoadListBox(lstClientes, clientes);
                    }*/

                    ControlHelper.UpdateGrid(dgvClientes, clientes);
                    lstClientes.Items.Clear();
                    LoadListBox(lstClientes, clientes);
                    EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Serializacion, Operacion.Deserializar));

                    txtRuta.Text = $"Ruta: {filePath}";

                    MessageBox.Show("Datos deserializados exitosamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private List<ClienteBE> ObtenerClientesDeGrilla()
        {
            if (dgvClientes.DataSource is List<ClienteBE> listaClientes)
            {
                return listaClientes;
            }
            else
            {
                MessageBox.Show("El origen de datos no es una lista de ClienteBE.");
                return new List<ClienteBE>();
            }
        }

        public static void LoadListBox(ListBox listBox, List<ClienteBE> clientes)
        {
            foreach (var cliente in clientes)
            {
                listBox.Items.Add($"DNI: {cliente.Dni}");
                listBox.Items.Add($"Nombre: {cliente.Nombre}");
                listBox.Items.Add($"Apellido: {cliente.Apellido}");
                listBox.Items.Add($"Correo: {cliente.Correo}");
                listBox.Items.Add($"Teléfono: {cliente.Telefono}");
                listBox.Items.Add("");
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            CambiarModo(Modo.Consulta);
            lstClientes.Items.Clear();
            txtRuta.Text = string.Empty;
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
