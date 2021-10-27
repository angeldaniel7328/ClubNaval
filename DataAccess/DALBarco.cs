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

                int rows = Consulta.EjecucionSinConsulta("SP_InsertarBarco", parametros);

                return (rows == 1);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
        }
    }
}
