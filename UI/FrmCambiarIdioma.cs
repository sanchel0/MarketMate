using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;
using Services;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmCambiarIdioma : BaseFormObserver
    {
        public FrmCambiarIdioma()
        {
            InitializeComponent();
            SetupLanguageComboBox();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboIdiomas.SelectedItem != null)
                {
                    Language selectedLanguage = (Language)cboIdiomas.SelectedValue;

                    SessionManager.Language = selectedLanguage;
                    UsuarioBLL usuarioBLL = new UsuarioBLL();
                    usuarioBLL.Update(SessionManager.GetUser());
                    EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.CambiarIdioma));
                    SetupLanguageComboBox();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void SetupLanguageComboBox()
        {
            cboIdiomas.DataSource = null;
            cboIdiomas.Items.Clear();

            cboIdiomas.DisplayMember = "Value"; // Indicar que se mostrará el value del dictionary
            cboIdiomas.ValueMember = "Key"; // Indicar que el valor seleccionado será la key del dictionary (enum Language)

            var languageDictionary = new Dictionary<Language, string>();

            // Agregar las traducciones al diccionario temporal
            foreach (Language languageEnum in Enum.GetValues(typeof(Language)))
            {
                string key = languageEnum.ToString(); // Clave del enum (e.g., "es", "en")
                string value = Translation[key];      // Valor traducido desde el diccionario (e.g., "Spanish", "English")

                languageDictionary.Add(languageEnum, value);
            }

            cboIdiomas.DataSource = new BindingSource(languageDictionary, null);

            cboIdiomas.SelectedValue = SessionManager.Language;
        }

        private void FrmCambiarIdioma_Load(object sender, EventArgs e)
        {

        }
    }
}
