using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace XF_FreeDiving.Repository.Interfaces
{
    /// <summary>
    /// 共用基本對資料庫存取一定會用到的方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDataStore<T>
    {
        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<bool> InsertAsync(T item);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<bool> UpdateItemAsync(T item);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> DeleteItemAsync(Guid id);

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<T> GetByIdAsync(Guid id);


        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <param name="forceRefresh">if set to <c>true</c> [force refresh].</param>
        /// <returns></returns>
        Task<List<T>> GetAllAsync(bool forceRefresh = false);
    }
}