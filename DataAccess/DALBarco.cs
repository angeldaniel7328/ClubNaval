using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DALBarco
    {
        public static bool InsertarBarco(VOBarco barco)
        {
            try {
                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("@Matricula", SqlDbType.VarChar, barco.Matricula));
                parametros.Add(new Parametro("@NoAmarre", SqlDbType.VarChar, barco.NoAmarre));
                parametros.Add(new Parametro("@Nombre", SqlDbType.VarChar, barco.Nombre));
                parametros.Add(new Parametro("@Cuota", SqlDbType.Decimal, barco.Cuota));
                parametros.Add(new Parametro("@IdOwner", SqlDbType.Int, barco.IdOwner));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, barco.UrlFoto));
                int rows = Consulta.EjecutarSinConsulta("SP_InsertarBarco", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
        }

        public static VOBarco ConsultarBarcoPorId(int idBarco)
        {
            VOBarco barco;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdBarco", SqlDbType.Int, idBarco));
                Dictionary<string, object> datos = Consulta.EjecutarLectura("SP_ConsultarBarcoPorId", parametros);
                string matricula = (string)datos["Matricula"];
                string noAmarre = (string)datos["NoAmarre"];
                string nombre = (string)datos["Nombre"];
                double cuota = (double)datos["Cuota"];
                int idOwner = (int)datos["IdOwner"];
                bool disponibilidad = (bool)datos["Disponibilidad"];
                string urlFoto = (string)datos["UrlFoto"];
                barco = new VOBarco(idBarco, matricula, noAmarre, nombre, cuota, idOwner, disponibilidad, urlFoto);
            }
            catch(Exception){
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return barco;
        }

        public static List<VOBarco> ConsultarBarcos(bool? disponibilidad)
        {
            List<VOBarco> barcos = new List<VOBarco>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Disponibilidad", SqlDbType.Bit, disponibilidad));
                DataTable datosBarcos = Consulta.EjecutarConLlenado("SP_ConsultarBarcos", parametros);
                foreach (DataRow registro in datosBarcos.Rows)
                {
                    barcos.Add(new VOBarco(registro));
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return barcos;
        }

        public static List<VOBarco> ConsultarBarcosPorDueño(int idOwner, bool? disponibilidad)
        {
            List<VOBarco> barcos = new List<VOBarco>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Disponibilidad", SqlDbType.Bit, disponibilidad));
                parametros.Add(new Parametro("@IdOwner", SqlDbType.Int, idOwner));
                DataTable datosBarcos = Consulta.EjecutarConLlenado("SP_ConsultarBarcosPorOwner", parametros);
                foreach (DataRow registro in datosBarcos.Rows)
                {
                    barcos.Add(new VOBarco(registro));
                }
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return barcos;
        }

        public static bool ActualizarBarco(VOBarco barco)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdBarco", SqlDbType.Int, barco.IdBarco));
                parametros.Add(new Parametro("@Matricula", SqlDbType.VarChar, barco.Matricula));
                parametros.Add(new Parametro("@NoAmarre", SqlDbType.VarChar, barco.NoAmarre));
                parametros.Add(new Parametro("@Nombre", SqlDbType.VarChar, barco.Nombre));
                parametros.Add(new Parametro("@Cuota", SqlDbType.Decimal, barco.Cuota));
                parametros.Add(new Parametro("@IdOwner", SqlDbType.Int, barco.IdOwner));
                parametros.Add(new Parametro("@UrlFoto", SqlDbType.VarChar, barco.UrlFoto));
                parametros.Add(new Parametro("@Disponibilidad", SqlDbType.Bit, barco.Disponibilidad));
                int rows = Consulta.EjecutarSinConsulta("SP_ActualizarBarco", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo actualizar en la base de datos");
            }
        }

        public static bool EliminarBarco(int idBarco)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdBarco", SqlDbType.Int, idBarco));
                int rows = Consulta.EjecutarSinConsulta("SP_EliminarBarco", parametros);
                return (rows != 0);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo eliminar en la base de datos");
            }
        }
    }
}
