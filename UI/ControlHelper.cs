using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;

namespace UI
{
    public class ControlHelper
    {
        public static void UpdateGrid<T>(DataGridView dgv, List<T> list, params string[] hiddenColumns)
        {
            dgv.SuspendLayout();
            dgv.DataSource = null;
            dgv.DataSource = new List<T>(list);
            
            if (hiddenColumns != null && hiddenColumns.Length > 0)
            {
                foreach (string column in hiddenColumns)
                {
                    if (dgv.Columns[column] != null)
                    {
                        dgv.Columns[column].Visible = false;
                    }
                }
            }
            dgv.ResumeLayout();
            dgv.Refresh();
        }

        public static void LoadListBox<T>(ListBox listBox, List<T> list)
        {
            listBox.DataSource = new List<T>(list);
            listBox.DisplayMember = "Nombre";
        }

        public static void LoadComboBox<T>(ComboBox cbo, List<T> list)
        {
            cbo.DataSource = list;
            cbo.DisplayMember = "Nombre";
        }

        public static void FillComboBox<T>(ComboBox comboBox)
        {
            if (comboBox.Items.Count == 0)
            {
                var valoresEnum = Enum.GetValues(typeof(T)).Cast<T>();

                foreach (var valor in valoresEnum)
                {
                    comboBox.Items.Add(valor);
                }
            }
        }

        public static void ClearTextBoxes(Control container)
        {
            foreach (Control control in container.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear();
                }
            }
        }

        /*public static void ClearSelectionGrid(DataGridView dataGridView)
        {
            if (dataGridView != null)
            {
                dataGridView.ClearSelection();
            }
        }*/

        public static void EnableControls(params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.Enabled = true;
            }
        }

        public static void DisableControls(params Control[] controls)
        {
            foreach (var control in controls)
            {
                control.Enabled = false;
            }
        }

        public static void SetLabelMessage(Label lbl, string mensaje)
        {
            lbl.Text = mensaje;
        }

        public static void ValidateTextBoxLength(TextBox textBox, int expectedLength)
        {
            /*if (textBox.Text.Length != expectedLength)
            {
                throw new ArgumentException($"Por favor ingrese un número válido para {RemoveControlPrefix(textBox.Name)} ({expectedLength} digitos).");
            }*/
            if (textBox.Text.Length != expectedLength)
            {
                ValidationErrorType errorType = ValidationErrorType.IncorrectLength8Digits; // Valor por defecto

                switch (expectedLength)
                {
                    case 8:
                        errorType = ValidationErrorType.IncorrectLength8Digits;
                        break;
                    case 10:
                        errorType = ValidationErrorType.IncorrectLength10Digits;
                        break;
                    case 16:
                        errorType = ValidationErrorType.IncorrectLength16Digits;
                        break;
                }

                throw new ValidationException(errorType);
            }
        }

        public static void ValidateNumeric(params TextBox[] textboxes)
        {
            /*List<string> invalidControlsNames = new List<string>();

            foreach (var textbox in textboxes)
            {
                if (!int.TryParse(textbox.Text, out _))
                {
                    invalidControlsNames.Add(RemoveControlPrefix(textbox.Name));
                }
            }

            if (invalidControlsNames.Count > 0)
            {
                throw new ArgumentException($"Los campos {string.Join(", ", invalidControlsNames)} deben contener solo números.");
            }*/
            foreach (var textbox in textboxes)
            {
                if (!int.TryParse(textbox.Text, out _))
                {
                    throw new ValidationException(ValidationErrorType.OnlyNumbersAllowed);
                }
            }
        }

        public static void ValidateText(params TextBox[] textboxes)
        {
            foreach (var textbox in textboxes)
            {
                if (!string.IsNullOrEmpty(textbox.Text) && textbox.Text.Any(char.IsDigit))
                {
                    throw new ValidationException(ValidationErrorType.OnlyLettersAllowed);
                }
            }
        }

        public static void ValidateNotEmpty(params Control[] controls)
        {
            /*List<string> controlsNames = new List<string>();

            foreach (var control in controls)
            {
                if (control is TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        controlsNames.Add(RemoveControlPrefix(control.Name));
                    }
                }
                else if (control is ComboBox comboBox)
                {
                    if (comboBox.SelectedItem == null)
                    {
                        controlsNames.Add(RemoveControlPrefix(control.Name));
                    }
                }
            }

            if (controlsNames.Count > 0)
            {
                throw new ArgumentException($"Los campos {string.Join(", ", controlsNames)} no pueden estar vacíos.");
            }*/
            foreach (var control in controls)
            {
                if (control is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
                {
                    throw new ValidationException(ValidationErrorType.IncompleteFields);
                }
                else if (control is ComboBox comboBox && comboBox.SelectedItem == null)
                {
                    throw new ValidationException(ValidationErrorType.IncompleteFields);
                }
            }
        }

        private static string RemoveControlPrefix(string controlName)
        {
            if (string.IsNullOrEmpty(controlName))
            {
                return controlName;
            }

            // Recorrer cada caracter en el nombre del control
            for (int i = 0; i < controlName.Length; i++)
            {
                // Si se encuentra una letra mayúscula
                if (char.IsUpper(controlName[i]))
                {
                    // Devolver el substring desde la primera letra mayúscula encontrada
                    return controlName.Substring(i);
                }
            }
            return controlName;
        }

    }
}
