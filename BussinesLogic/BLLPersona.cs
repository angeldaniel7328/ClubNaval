using System;
using System.Collections.Generic;
using Entities;
using DataAccess;

namespace BussinesLogic
{
    public static class BLLPersona
    {
        public static bool InsertarPersona(VOPersona persona)
        {
            try
            {
                return DALPersona.InsertarPersona(persona);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static bool ActualizarPersona(VOPersona persona)
        {
            try
            {
                return DALPersona.ActualizarPersona(persona);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static bool EliminarPersona(string idPersona)
        {
            try
            {
                return DALPersona.EliminarPersona(int.Parse(idPersona));
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
        }

        public static VOPersona ConsultarPersonaPorId(string idPersona)
        {
            VOPersona persona;
            try
            {
                persona = DALPersona.ConsultarPersonaPorId(int.Parse(idPersona));
                if (persona.Equals(null))
                    throw new ArgumentException("El id buscado no existe en la base de datos");
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
            return persona;
        }

        public static List<VOPersona> ConsultarPersonas(bool? disponibilidad)
        {
            List<VOPersona> personas;
            try
            {
                personas = DALPersona.ConsultarPersonas(disponibilidad);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
            return personas;
        }

        public static List<VOPersona> ConsultarPersonasPorCargo(string cargo, bool? disponibilidad)
        {
            List<VOPersona> personas;
            try
            {
                personas = DALPersona.ConsultarPersonasPorCargo(int.Parse(cargo), disponibilidad);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Ocurrio un error " + e.Message);
            }
            return personas;
        }

        public static List<VOPersona> CatalogoPersona(int[] cargo, bool? disponibilidad)
        {
            List<VOPersona> catalogo = new List<VOPersona>();
            foreach (int c in cargo)
            {
                catalogo.AddRange(ConsultarPersonasPorCargo(c.ToString(), disponibilidad));
            }
            return catalogo;
        }
    }
}
