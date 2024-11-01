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
    public partial class FrmAuditoriaCambios : Form
    {
        List<ProductoC> _cambios;
        ProductoCBLL _productoCBLL;
        DateTime startDate;
        DateTime endDate;

        public FrmAuditoriaCambios()
        {
            InitializeComponent();
            _cambios = new List<ProductoC>();
            _productoCBLL = new ProductoCBLL();
            dgvCambios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCambios.MultiSelect = false;
        }

        private void FrmAuditoriaCambios_Load(object sender, EventArgs e)
        {
            startDate = DateTime.Now.AddDays(-3);
            endDate = DateTime.Now;
            UpdateGrid(null, startDate, endDate, null);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            try
            {
                _productoCBLL.ValidarFechas(dtpInicio.Value, dtpFin.Value);
                UpdateGrid(Convert.ToInt32(txtCod.Text), dtpInicio.Value, dtpFin.Value, txtNombre.Text);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCambios.SelectedRows.Count > 0)
                {
                    ProductoC cambio = (ProductoC)dgvCambios.SelectedRows[0].DataBoundItem;
                    _productoCBLL.ActivarCambio(cambio);
                    UpdateGrid(null, startDate, endDate, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ControlHelper.ClearTextBoxes(this);

            dtpInicio.Value = DateTime.Now;
            dtpFin.Value = DateTime.Now;

            UpdateGrid(null, startDate, endDate, null);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void UpdateGrid(int? codProd, DateTime? fechaInicio, DateTime? fechaFin, string nombre)
        {
            _cambios = _productoCBLL.GetCambiosFiltrados(codProd, fechaInicio, fechaFin, nombre);
            ControlHelper.UpdateGrid(dgvCambios, _cambios, "ID");

            dgvCambios.Columns["Hora"].DefaultCellStyle.Format = "HH:mm:ss";
        }
    }
}
