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
    public class UserService : IUserService
    {
        private readonly IDataStore<User> _userRepository;

        public UserService(IDataStore<User> userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <returns></returns>
        public async Task<List<User>> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return users.ToList();
        }

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<User> GetByIdAsync(string id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(User item)
        {
            return await _userRepository.InsertAsync(item);
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<bool> UpdateItemAsync(User item)
        {
            return await _userRepository.UpdateItemAsync(item);
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public async Task<bool> DeleteItemAsync(string id)
        {
            return await _userRepository.DeleteItemAsync(id);
        }
    }
}
