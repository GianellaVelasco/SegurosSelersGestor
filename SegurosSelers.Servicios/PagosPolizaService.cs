using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using SegurosSelers.Entidades;
using SegurosSelers.CapaDeDatos;

namespace SegurosSelers.Servicios
{
    public class PagosPolizaService
    {
        private OperacionesBD _operacionesBD;

        public PagosPolizaService()
        {
            _operacionesBD = new OperacionesBD();
        }

        public List<PagosPoliza> ObtenerPagos()
        {
            List<PagosPoliza> pagos = new List<PagosPoliza>();
            string query = "SELECT IdPago, IdUsuario, IdPoliza, FechaVto, Observaciones FROM PagosPoliza";
            SqlDataReader reader = _operacionesBD.EjecutarConsulta(query);

            try
            {
                while (reader.Read())
                {
                    PagosPoliza pago = new PagosPoliza
                    {
                        IdPago = (int)reader["IdPago"],
                        IdUsuario = (int)reader["IdUsuario"],
                        IdPoliza = (int)reader["IdPoliza"],
                        FechaVto = reader["FechaVto"] == DBNull.Value ? null : (DateTime?)reader["FechaVto"],
                        Observaciones = reader["Observaciones"] == DBNull.Value ? null : reader["Observaciones"].ToString()?.Trim()
                    };
                    pagos.Add(pago);
                }
            }
            finally
            {
                reader.Close();
            }

            return pagos;
        }

        public List<PagosPoliza> ObtenerPagosPorUsuario(int idUsuario)
        {
            List<PagosPoliza> pagos = new List<PagosPoliza>();
            string query = "SELECT IdPago, IdUsuario, IdPoliza, FechaVto, Observaciones FROM PagosPoliza WHERE IdUsuario = @IdUsuario";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdUsuario", idUsuario)
            };

            SqlDataReader reader = _operacionesBD.EjecutarConsulta(query, parametros);

            try
            {
                while (reader.Read())
                {
                    PagosPoliza pago = new PagosPoliza
                    {
                        IdPago = (int)reader["IdPago"],
                        IdUsuario = (int)reader["IdUsuario"],
                        IdPoliza = (int)reader["IdPoliza"],
                        FechaVto = reader["FechaVto"] == DBNull.Value ? null : (DateTime?)reader["FechaVto"],
                        Observaciones = reader["Observaciones"] == DBNull.Value ? null : reader["Observaciones"].ToString()?.Trim()
                    };
                    pagos.Add(pago);
                }
            }
            finally
            {
                reader.Close();
            }

            return pagos;
        }

        public PagosPoliza ObtenerUltimoPagoPorPoliza(int idPoliza)
        {
            PagosPoliza pago = null;
            // Asumiendo que quieres el último pago por fecha de vencimiento o alguna otra lógica
            // Esta consulta es un ejemplo, ajusta según tu lógica de "último pago"
            string query = "SELECT TOP 1 IdPago, IdUsuario, IdPoliza, FechaVto, Observaciones FROM PagosPoliza WHERE IdPoliza = @IdPoliza ORDER BY FechaVto DESC";
            SqlParameter[] parametros = new SqlParameter[]
            {
                new SqlParameter("@IdPoliza", idPoliza)
            };

            SqlDataReader reader = _operacionesBD.EjecutarConsulta(query, parametros);

            try
            {
                if (reader.Read())
                {
                    pago = new PagosPoliza
                    {
                        IdPago = (int)reader["IdPago"],
                        IdUsuario = (int)reader["IdUsuario"],
                        IdPoliza = (int)reader["IdPoliza"],
                        FechaVto = reader["FechaVto"] == DBNull.Value ? null : (DateTime?)reader["FechaVto"],
                        Observaciones = reader["Observaciones"] == DBNull.Value ? null : reader["Observaciones"].ToString()?.Trim()
                    };
                }
            }
            finally
            {
                reader.Close();
            }
            return pago;
        }
    }
}