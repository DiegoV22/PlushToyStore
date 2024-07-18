using PlushToyStore.Models;
using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlushToyStore.Services
{
    public class PelucheService
    {
        private readonly SQLiteAsyncConnection _database;

        public PelucheService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Peluche>().Wait();
        }

        public Task<List<Peluche>> GetPeluchesAsync()
        {
            return _database.Table<Peluche>().ToListAsync();
        }

        public Task<int> AddPelucheAsync(Peluche peluche)
        {
            return _database.InsertAsync(peluche);
        }

        public Task<int> UpdatePelucheAsync(Peluche peluche)
        {
            return _database.UpdateAsync(peluche);
        }

        public Task<int> DeletePelucheAsync(Peluche peluche)
        {
            return _database.DeleteAsync(peluche);
        }
    }
}

