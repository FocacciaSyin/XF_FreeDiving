using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Repository.Interfaces;

namespace XF_FreeDiving.Repository.Implements
{
    public class UserFirebaseRepository : IDataStore<User>
    {
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

        public Task<User> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> InsertAsync(User item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}