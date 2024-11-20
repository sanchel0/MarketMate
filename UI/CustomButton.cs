using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace UI
{
    public class CustomButton : Button
    {
        public CustomButton()
        {
            this.BackColor = Color.FromArgb(59, 176, 169);
            this.ForeColor = SystemColors.ButtonHighlight;
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 1;
        }
    }
}
