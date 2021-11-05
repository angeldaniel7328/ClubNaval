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
            VOPersona persona = new VOPersona("9212856444", "Col. Miguel Hidalgo", 
                "Angel Daniel", "adaniellova@gmail.com", ((int)Cargos.CAPITAN), true, 
                "https://photo.isu.pub/angeldaniel321/photo_large.jpg");

            DALPersona.InsertarPersona(persona);

            List<VOBarco> barcos = DALBarco.ConsultarBarcos(null);
            barcos.ForEach((VOBarco barco) => Console.WriteLine(barco.IdBarco));
            Console.ReadKey();
        }
    }
}
