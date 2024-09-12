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
    public partial class FrmGenerarSolicitudCotizacion : Form
    {
        public FrmGenerarSolicitudCotizacion()
        {
            InitializeComponent();
        }

        private void FrmGenerarSolicitudCotizacion_Load(object sender, EventArgs e)
        {

        }

        private void btnSeleccionarProd_Click(object sender, EventArgs e)
        {

        }

        private void btnQuitarProd_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistroInicial_Click(object sender, EventArgs e)
        {
            FrmRegistrarProveedor f = new FrmRegistrarProveedor(null);
            f.Show();
        }

        private void btnProcesarPago_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
