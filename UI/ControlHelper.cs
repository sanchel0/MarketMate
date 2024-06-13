using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public class ControlHelper
    {
        public static void UpdateGrid<T>(DataGridView dgv, List<T> list, params string[] hiddenColumns)
        {
            dgv.DataSource = null;
            dgv.DataSource = list;

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

            dgv.Refresh();
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

        public static void ValidateTextBoxLength(TextBox textBox, int expectedLength)
        {
            if (textBox.Text.Length != expectedLength)
            {
                throw new ArgumentException($"Por favor ingrese un número válido para {RemoveControlPrefix(textBox.Name)} ({expectedLength} digitos).");
            }
        }

        public static void ValidateNumeric(params TextBox[] textboxes)
        {
            List<string> invalidControlsNames = new List<string>();

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
            }
        }

        public static void ValidateNotEmpty(params Control[] controls)
        {
            List<string> controlsNames = new List<string>();

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
