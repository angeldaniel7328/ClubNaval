using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class VOSalidaExtendida: VOSalida
    {
        public string NombreBarco { get; set; }
        public string UrlFotoBarco { get; set; }
        public string NombreCapitan { get; set; }
        public string UrlFotoCapitan { get; set; }

        public VOSalidaExtendida(DataRow fila) : base(fila) {
            NombreBarco = (string)fila["NombreBarco"];
            UrlFotoBarco = (string)fila["UrlFotoBarco"];
            NombreCapitan = (string)fila["NombreCapitan"];
            UrlFotoCapitan = (string)fila["UrlFotoCapitan"];
        }

        public VOSalidaExtendida(int idSalida, DateTime? fechaHoraSalida, string destino, 
            string estado, int idBarco, int idPersona, string nombreBarco, string urlFotoBarco, 
            string nombreCapitan, string urlFotoCapitan)
            : base(idSalida, fechaHoraSalida, destino, estado, idBarco, idPersona)
        {
            NombreBarco = nombreBarco;
            UrlFotoBarco = urlFotoBarco;
            NombreCapitan = nombreCapitan;
            UrlFotoCapitan = urlFotoCapitan;
        }

        public VOSalidaExtendida(DateTime? fechaHoraSalida, string destino,
            string estado, int idBarco, int idPersona, string nombreBarco, string urlFotoBarco,
            string nombreCapitan, string urlFotoCapitan)
            : base(fechaHoraSalida, destino, estado, idBarco, idPersona)
        {
            NombreBarco = nombreBarco;
            UrlFotoBarco = urlFotoBarco;
            NombreCapitan = nombreCapitan;
            UrlFotoCapitan = urlFotoCapitan;
        }
    }
}
