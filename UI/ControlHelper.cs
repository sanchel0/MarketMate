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
    }
}
