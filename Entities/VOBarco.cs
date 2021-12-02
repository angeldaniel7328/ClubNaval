using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VOBarco
    {
        public int IdBarco { get; set; }
        public string Matricula { get; set; }
        public string NoAmarre { get; set; }
        public string Nombre { get; set; }
        public double? Cuota { get; set; }
        public int IdOwner { get; set; }
        public bool? Disponibilidad { get; set; }
        public string UrlFoto { get; set; }

        public VOBarco(int idBarco, string matricula, string noAmarre, string nombre, 
            double cuota, int idOwner, bool disponibilidad, string urlFoto)
        {
            IdBarco = idBarco;
            Matricula = matricula;
            NoAmarre = noAmarre;
            Nombre = nombre;
            Cuota = cuota;
            IdOwner = idOwner;
            Disponibilidad = disponibilidad;
            UrlFoto = urlFoto;
        }

        public VOBarco(string matricula, string noAmarre, string nombre,
            double cuota, int idOwner, bool disponibilidad, string urlFoto)
        {
            Matricula = matricula;
            NoAmarre = noAmarre;
            Nombre = nombre;
            Cuota = cuota;
            IdOwner = idOwner;
            Disponibilidad = disponibilidad;
            UrlFoto = urlFoto;
        }

        public VOBarco(DataRow fila)
        {
            IdBarco = (int)fila["IdBarco"];
            Matricula = (string)fila["Matricula"];
            NoAmarre = (string)fila["NoAmarre"];
            Nombre = (string)fila["Nombre"];
            Cuota = double.Parse(fila["Cuota"].ToString());
            IdOwner = int.Parse(fila["IdOwner"].ToString());
            Disponibilidad = bool.Parse(fila["Disponibilidad"].ToString());
            UrlFoto = (string)fila["UrlFoto"];
        }

        public VOBarco() { }
    }
}
