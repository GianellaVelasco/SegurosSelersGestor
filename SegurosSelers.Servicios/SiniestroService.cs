using Microsoft.Data.SqlClient;
using SegurosSelers.Entidades;
using System.Collections.Generic;
using System.Configuration;
using System; // Agregado para el manejo de excepciones

namespace SegurosSelers.Servicios
{
    public class SiniestroService
    {
        private readonly string _connectionString;

        // Constructor que lee desde app.config
        public SiniestroService()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
        }

        // Constructor para inyección de dependencias o pruebas
        public SiniestroService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<SiniestroViewModel> ObtenerSiniestros()
        {
            var siniestros = new List<SiniestroViewModel>();
            string sql = @"
                SELECT
                    s.idSiniestro,
                    s.fecha,
                    s.hora,
                    s.descripcion,
                    s.imagenUrl AS ImagenUrlSiniestro,
                    s.estadoSolicitud,
                    u.Apellido AS ApellidoCliente,
                    u.Nombre AS NombreCliente,
                    v.nombreVehiculo AS NombreTipoVehiculo,
                    v.imagenUrl AS ImagenUrlVehiculo
                FROM Siniestro s
                INNER JOIN Usuario u ON s.idUsuario = u.idUsuario
                INNER JOIN Vehiculo v ON u.idTipoVehiculo = v.idTipoVehiculo;
            ";

            try
            {
                using (var conexion = new SqlConnection(_connectionString))
                {
                    conexion.Open();
                    using (var cmd = new SqlCommand(sql, conexion))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                siniestros.Add(new SiniestroViewModel
                                {
                                    IdSiniestro = reader.GetInt32(reader.GetOrdinal("idSiniestro")),
                                    FechaSiniestro = reader.GetDateTime(reader.GetOrdinal("fecha")),
                                    HoraSiniestro = reader.GetTimeSpan(reader.GetOrdinal("hora")),
                                    Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? string.Empty : reader.GetString(reader.GetOrdinal("descripcion")),
                                    ImagenUrlSiniestro = reader.IsDBNull(reader.GetOrdinal("ImagenUrlSiniestro")) ? string.Empty : reader.GetString(reader.GetOrdinal("ImagenUrlSiniestro")),
                                    Estado = reader.GetString(reader.GetOrdinal("estadoSolicitud")),
                                    ApellidoNombreCliente = $"{reader.GetString(reader.GetOrdinal("ApellidoCliente"))} {reader.GetString(reader.GetOrdinal("NombreCliente"))}",
                                    NombreTipoVehiculo = reader.IsDBNull(reader.GetOrdinal("NombreTipoVehiculo")) ? string.Empty : reader.GetString(reader.GetOrdinal("NombreTipoVehiculo")),
                                    ImagenUrlVehiculo = reader.IsDBNull(reader.GetOrdinal("ImagenUrlVehiculo")) ? string.Empty : reader.GetString(reader.GetOrdinal("ImagenUrlVehiculo"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Registra la excepción (ej., en un archivo, consola o framework de logging)
                // Para demostración, solo la relanzamos, pero en una aplicación real, podrías manejarla de forma más elegante
                throw new Exception("Error al obtener los siniestros de la base de datos.", ex);
            }
            return siniestros;
        }

        public List<SiniestroViewModel> ObtenerSiniestrosPorEstado(string estado)
        {
            var siniestros = new List<SiniestroViewModel>();
            string sql = @"
                SELECT
                    s.idSiniestro,
                    s.fecha,
                    s.hora,
                    s.descripcion,
                    s.imagenUrl AS ImagenUrlSiniestro,
                    s.estadoSolicitud,
                    u.Apellido AS ApellidoCliente,
                    u.Nombre AS NombreCliente,
                    v.nombreVehiculo AS NombreTipoVehiculo,
                    v.imagenUrl AS ImagenUrlVehiculo
                FROM Siniestro s
                INNER JOIN Usuario u ON s.idUsuario = u.idUsuario
                INNER JOIN Vehiculo v ON u.idTipoVehiculo = v.idTipoVehiculo
                WHERE s.estadoSolicitud = @Estado;";

            try
            {
                using (var conexion = new SqlConnection(_connectionString))
                {
                    conexion.Open();
                    using (var cmd = new SqlCommand(sql, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Estado", estado);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                siniestros.Add(new SiniestroViewModel
                                {
                                    IdSiniestro = reader.GetInt32(reader.GetOrdinal("idSiniestro")),
                                    FechaSiniestro = reader.GetDateTime(reader.GetOrdinal("fecha")),
                                    HoraSiniestro = reader.GetTimeSpan(reader.GetOrdinal("hora")),
                                    Descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion")) ? string.Empty : reader.GetString(reader.GetOrdinal("descripcion")),
                                    ImagenUrlSiniestro = reader.IsDBNull(reader.GetOrdinal("ImagenUrlSiniestro")) ? string.Empty : reader.GetString(reader.GetOrdinal("ImagenUrlSiniestro")),
                                    Estado = reader.GetString(reader.GetOrdinal("estadoSolicitud")),
                                    ApellidoNombreCliente = $"{reader.GetString(reader.GetOrdinal("ApellidoCliente"))} {reader.GetString(reader.GetOrdinal("NombreCliente"))}",
                                    NombreTipoVehiculo = reader.IsDBNull(reader.GetOrdinal("NombreTipoVehiculo")) ? string.Empty : reader.GetString(reader.GetOrdinal("NombreTipoVehiculo")),
                                    ImagenUrlVehiculo = reader.IsDBNull(reader.GetOrdinal("ImagenUrlVehiculo")) ? string.Empty : reader.GetString(reader.GetOrdinal("ImagenUrlVehiculo"))
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener los siniestros por estado '{estado}' de la base de datos.", ex);
            }
            return siniestros;
        }

        public bool ModificarEstadoSiniestro(int idSiniestro, string nuevoEstado)
        {
            const string sql = @"UPDATE Siniestro SET estadoSolicitud = @Estado WHERE idSiniestro = @IdSiniestro";

            try
            {
                using (var conexion = new SqlConnection(_connectionString))
                {
                    conexion.Open();
                    using (var cmd = new SqlCommand(sql, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Estado", nuevoEstado);
                        cmd.Parameters.AddWithValue("@IdSiniestro", idSiniestro);

                        int filasAfectadas = cmd.ExecuteNonQuery();

                        return filasAfectadas > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al modificar el estado del siniestro {idSiniestro} a '{nuevoEstado}'.", ex);
            }
        }
    }
}