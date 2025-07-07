using SQLite;
using MulloJ_ExamenP3.Models;

namespace MulloJ_ExamenP3.Repositories
{
    public class SuscripcionRepository
    {
        private readonly SQLiteAsyncConnection _database;

        public SuscripcionRepository(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Suscripcion>().Wait();
        }

        public Task<List<Suscripcion>> ObtenerSuscripcionesAsync()
        {
            return _database.Table<Suscripcion>().ToListAsync();
        }

        public Task<int> AgregarSuscripcionAsync(Suscripcion suscripcion)
        {
            return _database.InsertAsync(suscripcion);
        }

        public Task<int> EliminarSuscripcionAsync(Suscripcion suscripcion)
        {
            return _database.DeleteAsync(suscripcion);
        }

        public Task<int> ActualizarSuscripcionAsync(Suscripcion suscripcion)
        {
            return _database.UpdateAsync(suscripcion);
        }
    }
}