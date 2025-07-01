using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using SegurosSelers.Entidades;
using SegurosSelers.CapaDeDatos;

namespace SegurosSelers.Servicios
{
    public class GestorService
    {
        private OperacionesBD _operacionesBD;

        public GestorService()
        {
            _operacionesBD = new OperacionesBD();
        }

        // Método para obtener todos los gestores
        public List<Gestor> ObtenerGestores()
        {
            List<Gestor> gestores = new List<Gestor>();
            string query = "SELECT idGestor, nombre, apellido, correo, telefono, clave FROM Gestor"; // ¡No selecciones la clave en producción!
            SqlDataReader reader = _operacionesBD.EjecutarConsulta(query);

            try
            {
                while (reader.Read())
                {
                    Gestor gestor = new Gestor
                    {
                        IdGestor = (int)reader["idGestor"],
                        Nombre = (string)reader["nombre"],
                        Apellido = (string)reader["apellido"],
                        Correo = (string)reader["correo"],
                        //Telefono = (string)reader["telefono"],  // Quitado el teléfono
                        Clave = (string)reader["clave"] // ¡No uses esto en producción!
                    };
                    gestores.Add(gestor);
                }
            }
            finally
            {
                reader.Close(); // Asegúrate de cerrar el lector
            }
            return gestores;
        }

        // Método para obtener un gestor por su ID
        public Gestor ObtenerGestorPorId(int idGestor)
        {
            Gestor gestor = null;
            string query = "SELECT idGestor, nombre, apellido, correo, telefono, clave FROM Gestor WHERE idGestor = @idGestor";  //¡No selecciones la clave en producción!
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@idGestor", idGestor)
            };
            SqlDataReader reader = _operacionesBD.EjecutarConsulta(query, parametros);

            try
            {
                if (reader.Read())
                {
                    gestor = new Gestor
                    {
                        IdGestor = (int)reader["idGestor"],
                        Nombre = (string)reader["nombre"],
                        Apellido = (string)reader["apellido"],
                        Correo = (string)reader["correo"],
                        Clave = (string)reader["clave"] // ¡No uses esto en producción!
                    };
                }
            }
            finally
            {
                reader.Close();
            }
            return gestor;
        }

        // Método para obtener un gestor por su correo electrónico
        public Gestor ObtenerGestorPorCorreo(string correo)
        {
            Gestor gestor = null;
            string query = "SELECT idGestor, nombre, apellido, correo, clave FROM Gestor WHERE correo = @correo"; // ¡No selecciones la clave en producción!
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@correo", correo)
            };
            SqlDataReader reader = _operacionesBD.EjecutarConsulta(query, parametros);

            try
            {
                if (reader.Read())
                {
                    gestor = new Gestor
                    {
                        IdGestor = (int)reader["idGestor"],
                        Nombre = (string)reader["nombre"],
                        Apellido = (string)reader["apellido"],
                        Correo = (string)reader["correo"],
                        Clave = (string)reader["clave"] // ¡No uses esto en producción!
                    };
                }
            }
            finally
            {
                reader.Close();
            }
            return gestor;
        }

        // Método para guardar un nuevo gestor
        public void GuardarGestor(Gestor gestor)
        {
            string query = "INSERT INTO Gestor (nombre, apellido, correo, clave) VALUES (@Nombre, @Apellido, @Correo, @Clave)"; // ¡Encriptar la clave!
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@Nombre", gestor.Nombre),
                new SqlParameter("@Apellido", gestor.Apellido),
                new SqlParameter("@Correo", gestor.Correo),
                new SqlParameter("@Clave", gestor.Clave) // ¡Encriptar la clave antes de guardarla!
            };
            _operacionesBD.EjecutarComando(query, parametros);
        }

        // Método para actualizar un gestor existente
        public void ActualizarGestor(Gestor gestor)
        {
            string query = "UPDATE Gestor SET nombre = @Nombre, apellido = @Apellido, correo = @Correo, clave = @Clave WHERE idGestor = @IdGestor"; // ¡Encriptar la clave!
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdGestor", gestor.IdGestor),
                new SqlParameter("@Nombre", gestor.Nombre),
                new SqlParameter("@Apellido", gestor.Apellido),
                new SqlParameter("@Correo", gestor.Correo),
                new SqlParameter("@Clave", gestor.Clave) // ¡Encriptar la clave antes de actualizarla!
            };
            _operacionesBD.EjecutarComando(query, parametros);
        }

        // Método para eliminar un gestor por su ID
        public void EliminarGestor(int idGestor)
        {
            string query = "DELETE FROM Gestor WHERE idGestor = @idGestor";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@idGestor", idGestor)
            };
            _operacionesBD.EjecutarComando(query, parametros);
        }
    }
}
