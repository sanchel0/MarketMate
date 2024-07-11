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
    public partial class FrmTickets : Form
    {
        TicketBLL ticketBLL;
        List<TicketBE> list = null;
        public FrmTickets()
        {
            InitializeComponent();
            ticketBLL = new TicketBLL();
            list = ticketBLL.GetAll();
            ControlHelper.UpdateGrid(dgvTickets, list, "NumeroTarjeta");
        }

        private void FrmTickets_Load(object sender, EventArgs e)
        {

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if(dgvTickets.SelectedRows.Count > 0)
            {
                TicketBE ticketBE = (TicketBE)dgvTickets.SelectedRows[0].DataBoundItem;

                string filePath = "ticket.pdf";
                PDFGenerator pdfGenerator = new PDFGenerator();
                pdfGenerator.GenerateTicketPDF(ticketBE, filePath);
            }
        }
    }
}
