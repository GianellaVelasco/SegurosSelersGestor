using SegurosSelers.Entidades; // Asegúrate de tener esta referencia a tu clase Poliza
using SegurosSelers.CapaDeDatos; // Asegúrate de tener esta referencia a tu clase OperacionesBD
using Microsoft.Data.SqlClient; // Usado para SqlParameter y SqlDataReader
using System.Collections.Generic;

namespace SegurosSelers.Servicios
{
    public class PolizaService
    {
        private OperacionesBD _operacionesBD;

        public PolizaService()
        {
            _operacionesBD = new OperacionesBD();
        }

        /// <summary>
        /// Obtiene una lista de todas las pólizas desde la base de datos.
        /// </summary>
        /// <returns>Una lista de objetos Poliza.</returns>
        public List<Poliza> ObtenerPolizas()
        {
            List<Poliza> polizas = new List<Poliza>();
            string query = "SELECT IdPoliza, NombrePack, DescripcionCobertura, Precio, Estado FROM Poliza";

            SqlDataReader reader = _operacionesBD.EjecutarConsulta(query);

            try
            {
                while (reader.Read())
                {
                    Poliza poliza = new Poliza
                    {
                        IdPoliza = (int)reader["IdPoliza"],
                        NombrePack = (string)reader["NombrePack"],
                        DescripcionCobertura = (string)reader["DescripcionCobertura"],
                        Precio = (decimal)reader["Precio"],
                        Estado = (bool)reader["Estado"]
                    };
                    polizas.Add(poliza);
                }
            }
            finally
            {
                reader.Close();
            }
            return polizas;
        }

        /// <summary>
        /// Cambia el estado (activo/inactivo) de una póliza en la base de datos.
        /// </summary>
        /// <param name="idPoliza">El ID de la póliza a modificar.</param>
        /// <param name="nuevoEstado">El nuevo estado (true para activo, false para inactivo).</param>
        public void CambiarEstadoPoliza(int idPoliza, bool nuevoEstado)
        {
            string query = "UPDATE Poliza SET Estado = @Estado WHERE IdPoliza = @IdPoliza";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Estado", nuevoEstado),
                new SqlParameter("@IdPoliza", idPoliza)
            };
            _operacionesBD.EjecutarComando(query, parametros);
        }
    }
}