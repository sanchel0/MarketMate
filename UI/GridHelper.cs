using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public class GridHelper
    {
        public static void ActualizarGrilla<T>(DataGridView dgv, List<T> list, params string[] hiddenColumns)
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
    }
}
