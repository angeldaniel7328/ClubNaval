using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public class DALBarco
    {
        public static bool Insertar(VOBarco barco)
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
                return (rows == 1);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
        }

        public static VOBarco ConsultarBarco(int idBarco)
        {
            VOBarco barco;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdBarco", SqlDbType.Int, idBarco));
                List<object> datos = Consulta.EjecutarLectura("SP_EjecutarBarcoPorId", parametros);
                string matricula = (string)datos[1];
                string noAmarre = (string)datos[2];
                string nombre = (string)datos[3];
                double cuota = (double)datos[4];
                int idOwner = (int)datos[5];
                bool disponibilidad = (bool)datos[6];
                string urlFoto = (string)datos[7];
                barco = new VOBarco(idBarco, matricula, noAmarre, nombre, cuota, idOwner, disponibilidad, urlFoto);
            }
            catch(Exception){
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return barco;
        }
    }
}
