using PlushToyStore.Models;
using SQLite;
using SQLiteNetExtensionsAsync.Extensions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlushToyStore.Services
{
    public class CompraService
    {
        private readonly SQLiteAsyncConnection _database;

        public CompraService(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Compra>().Wait();
        }

        public Task<List<Compra>> GetComprasAsync()
        {
            return _database.GetAllWithChildrenAsync<Compra>();
        }

        public Task AddCompraAsync(Compra compra)
        {
            return _database.InsertWithChildrenAsync(compra);
        }

        public Task UpdateCompraAsync(Compra compra)
        {
            return _database.UpdateWithChildrenAsync(compra);
        }

        public Task DeleteCompraAsync(Compra compra)
        {
            return _database.DeleteAsync(compra);
        }
    }
}
