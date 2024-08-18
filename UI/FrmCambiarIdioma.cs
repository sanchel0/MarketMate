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
            if (cboIdiomas.SelectedItem != null)
            {
                Language selectedLanguage = (Language)cboIdiomas.SelectedValue;

                SessionManager.Language = selectedLanguage;
                UsuarioBLL usuarioBLL = new UsuarioBLL();
                usuarioBLL.Update(SessionManager.GetUser());

                SetupLanguageComboBox();
            }
        }

        private void SetupLanguageComboBox()
        {
            cboIdiomas.DataSource = null;
            cboIdiomas.Items.Clear();

            cboIdiomas.DisplayMember = "Value"; // Indicar que se mostrará el value del dictionary
            cboIdiomas.ValueMember = "Key"; // Indicar que el valor seleccionado será la key del dictionary (enum Language)

            var languageTranslations = Translation.Enums["Language"];

            // Crear un diccionario temporal para almacenar el enum y su traducción
            var languageDictionary = new Dictionary<Language, string>();

            // Agregar cada traducción al diccionario temporal
            foreach (var languageEntry in languageTranslations)
            {
                // languageEntry.Key contiene el nombre del enum Language (como "es", "en")
                // languageEntry.Value contiene la traducción (como "Spanish", "English")

                Language languageEnum;
                Enum.TryParse(languageEntry.Key, out languageEnum);

                languageDictionary.Add(languageEnum, languageEntry.Value);
            }

            cboIdiomas.DataSource = new BindingSource(languageDictionary, null);

            cboIdiomas.SelectedValue = SessionManager.Language;
        }
    }
}
