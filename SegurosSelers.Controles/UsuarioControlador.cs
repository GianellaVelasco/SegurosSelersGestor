using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Form;
using SegurosSelers.Entidades;
using SegurosSelers.Servicios;

namespace SegurosSelers.Control
{
    public class UsuarioControlador
    {
        private UsuarioService _usuarioService;
        private DataGridView _dataGridView;

        public UsuarioControlador()
        {
            _usuarioService = new UsuarioService();
        }

        public Control ObtenerListadoUsuarios()
        {
            _dataGridView = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = false,
                AllowUserToAddRows = false,
                ReadOnly = true
            };

            // Columnas
            _dataGridView.Columns.Add("Id", "ID");
            _dataGridView.Columns.Add("Nombre", "Nombre");
            _dataGridView.Columns.Add("Apellido", "Apellido");
            _dataGridView.Columns.Add("Correo", "Correo");

            DataGridViewTextBoxColumn estadoCol = new DataGridViewTextBoxColumn
            {
                Name = "EstadoTexto",
                HeaderText = "Estado"
            };
            _dataGridView.Columns.Add(estadoCol);

            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn
            {
                Name = "ActivarDesactivar",
                HeaderText = "",
                Text = "",
                UseColumnTextForButtonValue = false
            };
            _dataGridView.Columns.Add(btnCol);

            _dataGridView.CellClick += _dataGridView_CellClick;
            _dataGridView.CellFormatting += _dataGridView_CellFormatting;

            MostrarListadoUsuarios();

            return _dataGridView;
        }

        private void MostrarListadoUsuarios()
        {
            try
            {
                List<Usuario> usuarios = _usuarioService.ObtenerUsuarios();
                _dataGridView.Rows.Clear();

                foreach (Usuario usuario in usuarios)
                {
                    _dataGridView.Rows.Add(usuario.IdUsuario, usuario.Nombre, usuario.Apellido, usuario.Correo, usuario.Estado);
                }

                _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de usuarios: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == _dataGridView.Columns["ActivarDesactivar"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = _dataGridView.Rows[e.RowIndex];
                int idUsuario = (int)row.Cells["Id"].Value;
                bool estadoActual = (bool)row.Cells["EstadoTexto"].Tag;

                try
                {
                    _usuarioService.CambiarEstadoUsuario(idUsuario, !estadoActual);
                    MostrarListadoUsuarios();
                    MessageBox.Show($"Usuario {(estadoActual ? "desactivado" : "activado")}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cambiar el estado del usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (_dataGridView.Columns[e.ColumnIndex].Name == "EstadoTexto")
            {
                if (e.RowIndex >= 0 && _dataGridView.Rows[e.RowIndex].Cells[4].Value is bool estadoBool)
                {
                    e.Value = estadoBool ? "Activo" : "Inactivo";
                    e.CellStyle.ForeColor = estadoBool ? Color.Green : Color.Red;
                    e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                    e.FormattingApplied = true;
                    _dataGridView.Rows[e.RowIndex].Cells["EstadoTexto"].Tag = estadoBool;
                }
            }

            if (_dataGridView.Columns[e.ColumnIndex].Name == "ActivarDesactivar" && e.RowIndex >= 0)
            {
                if (_dataGridView.Rows[e.RowIndex].Cells["EstadoTexto"].Tag is bool estadoActual)
                {
                    var buttonCell = (DataGridViewButtonCell)_dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    buttonCell.Value = estadoActual ? "Desactivar" : "Activar";
                    buttonCell.Style.BackColor = estadoActual ? Color.IndianRed : Color.LightGreen;
                    buttonCell.Style.ForeColor = Color.White;
                    buttonCell.FlatStyle = FlatStyle.Flat;
                }
            }
        }
    }
}
