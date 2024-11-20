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
using Services;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmCobrarVenta : BaseFormObserver
    {
        TicketBLL _ticketBLL;
        TicketBE _ticketBE;
        public int? NumTrans { get; private set; }
        public MetodoPago MetodoPagoSeleccionado { get; private set; }
        public TipoTarjeta? TipoTarjetaSeleccionada { get; private set; }
        public long? NumTarjeta { get; private set; }
        public string AliasMP { get; private set; }
        public DateTime FechaTrans { get; private set; }
        public FrmCobrarVenta(TicketBE pTicketBE)
        {
            InitializeComponent();
            _ticketBLL = new TicketBLL();
            _ticketBE = pTicketBE;
        }

        private void FrmCobrarVenta_Load(object sender, EventArgs e)
        {
            txtNumTicket.Text = _ticketBE.NumeroTicket.ToString();
            txtCliente.Text = _ticketBE.Cliente.ToString();
            txtMonto.Text = _ticketBE.Monto.ToString();
            dtpFechaTransaccion.Value = DateTime.Today;

            ControlHelper.FillComboBox<MetodoPago>(cboMetodoPago);
            ControlHelper.FillComboBox<TipoTarjeta>(cboTipoTarjeta);

            ControlHelper.DisableControls(cboTipoTarjeta, btnConectar, dtpFechaTransaccion);
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cboMetodoPago.SelectedItem != null && (MetodoPago)cboMetodoPago.SelectedItem != MetodoPago.Efectivo)
                {
                    NumTrans = _ticketBLL.GetLastTransactionNumber();
                    txtNumTransaccion.Text = NumTrans.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (MetodoPagoSeleccionado)
                {
                    case MetodoPago.TarjetaCredito:
                    case MetodoPago.TarjetaDebito:
                        ControlHelper.ValidateNotEmpty(txtNumTarjeta, cboTipoTarjeta);
                        ControlHelper.ValidateTextBoxLength(txtNumTarjeta, 16);
                        break;

                    case MetodoPago.MercadoPago:
                        ControlHelper.ValidateNotEmpty(txtAlias);
                        break;

                    case MetodoPago.Efectivo:
                        break;
                }
                TipoTarjetaSeleccionada = (TipoTarjeta?)cboTipoTarjeta.SelectedItem;
                NumTarjeta = string.IsNullOrEmpty(txtNumTarjeta.Text) ? (long?)null : long.Parse(txtNumTarjeta.Text);
                AliasMP = txtAlias.Text;
                FechaTrans = dtpFechaTransaccion.Value;

                string mensaje = Translation.GetEnumTranslation(SuccessType.OperationSuccess);
                MessageBox.Show(mensaje);

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (ValidationException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (DatabaseException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cboMetodoPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetodoPagoSeleccionado = (MetodoPago)cboMetodoPago.SelectedItem;
            
            switch (MetodoPagoSeleccionado)
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
