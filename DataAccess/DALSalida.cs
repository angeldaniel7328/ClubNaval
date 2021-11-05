using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DALSalida
    {
        public static bool InsertarSalida(VOSalida salida)
        {
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@FechaHoraSalida", SqlDbType.DateTime, salida.FechaHoraSalida));
                parametros.Add(new Parametro("@Destino", SqlDbType.VarChar, salida.Destino));
                parametros.Add(new Parametro("@Estado", SqlDbType.VarChar, salida.Estado));
                parametros.Add(new Parametro("@IdBarco", SqlDbType.Int, salida.IdBarco));
                parametros.Add(new Parametro("@IdCapitan", SqlDbType.Int, salida.IdPersona));
                int rows = Consulta.EjecutarSinConsulta("SP_InsertarSalida", parametros);
                return (rows == 1);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo insertar en la base de datos");
            }
        }

        public static VOSalida ConsultarSalidasPorId(int idSalida)
        {
            VOSalida salida;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdSalida", SqlDbType.Int, idSalida));
                Dictionary<string, object> datos = Consulta.EjecutarLectura("SP_ConsultarSalidasPorId", parametros);
                DateTime fechaHoraSalida = (DateTime)datos["FechaHoraSalida"];
                string destino = (string)datos["Destino"];
                string estado = (string)datos["Estado"];
                int idBarco = (int)datos["IdBarco"];
                int idPersona = (int)datos["IdPersona"];
                salida = new VOSalida(idSalida, fechaHoraSalida, destino, estado, idBarco, idPersona);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return salida;
        }

        public static List<VOSalida> ConsultarSalidasPorEstado(string estado)
        {
            List<VOSalida> salidas = new List<VOSalida>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Estado", SqlDbType.VarChar, estado));
                DataTable datosSalidas = Consulta.EjecutarConLlenado("SP_ConsultarSalidasPorEstado", parametros);
                foreach (DataRow registro in datosSalidas.Rows) salidas.Add(new VOSalida(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return salidas;
        }

        public static VOSalidaExtendida ConsultarSalidasPorIdExtendida(int idSalida)
        {
            VOSalidaExtendida salida;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@IdSalida", SqlDbType.Int, idSalida));
                Dictionary<string, object> datos = Consulta.EjecutarLectura("SP_ConsultarSalidasPorIdExtendida", parametros);
                DateTime fechaHoraSalida = (DateTime)datos["FechaHoraSalida"];
                string destino = (string)datos["Destino"];
                string estado = (string)datos["Estado"];
                int idBarco = (int)datos["IdBarco"];
                int idPersona = (int)datos["IdPersona"];
                string nombreBarco = (string)datos["NombreBarco"];
                string urlFotoBarco = (string)datos["UrlFotoBarco"];
                string nombreCapitan = (string)datos["NombreCapitan"];
                string urlFotoCapitan = (string)datos["UrlFotoCapitan"];
                salida = new VOSalidaExtendida(idSalida, fechaHoraSalida, destino, estado, idBarco, idPersona,
                    nombreBarco, urlFotoBarco, nombreCapitan, urlFotoCapitan);
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return salida;
        }

        public static List<VOSalidaExtendida> ConsultarSalidasPorEstadoExtendida(string estado)
        {
            List<VOSalidaExtendida> salidas = new List<VOSalidaExtendida>();
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("@Estado", SqlDbType.VarChar, estado));
                DataTable datosSalidas = Consulta.EjecutarConLlenado("SP_ConsultarSalidasPorEstadoExtendida", parametros);
                foreach (DataRow registro in datosSalidas.Rows) salidas.Add(new VOSalidaExtendida(registro));
            }
            catch (Exception)
            {
                throw new ArgumentException("No se pudo consultar en la base de datos");
            }
            return salidas;
        }
    }
}
