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
using Services;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmProcesarPago : BaseFormObserver
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
            txtCBU.Text = orden.Proveedor.CBU;
        }

        private void btnRegistrarPago_Click(object sender, EventArgs e)
        {
            try
            {
                //new OrdenCompraBLL().AsignarNumeroTransferencia(orden, Convert.ToInt32(txtNumTransac.Text));
                NumTransferencia = Convert.ToInt32(txtNumTransac.Text);
                DialogResult = DialogResult.OK;
            }
            catch (ValidationException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            catch (DatabaseException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
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
