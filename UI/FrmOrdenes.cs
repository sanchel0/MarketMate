using BE;
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

namespace UI
{
    public partial class FrmOrdenes : Form
    {
        OrdenCompraBLL ordenBLL;
        public FrmOrdenes()
        {
            InitializeComponent();
            ordenBLL = new OrdenCompraBLL();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            List<OrdenCompraBE> ordenesSeleccionadas = ObtenerOrdenesSeleccionadasDesdeGrilla(dgvOrdenes);

            ordenBLL.GenerarReporteDeOrdenes(ordenesSeleccionadas);

            MessageBox.Show("El reporte se ha generado correctamente.");
        }

        private void FrmOrdenes_Load(object sender, EventArgs e)
        {
            ControlHelper.UpdateGrid(dgvOrdenes, ordenBLL.GetAll());
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }

        public List<OrdenCompraBE> ObtenerOrdenesSeleccionadasDesdeGrilla(DataGridView grilla)
        {
            List<OrdenCompraBE> ordenesSeleccionadas = new List<OrdenCompraBE>();

            if (grilla.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow fila in grilla.SelectedRows)
                {
                    ordenesSeleccionadas.Add((OrdenCompraBE)fila.DataBoundItem);
                }
            }
            else
            {
                if (grilla.Rows.Count == 1)
                {
                    ordenesSeleccionadas.Add((OrdenCompraBE)grilla.Rows[0].DataBoundItem);
                }
                else if (grilla.Rows.Count > 1)
                {
                    foreach (DataGridViewRow fila in grilla.Rows)
                    {
                        ordenesSeleccionadas.Add((OrdenCompraBE)fila.DataBoundItem);
                    }
                }
            }

            return ordenesSeleccionadas;
        }
    }
}
