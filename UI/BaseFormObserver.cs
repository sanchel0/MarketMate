using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace UI
{
    [System.ComponentModel.DesignerCategory("")]
    public class BaseFormObserver : Form, ILanguageObserver
    {
        protected LanguageSubject _languageSubject;

        public BaseFormObserver()
        {
            _languageSubject = LanguageSubject.Instance;
            this.FormClosed += BaseFormObserver_FormClosed;
        }

        public string FormName
        {
            get { return this.Name; }
        }

        protected Translation Translation
        {
            get
            {
                return _languageSubject.GetTranslations(this.Name);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _languageSubject.Attach(this);
            var translation = Translation;
            if (translation.Controls != null)
                UpdateControlsLanguage(this, translation.Controls);
        }

        private void BaseFormObserver_FormClosed(object sender, FormClosedEventArgs e)
        {
            _languageSubject.Detach(this);
        }

        public virtual void UpdateLanguage(/*Dictionary<string, Translation> translations*/)
        {
            /*if (translations.ContainsKey(this.Name))
            {
                UpdateControlsLanguage(this, translations[this.Name].Controls);//Es posibel q no haga falta esto, ya que no es un Dictionary<string, Translation> translations, sino un Translation, por lo q no hace falta pasar el formname
            }*/
            UpdateControlsLanguage(this, Translation.Controls);
        }

        protected void UpdateControlsLanguage(Control parent, Dictionary<string, Dictionary<string, string>> controlsTranslations)
        {
            if (controlsTranslations.ContainsKey("Form") && controlsTranslations["Form"].ContainsKey(FormName))
            {
                this.Text = controlsTranslations["Form"][FormName];
            }

            foreach (Control control in parent.Controls)
            {
                string controlType = control.GetType().Name;
                if (controlsTranslations.ContainsKey(controlType) && controlsTranslations[controlType].ContainsKey(control.Name))
                {
                    control.Text = controlsTranslations[controlType][control.Name];
                }
                if (controlType == "MenuStrip")
                {
                    MenuStrip menuStrip = control as MenuStrip;
                    UpdateMenuStripItems(menuStrip.Items, controlsTranslations);
                }
                if (control is DataGridView dataGridView)
                {
                    TranslateGridHeaders(dataGridView, controlsTranslations);
                }

                if (control.HasChildren)
                {
                    UpdateControlsLanguage(control, controlsTranslations);
                }
            }
        }

        private void UpdateMenuStripItems(ToolStripItemCollection items, Dictionary<string, Dictionary<string, string>> controlsTranslations)
        {
            foreach (ToolStripMenuItem item in items)
            {
                if (controlsTranslations.ContainsKey("MenuStrip") && controlsTranslations["MenuStrip"].ContainsKey(item.Name))
                {
                    item.Text = controlsTranslations["MenuStrip"][item.Name];
                }

                if (item.HasDropDownItems)
                {
                    UpdateMenuStripItems(item.DropDownItems, controlsTranslations);
                }
            }
        }

        /*protected virtual void TranslateGrid(DataGridView dataGridView)
        {
            //translation = LanguageSubject.Instance.GetTranslations(this.Name);
        }*/
        //Este sería útil si es que no se tiene como propiedad un tipo de clase

        private void TranslateGridHeaders(DataGridView dgv, Dictionary<string, Dictionary<string, string>> controlsTranslations)
        {
            if (controlsTranslations.TryGetValue(dgv.Name, out var dgvTranslations))
            {

                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    if (dgvTranslations.ContainsKey(column.HeaderText))// or column.Name
                    {
                        string translatedHeader = dgvTranslations[column.HeaderText];
                        column.HeaderText = translatedHeader;
                    }
                }
            }
        }

        protected void TranslateEntityList<T>(List<T> entities, Dictionary<string, Dictionary<string, Dictionary<string, string>>> entitiesTranslations)
        {
            foreach (var entity in entities)
            {
                TranslateEntity(entity, entitiesTranslations);
            }
        }

        private void TranslateEntity<T>(T entity, Dictionary<string, Dictionary<string, Dictionary<string, string>>> entitiesTranslations)
        {
            var entityType = typeof(T);
            var entityProperties = entityType.GetProperties();

            foreach (var prop in entityProperties)
            {
                object originalValue = prop.GetValue(entity);
                if (entitiesTranslations.TryGetValue(entityType.Name, out var entityTranslations) && entityTranslations.TryGetValue(prop.Name, out var fieldTranslations))
                {
                    if (originalValue != null && fieldTranslations.TryGetValue(originalValue.ToString(), out var translatedValue))
                    {
                        prop.SetValue(entity, translatedValue);
                    }

                }
                else if (IsListType(prop.PropertyType))
                {
                    TranslateListProperty((IEnumerable<object>)originalValue, entitiesTranslations);
                }
                if (IsComplexType(prop.PropertyType))
                {
                    TranslateComplexProperty(originalValue, entitiesTranslations);
                }
                
            }
        }

        private void TranslateComplexProperty(object complexEntity, Dictionary<string, Dictionary<string, Dictionary<string, string>>> entitiesTranslations)
        {
            if (complexEntity == null)
                return;

            var complexType = complexEntity.GetType();
            var complexProperties = complexType.GetProperties();

            foreach (var prop in complexProperties)
            {
                if (entitiesTranslations.TryGetValue(complexType.Name, out var complexEntityTranslations) && complexEntityTranslations.TryGetValue(prop.Name, out var fieldTranslations))
                {
                    object originalValue = prop.GetValue(complexEntity);

                    if (originalValue != null && fieldTranslations.TryGetValue(originalValue.ToString(), out var translatedValue))
                    {
                        prop.SetValue(complexEntity, translatedValue);
                    }
                    else if (IsListType(prop.PropertyType))
                    {
                        TranslateListProperty((IEnumerable<object>)originalValue, entitiesTranslations);
                    }
                    if (IsComplexType(prop.PropertyType))
                    {
                        TranslateComplexProperty(originalValue, entitiesTranslations);
                    }

                }
            }
        }

        private void TranslateListProperty(IEnumerable<object> list, Dictionary<string, Dictionary<string, Dictionary<string, string>>> entitiesTranslations)
        {
            foreach (var item in list)
            {
                TranslateEntity(item, entitiesTranslations);
            }
        }

        private bool IsComplexType(Type type)
        {
            return type.IsClass && type != typeof(string);
        }

        private bool IsListType(Type type)
        {
            return typeof(System.Collections.IEnumerable).IsAssignableFrom(type) && type != typeof(string);
        }

        /*protected virtual T TranslateToEnglish<T>(T entity)
        {
            // Implementación por defecto o abstracta si se prefiere
            return entity;
        }

        protected virtual T TranslateToSpanish<T>(T entity, T originalEntity) where T : class
        {
            // Implementación por defecto o abstracta si se prefiere
            return entity;
        }*/

        protected void TextBox_LettersOnly(object sender, KeyPressEventArgs e)
        {
            try
            {
                ValidateKeyPress(e, @"^[a-zA-Z]+$", ValidationErrorType.OnlyLettersAllowed);
            }
            catch (ValidationException ex)
            {
                HandleValidationException(ex);
            }
        }

        protected void TextBox_NumbersOnly(object sender, KeyPressEventArgs e)
        {
            try
            {
                ValidateKeyPress(e, @"^[0-9]+$", ValidationErrorType.OnlyNumbersAllowed);
            }
            catch (ValidationException ex)
            {
                HandleValidationException(ex);
            }
        }

        private void ValidateKeyPress(KeyPressEventArgs e, string pattern, ValidationErrorType errorType)
        {
            Regex regex = new Regex(pattern);

            bool isValid = regex.IsMatch(e.KeyChar.ToString());

            if (!isValid)
            {
                e.Handled = true;
                throw new ValidationException(errorType);
            }
        }

        private void HandleValidationException(ValidationException ex)
        {
            string errorMessage = this.Translation.GetEnumTranslation(ex.ErrorType);
            MessageBox.Show(errorMessage);
        }
    }
}
