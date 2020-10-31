using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XF_FreeDiving.Models
{
    public class DivingLog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string name { get; set; }
        public TimeSpan time { get; set; }
    }
}
