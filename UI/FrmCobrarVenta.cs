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
using UI;

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
            txtNumTicket.Text = ticketBE.NumeroTicket.ToString();
            txtCliente.Text = ticketBE.Cliente.ToString();
            txtMonto.Text = ticketBE.Monto.ToString();
            dtpFechaTransaccion.Value = DateTime.Today;

            ControlHelper.FillComboBox<MetodoPago>(cboMetodoPago);
            ControlHelper.FillComboBox<TipoTarjeta>(cboTipoTarjeta);

            ControlHelper.DisableControls(cboTipoTarjeta, btnConectar, dtpFechaTransaccion);
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
            if(cboMetodoPago.SelectedItem != null && (MetodoPago)cboMetodoPago.SelectedItem != MetodoPago.Efectivo)
            {
                int numTransaccion = ticketBLL.GetLastTransactionNumber();
                txtNumTransaccion.Text = numTransaccion.ToString();
            }
        }

        private void cboMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetodoPago metodoPagoSeleccionado = (MetodoPago)cboMetodoPago.SelectedItem;
            
            switch (metodoPagoSeleccionado)
            {
                case MetodoPago.TarjetaCredito:
                case MetodoPago.TarjetaDebito:
                    ControlHelper.EnableControls(txtNumTarjeta, cboTipoTarjeta, btnConectar);
                    ControlHelper.DisableControls(txtAlias);
                    break;
                case MetodoPago.MercadoPago:
                    ControlHelper.EnableControls(txtAlias, btnConectar);
                    ControlHelper.DisableControls(txtNumTarjeta, cboTipoTarjeta);
                    break;
                case MetodoPago.Efectivo:
                    ControlHelper.DisableControls(txtNumTarjeta, txtAlias, cboTipoTarjeta, btnConectar);
                    break;
            }
        }
    }
}
