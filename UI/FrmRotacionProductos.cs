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
    public partial class FrmRotacionProductos : BaseFormObserver
    {
        public FrmRotacionProductos()
        {
            InitializeComponent();
        }

        private void FrmRotacionProductos_Load(object sender, EventArgs e)
        {
            dgvProds.DataSource = new List<ProductoBE>();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            try
            {
                bool esMayor = rdoMayor.Checked;
                TranslationService.SetTranslations(this.Translation);
                List<ProductoBE> list = new ProductoBLL().GenerarReporteRotacion(dtpInicio.Value, dtpFin.Value, esMayor);
                TranslateEntityList(list, Translation);
                dgvProds.DataSource = list;
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
    }
}
