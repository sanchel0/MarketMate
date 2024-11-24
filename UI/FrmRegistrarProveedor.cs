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
    public partial class FrmRegistrarProveedor : BaseFormObserver
    {
        private ProveedorBE prov = null;
        ProveedorBLL proveedorBLL;

        public FrmRegistrarProveedor(ProveedorBE pProveedor)
        {
            InitializeComponent();
            if (pProveedor == null)
                ControlHelper.DisableControls(lblDir, lblBanco, lblCbu);
            else
            {
                FillTextBoxes(pProveedor);
                prov = pProveedor;
            }
            proveedorBLL = new ProveedorBLL();

        }

        private void FrmRegistrarProveedor_Load(object sender, EventArgs e)
        {
            if (prov == null)
                lblProcessType.Text = SessionManager.Language == Language.es ? "Registro Inicial de Proveedor" : "Initial Supplier Registration";
            else
            {
                lblProcessType.Text = SessionManager.Language == Language.es ? "Completar Registro de Proveedor" : "Complete Supplier Registration";
                cboTipoCuenta.DataSource = Enum.GetValues(typeof(TipoCuenta));

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (prov != null)
                {
                    proveedorBLL.CompleteRegistration(prov, txtDir.Text, txtBanco.Text, (TipoCuenta)cboTipoCuenta.SelectedItem, txtNumCuenta.Text, txtAlias.Text, txtCbu.Text);
                }
                else
                {
                    prov = new ProveedorBE(
                        txtCuit.Text,
                        txtNombre.Text,
                        txtRazon.Text,
                        int.Parse(txtTel.Text),
                        txtCorreo.Text
                        );
                    proveedorBLL.Insert(prov);
                }
                MessageBox.Show(GetTranslation(SuccessType.OperationSuccess));
                Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillTextBoxes(ProveedorBE p)
        {
            txtCuit.Text = p.CUIT.ToString();
            txtNombre.Text = p.Nombre;
            txtRazon.Text = p.RazonSocial;
            txtTel.Text = p.Telefono.ToString();
            txtCorreo.Text = p.Correo;
        }
    }
}
