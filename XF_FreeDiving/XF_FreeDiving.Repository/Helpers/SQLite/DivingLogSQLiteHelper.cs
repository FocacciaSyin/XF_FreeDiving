using SQLite;
using System;
using System.Linq;
using System.Threading.Tasks;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Repository.Helpers.Interfaces;

namespace XF_FreeDiving.Repository.Helpers.SQLite
{
    /// <summary>
    /// 處理清單對SQLite的動作
    /// </summary>
    public class DivingLogSQLiteHelper : ISQLiteHelper
    {
        private readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
       {
           return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
       });

        private bool initialized = false;

        /// <summary>
        /// 建構式
        /// </summary>
        public DivingLogSQLiteHelper()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        private SQLiteAsyncConnection _database => lazyInitializer.Value;

        /// <summary>
        /// 初始化相關設定
        /// </summary>
        /// <returns></returns>
        public SQLiteAsyncConnection GetSQLiteConnectionAsync()
        {
            return _database;
        }

        /// <summary>
        ///初始化SQLite
        /// </summary>
        /// <returns></returns>
        private async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!_database.TableMappings.Any(m => m.MappedType.Name == typeof(DivingLog).Name))
                {
                    await _database.CreateTablesAsync(CreateFlags.None, typeof(DivingLog)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }
    }
}