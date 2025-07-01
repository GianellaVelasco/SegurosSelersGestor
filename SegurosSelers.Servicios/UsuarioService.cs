using System;
using System.Collections.Generic;
using SegurosSelers.Entidades; // Asegúrate de tener esta referencia a tu clase Usuario
using SegurosSelers.CapaDeDatos; // Asegúrate de tener esta referencia a tu clase OperacionesBD
using Microsoft.Data.SqlClient; // Usado para SqlParameter y SqlDataReader

namespace SegurosSelers.Servicios
{
    public class UsuarioService
    {
        private OperacionesBD _operacionesBD;

        public UsuarioService()
        {
            _operacionesBD = new OperacionesBD(); // Instancia tu clase de operaciones de base de datos
        }

        // Método para obtener la lista completa de usuarios
        public List<Usuario> ObtenerUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();
            // Consulta para obtener todos los datos de los usuarios
            string query = "SELECT idUsuario, nombre, apellido, correo, clave, tipoUsuario, estado, idTipoVehiculo, idGestor FROM Usuario";

            // Ejecuta la consulta y obtiene un SqlDataReader
            SqlDataReader reader = _operacionesBD.EjecutarConsulta(query);

            try
            {
                // Itera a través de los resultados del lector
                while (reader.Read())
                {
                    Usuario usuario = new Usuario
                    {
                        IdUsuario = (int)reader["idUsuario"],
                        Nombre = (string)reader["nombre"],
                        Apellido = (string)reader["apellido"],
                        Correo = (string)reader["correo"],
                        Clave = (string)reader["clave"], // ¡ATENCIÓN: No uses contraseñas directamente así en producción!
                        TipoUsuario = (int)reader["tipoUsuario"],
                        Estado = (bool)reader["estado"],
                        IdTipoVehiculo = (int)reader["idTipoVehiculo"],
                        IdGestor = (int)reader["idGestor"]
                    };
                    usuarios.Add(usuario);
                }
            }
            finally
            {
                // Asegúrate de cerrar el lector para liberar los recursos
                reader.Close();
            }
            return usuarios;
        }

        // Método para cambiar el estado de un usuario en la base de datos
        public void CambiarEstadoUsuario(int idUsuario, bool nuevoEstado)
        {
            // Consulta UPDATE para modificar el campo 'estado' del usuario
            string query = "UPDATE Usuario SET estado = @Estado WHERE idUsuario = @IdUsuario";

            // Define los parámetros para la consulta SQL
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Estado", nuevoEstado), // Nuevo estado (true/false)
                new SqlParameter("@IdUsuario", idUsuario)  // ID del usuario a modificar
            };

            // Ejecuta el comando de actualización a través de la capa de datos
            _operacionesBD.EjecutarComando(query, parametros);
        }

        // Método para obtener un solo usuario por ID (útil para otras funcionalidades, no directamente para este cambio)
        public Usuario ObtenerUsuarioPorId(int idUsuario)
        {
            Usuario usuario = null;
            string query = "SELECT idUsuario, nombre, apellido, correo, clave, tipoUsuario, estado, idTipoVehiculo, idGestor FROM Usuario WHERE idUsuario = @IdUsuario";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario)
            };
            SqlDataReader reader = _operacionesBD.EjecutarConsulta(query, parametros);

            try
            {
                if (reader.Read())
                {
                    usuario = new Usuario
                    {
                        IdUsuario = (int)reader["idUsuario"],
                        Nombre = (string)reader["nombre"],
                        Apellido = (string)reader["apellido"],
                        Correo = (string)reader["correo"],
                        Clave = (string)reader["clave"], // ¡No uses esto en producción!
                        TipoUsuario = (int)reader["tipoUsuario"],
                        Estado = (bool)reader["estado"],
                        IdTipoVehiculo = (int)reader["idTipoVehiculo"],
                        IdGestor = (int)reader["idGestor"]
                    };
                }
            }
            finally
            {
                reader.Close();
            }
            return usuario;
        }
    }
}