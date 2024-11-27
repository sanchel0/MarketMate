using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfiumViewer;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmAyuda : BaseFormObserver
    {
        private string formName;
        PdfiumViewer.PdfViewer pdf;
        public FrmAyuda(string form)
        {
            InitializeComponent();
            formName = form;
            pdf = new PdfViewer();
            this.Controls.Add(pdf);
            pdf.Dock = DockStyle.Fill;
        }

        private void FrmAyuda_Load(object sender, EventArgs e)
        {
            string languageFolder = SessionManager.Language == BE.Language.en ? "English" : "Spanish";

            string pathFolder = Path.Combine(Application.StartupPath, "HelpFiles", languageFolder);

            string pdfPath = Path.Combine(pathFolder, $"{formName}.pdf");

            if (File.Exists(pdfPath))
            {
                byte[] bytes =File.ReadAllBytes(pdfPath);
                var stream = new MemoryStream(bytes);
                PdfDocument pdfDocument = PdfDocument.Load(stream);
                pdf.Document = pdfDocument;
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
