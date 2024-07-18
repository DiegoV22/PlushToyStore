// Models/Peluche.cs
using SQLite;

namespace PlushToyStore.Models
{
    public class Peluche
    {
        [PrimaryKey, AutoIncrement]
        public int IdPeluche { get; set; }
        public string NombreP { get; set; }
        public string TamanoP { get; set; }
        public string DescripcionP { get; set; }
        public decimal Precio { get; set; }
    }
}

