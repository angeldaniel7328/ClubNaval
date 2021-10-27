
using System;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;

namespace DataAccess
{
    public class Conexion
    {
        public string CadenaConexion { get; private set; }

        public Conexion() => Configurar();

        private void Configurar()
        {
            try
            {
                CadenaConexion = ConfigurationManager.AppSettings.Get("CADENA_CONEXION");
                //DbProviderFactories.ge
            }
            catch (Exception)
            {
                throw new ArgumentException("Error al configurar la cadena de conexión");
            }
        }
    }
}
