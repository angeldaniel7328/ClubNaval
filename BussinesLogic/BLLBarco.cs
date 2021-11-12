using System;
using System.Collections.Generic;
using Entities;
using DataAccess;

namespace BussinesLogic
{
    public static class BLLBarco
    {
        public static bool InsertarBarco(VOBarco barco)
        {
            try
            {
                return DALBarco.InsertarBarco(barco);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static bool ActualizarBarco(VOBarco barco)
        {
            try
            {
                return DALBarco.ActualizarBarco(barco);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static bool EliminarBarco(string idBarco)
        {
            try
            {
                return DALBarco.EliminarBarco(int.Parse(idBarco));
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static VOBarco ConsultarBarcoPorId(string idBarco)
        {
            VOBarco barco;
            try
            {
                barco = DALBarco.ConsultarBarcoPorId(int.Parse(idBarco));
                if (barco.Equals(null))
                    throw new ArgumentException("El id buscado no existe en la base de datos");
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
            return barco;
        }

        public static List<VOBarco> ConsultarBarcos(bool? disponibilidad)
        {
            List<VOBarco> barcos;
            try
            {
                barcos = DALBarco.ConsultarBarcos(disponibilidad);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
            return barcos;
        }

        public static List<VOBarco> ConsultarBarcosPorDueño(string idOwner, bool? disponibilidad)
        {
            List<VOBarco> barcos;
            try
            {
                barcos = DALBarco.ConsultarBarcosPorDueño(int.Parse(idOwner), disponibilidad);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
            return barcos;
        }
    }
}
