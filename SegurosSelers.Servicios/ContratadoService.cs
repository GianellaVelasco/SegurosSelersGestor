using Microsoft.Data.SqlClient;
using SegurosSelers.Entidades;
using SegurosSelers.CapaDeDatos;
using System;
using System.Collections.Generic;
using System.Configuration; // Necesario para ConfigurationManager (aunque no se use directamente en este servicio, se mantiene por si se añade un constructor que lo requiera)

namespace SegurosSelers.Servicios
{
    public class ContratadoService
    {
        private OperacionesBD _operacionesBD;

        public ContratadoService()
        {
            _operacionesBD = new OperacionesBD(); // Usa el constructor por defecto de OperacionesBD
        }

        // Tus métodos existentes:
        public List<Contratado> ObtenerContratadoPorUsuario(int idUsuario)
        {
            List<Contratado> contratos = new List<Contratado>();
            string query = "SELECT IdSegCont, IdUsuario, IdPoliza, FechaContrato, FechaFin, Observaciones FROM Contratado WHERE IdUsuario = @IdUsuario";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario)
            };

            SqlDataReader reader = null;
            try
            {
                reader = _operacionesBD.EjecutarConsulta(query, parametros);
                while (reader.Read())
                {
                    Contratado contrato = new Contratado
                    {
                        IdSegCont = (int)reader["IdSegCont"],
                        IdUsuario = (int)reader["IdUsuario"],
                        IdPoliza = (int)reader["IdPoliza"],
                        FechaContrato = (DateTime)reader["FechaContrato"],
                        FechaFin = reader["FechaFin"] == DBNull.Value ? null : (DateTime?)reader["FechaFin"],
                        Observaciones = reader["Observaciones"] == DBNull.Value ? null : reader["Observaciones"].ToString()?.Trim()
                    };
                    contratos.Add(contrato);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener contratos por usuario {idUsuario}: {ex.Message}", ex);
            }
            finally
            {
                reader?.Close(); // Asegura que el lector se cierre
            }
            return contratos;
        }

        public List<Contratado> ObtenerContratos()
        {
            List<Contratado> contratos = new List<Contratado>();
            string query = "SELECT IdSegCont, IdUsuario, IdPoliza, FechaContrato, FechaFin, Observaciones FROM Contratado";

            SqlDataReader reader = null;
            try
            {
                reader = _operacionesBD.EjecutarConsulta(query);
                while (reader.Read())
                {
                    Contratado contrato = new Contratado
                    {
                        IdSegCont = (int)reader["IdSegCont"],
                        IdUsuario = (int)reader["IdUsuario"],
                        IdPoliza = (int)reader["IdPoliza"],
                        FechaContrato = (DateTime)reader["FechaContrato"],
                        FechaFin = reader["FechaFin"] == DBNull.Value ? null : (DateTime?)reader["FechaFin"],
                        Observaciones = reader["Observaciones"] == DBNull.Value ? null : reader["Observaciones"].ToString()?.Trim()
                    };
                    contratos.Add(contrato);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener todos los contratos: {ex.Message}", ex);
            }
            finally
            {
                reader?.Close(); // Asegura que el lector se cierre
            }
            return contratos;
        }

        public Contratado ObtenerContratoPorIdPoliza(int idPoliza)
        {
            Contratado contrato = null;
            string query = "SELECT IdSegCont, IdUsuario, IdPoliza, FechaContrato, FechaFin, Observaciones FROM Contratado WHERE IdPoliza = @IdPoliza";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdPoliza", idPoliza)
            };

            SqlDataReader reader = null;
            try
            {
                reader = _operacionesBD.EjecutarConsulta(query, parametros);
                if (reader.Read())
                {
                    contrato = new Contratado
                    {
                        IdSegCont = (int)reader["IdSegCont"],
                        IdUsuario = (int)reader["IdUsuario"],
                        IdPoliza = (int)reader["IdPoliza"],
                        FechaContrato = (DateTime)reader["FechaContrato"],
                        FechaFin = reader["FechaFin"] == DBNull.Value ? null : (DateTime?)reader["FechaFin"],
                        Observaciones = reader["Observaciones"] == DBNull.Value ? null : reader["Observaciones"].ToString()?.Trim()
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al obtener contrato por ID de póliza {idPoliza}: {ex.Message}", ex);
            }
            finally
            {
                reader?.Close(); // Asegura que el lector se cierre
            }
            return contrato;
        }

        // *** NUEVO MÉTODO: Obtener Contratados como ViewModel ***
        public List<ContratadoViewModel> ObtenerContratadosViewModel()
        {
            var listaContratados = new List<ContratadoViewModel>();

            // Query para obtener datos combinando Contratado, Usuario y Poliza
            string query = @"
                SELECT
                    c.IdSegCont,
                    u.Apellido,
                    u.Nombre,
                    p.NombrePack,
                    c.FechaContrato,
                    c.FechaFin,
                    c.Observaciones
                FROM Contratado c
                INNER JOIN Usuario u ON c.IdUsuario = u.idUsuario
                INNER JOIN Poliza p ON c.IdPoliza = p.IdPoliza;
            ";

            SqlDataReader reader = null;
            try
            {
                reader = _operacionesBD.EjecutarConsulta(query);
                while (reader.Read())
                {
                    var contratado = new ContratadoViewModel
                    {
                        IdSegCont = reader.GetInt32(reader.GetOrdinal("IdSegCont")),
                        ApellidoNombreCliente = $"{reader.GetString(reader.GetOrdinal("Apellido"))} {reader.GetString(reader.GetOrdinal("Nombre"))}",
                        NombrePackPoliza = reader.GetString(reader.GetOrdinal("NombrePack")),
                        FechaContrato = reader.GetDateTime(reader.GetOrdinal("FechaContrato")),
                        FechaFin = reader.IsDBNull(reader.GetOrdinal("FechaFin")) ? (DateTime?)null : reader.GetDateTime(reader.GetOrdinal("FechaFin")),
                        Observaciones = reader.IsDBNull(reader.GetOrdinal("Observaciones")) ? string.Empty : reader.GetString(reader.GetOrdinal("Observaciones")).Trim()
                    };
                    // Determinar si la póliza está vigente
                    contratado.EstaVigente = (contratado.FechaFin == null || contratado.FechaFin >= DateTime.Today);

                    listaContratados.Add(contratado);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener las coberturas contratadas como ViewModel de la base de datos.", ex);
            }
            finally
            {
                reader?.Close(); // Asegura que el lector se cierre
            }
            return listaContratados;
        }

        // *** NUEVO MÉTODO: Desactivar Cobertura ***
        public bool DesactivarCobertura(int idSegCont)
        {
            const string sql = "UPDATE Contratado SET FechaFin = @FechaFin WHERE IdSegCont = @IdSegCont";
            try
            {
                SqlParameter[] parametros = new SqlParameter[]
                {
                    new SqlParameter("@FechaFin", DateTime.Today), // Se desactiva a la fecha actual
                    new SqlParameter("@IdSegCont", idSegCont)
                };
                _operacionesBD.EjecutarComando(sql, parametros);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al desactivar la cobertura {idSegCont}.", ex);
            }
        }
    }
}