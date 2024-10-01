using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmLogout : BaseFormObserver
    {
        public FrmLogout()
        {
            InitializeComponent();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Usuario, Operacion.Logout));
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void FrmLogout_Load(object sender, EventArgs e)
        {

        }
    }
}
