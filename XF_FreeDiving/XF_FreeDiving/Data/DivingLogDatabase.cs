using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF_FreeDiving.Models;

namespace XF_FreeDiving.Data
{
    public class DivingLogDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DivingLogDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(DivingLog).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(DivingLog)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }


        public Task<List<DivingLog>> GetItemsAsync()
        {
            return Database.Table<DivingLog>().ToListAsync();
        }

        public Task<List<DivingLog>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<DivingLog>("SELECT * FROM [DivingLog] WHERE [Name] = 'David'");
        }

        public Task<DivingLog> GetItemAsync(int id)
        {
            return Database.Table<DivingLog>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(DivingLog item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(DivingLog item)
        {
            return Database.DeleteAsync(item);
        }
    }
}
