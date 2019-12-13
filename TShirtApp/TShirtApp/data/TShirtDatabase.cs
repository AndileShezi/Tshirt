using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TShirtApp.models;

namespace TShirtApp.data
{
    public class TShirtDatabase
    {
        private SQLiteAsyncConnection database;

        public TShirtDatabase(string dbPath)
        {

            database = new SQLiteAsyncConnection(dbPath); 
            database.CreateTableAsync<TShirtDetails>().Wait();

            
           
        }

        public Task<List<TShirtDetails>> GetTShirtAsync()
        {
            return database.Table<TShirtDetails>().ToListAsync();
        }

        public Task<List<TShirtDetails>> GetTShirtNotDoneAsync()
        {
            return database.QueryAsync<TShirtDetails>("Select * From [TShirtDetails] Where [Done] = 0");
        }

        public async Task<TShirtDetails> GetTShirtAsync(int id)
        {
            var latest = await database.Table<TShirtDetails>().Where(i => i.ID == id).FirstOrDefaultAsync();

            return latest;
        }


        public async void UpdateProduct(TShirtDetails TShirt)
        {
            await database.UpdateAsync(TShirt);
        }

     /*   public Task<int> SaveTShirtAsync(TShirtDetails TShirt)
        {
            if (TShirt.ID != 0)
            {
                return database.UpdateAsync(TShirt);
            }
            else
            {
                return database.InsertAsync(TShirt);
            }
        } */

        public Task<int> DeleteTShirtAsync(TShirtDetails item)
        {
            return database.DeleteAsync(item);
        }

    }
}
