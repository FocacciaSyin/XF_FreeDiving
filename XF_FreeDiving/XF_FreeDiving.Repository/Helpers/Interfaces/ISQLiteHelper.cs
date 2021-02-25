using SQLite;

namespace XF_FreeDiving.Repository.Helpers.Interfaces
{
    /// <summary>
    /// SQLite 連線相關介面
    /// </summary>
    public interface ISQLiteHelper
    {
        /// <summary>
        /// 初始化相關設定
        /// </summary>
        /// <returns></returns>
        SQLiteAsyncConnection GetSQLiteConnectionAsync();


    }
}
