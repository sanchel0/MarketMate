using iTextSharp.text.pdf;
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
    [DesignerCategory("Form")]
    public partial class FrmAyuda : BaseFormObserver
    {
        private string formName;
        public FrmAyuda(string form)
        {
            InitializeComponent();
            formName = form;
        }

        private void FrmAyuda_Load(object sender, EventArgs e)
        {
            string pathFolder = Path.Combine(Application.StartupPath, "Forms");

            string rutaImagen = Path.Combine(Path.Combine(pathFolder, $"{formName}.png"));

            if (File.Exists(rutaImagen))
            {
                pictureBox1.Image = Image.FromFile(rutaImagen);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
