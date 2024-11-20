using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmAyuda : Form
    {
        private string formName;
        public FrmAyuda(string form)
        {
            InitializeComponent();
            formName = form;
        }

        private void FrmAyuda_Load(object sender, EventArgs e)
        {
            string carpetaImagenes = @"C:\Users\user\Desktop\Forms";

            string rutaImagen = Path.Combine(carpetaImagenes, $"{formName}.png");

            if (File.Exists(rutaImagen))
            {
                pictureBox1.Image = Image.FromFile(rutaImagen);
            }
        }
    }
}
