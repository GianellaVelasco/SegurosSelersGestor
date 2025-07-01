using SegurosSelers.Entidades;
using SegurosSelers.Servicios;
using System;
using System.Collections.Generic;
using System.Configuration; // Necesario para ConfigurationManager
using System.Drawing;
using System.Windows.Forms;

namespace SegurosSelers.Formularios.Controles
{
    public partial class UserControlContratados : UserControl
    {
        private ContratadoService _contratadoService;

        public UserControlContratados()
        {
            InitializeComponent();
            _contratadoService = new ContratadoService(); // Usa el constructor por defecto

            InicializarDataGridView();
            // CargarContratados() se llamará desde FormularioHome o cuando sea necesario
        }

        private void InicializarDataGridView()
        {
            dataGridViewContratados.Dock = DockStyle.Fill;
            dataGridViewContratados.AutoGenerateColumns = false;
            dataGridViewContratados.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewContratados.ReadOnly = false; // Permitir edición si quieres un botón/combo para desactivar
            dataGridViewContratados.AllowUserToAddRows = false;
            dataGridViewContratados.AllowUserToDeleteRows = false;

            dataGridViewContratados.Columns.Clear();

            // Definición de Columnas
            dataGridViewContratados.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdSegCont", HeaderText = "CONTRATO N°", DataPropertyName = "IdSegCont", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, ReadOnly = true });
            dataGridViewContratados.Columns.Add(new DataGridViewTextBoxColumn { Name = "ApellidoNombreCliente", HeaderText = "CLIENTE", DataPropertyName = "ApellidoNombreCliente", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 150, ReadOnly = true });
            dataGridViewContratados.Columns.Add(new DataGridViewTextBoxColumn { Name = "NombrePackPoliza", HeaderText = "PÓLIZA", DataPropertyName = "NombrePackPoliza", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 100, ReadOnly = true });
            dataGridViewContratados.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaContrato", HeaderText = "FECHA CONT.", DataPropertyName = "FechaContrato", DefaultCellStyle = { Format = "yyyy-MM-dd" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, ReadOnly = true });
            dataGridViewContratados.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaFin", HeaderText = "FECHA FIN", DataPropertyName = "FechaFin", DefaultCellStyle = { Format = "yyyy-MM-dd" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, ReadOnly = true });
            dataGridViewContratados.Columns.Add(new DataGridViewTextBoxColumn { Name = "Observaciones", HeaderText = "OBSERVACIONES", DataPropertyName = "Observaciones", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 200, ReadOnly = true });

            // Columna de estado de vigencia (personalizada)
            DataGridViewTextBoxColumn estadoVigenciaColumn = new DataGridViewTextBoxColumn
            {
                Name = "EstadoVigencia",
                HeaderText = "VIGENCIA",
                ReadOnly = true,
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridViewContratados.Columns.Add(estadoVigenciaColumn);

            // Columna de botón para desactivar
            DataGridViewButtonColumn btnDesactivarColumn = new DataGridViewButtonColumn
            {
                Name = "DesactivarCobertura",
                HeaderText = "ACCIÓN",
                UseColumnTextForButtonValue = false, // Lo estableceremos en CellFormatting
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };
            dataGridViewContratados.Columns.Add(btnDesactivarColumn);


            dataGridViewContratados.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewContratados.RowHeadersVisible = false;

            // Suscribir eventos
            dataGridViewContratados.CellFormatting += DataGridViewContratados_CellFormatting;
            dataGridViewContratados.CellContentClick += DataGridViewContratados_CellContentClick;
        }

        public void CargarContratados()
        {
            try
            {
                List<ContratadoViewModel> contratados = _contratadoService.ObtenerContratadosViewModel(); // Llama al nuevo método
                dataGridViewContratados.DataSource = null; // Limpiar DataSource antes de reasignar
                dataGridViewContratados.DataSource = contratados;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar las coberturas contratadas: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DataGridViewContratados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ContratadoViewModel contratado = dataGridViewContratados.Rows[e.RowIndex].DataBoundItem as ContratadoViewModel;

                if (contratado != null)
                {
                    // Formato para la columna de Vigencia
                    if (dataGridViewContratados.Columns[e.ColumnIndex].Name == "EstadoVigencia")
                    {
                        e.Value = contratado.EstaVigente ? "Activa" : "Finalizada";
                        e.CellStyle.ForeColor = contratado.EstaVigente ? Color.Green : Color.Red;
                        e.FormattingApplied = true;
                    }
                    // Formato para el botón de Desactivar
                    else if (dataGridViewContratados.Columns[e.ColumnIndex].Name == "DesactivarCobertura")
                    {
                        e.Value = contratado.EstaVigente ? "Desactivar" : "Finalizada";
                        e.CellStyle.BackColor = contratado.EstaVigente ? Color.IndianRed : Color.DarkGray; // Rojo para desactivar, gris para finalizada
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                        e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;
                        // Deshabilitar el botón visualmente si ya está finalizada
                        if (!contratado.EstaVigente)
                        {
                            e.CellStyle.ForeColor = Color.DimGray; // Texto más tenue
                            // No se puede deshabilitar el clic directamente aquí,
                            // se maneja en CellContentClick
                        }
                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void DataGridViewContratados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewContratados.Columns["DesactivarCobertura"].Index && e.RowIndex >= 0)
            {
                ContratadoViewModel selectedContratado = dataGridViewContratados.Rows[e.RowIndex].DataBoundItem as ContratadoViewModel;

                if (selectedContratado != null && selectedContratado.EstaVigente) // Solo si está vigente se puede desactivar
                {
                    if (MessageBox.Show($"¿Está seguro de desactivar la cobertura NRO {selectedContratado.IdSegCont}?", "Confirmar Desactivación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        try
                        {
                            bool exito = _contratadoService.DesactivarCobertura(selectedContratado.IdSegCont);

                            if (exito)
                            {
                                MessageBox.Show($"Cobertura NRO {selectedContratado.IdSegCont} desactivada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                CargarContratados(); // Recargar para reflejar el cambio en la UI
                            }
                            else
                            {
                                MessageBox.Show($"No se pudo desactivar la cobertura NRO {selectedContratado.IdSegCont}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error al desactivar la cobertura: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else if (selectedContratado != null && !selectedContratado.EstaVigente)
                {
                    MessageBox.Show("Esta cobertura ya está finalizada y no puede ser desactivada nuevamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}