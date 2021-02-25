using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Repository.Interfaces;
using XF_FreeDiving.Service.Interfaces;

namespace XF_FreeDiving.Service.Impements
{
    /// <summary>
    /// DivingLogService
    /// </summary>
    /// <seealso cref="XF_FreeDiving.Service.Interfaces.IDivingLogService" />
    public class DivingLogService : IDivingLogService
    {
        private readonly IDataStore<DivingLog> _dataStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivingLogService"/> class.
        /// </summary>
        /// <param name="dataStore">The data store.</param>
        public DivingLogService(IDataStore<DivingLog> dataStore)
        {
            _dataStore = dataStore;
        }
        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> InsertAsync(DivingLog item)
        {
            return await _dataStore.InsertAsync(item);
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> UpdateItemAsync(DivingLog item)
        {
            return await _dataStore.UpdateItemAsync(item);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> DeleteItemAsync(Guid id)
        {
            return await _dataStore.DeleteItemAsync(id);
        }

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<DivingLog> GetByIdAsync(Guid id)
        {
            return await _dataStore.GetByIdAsync(id);
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        public async Task<List<DivingLog>> GetAllAsync()
        {
            return await _dataStore.GetAllAsync();
        }
    }
}
