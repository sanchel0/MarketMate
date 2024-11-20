using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UI
{
    public class CustomDataGridView : DataGridView
    {
        public CustomDataGridView()
        {
            this.BackgroundColor = SystemColors.ControlLight;
            this.BorderStyle = BorderStyle.None;
        }
    }
}
