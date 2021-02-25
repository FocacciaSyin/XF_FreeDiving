using System;
using SQLite;

namespace XF_FreeDiving.Repository.Entities
{
    public class DivingLog
    {
        [PrimaryKey, AutoIncrement]
        public Guid ID { get; set; }

        public string name { get; set; }

        public TimeSpan time { get; set; }

        public DateTime createDate { get; set; }

      
    }
}