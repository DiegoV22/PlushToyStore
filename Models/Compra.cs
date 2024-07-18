using SQLite;
using SQLiteNetExtensions.Attributes;
using System;

namespace PlushToyStore.Models
{
    public class Compra
    {
        [PrimaryKey, AutoIncrement]
        public int IdCompra { get; set; }

        [ForeignKey(typeof(User))]
        public int IdUsuario { get; set; }

        [ForeignKey(typeof(Peluche))]
        public int IdPeluche { get; set; }

        public DateTime FechaCompra { get; set; }

        [ManyToOne]
        public User Usuario { get; set; }

        [ManyToOne]
        public Peluche Peluche { get; set; }
    }
}
