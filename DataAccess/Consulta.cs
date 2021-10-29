using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public struct Parametro
    {
        public string Nombre { get; set; }
        public SqlDbType Tipo { get; set; }
        public object Valor { get; set; }

        public Parametro(string nombre, SqlDbType tipo, object valor)
        {
            this.Nombre = nombre;
            this.Tipo = tipo;
            this.Valor = valor;
        }      
    }

    public static class Consulta
    {
        public static int EjecutarSinConsulta(string procedimiento, List<Parametro> parametros)
        {
            Conexion conexion = new Conexion();
            SqlConnection sqlConnection = new SqlConnection(conexion.CadenaConexion);
            int rows;
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(procedimiento, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                parametros.ForEach((parametro) => cmd.Parameters.Add(parametro.Nombre, parametro.Tipo).Value = parametro.Valor);          
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
            finally
            {
                sqlConnection.Close();
            }
            return rows;
        }

        public static List<object> EjecutarLectura(string procedimiento, List<Parametro> parametros)
        {
            Conexion conexion = new Conexion();
            SqlConnection sqlConnection = new SqlConnection(conexion.CadenaConexion);
            SqlDataReader datos;
            List<object> registro = new List<object>();
            try
            {
                sqlConnection.Open();
                SqlCommand cmd = new SqlCommand(procedimiento, sqlConnection);
                cmd.CommandType = CommandType.StoredProcedure;
                parametros.ForEach((parametro) => cmd.Parameters.Add(parametro.Nombre, parametro.Tipo).Value = parametro.Valor);
                datos = cmd.ExecuteReader();
                while (datos.Read())
                {
                    foreach (var valor in datos)
                    {
                        registro.Add(valor);
                    }
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
            finally
            {
                sqlConnection.Close();
            }
            return registro;
        }
    }
}
