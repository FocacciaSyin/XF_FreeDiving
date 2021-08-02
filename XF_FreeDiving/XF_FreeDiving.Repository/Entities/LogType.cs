using SQLite;

namespace XF_FreeDiving.Repository.Entities
{
    /// <summary>
    /// 紀錄時間的種類
    /// </summary>
    public class LogType
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public 紀錄種類 Mode { get; set; }
        public string TypeName { get; set; }

        public enum 紀錄種類
        {
            碼表,
            目標計時,
            多人計時
        }
    }
}