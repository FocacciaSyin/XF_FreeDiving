using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Repository.Helpers.Interfaces;
using XF_FreeDiving.Repository.Interfaces;

namespace XF_FreeDiving.Repository.Implements
{
    /// <summary>
    ///
    /// </summary>
    /// <seealso cref="XF_FreeDiving.Repository.Interfaces.IDataStore{XF_FreeDiving.Repository.Entities.User}" />
    public class UserFirebaseRepository : IDataStore<User>
    {
        private readonly IFirebaseHelper _firebase;

        public UserFirebaseRepository(IFirebaseHelper firebase)
        {
            _firebase = firebase;
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> DeleteItemAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <param name="forceRefresh">if set to <c>true</c> [force refresh].</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<User>> GetAllAsync(bool forceRefresh = false)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> InsertAsync(User item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> UpdateItemAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}