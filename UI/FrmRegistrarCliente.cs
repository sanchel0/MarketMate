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
using UI;

namespace GUI
{
    [DesignerCategory("Form")]
    public partial class FrmRegistrarCliente : BaseFormObserver
    {
        public ClienteBE ClienteRegistrado { get; private set; }
        private ErrorProvider errorProvider;
        public FrmRegistrarCliente()
        {
            InitializeComponent();
            errorProvider = new ErrorProvider();
            errorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;

            txtNombre.KeyPress += TextBox_LettersOnly;
            txtApellido.KeyPress += TextBox_LettersOnly;
            txtDni.KeyPress += TextBox_NumbersOnly;
            txtTelefono.KeyPress += TextBox_NumbersOnly;
        }

        private void RegistrarCliente_Load(object sender, EventArgs e)
        {

        }

        private void btnRegsitrar_Click(object sender, EventArgs e)
        {
            try
            {
                ControlHelper.ValidateNotEmpty(txtDni, txtNombre, txtApellido, txtCorreo, txtTelefono);
                ControlHelper.ValidateTextBoxLength(txtDni, 8);
                ControlHelper.ValidateTextBoxLength(txtTelefono, 10);
                
                ClienteBLL clienteBLL = new ClienteBLL();

                List<ClienteBE> list = clienteBLL.GetAll();
                clienteBLL.VerificarDni(list, txtDni.Text);

                

                ClienteBE cliente = new ClienteBE(txtDni.Text, txtNombre.Text, txtApellido.Text, txtCorreo.Text, int.Parse(txtTelefono.Text));
                clienteBLL.Insert(cliente);
                ClienteRegistrado = cliente;

                string mensaje = Translation.GetEnumTranslation(SuccessType.OperationSuccess);
                MessageBox.Show(mensaje);

                this.Close();
            }
            catch (ValidationException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch(DatabaseException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
