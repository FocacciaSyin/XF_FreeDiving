using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF_FreeDiving.Repository.Entities;

namespace XF_FreeDiving.Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<bool> InsertAsync(User item);

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        Task<bool> UpdateItemAsync(User item);

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<bool> DeleteItemAsync(string id);

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<User> GetByIdAsync(string id);

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        Task<List<User>> GetAllAsync();

    }
}
