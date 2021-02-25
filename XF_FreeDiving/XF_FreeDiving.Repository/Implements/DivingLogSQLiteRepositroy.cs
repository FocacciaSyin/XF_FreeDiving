using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Repository.Helpers.Interfaces;
using XF_FreeDiving.Repository.Interfaces;

namespace XF_FreeDiving.Repository.Implements
{
    /// <summary>
    /// 使用SQLite對資料庫進行處理
    /// </summary>
    /// <seealso cref="XF_FreeDiving.Repository.Interfaces.IDataStore{XF_FreeDiving.Repository.Entities.DivingLog}"/>
    public class DivingLogSQLiteRepositroy : IDataStore<DivingLog>
    {
        private readonly ISQLiteHelper _sQLiteHelper;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivingLogSQLiteRepositroy"/> class.
        /// </summary>
        /// <param name="sQLiteHelper">The s q lite helper.</param>
        public DivingLogSQLiteRepositroy(ISQLiteHelper sQLiteHelper)
        {
            _sQLiteHelper = sQLiteHelper;
        }

        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> InsertAsync(DivingLog item)
        {
            var result = await _sQLiteHelper.GetSQLiteConnectionAsync().InsertAsync(item);
            if (result > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateItemAsync(DivingLog item)
        {
            var result = await _sQLiteHelper.GetSQLiteConnectionAsync().UpdateAsync(item);
            if (result > 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteItemAsync(Guid id)
        {
            var item = await GetByIdAsync(id);

            if (item != null)
            {
                var result = await _sQLiteHelper.GetSQLiteConnectionAsync().DeleteAsync(item);
                if (result > 0)
                    return true;
                else
                    return false;
            }

            return false;
        }

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<DivingLog> GetByIdAsync(Guid id)
        {
            return await _sQLiteHelper.GetSQLiteConnectionAsync().Table<DivingLog>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <param name="forceRefresh">if set to <c>true</c> [force refresh].</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<DivingLog>> GetAllAsync(bool forceRefresh = false)
        {
            return await _sQLiteHelper.GetSQLiteConnectionAsync().Table<DivingLog>().ToListAsync();
        }
    }
}