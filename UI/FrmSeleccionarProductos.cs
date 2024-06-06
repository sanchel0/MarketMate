using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI;

namespace GUI
{
    public partial class FrmSeleccionarProductos : Form
    {
        ProductoBLL productoBLL = new ProductoBLL();

        public FrmSeleccionarProductos()
        {
            InitializeComponent();
            productoBLL = new ProductoBLL();
        }

        private void SeleccionarProductos_Load(object sender, EventArgs e)
        {
            ControlHelper.UpdateGrid(dgvProductos, productoBLL.GetAll());
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {

        }

        private void btnQuitar_Click(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {

        }
    }
}
