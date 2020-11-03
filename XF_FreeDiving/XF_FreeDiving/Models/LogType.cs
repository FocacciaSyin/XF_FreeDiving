using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF_FreeDiving.Models
{
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
