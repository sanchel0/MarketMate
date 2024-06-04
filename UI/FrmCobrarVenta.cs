using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using BE;

namespace GUI
{
    public partial class FrmCobrarVenta : Form
    {
        TicketBLL ticketBLL;
        TicketBE ticketBE;
        public FrmCobrarVenta(TicketBE pTicketBE)
        {
            InitializeComponent();
            ticketBLL = new TicketBLL();
            ticketBE = pTicketBE;
        }

        private void FrmCobrarVenta_Load(object sender, EventArgs e)
        {

        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                if(int.TryParse(txtNumTransaccion.Text, out int numTransaccion) && int.TryParse(txtNumTarjeta.Text, out int numTarjeta) && (txtNumTarjeta.Text.Length == 16) && cboMetodoPago.SelectedItem != null)
                {
                    ticketBLL.AsignarDatosPago(ticketBE, numTransaccion, (MetodoPago)cboMetodoPago.SelectedItem, (TipoTarjeta?)cboTipoTarjeta.SelectedItem, numTarjeta, txtAlias.Text, dtpFechaTransaccion.Value);
                }
                else
                {
                    throw new Exception("Datos no válidos o faltantes en el formulario.");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {

        }
    }
}
