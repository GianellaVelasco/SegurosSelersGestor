using SegurosSelers.Entidades;
using SegurosSelers.Servicios;
using System.Net;

namespace SegurosSelers.Formularios.Controles
{
    public partial class UserControlSiniestros : UserControl
    {
        private SiniestroService _siniestroService;
        private Image _viewImageIcon;

        // Lista de estados de siniestro: ACEPTADA, RECHAZADA, EN CURSO
        private List<string> _estadosSiniestro = new List<string>
        {
            "ACEPTADA",
            "RECHAZADA",
            "EN CURSO"
        };

        public UserControlSiniestros()
        {
            InitializeComponent();

            // Instancia el SiniestroService usando su constructor por defecto
            // que ahora se encarga de leer la cadena de conexión del App.config.
            _siniestroService = new SiniestroService();

            // Cargar el icono de "ver imagen"
            try
            {
                using (var wc = new WebClient())
                {
                    byte[] bytes = wc.DownloadData("https://i.imgur.com/8Q9W1b2.png"); // Icono de ojo
                    using (var ms = new System.IO.MemoryStream(bytes))
                    {
                        _viewImageIcon = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar el icono de ver imagen: {ex.Message}", "Error de Icono", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                _viewImageIcon = SystemIcons.Information.ToBitmap(); // Icono de fallback
            }

            InicializarDataGridView();
            CargarSiniestros(); // Carga los datos al iniciar el control

            // Suscribir eventos del DataGridView
            dataGridViewSiniestros.CellFormatting += dataGridViewSiniestros_CellFormatting;
            dataGridViewSiniestros.CellContentClick += dataGridViewSiniestros_CellContentClick;
            dataGridViewSiniestros.CellValueChanged += dataGridViewSiniestros_CellValueChanged;
            dataGridViewSiniestros.CurrentCellDirtyStateChanged += dataGridViewSiniestros_CurrentCellDirtyStateChanged;
            dataGridViewSiniestros.DataError += dataGridViewSiniestros_DataError; // Manejo de errores para el ComboBox
        }

        // Método para cargar los siniestros desde el servicio
        public void CargarSiniestros()
        {
            try
            {
                var siniestros = _siniestroService.ObtenerSiniestros();
                dataGridViewSiniestros.DataSource = null; // Limpiar DataSource antes de reasignar
                dataGridViewSiniestros.DataSource = siniestros;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los siniestros: {ex.Message}", "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InicializarDataGridView()
        {
            dataGridViewSiniestros.Dock = DockStyle.Fill;
            dataGridViewSiniestros.AutoGenerateColumns = false;
            dataGridViewSiniestros.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSiniestros.ReadOnly = false;
            dataGridViewSiniestros.AllowUserToAddRows = false;
            dataGridViewSiniestros.AllowUserToDeleteRows = false;

            dataGridViewSiniestros.Columns.Clear();

            // Definición de Columnas con AUTO-DIMENSIONAMIENTO REFINADO

            // NRO SOLICITUD - Ajuste por contenido, no expandible
            dataGridViewSiniestros.Columns.Add(new DataGridViewTextBoxColumn { Name = "IdSiniestro", HeaderText = "NRO", DataPropertyName = "IdSiniestro", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, ReadOnly = true });

            // APELLIDO Y NOMBRE CLIENTE - Ajuste por contenido, pero más flexible
            dataGridViewSiniestros.Columns.Add(new DataGridViewTextBoxColumn { Name = "ApellidoNombreCliente", HeaderText = "ASEGURADO", DataPropertyName = "ApellidoNombreCliente", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 150, ReadOnly = true }); // Más peso para que ocupe más espacio

            // TIPO DE VEHÍCULO - Ajuste por contenido
            dataGridViewSiniestros.Columns.Add(new DataGridViewTextBoxColumn { Name = "NombreTipoVehiculo", HeaderText = "VEHÍCULO", DataPropertyName = "NombreTipoVehiculo", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, ReadOnly = true });

            // FECHA DEL SINIESTRO - Ajuste por contenido, no expandible
            dataGridViewSiniestros.Columns.Add(new DataGridViewTextBoxColumn { Name = "FechaSiniestro", HeaderText = "FECHA", DataPropertyName = "FechaSiniestro", DefaultCellStyle = { Format = "yyyy-MM-dd" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, ReadOnly = true });

            // HORA DEL SINIESTRO - Ajuste por contenido, no expandible
            dataGridViewSiniestros.Columns.Add(new DataGridViewTextBoxColumn { Name = "HoraSiniestro", HeaderText = "HORA", DataPropertyName = "HoraSiniestro", DefaultCellStyle = { Format = "hh\\:mm\\:ss" }, AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells, ReadOnly = true });

            // Columna ComboBox para CAMBIAR ESTADO - Ajuste por contenido (texto más largo del combo)
            DataGridViewComboBoxColumn cambioEstadoColumn = new DataGridViewComboBoxColumn
            {
                Name = "CambiarEstado",
                HeaderText = "CAMBIAR ESTADO A",
                DataSource = _estadosSiniestro,
                DataPropertyName = "Estado", // Se enlaza a la propiedad 'Estado' del ViewModel
                FlatStyle = FlatStyle.Flat, // Este FlatStyle ya ayuda a que se vea más como un botón
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells // Ajuste por el texto del combo
            };
            dataGridViewSiniestros.Columns.Add(cambioEstadoColumn);

            // DESCRIPCIÓN - ¡Esta es la que debe tomar el espacio restante!
            dataGridViewSiniestros.Columns.Add(new DataGridViewTextBoxColumn { Name = "Descripcion", HeaderText = "DESCRIPCIÓN", DataPropertyName = "Descripcion", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, FillWeight = 200, ReadOnly = true }); // Mayor peso para que sea la principal en expandirse

            // Columna para la IMAGEN DEL SINIESTRO (ahora visible y con icono)
            // HeaderText cambiado a solo "IMAGEN"
            DataGridViewImageColumn viewImageColumnSiniestro = new DataGridViewImageColumn
            {
                Name = "VerImagenSiniestro",
                HeaderText = "IMAGEN", // Renombrado a "IMAGEN"
                ImageLayout = DataGridViewImageCellLayout.Zoom,
                Width = 80, // Ancho fijo, ajusta si es necesario
                ReadOnly = true // Esta columna solo muestra un icono para hacer clic
            };
            dataGridViewSiniestros.Columns.Add(viewImageColumnSiniestro);

            // Ajustar el modo de auto-dimensionamiento del DataGridView a nivel de control
            dataGridViewSiniestros.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Asegurar que las filas se ajusten a su contenido si hay descripciones largas
            dataGridViewSiniestros.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders);
            dataGridViewSiniestros.RowHeadersVisible = false;
        }

        private void dataGridViewSiniestros_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Formateo para la columna de imagen del siniestro
                if (dataGridViewSiniestros.Columns[e.ColumnIndex].Name == "VerImagenSiniestro")
                {
                    var siniestro = dataGridViewSiniestros.Rows[e.RowIndex].DataBoundItem as SiniestroViewModel;
                    if (siniestro != null && !string.IsNullOrEmpty(siniestro.ImagenUrlSiniestro))
                    {
                        e.Value = _viewImageIcon; // Mostrar el icono de ojo
                    }
                    else
                    {
                        e.Value = null; // No mostrar nada si no hay URL
                    }
                    e.FormattingApplied = true;
                }
                // Formateo para la columna ComboBox "CambiarEstado"
                else if (dataGridViewSiniestros.Columns[e.ColumnIndex].Name == "CambiarEstado")
                {
                    SiniestroViewModel siniestro = dataGridViewSiniestros.Rows[e.RowIndex].DataBoundItem as SiniestroViewModel;

                    if (siniestro != null)
                    {
                        switch (siniestro.Estado)
                        {
                            case "ACEPTADA":
                                e.CellStyle.BackColor = Color.ForestGreen;
                                e.CellStyle.ForeColor = Color.White;
                                break;
                            case "RECHAZADA":
                                e.CellStyle.BackColor = Color.Maroon;
                                e.CellStyle.ForeColor = Color.White;
                                break;
                            case "EN CURSO":
                                e.CellStyle.BackColor = Color.SteelBlue;
                                e.CellStyle.ForeColor = Color.White;
                                break;
                            default:
                                e.CellStyle.BackColor = Color.LightGray;
                                e.CellStyle.ForeColor = Color.Black;
                                break;
                        }
                        e.CellStyle.SelectionBackColor = e.CellStyle.BackColor;
                        e.CellStyle.SelectionForeColor = e.CellStyle.ForeColor;

                        e.FormattingApplied = true;
                    }
                }
            }
        }

        private void dataGridViewSiniestros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Manejo del clic para la columna de imagen del SINIESTRO
            if (dataGridViewSiniestros.Columns[e.ColumnIndex].Name == "VerImagenSiniestro" && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridViewSiniestros.Rows[e.RowIndex];
                SiniestroViewModel siniestro = row.DataBoundItem as SiniestroViewModel;

                if (siniestro != null && !string.IsNullOrEmpty(siniestro.ImagenUrlSiniestro))
                {
                    using (FormularioImagenPopUp popup = new FormularioImagenPopUp())
                    {
                        popup.CargarImagenDesdeUrl(siniestro.ImagenUrlSiniestro);
                        popup.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("No hay URL de imagen de siniestro disponible.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dataGridViewSiniestros_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewSiniestros.Columns[e.ColumnIndex].Name == "CambiarEstado" && e.RowIndex >= 0)
            {
                dataGridViewSiniestros.EndEdit();

                DataGridViewComboBoxCell cell = dataGridViewSiniestros.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                if (cell != null && cell.Value != null)
                {
                    string nuevoEstado = cell.Value.ToString();
                    SiniestroViewModel siniestro = dataGridViewSiniestros.Rows[e.RowIndex].DataBoundItem as SiniestroViewModel;

                    if (siniestro != null)
                    {
                        if (MessageBox.Show($"¿Está seguro de cambiar el estado del siniestro {siniestro.IdSiniestro} a '{nuevoEstado}'?", "Confirmar Cambio de Estado", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                bool exito = _siniestroService.ModificarEstadoSiniestro(siniestro.IdSiniestro, nuevoEstado);

                                if (exito)
                                {
                                    MessageBox.Show($"Estado del siniestro {siniestro.IdSiniestro} actualizado a '{nuevoEstado}'.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    siniestro.Estado = nuevoEstado;
                                    dataGridViewSiniestros.InvalidateRow(e.RowIndex);
                                }
                                else
                                {
                                    MessageBox.Show($"No se pudo actualizar el estado del siniestro {siniestro.IdSiniestro}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    CargarSiniestros();
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show($"Error al actualizar el estado: {ex.Message}", "Error de Actualización", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                CargarSiniestros();
                            }
                        }
                        else
                        {
                            CargarSiniestros();
                        }
                    }
                }
            }
        }

        private void dataGridViewSiniestros_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (dataGridViewSiniestros.IsCurrentCellDirty)
            {
                dataGridViewSiniestros.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void dataGridViewSiniestros_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dataGridViewSiniestros.Columns[e.ColumnIndex].Name == "CambiarEstado")
            {
                System.Diagnostics.Debug.WriteLine($"DataError en columna 'CambiarEstado' (Fila {e.RowIndex}, Columna {e.ColumnIndex}): {e.Exception.Message}");
                var valueProblem = dataGridViewSiniestros.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                System.Diagnostics.Debug.WriteLine($"Valor en la celda que causó el error: {valueProblem}");
                var siniestroProblematico = dataGridViewSiniestros.Rows[e.RowIndex].DataBoundItem as SiniestroViewModel;
                if (siniestroProblematico != null)
                {
                    System.Diagnostics.Debug.WriteLine($"Estado del ViewModel asociado a la fila: {siniestroProblematico.Estado}");
                }
                e.ThrowException = false;
            }
            else
            {
                e.ThrowException = false;
                System.Diagnostics.Debug.WriteLine($"Otro DataError no manejado en DataGridView: {e.Exception.Message}");
            }
        }
    }
}