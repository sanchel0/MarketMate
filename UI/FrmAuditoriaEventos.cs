﻿using BE;
using BLL;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class FrmAuditoriaEventos : Form
    {
        EventoBLL _eventoBLL;
        List<Evento> _eventos;
        DateTime startDate;
        DateTime endDate;

        public FrmAuditoriaEventos()
        {
            InitializeComponent();
            _eventoBLL = new EventoBLL();
            _eventos = new List<Evento>();
            cboOperacion.TextChanged += (sender, e) => ComboBox_TextChanged<Operacion>(sender, e);
            cboModulo.TextChanged += (sender, e) => ComboBox_TextChanged<Modulo>(sender, e);
            dgvEventos.CellFormatting += dgvEventos_CellFormatting;
        }

        private void FrmBitacoraDeEventos_Load(object sender, EventArgs e)
        {
            startDate = DateTime.Now.AddDays(-3);
            endDate = DateTime.Now;
            UpdateGrid(null, startDate, endDate, null, null, null);

            cboOperacion.DataSource = Enum.GetValues(typeof(Operacion));

            cboModulo.DataSource = Enum.GetValues(typeof(Modulo));

            List<int> values = new List<int> { 1, 2, 3, 4, 5 };
            cboCriticidad.DataSource = values;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ControlHelper.ClearTextBoxes(this);
            UpdateGrid(null, startDate, endDate, null, null, null);
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if (dtpInicio.Value < dtpFin.Value)
            {
                UpdateGrid(txtUsername.Text, dtpInicio.Value, dtpFin.Value, cboModulo.SelectedItem.ToString(), cboOperacion.SelectedItem.ToString(), cboCriticidad.SelectedItem != null ? (int?)cboCriticidad.SelectedItem : null);
            }
            else
            {
                MessageBox.Show("Fecha de Inicio es mayor que la Fecha de Fin.");
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            var pdfGenerator = new PDFGenerator();

            List<Evento> eventos = dgvEventos.DataSource as List<Evento>;
            var eventReportPdfContent = new EventReportPdfContent(eventos);
            string defaultPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "EventReport.pdf");
            pdfGenerator.GeneratePDF(eventReportPdfContent, defaultPath);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ComboBox_TextChanged<T>(object sender, EventArgs e) where T : Enum
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox == null) return;

            string filtro = comboBox.Text;

            // Convertir valores enum a nombres para la búsqueda
            var listaCompletaEventos = Enum.GetValues(typeof(T)).Cast<T>().ToList();
            List<string> nombresEnum = listaCompletaEventos.Select(val => val.ToString()).ToList();

            // Restaurar la lista completa si el texto está vacío
            if (string.IsNullOrEmpty(filtro))
            {
                comboBox.DataSource = new List<string>(nombresEnum);
                if (comboBox.Items.Count > 0)
                {
                    comboBox.SelectedIndex = 0; // Selecciona el primer elemento si hay alguno
                }
            }
            else
            {
                // Filtrar la lista
                var eventosFiltrados = nombresEnum.Where(nombre => nombre.IndexOf(filtro, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

                comboBox.DataSource = eventosFiltrados;
                if (eventosFiltrados.Count > 0)
                {
                    comboBox.SelectedIndex = 0; // Selecciona el primer elemento de la lista filtrada
                }
            }
        }

        private void dgvEventos_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                var dataGridView = (DataGridView)sender;
                var columnName = dataGridView.Columns[e.ColumnIndex].Name;

                if (columnName == "Usuario")
                {
                    var cellValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                    if (cellValue != null && cellValue is UsuarioBE user)
                    {
                        e.Value = user.Username;
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void UpdateGrid(string username, DateTime? fechaInicio, DateTime? fechaFin, string modulo, string operacion, int? criticidad)
        {
            _eventos = _eventoBLL.GetEventosFiltrados(username, fechaInicio, fechaFin, modulo, operacion, criticidad);
            ControlHelper.UpdateGrid(dgvEventos, _eventos);

            dgvEventos.Columns["Hora"].DefaultCellStyle.Format = "HH:mm:ss";
        }

        private void dgvEventos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvEventos.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvEventos.SelectedRows[0];
                Evento evento = (Evento)selectedRow.DataBoundItem;

                txtNombre.Text = evento.Usuario.Nombre;
                txtApellido.Text = evento.Usuario.Apellido;
            }
        }
    }
}