using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluasi_Tengah_Semester
{
    public class ContactRepository
    {
        private readonly SQLiteAsyncConnection database;

        public ContactRepository(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Contact>().Wait();
        }

        public async Task<List<Contact>> GetContactsAsync()
        {
            return await database.Table<Contact>().ToListAsync();
        }

        public async Task<Contact> GetContactAsync(int id)
        {
            return await database.Table<Contact>().Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task InsertContact(Contact contact)
        {
            await database.InsertAsync(contact);
        }

        public async Task UpdateContact(Contact contact)
        {
            await database.UpdateAsync(contact);
        }

        public async Task DeleteContact(Contact contact)
        {
            await database.DeleteAsync(contact);
        }
    }



}
