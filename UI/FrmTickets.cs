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
            InitializeComponent();
            ticketBLL = new TicketBLL();
            try
            {
                list = ticketBLL.GetAll();
            }
            catch (DatabaseException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
                MessageBox.Show(errorMessage);
            }
            ControlHelper.UpdateGrid(dgvTickets, list, "NumeroTarjeta");
        }

        private void FrmTickets_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTickets.SelectedRows.Count > 0)
                {
                    TicketBE ticketBE = (TicketBE)dgvTickets.SelectedRows[0].DataBoundItem;

                    //string filePath = "ticket.pdf";
                    /*PDFGenerator pdfGenerator = new PDFGenerator(Translation.PDF);
                    pdfGenerator.GenerateTicketPDF(ticketBE, filePath);*/
                    EventoBLL.Insert(new Evento(SessionManager.GetUser(), Modulo.Reportes, Operacion.GenerarReporte1));
                }
                else
                {
                    throw new ValidationException(ValidationErrorType.NoSelection);
                }
            }
            catch (ValidationException ex)
            {
                string errorMessage = Translation.GetEnumTranslation(ex.ErrorType);
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
    }
}
