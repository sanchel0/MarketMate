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
    [DesignerCategory("Form")]
    public partial class FrmOrdenes : BaseFormObserver
    {
        OrdenCompraBLL ordenBLL;
        public FrmOrdenes()
        {
            InitializeComponent();
            ordenBLL = new OrdenCompraBLL();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                List<OrdenCompraBE> ordenesSeleccionadas = ObtenerOrdenesSeleccionadasDesdeGrilla(dgvOrdenes);

                ordenBLL.GenerarReporteDeOrdenes(ordenesSeleccionadas);
                MessageBox.Show(GetTranslation(SuccessType.OperationSuccess));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmOrdenes_Load(object sender, EventArgs e)
        {
            try
            {
                List<OrdenCompraBE> list = ordenBLL.GetAll();
                TranslateEntityList(list, Translation);
                ControlHelper.UpdateGrid(dgvOrdenes, list);
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
