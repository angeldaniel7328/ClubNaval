﻿using System;
using System.Data;

namespace Entities
{
    public class VOSalida
    {
        public int IdSalida { get; set; }
        public DateTime? FechaHoraSalida { get; set; }
        public string Destino { get; set; }
        public string Estado { get; set; }
        public int IdBarco { get; set; }
        public int IdPersona { get; set; }

        public VOSalida(DataRow fila)
        {
            IdSalida = int.Parse(fila["IdSalida"].ToString());
            FechaHoraSalida = (DateTime?)fila["FechaHoraSalida"];
            Destino = (string)fila["Destino"];
            Estado = (string)fila["Estado"];
            IdBarco = int.Parse(fila["IdBarco"].ToString());
            IdPersona = int.Parse(fila["IdPersona"].ToString());
        }

        public VOSalida(int idSalida, DateTime? fechaHoraSalida, string destino, string estado, int idBarco, int idPersona)
        {
            IdSalida = idSalida;
            FechaHoraSalida = fechaHoraSalida;
            Destino = destino;
            Estado = estado;
            IdBarco = idBarco;
            IdPersona = idPersona;
        }

        public VOSalida(DateTime? fechaHoraSalida, string destino, string estado, int idBarco, int idPersona)
        {
            FechaHoraSalida = fechaHoraSalida;
            Destino = destino;
            Estado = estado;
            IdBarco = idBarco;
            IdPersona = idPersona;
        }

        public VOSalida()
        {

        }

    }

    public enum EstadoSalida
    {
        EN_PROCESO,
        FINALIZADA
    }

}
