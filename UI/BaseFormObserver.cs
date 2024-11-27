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

        protected Dictionary<string, string> Translation
        {
            get
            {
                return _languageSubject.GetTranslations(this.Name); // Cargar traducciones directamente en un diccionario plano
            }
        }

        public string GetTranslation(string key)
        {
            if (Translation.TryGetValue(key, out var value))
            {
                return value;
            }

            return key;
        }

        public string GetTranslation(Enum enumValue)
        {
            /*string key = enumValue.ToString();

            if (Translation.TryGetValue(key, out var value))
            {
                return value;
            }

            return key;*/
            return _languageSubject.GetEnumTranslation(enumValue);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _languageSubject.Attach(this);
            var translation = Translation;
            if (translation != null)
                UpdateControlsLanguage(this, translation);
        }

        private void BaseFormObserver_FormClosed(object sender, FormClosedEventArgs e)
        {
            _languageSubject.Detach(this);
        }

        public virtual void UpdateLanguage(/*Dictionary<string, Translation> translations*/)
        {
            if (Translation != null)
                UpdateControlsLanguage(this, Translation);
        }

        protected void UpdateControlsLanguage(Control parent, Dictionary<string, string> controlsTranslations)
        {
            if (controlsTranslations.ContainsKey(FormName))
            {
                this.Text = controlsTranslations[FormName];
            }

            foreach (Control control in parent.Controls)
            {
                if (controlsTranslations.ContainsKey(control.Name))
                {
                    control.Text = controlsTranslations[control.Name];
                }

                if (control is MenuStrip menuStrip)
                {
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
                /*string controlType = control.GetType().Name;
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
                }*/
            }
        }

        private void UpdateMenuStripItems(ToolStripItemCollection items, Dictionary<string, string> controlsTranslations)
        {
            foreach (ToolStripMenuItem item in items)
            {
                if (controlsTranslations.ContainsKey(item.Name))
                {
                    item.Text = controlsTranslations[item.Name]; // Traducir cada item de menú
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

        private void TranslateGridHeaders(DataGridView dgv, Dictionary<string, string> controlsTranslations)
        {
            foreach (DataGridViewColumn column in dgv.Columns)
            {
                if (controlsTranslations.ContainsKey(column.Name))
                {
                    column.HeaderText = controlsTranslations[column.Name]; // Traducir los encabezados de las columnas
                }
            }
        }

        protected void TranslateEntityList<T>(List<T> entities, Dictionary<string, string> controlsTranslations)
        {
            foreach (var entity in entities)
            {
                TranslateEntity(entity, controlsTranslations);
            }
        }

        private void TranslateEntity<T>(T entity, Dictionary<string, string> entitiesTranslations)
        {
            var entityType = typeof(T);
            var entityProperties = entityType.GetProperties();

            foreach (var prop in entityProperties)
            {
                object originalValue = prop.GetValue(entity);
                string propertyKey = prop.Name;

                /*if (entitiesTranslations.ContainsKey(propertyKey))
                {
                    prop.SetValue(entity, entitiesTranslations[propertyKey]);
                }
                else*/
                if (originalValue != null && entitiesTranslations.TryGetValue(originalValue.ToString(), out string translatedValue))
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        prop.SetValue(entity, translatedValue);
                    }
                }
                if (IsListType(prop.PropertyType))
                {
                    TranslateListProperty((IEnumerable<object>)originalValue, entitiesTranslations);
                }
                else if (prop.PropertyType.IsEnum)
                {
                    if (originalValue != null)
                    {
                        string originalValueStr = originalValue.ToString();

                        // Buscar en el diccionario el valor traducido
                        if (entitiesTranslations.TryGetValue(originalValueStr, out string translatedEnumValue))
                        {
                            // Buscar el valor del enum correspondiente al traducido
                            foreach (var enumValue in Enum.GetValues(prop.PropertyType))
                            {
                                if (enumValue.ToString() == translatedEnumValue)
                                {
                                    prop.SetValue(entity, enumValue);
                                    break;
                                }
                            }
                        }
                    }
                }
                else if (IsComplexType(prop.PropertyType))
                {
                    TranslateComplexProperty(originalValue, entitiesTranslations);
                }
                
            }
        }

        private void TranslateComplexProperty(object complexEntity, Dictionary<string, string> entitiesTranslations)
        {
            if (complexEntity == null)
                return;

            var complexType = complexEntity.GetType();
            var complexProperties = complexType.GetProperties();

            foreach (var prop in complexProperties)
            {
                string propertyKey = prop.Name;
                object originalValue = prop.GetValue(complexEntity);

                if (originalValue != null && entitiesTranslations.ContainsKey(originalValue.ToString()))
                {
                    if (IsComplexType(prop.PropertyType))
                    {
                        TranslateComplexProperty(originalValue, entitiesTranslations);
                    }
                    else if (IsListType(prop.PropertyType))
                    {
                        TranslateListProperty((IEnumerable<object>)originalValue, entitiesTranslations);
                    }
                    else
                    {
                        string translatedValue = entitiesTranslations[originalValue.ToString()];
                        prop.SetValue(complexEntity, translatedValue);
                    }
                }
            }
        }

        private void TranslateListProperty(IEnumerable<object> list, Dictionary<string, string> entitiesTranslations)
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

                /*protected void TextBox_LettersOnly(object sender, KeyPressEventArgs e)
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
                }*/

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

        /*private void HandleValidationException(ValidationException ex)
        {
            string errorMessage = this.Translation.GetEnumTranslation(ex.ErrorType);
            MessageBox.Show(errorMessage);
        }*/
    }
}
