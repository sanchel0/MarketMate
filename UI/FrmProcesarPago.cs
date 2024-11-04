using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BE;
using BLL;

namespace UI
{
    public partial class FrmProcesarPago : Form
    {
        public int NumTransferencia { get; private set; }
        private OrdenCompraBE orden;
        public FrmProcesarPago(OrdenCompraBE ordenCompraBE)
        {
            InitializeComponent();
            orden = ordenCompraBE;
        }

        private void FrmProcesarPago_Load(object sender, EventArgs e)
        {
            txtNumOrden.Text = orden.NumeroOrden.ToString();
            txtBanco.Text = orden.Proveedor.Banco;
            txtMonto.Text = orden.Total.ToString();
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                //new OrdenCompraBLL().AsignarNumeroTransferencia(orden, Convert.ToInt32(txtNumTransac.Text));
                NumTransferencia = Convert.ToInt32(txtNumTransac.Text);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmProcesarPago_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }
    }
}
