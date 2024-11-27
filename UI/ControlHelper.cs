using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Services;
//using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UI
{
    public static class ControlHelper
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

        public static void UpdateGrid<T>(DataGridView dgv, BindingList<T> bindingList, params string[] hiddenColumns)
        {
            dgv.SuspendLayout();
            dgv.DataSource = null;
            dgv.DataSource = bindingList;

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

        public static void ClearGrid(DataGridView grid)
        {
            if (grid != null)
            {
                grid.DataSource = null;
                //grid.Rows.Clear();
            }
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

        public static void TextBox_LettersOnly(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z]+$");

            bool isValid = regex.IsMatch(e.KeyChar.ToString());

            if (!isValid)
            {
                e.Handled = true;
                throw new ValidationException(ValidationErrorType.OnlyLettersAllowed);
            }
        }

        public static void TextBox_NumbersOnly(object sender, KeyPressEventArgs e)
        {
            Regex regex = new Regex(@"^[0-9]+$");

            bool isValid = regex.IsMatch(e.KeyChar.ToString());

            if (!isValid)
            {
                e.Handled = true;
                throw new ValidationException(ValidationErrorType.OnlyNumbersAllowed);
            }
        }

        internal static void QuitarSeleccion<T>(DataGridView gridView, BindingList<T> lista)
        {
            TryGetSelectedRow(gridView, out T item);
            lista.Remove(item);
        }

        internal static void TryGetSelectedRow<T>(DataGridView gridView, out T selectedItem)
        {
            selectedItem = default;
            if (gridView.SelectedRows.Count > 0)
            {
                selectedItem = (T)gridView.SelectedRows[0].DataBoundItem;
                if (selectedItem == null)
                {
                    throw new ValidationException(ValidationErrorType.NullSelectedItem);
                }
            }
            else
            {
                throw new ValidationException(ValidationErrorType.NoSelection);
            }
        }

        internal static bool TryGetSelectedRowWithoutException<T>(DataGridView gridView, out T selectedItem)
        {
            selectedItem = default;
            if (gridView.SelectedRows.Count > 0)
            {
                selectedItem = (T)gridView.SelectedRows[0].DataBoundItem;
                return true;
            }
            return false;
        }

        public static void FormatDecimalKeyPress(object sender, KeyPressEventArgs e)
        {
            string senderText = (sender as TextBox).Text;
            int cursorPosition = (sender as TextBox).SelectionStart;
            string[] splitByDecimal = senderText.Split('.');

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                return;
            }

            if (e.KeyChar == '.' && senderText.Contains("."))
            {
                e.Handled = true;
                return;
            }

            if (!char.IsControl(e.KeyChar) && senderText.IndexOf('.') < cursorPosition
                && splitByDecimal.Length > 1 && splitByDecimal[1].Length == 2)
            {
                e.Handled = true;
            }
        }

        public static void FormatDecimalTextChanged(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            int cursorPosition = textBox.SelectionStart;
            string enteredText = textBox.Text;

            if (decimal.TryParse(enteredText, out _))
            {
                string[] splitByDecimal = enteredText.Split('.');
                if (splitByDecimal.Length > 1 && splitByDecimal[1].Length > 2)
                {
                    textBox.Text = enteredText.Remove(cursorPosition - 1, 1);
                    textBox.SelectionStart = cursorPosition - 1;
                }
            }
        }
        
        public static void FormatDecimalLeave(object sender, EventArgs e)
        {
            var textBox = sender as System.Windows.Forms.TextBox;

            if (string.IsNullOrEmpty(textBox.Text))
            {
                decimal num = 0;
                textBox.Text = num.ToString("F2", CultureInfo.InvariantCulture);
            }
            else if (decimal.TryParse(textBox.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal value))
            {
                textBox.Text = value.ToString("F2", CultureInfo.InvariantCulture);
            }
            else if (textBox.Text.EndsWith("."))
            {
                textBox.Text += "00";
            }
            else if ((textBox.Text.Contains(".")))
                textBox.Text += ".00";
        }
    }
}
