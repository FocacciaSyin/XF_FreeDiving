using Firebase.Database;
using XF_FreeDiving.Repository.Helpers.Interfaces;

namespace XF_FreeDiving.Repository.Helpers.Firebase
{
    /// <summary>
    /// 取得 FirebaseDatabase 連線字串
    /// </summary>
    /// <seealso cref="IFirebaseHelper" />
    public class DivingLogFirebaseHelper : IFirebaseHelper
    {
        private readonly FirebaseClient _firebase = new FirebaseClient("https://xf-freediving-default-rtdb.firebaseio.com/");

        /// <summary>
        /// Gets the firebase client.
        /// </summary>
        /// <returns></returns>
        public FirebaseClient GetFirebaseClient()
        {
            return _firebase;
        }
    }
}
