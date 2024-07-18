// Models/User.cs
using System;
using SQLite;

namespace PlushToyStore.Models
{
    public class User
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int IdUsuario { get; set; }

        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string CorreoElectronico { get; set; }
        public DateTime FechaNacimiento { get; set; }
    }
}



