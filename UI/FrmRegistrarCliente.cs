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
    public partial class FrmRegistrarCliente : Form
    {
        public ClienteBE ClienteRegistrado { get; private set; }
        private ErrorProvider errorProvider;
        public FrmRegistrarCliente()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        private void RegistrarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnRegsitrar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.ValidateNotEmpty(txtDni, txtNombre, txtApellido, txtCorreo, txtTelefono);
                /*if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    errorProvider.SetError(txtNombre, "Ingrese un nombre válido.");
                    return; // Detener la validación
                }

                if (string.IsNullOrEmpty(txtApellido.Text))
                {
                    errorProvider.SetError(txtApellido, "Ingrese un apellido válido.");
                    return; // Detener la validación
                }*/
                ControlHelper.ValidateNumeric(txtDni, txtTelefono);
                ControlHelper.ValidateTextBoxLength(txtDni, 8);
                ControlHelper.ValidateTextBoxLength(txtTelefono, 10);

                ClienteBLL clienteBLL = new ClienteBLL();
                ClienteBE cliente = new ClienteBE(txtDni.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, int.Parse(txtTelefono.Text));
                clienteBLL.Insert(cliente);
                ClienteRegistrado = cliente;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
