using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            _languageSubject.Attach(this);
            var translations = _languageSubject.GetTranslations(this.Name);
            UpdateControlsLanguage(this, translations.Controls);
        }

        private void BaseFormObserver_FormClosed(object sender, FormClosedEventArgs e)
        {
            _languageSubject.Detach(this);
        }

        public virtual void UpdateLanguage(Dictionary<string, Translation> translations)
        {
            if (translations.ContainsKey(this.Name))
            {
                UpdateControlsLanguage(this, translations[this.Name].Controls);
            }
        }

        protected void UpdateControlsLanguage(Control parent, Dictionary<string, Dictionary<string, string>> controlsTranslations)
        {
            foreach (Control control in parent.Controls)
            {
                string controlType = control.GetType().Name;
                if (controlsTranslations.ContainsKey(controlType) && controlsTranslations[controlType].ContainsKey(control.Name))
                {
                    control.Text = controlsTranslations[controlType][control.Name];
                }

                if (control is DataGridView dataGridView)
                {
                    TranslateGrid(dataGridView);
                }

                if (control.HasChildren)
                {
                    UpdateControlsLanguage(control, controlsTranslations);
                }
            }
        }

        protected virtual void TranslateGrid(DataGridView dataGridView)
        {
            Translation translation = LanguageSubject.Instance.GetTranslations(this.Name);
        }

        protected void UpdateGridLanguage<T>(DataGridView dataGridView, Translation translation)
        {
            string entityName = typeof(T).Name;
            var entityTranslations = translation.Entities[entityName];

            foreach (DataGridViewColumn column in dataGridView.Columns)
            {
                if (entityTranslations["Headers"].ContainsKey(column.Name))
                {
                    string translatedHeader = entityTranslations["Headers"][column.Name];
                    column.HeaderText = translatedHeader;
                }
            }

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                T entity = (T)row.DataBoundItem;
                if (entity != null)
                {
                    foreach (var prop in typeof(T).GetProperties())
                    {
                        if (entityTranslations.ContainsKey(prop.Name))
                        {
                            var fieldTranslations = entityTranslations[prop.Name];
                            string originalValue = prop.GetValue(entity)?.ToString();
                            if (originalValue != null && fieldTranslations.ContainsKey(originalValue))
                            {
                                string translatedValue = fieldTranslations[originalValue];
                                row.Cells[prop.Name].Value = translatedValue;
                            }
                        }
                    }
                }
            }
        }
    }
}
