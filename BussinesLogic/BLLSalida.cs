using System;
using System.Collections.Generic;
using Entities;
using DataAccess;

namespace BussinesLogic
{
    public static class BLLSalida
    {
        public static bool InsertarSalida(VOSalida salida)
        {
            try
            {
                BLLPersona.ActualizarPersona(new VOPersona()
                {
                    IdPersona = salida.IdPersona,
                    Disponibilidad = false
                });
                BLLBarco.ActualizarBarco(new VOBarco()
                {
                    IdBarco = salida.IdBarco,
                    Disponibilidad = false
                });
                return DALSalida.InsertarSalida(salida);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static bool FinalizarSalida(string idSalida)
        {
            try
            {
                return DALSalida.FinalizarSalida(int.Parse(idSalida), 
                    Enum.GetName(typeof(EstadoSalida), EstadoSalida.FINALIZADA));
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static List<VOSalida> ConsultarSalidaPorEstado(string estado)
        {
            try
            {
                return DALSalida.ConsultarSalidasPorEstado(estado);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static List<VOSalidaExtendida> ConsultarSalidaPorEstadoExtendida(string estado)
        {
            try
            {
                return DALSalida.ConsultarSalidasPorEstadoExtendida(estado);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static VOSalida ConsultarSalidaPorId(string idSalida)
        {
            try
            {
                return DALSalida.ConsultarSalidasPorId(int.Parse(idSalida));
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static VOSalidaExtendida ConsultarSalidaPorIdExtendida(string idSalida)
        {
            try
            {
                return DALSalida.ConsultarSalidasPorIdExtendida(int.Parse(idSalida));
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }
    }
}
