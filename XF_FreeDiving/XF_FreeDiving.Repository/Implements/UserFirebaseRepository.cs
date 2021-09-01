using Firebase.Database.Query;
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
    /// 使用FireBase處理使用者資料
    /// </summary>
    public class UserFirebaseRepository : IDataStore<User>
    {
        private readonly IFirebaseHelper _firebase;
        private readonly string _DbName = "User";
        public UserFirebaseRepository(IFirebaseHelper firebase)
        {
            _firebase = firebase;
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <param name="forceRefresh">if set to <c>true</c> [force refresh].</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<List<User>> GetAllAsync(bool forceRefresh = false)
        {
            return (await _firebase.GetFirebaseClient()
                    .Child(_DbName)
                    .OnceAsync<User>())
                .Select((item, i) => new User
                {
                    ID = item.Object.ID,
                    UserName = item.Object.UserName,
                    ImageURL = item.Object.ImageURL
                }).ToList();
        }

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<User> GetByIdAsync(string id)
        {
            return (await _firebase.GetFirebaseClient()
                    .Child(_DbName)
                    .OnceAsync<User>())
                .Select((item, i) => new User
                {
                    ID = item.Object.ID,
                    UserName = item.Object.UserName,
                    ImageURL = item.Object.ImageURL
                }).FirstOrDefault(p => p.ID == id);
        }

        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> InsertAsync(User item)
        {
            try
            {
                var result = await _firebase
                    .GetFirebaseClient()
                    .Child(_DbName)
                    .PostAsync(item, true);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 更新資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> UpdateItemAsync(User item)
        {
            try
            {
                await _firebase
                    .GetFirebaseClient()
                    .Child(_DbName)
                    .PutAsync(item);

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 刪除資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<bool> DeleteItemAsync(string id)
        {
            try
            {
                var toDeletePerson =
                    (await _firebase.GetFirebaseClient()
                        .Child(_DbName)
                        .OnceAsync<User>())
                    .Where(a => a.Object.ID == id).FirstOrDefault();

                await _firebase
                    .GetFirebaseClient()
                    .Child(_DbName)
                    .Child(toDeletePerson.Key).DeleteAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}