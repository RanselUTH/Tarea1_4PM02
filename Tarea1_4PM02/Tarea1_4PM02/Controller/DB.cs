using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tarea1_4PM02.Models;

namespace Tarea1_4PM02.Controller
{
    public class DB
    {
        readonly SQLiteAsyncConnection db;
        public DB(string path)
        {
            db = new SQLiteAsyncConnection(path);
            db.CreateTableAsync<Foto>();
        }
        #region CRUD
        public Task<int> insertUpdateFoto(Foto img)
        {
            if (img.id != 0)
            {
                return db.UpdateAsync(img);
            }
            else
            {
                return db.InsertAsync(img);
            }
        }
        public Task<List<Foto>> getListFotos()
        {
            return db.Table<Foto>().ToListAsync();
        }

        public Task<Foto> getFoto(int id)
        {
            return db.Table<Foto>()
                .Where(i => i.id == id)
                .FirstOrDefaultAsync();
        }
        public Task<int> delFoto(Foto img)
        {
            return db.DeleteAsync(img);
        }

        #endregion CRUD
    }
}

