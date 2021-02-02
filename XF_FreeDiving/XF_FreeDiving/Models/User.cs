using SQLite;

namespace XF_FreeDiving.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string UserName { get; set; }
        public string ImagePath { get; set; }
    }
}