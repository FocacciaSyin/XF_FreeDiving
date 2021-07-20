using Firebase.Database;

namespace XF_FreeDiving.Repository.Helpers.Interfaces
{
    /// <summary>
    /// 使用FireBase連線相關介面
    /// </summary>
    public interface IFirebaseHelper
    {
        /// <summary>
        /// 取得 FireBase 連線設定
        /// </summary>
        /// <returns></returns>
        FirebaseClient GetFirebaseClient();
    }
}
