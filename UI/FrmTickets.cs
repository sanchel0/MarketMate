using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    [DesignerCategory("Form")]
    public partial class FrmTickets : BaseFormObserver
    {
        TicketBLL ticketBLL;
        List<TicketBE> list = null;
        public FrmTickets()
        {
            try
            {
                InitializeComponent();
                ticketBLL = new TicketBLL();
                try
                {
                    list = ticketBLL.GetAll();
                }
                catch (DatabaseException ex)
                {
                    string errorMessage = GetTranslation(ex.ErrorType);
                    MessageBox.Show(errorMessage);
                    MessageBox.Show(ex.Message);
                }
                TranslateEntityList(list, Translation);
                ControlHelper.UpdateGrid(dgvTickets, list, "NumeroTarjeta");
            }
            catch (ValidationException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
        }

        private void FrmTickets_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                List<TicketBE> items = ObtenerTicketsSeleccionadosDesdeGrilla(dgvTickets);
                TranslationService.SetTranslations(this.Translation);
                ticketBLL.GenerarReporteDeTickets(items);

                MessageBox.Show(GetTranslation(SuccessType.OperationSuccess));
            }
            catch (ValidationException ex)
            {
                string errorMessage = GetTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
                MessageBox.Show(ex.Message);
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

        public List<TicketBE> ObtenerTicketsSeleccionadosDesdeGrilla(DataGridView grilla)
        {
            List<TicketBE> items = new List<TicketBE>();

            if (grilla.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow fila in grilla.SelectedRows)
                {
                    items.Add((TicketBE)fila.DataBoundItem);
                }
            }
            else
            {
                if (grilla.Rows.Count == 1)
                {
                    items.Add((TicketBE)grilla.Rows[0].DataBoundItem);
                }
                else if (grilla.Rows.Count > 1)
                {
                    foreach (DataGridViewRow fila in grilla.Rows)
                    {
                        items.Add((TicketBE)fila.DataBoundItem);
                    }
                }
            }

            return items;
        }
    }
}
