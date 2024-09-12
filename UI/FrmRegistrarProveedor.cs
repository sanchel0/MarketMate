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

namespace UI
{
    public partial class FrmRegistrarProveedor : Form
    {
        public FrmRegistrarProveedor(ProveedorBE pProveedor)
        {
            InitializeComponent();
            if (pProveedor == null)
                ControlHelper.DisableControls(lblDir, lblBanco, lblCbu);
            else
                FillTextBoxes(pProveedor);
        }

        private void FrmRegistrarProveedor_Load(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

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
