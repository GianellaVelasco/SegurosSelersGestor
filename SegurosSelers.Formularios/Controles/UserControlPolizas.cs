using SegurosSelers.Entidades;
using SegurosSelers.Servicios;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SegurosSelers.Formularios.Controles
{
    public partial class UserControlPolizas : UserControl
    {
        private PolizaService _polizaService;

        public UserControlPolizas()
        {
            InitializeComponent();
            _polizaService = new PolizaService();
            ConfigureDataGridView();
            CargarPolizas();
        }

        private void ConfigureDataGridView()
        {
            dataGridViewPolizas.Dock = DockStyle.Fill;
            dataGridViewPolizas.AutoGenerateColumns = false;
            dataGridViewPolizas.AllowUserToAddRows = false;
            dataGridViewPolizas.AllowUserToDeleteRows = false;
            dataGridViewPolizas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewPolizas.ReadOnly = false;

            dataGridViewPolizas.Columns.Clear();

            // 1. Columna de IdPoliza (solo lectura)
            DataGridViewTextBoxColumn idPolizaColumn = new DataGridViewTextBoxColumn
            {
                Name = "IdPoliza",
                HeaderText = "NÚMERO",
                DataPropertyName = "IdPoliza",
                ReadOnly = true
            };
            dataGridViewPolizas.Columns.Add(idPolizaColumn);

            // 2. Columna de NombrePack (solo lectura)
            DataGridViewTextBoxColumn nombrePackColumn = new DataGridViewTextBoxColumn
            {
                Name = "NombrePack",
                HeaderText = "NOMBRE",
                DataPropertyName = "NombrePack",
                ReadOnly = true
            };
            dataGridViewPolizas.Columns.Add(nombrePackColumn);

            // 3. Columna personalizada para Estado (texto)
            DataGridViewTextBoxColumn estadoTextoColumn = new DataGridViewTextBoxColumn
            {
                Name = "EstadoTexto",
                HeaderText = "ESTADO",
                ReadOnly = true
            };
            dataGridViewPolizas.Columns.Add(estadoTextoColumn);

            // 4. Columna de botón para activar/desactivar
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
            {
                Name = "ActivarDesactivarPoliza",
                HeaderText = "ACCIÓN"
            };
            dataGridViewPolizas.Columns.Add(btnColumn);

            // Asignación de eventos
            dataGridViewPolizas.CellClick += DataGridViewPolizas_CellClick;
            dataGridViewPolizas.CellFormatting += DataGridViewPolizas_CellFormatting;
            dataGridViewPolizas.DataError += (s, e) => { e.ThrowException = false; };

            dataGridViewPolizas.RowHeadersVisible = false;
        }

        public void CargarPolizas()
        {
            try
            {
                List<Poliza> polizas = _polizaService.ObtenerPolizas();
                dataGridViewPolizas.DataSource = polizas;
                dataGridViewPolizas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de pólizas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewPolizas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewPolizas.Columns["ActivarDesactivarPoliza"].Index && e.RowIndex >= 0)
            {
                Poliza selectedPoliza = dataGridViewPolizas.Rows[e.RowIndex].DataBoundItem as Poliza;

                if (selectedPoliza != null)
                {
                    int idPoliza = selectedPoliza.IdPoliza;
                    bool estadoActual = selectedPoliza.Estado;

                    try
                    {
                        _polizaService.CambiarEstadoPoliza(idPoliza, !estadoActual);
                        CargarPolizas(); // Refresca los datos
                        MessageBox.Show($"Póliza {(estadoActual ? "desactivada" : "activada")} correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar el estado de la póliza: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DataGridViewPolizas_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Poliza poliza = dataGridViewPolizas.Rows[e.RowIndex].DataBoundItem as Poliza;

                if (poliza != null)
                {
                    if (dataGridViewPolizas.Columns[e.ColumnIndex].Name == "EstadoTexto")
                    {
                        e.Value = poliza.Estado ? "Activado" : "Desactivado";
                        e.CellStyle.ForeColor = poliza.Estado ? Color.Green : Color.Red;
                        e.FormattingApplied = true;
                    }
                    else if (dataGridViewPolizas.Columns[e.ColumnIndex].Name == "ActivarDesactivarPoliza")
                    {
                        e.Value = poliza.Estado ? "Desactivar" : "Activar";
                        e.CellStyle.BackColor = poliza.Estado ? Color.IndianRed : Color.LightGreen;
                        e.CellStyle.ForeColor = Color.White;
                        e.FormattingApplied = true;
                    }
                }
            }
        }
    }
}
