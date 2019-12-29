using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using FlashcardURL.Models;
using System.Threading.Tasks;
using System.Diagnostics;

namespace FlashcardURL.ViewModel
{

    public class FlashCardBusiness
    {
        readonly SQLiteAsyncConnection database;

        public FlashCardBusiness(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Flashcard>().Wait();
            database.CreateTableAsync<SavedList>().Wait();
        }


        public async Task<List<Flashcard>> GetSearchListAsync(string Tags, string searchtext)
        {
            string[] tags = Tags.Split(' ');
            List<Flashcard> result;
            var list = await GetItemsAsync();
            if (Tags == "")
            {
                result = list;
            }
            else
            {
                result = new List<Flashcard>();

                foreach (Flashcard f in list)
                {

                    var check = true;
                    foreach (string tag in tags)
                    {
                        if (f.Tags == null)
                        {
                            check = false;
                            break;
                        }
                        if (!f.Tags.Contains(tag))
                        {
                            check = false;
                            break;
                        }
                    }



                    if (check)
                    {
                        result.Add(f);
                    }
                }
            }
            var result1 = new List<Flashcard>();
            if (searchtext != "")
            {
                foreach (Flashcard f in result)
                {
                   if (f.Name.ToLower().Contains(searchtext.ToLower()))
                    {
                        result1.Add(f);
                    }
                }
            }
            else
            {
                return result;
            }
            return result1;
        }
        public Task<List<Flashcard>> GetItemsAsync()
        {
            return database.Table<Flashcard>().ToListAsync();
        }

        public Task<List<SavedList>> GetSavedListsAsync()
        {
            return database.Table<SavedList>().ToListAsync();
        }

        public Task<List<Flashcard>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Flashcard>("SELECT * FROM [Flashcard] WHERE [Done] = 0");
        }

        public Task<Flashcard> GetItemAsync(int id)
        {
            return database.Table<Flashcard>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<SavedList> GetSavedListAsync(int id) {
             return database.Table<SavedList>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Flashcard item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> SaveSavedListAsync(SavedList item) {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Flashcard item)
        {
            return database.DeleteAsync(item);
        }

        public Task<int> DeleteSavedListAsync(SavedList item)
        {
            return database.DeleteAsync(item);
        }
        public  Task<int> DropDataBase()
        {
            return  database.DropTableAsync<Flashcard>();
        }
    }
}
