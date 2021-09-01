using Firebase.Database.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Repository.Helpers.Interfaces;
using XF_FreeDiving.Repository.Interfaces;

namespace XF_FreeDiving.Repository.Implements
{
    /// <summary>
    /// 使用FireBase處理閉氣紀錄
    /// </summary>
    /// <seealso cref="DivingLog"/>
    public class DivingLogFirebaseRepostiry : IDataStore<DivingLog>
    {
        private readonly IFirebaseHelper _firebase;

        /// <summary>
        /// Initializes a new instance of the <see cref="DivingLogFirebaseRepostiry"/> class.
        /// </summary>
        /// <param name="firebase">The firebase.</param>
        public DivingLogFirebaseRepostiry(IFirebaseHelper firebase)
        {
            _firebase = firebase;
        }

        /// <summary>
        /// 新增單筆資料
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns></returns>
        public async Task<bool> InsertAsync(DivingLog item)
        {
            try
            {
                var result = await _firebase
                    .GetFirebaseClient()
                    .Child("DivingLog")
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
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> UpdateItemAsync(DivingLog item)
        {
            try
            {
                await _firebase
                    .GetFirebaseClient()
                    .Child("DivingLog")
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
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<bool> DeleteItemAsync(string id)
        {
            try
            {
                if (Guid.TryParse(id, out Guid guidId))
                {
                    var toDeletePerson =
                        (await _firebase.GetFirebaseClient()
                            .Child("DivingLog")
                            .OnceAsync<DivingLog>())
                        .Where(a => a.Object.ID == guidId).FirstOrDefault();

                    await _firebase
                        .GetFirebaseClient()
                        .Child("DivingLog")
                        .Child(toDeletePerson.Key).DeleteAsync();
                }
                else
                {
                    return false;
                }
              

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// 透過Id取得資料
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<DivingLog> GetByIdAsync(string id)
        {
            if (Guid.TryParse(id, out Guid guidId))
            {
                var allPersons = await GetAllAsync();
                await _firebase.GetFirebaseClient()
                    .Child("DivingLog")
                    .OnceAsync<DivingLog>();

                return allPersons.Where(item => item.ID == guidId).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 取得所有資料
        /// </summary>
        /// <param name="forceRefresh">if set to <c>true</c> [force refresh].</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public async Task<List<DivingLog>> GetAllAsync(bool forceRefresh = false)
        {
            return (await _firebase.GetFirebaseClient()
                .Child("DivingLog")
                .OnceAsync<DivingLog>())
                .Select((item, i) => new DivingLog
                {
                    ID = item.Object.ID,
                    sort = i + 1,
                    name = item.Object.name,
                    time = item.Object.time,
                    createDate = item.Object.createDate,
                    UpOrDown = item.Object.UpOrDown
                }).ToList();
        }
    }
}