using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XF_FreeDiving.Models;

namespace XF_FreeDiving.Data
{
    /// <summary>
    /// 處理清單對SQLite的動作
    /// </summary>
    public class DivingLogDatabase
    {
        private static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;

        private static bool initialized = false;

        /// <summary>
        /// 建構式
        /// </summary>
        public DivingLogDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        /// <summary>
        ///初始化SQLite
        /// </summary>
        /// <returns></returns>
        private async Task InitializeAsync()
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

        /// <summary>
        /// 取得所有淺水的紀錄
        /// </summary>
        /// <returns></returns>
        public Task<List<DivingLog>> GetItemsAsync()
        {
            return Database.Table<DivingLog>().ToListAsync();
        }

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<DivingLog> GetItemAsync(int id)
        {
            return Database.Table<DivingLog>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 儲存物件
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 刪除資料庫項目
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public Task<int> DeleteItemAsync(DivingLog item)
        {
            return Database.DeleteAsync(item);
        }
    }
}