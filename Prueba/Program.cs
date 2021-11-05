using DataAccess;
using Entities;
using System;
using System.Collections.Generic;

namespace Prueba
{
    class Program
    {
        static void Main(string[] args)
        {
            List<VOPersona> personas = DALPersona.ConsultarPersonas(null);
            personas.ForEach((VOPersona persona) => Console.WriteLine(persona.Nombre));
            Console.ReadKey();
        }
    }
}
