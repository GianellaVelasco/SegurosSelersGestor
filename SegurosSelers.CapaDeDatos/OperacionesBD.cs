using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;




namespace SegurosSelers.CapaDeDatos
{
    public class OperacionesBD
    {
        
        private string _connectionString;

        public OperacionesBD()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ConnectionString;
        }

        // Método para ejecutar una consulta que no devuelve resultados (INSERT, UPDATE, DELETE)
        public void EjecutarComando(string query, SqlParameter[] parametros = null)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros);
                    }
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log de errores (¡Importante!)
                    Console.WriteLine("Error al ejecutar comando: " + ex.Message);
                    throw; // Relanza la excepción para que se maneje en la capa superior
                }
            }
        }

        // Método para ejecutar una consulta que devuelve un único valor (COUNT, MAX, MIN, etc.)
        public object EjecutarEscalar(string query, SqlParameter[] parametros = null)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    if (parametros != null)
                    {
                        command.Parameters.AddRange(parametros);
                    }
                    object resultado = command.ExecuteScalar();
                    return resultado;
                }
                catch (Exception ex)
                {
                    // Log de errores
                    Console.WriteLine("Error al ejecutar escalar: " + ex.Message);
                    throw;
                }
            }
        }

        // Método para ejecutar una consulta que devuelve un conjunto de resultados (SELECT)
        public SqlDataReader EjecutarConsulta(string query, SqlParameter[] parametros = null)
        {
            SqlConnection connection = new SqlConnection(_connectionString); // No usar using aquí
            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                if (parametros != null)
                {
                    command.Parameters.AddRange(parametros);
                }
                SqlDataReader reader = command.ExecuteReader(CommandBehavior.CloseConnection); // Muy importante: CloseConnection
                return reader; // Devuelve el lector.  La conexión se cerrará al cerrar el lector.
            }
            catch (Exception ex)
            {
                // Log de errores
                Console.WriteLine("Error al ejecutar consulta: " + ex.Message);
                connection.Dispose(); // Asegurar que la conexión se libere en caso de error
                throw;
            }
        }
    }
}
