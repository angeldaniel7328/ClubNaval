using System;
using System.Data;

namespace Entities
{
    public class VOPersona
    {
        public int IdPersona { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public int? Cargo { get; set; }
        public bool? Disponibilidad { get; set; }
        public string UrlFoto { get; set; }

        public VOPersona(int idPersona, string telefono, string direccion, 
            string nombre, string correo, int? cargo, bool? disponibilidad, string urlFoto)
        {
            IdPersona = idPersona;
            Telefono = telefono;
            Direccion = direccion;
            Nombre = nombre;
            Correo = correo;
            Cargo = cargo;
            Disponibilidad = disponibilidad;
            UrlFoto = urlFoto;
        }

        public VOPersona(string telefono, string direccion, string nombre, 
            string correo, int? cargo, bool? disponibilidad, string urlFoto)
        {
            Telefono = telefono;
            Direccion = direccion;
            Nombre = nombre;
            Correo = correo;
            Cargo = cargo;
            Disponibilidad = disponibilidad;
            UrlFoto = urlFoto;
        }

        public VOPersona(DataRow fila)
        {
            IdPersona = (int)fila["IdPersona"];
            Telefono = (string)fila["Telefono"];
            Direccion = (string)fila["Direccion"];
            Nombre = (string)fila["Nombre"];
            Correo = (string)fila["Correo"];
            Cargo = (int)fila["Cargo"];
            Disponibilidad = (bool)fila["Disponibilidad"];
            UrlFoto = (string)fila["UrlFoto"];
        }
    }
}
