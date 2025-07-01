using SegurosSelers.Entidades; // Necesitas tus clases de entidad como 'Usuario', 'Contratado', 'PagosPoliza', 'UsuarioPolizaViewModel'
using SegurosSelers.Servicios; // Necesitas tu lógica de negocio de servicios
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms; // Necesario para UserControl, DataGridView, etc.

namespace SegurosSelers.Formularios.Controles
{
    public partial class UserControlUsuarios : UserControl
    {
        private UsuarioService _usuarioService;
        private ContratadoService _contratadoService;
        private PagosPolizaService _pagosPolizaService;

        public UserControlUsuarios()
        {
            InitializeComponent(); // Este método es generado por el diseñador
            _usuarioService = new UsuarioService();
            _contratadoService = new ContratadoService();
            _pagosPolizaService = new PagosPolizaService();
            InitializeDataGridViewProperties(); // Configura el DataGridView
            CargarUsuariosConPolizas(); // Carga los datos al iniciar el control
            this.dataGridViewUsuarios.DataError += DataGridViewUsuarios_DataError;
        }
        private void DataGridViewUsuarios_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            // Puedes registrar el error, mostrar un mensaje personalizado, o simplemente ignorarlo.
            e.ThrowException = false; // No lanzar la excepción al usuario
                                      // La línea e.Handled = true; es la que causa el error y debe ser eliminada.
                                      // Opcional: Console.WriteLine($"Error de formato en DataGridView: {e.Exception.Message}");
        }


        private void InitializeDataGridViewProperties()
        {
            dataGridViewUsuarios.Dock = DockStyle.Fill;
            dataGridViewUsuarios.AutoGenerateColumns = false; // Importante para definir columnas manualmente
            dataGridViewUsuarios.AllowUserToAddRows = false;
            dataGridViewUsuarios.AllowUserToDeleteRows = false;
            dataGridViewUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewUsuarios.ReadOnly = false; // Para permitir la interacción con el botón

            // Limpia las columnas existentes para asegurar que se definan de nuevo
            dataGridViewUsuarios.Columns.Clear();

            // Definición de Columnas para el UsuarioPolizaViewModel
            // Columna de Nombre Completo
            DataGridViewTextBoxColumn nombreCompletoColumn = new DataGridViewTextBoxColumn();
            nombreCompletoColumn.Name = "NombreCompleto";
            nombreCompletoColumn.HeaderText = "USUARIO";
            nombreCompletoColumn.DataPropertyName = "NombreCompleto";
            nombreCompletoColumn.ReadOnly = true;
            dataGridViewUsuarios.Columns.Add(nombreCompletoColumn);

            // Columna de Póliza Contratada
            DataGridViewTextBoxColumn polizaContratadaColumn = new DataGridViewTextBoxColumn();
            polizaContratadaColumn.Name = "PolizaContratada";
            polizaContratadaColumn.HeaderText = "POLIZA CONTRATADA";
            polizaContratadaColumn.DataPropertyName = "NombrePoliza"; // Asume que el ViewModel tiene un campo para esto
            polizaContratadaColumn.ReadOnly = true;
            dataGridViewUsuarios.Columns.Add(polizaContratadaColumn);

            // Columna de Vencimiento
            DataGridViewTextBoxColumn vencimientoColumn = new DataGridViewTextBoxColumn();
            vencimientoColumn.Name = "Vencimiento";
            vencimientoColumn.HeaderText = "VENCIMIENTO";
            vencimientoColumn.DataPropertyName = "FechaVencimientoDisplay"; // <-- ¡Cambia aquí!
            vencimientoColumn.ReadOnly = true;
            dataGridViewUsuarios.Columns.Add(vencimientoColumn);


            // Columna oculta para el estado booleano real del usuario
            DataGridViewCheckBoxColumn estadoUsuarioColumn = new DataGridViewCheckBoxColumn();
            estadoUsuarioColumn.Name = "EstadoUsuarioRaw"; // Nombre para acceder al valor booleano
            estadoUsuarioColumn.DataPropertyName = "EstadoUsuario";
            estadoUsuarioColumn.Visible = false; // No se muestra directamente, se usa para el botón
            dataGridViewUsuarios.Columns.Add(estadoUsuarioColumn);

            // Columna para el estado de vencimiento (texto y estilo)
            DataGridViewTextBoxColumn estadoVencimientoTextoColumn = new DataGridViewTextBoxColumn();
            estadoVencimientoTextoColumn.Name = "EstadoVencimientoTexto";
            estadoVencimientoTextoColumn.HeaderText = "ESTADO PAGO";
            estadoVencimientoTextoColumn.DataPropertyName = "EstadoVencimientoTexto"; // Ligado al ViewModel
            estadoVencimientoTextoColumn.ReadOnly = true;
            dataGridViewUsuarios.Columns.Add(estadoVencimientoTextoColumn);

            // Columna del botón Activar/Desactivar
            DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn();
            btnColumn.Name = "ActivarDesactivar";
            btnColumn.HeaderText = "ACCIÓN";
            dataGridViewUsuarios.Columns.Add(btnColumn);

            // Asignación de Eventos
            dataGridViewUsuarios.CellClick += DataGridViewUsuarios_CellClick;
            dataGridViewUsuarios.CellFormatting += DataGridViewUsuarios_CellFormatting;

            dataGridViewUsuarios.RowHeadersVisible = false;
        }

        public void CargarUsuariosConPolizas()
        {
            try
            {
                List<Usuario> usuarios = _usuarioService.ObtenerUsuarios();
                List<Contratado> contratos = _contratadoService.ObtenerContratos();
                List<PagosPoliza> pagos = _pagosPolizaService.ObtenerPagos();

                List<UsuarioPolizaViewModel> data = new List<UsuarioPolizaViewModel>();

                foreach (Usuario usuario in usuarios)
                {
                    // Buscar contratos asociados a este usuario
                    List<Contratado> contratosUsuario = contratos.Where(c => c.IdUsuario == usuario.IdUsuario).ToList();

                    if (contratosUsuario.Any())
                    {
                        foreach (Contratado contrato in contratosUsuario)
                        {
                            // Buscar el último pago de póliza para este contrato (o el que corresponda a la lógica de "vencimiento")
                            // Aquí la lógica asume que PagosPoliza tiene la fecha de vencimiento de la póliza contratada.
                            // Si 'PagosPoliza' es para pagos individuales, podrías necesitar otra lógica para el vencimiento de la póliza general.
                            // Por ahora, buscará el pago asociado a la póliza del contrato.
                            PagosPoliza ultimoPago = pagos.FirstOrDefault(p => p.IdPoliza == contrato.IdPoliza && p.IdUsuario == usuario.IdUsuario);

                            UsuarioPolizaViewModel vm = new UsuarioPolizaViewModel
                            {
                                IdUsuario = usuario.IdUsuario,
                                NombreCompleto = $"{usuario.Nombre} {usuario.Apellido}\n{usuario.Correo}",
                                Correo = usuario.Correo,
                                EstadoUsuario = usuario.Estado,
                                NombrePoliza = $"Póliza #{contrato.IdPoliza}", // Placeholder, ajusta esto si tienes una tabla de 'Poliza' con nombres
                                FechaContrato = contrato.FechaContrato,
                                FechaFinContrato = contrato.FechaFin,
                                FechaVencimientoPago = ultimoPago?.FechaVto // Fecha de vencimiento del pago si existe
                            };

                            // Determinar si está vencida
                            if (vm.FechaVencimientoPago.HasValue)
                            {
                                vm.EstaVencida = vm.FechaVencimientoPago.Value < DateTime.Today;
                                vm.EstadoVencimientoTexto = vm.EstaVencida ? "Vencida" : "Al día"; // Se usará en CellFormatting
                            }
                            else
                            {
                                vm.EstaVencida = false; // No hay fecha de vencimiento, asumir no vencida o manejar como "N/A"
                                vm.EstadoVencimientoTexto = "N/A";
                            }

                            data.Add(vm);
                        }
                    }
                    else
                    {
                        // Si el usuario no tiene contratos, aún así lo mostramos, pero con datos de póliza vacíos
                        data.Add(new UsuarioPolizaViewModel
                        {
                            IdUsuario = usuario.IdUsuario,
                            NombreCompleto = $"{usuario.Nombre} {usuario.Apellido}\n{usuario.Correo}",
                            Correo = usuario.Correo,
                            EstadoUsuario = usuario.Estado,
                            NombrePoliza = "Sin Póliza Contratada",
                            FechaContrato = null,
                            FechaFinContrato = null,
                            FechaVencimientoPago = null,
                            EstaVencida = false,
                            EstadoVencimientoTexto = "N/A"
                        });
                    }
                }

                dataGridViewUsuarios.DataSource = data; // Asigna la lista de ViewModels como origen de datos
                dataGridViewUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de usuarios y pólizas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DataGridViewUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridViewUsuarios.Columns["ActivarDesactivar"].Index && e.RowIndex >= 0)
            {
                // Obtenemos el objeto ViewModel de la fila actual
                UsuarioPolizaViewModel selectedUser = dataGridViewUsuarios.Rows[e.RowIndex].DataBoundItem as UsuarioPolizaViewModel;

                if (selectedUser != null)
                {
                    int idUsuario = selectedUser.IdUsuario;
                    bool estadoActual = selectedUser.EstadoUsuario; // Usamos el estado del ViewModel

                    try
                    {
                        _usuarioService.CambiarEstadoUsuario(idUsuario, !estadoActual);
                        // Refrescar solo el estado del ViewModel y actualizar la fila directamente
                        // O, si es más simple, recargar toda la lista como lo tenías antes
                        CargarUsuariosConPolizas(); // Recargar la lista para refrescar la UI completamente
                        MessageBox.Show($"Usuario {(estadoActual ? "desactivado" : "activado")}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cambiar el estado del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void DataGridViewUsuarios_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridViewUsuarios.Columns[e.ColumnIndex].Name == "ActivarDesactivar" && e.RowIndex >= 0)
            {
                var row = dataGridViewUsuarios.Rows[e.RowIndex];
                var usuario = row.DataBoundItem as UsuarioPolizaViewModel;

                if (usuario != null)
                {
                    // Cambia el texto del botón según el estado
                    string texto = usuario.EstadoUsuario ? "Desactivar" : "Activar";
                    dataGridViewUsuarios.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = texto;

                    // Opcional: cambia el color de fondo de la fila o celda según estado
                    row.DefaultCellStyle.BackColor = Color.White;
                    if (usuario.EstaVencida)
                    {
                        row.Cells["EstadoVencimientoTexto"].Style.ForeColor = Color.Red;
                        row.Cells["EstadoVencimientoTexto"].Style.Font = new Font(dataGridViewUsuarios.Font, FontStyle.Bold);
                    }

                    // Personalizar botón
                    DataGridViewCell cell = row.Cells[e.ColumnIndex];
                    cell.Style.ForeColor = Color.White;
                    cell.Style.BackColor = usuario.EstadoUsuario ? Color.IndianRed : Color.SeaGreen;
                    cell.Style.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                }
            }
        }

    }
}