using System;
using SQLite;

namespace XF_FreeDiving.Repository.Entities
{
    public class User
    {
        /// <summary>
        /// 使用者編號
        /// </summary>
        [PrimaryKey]
        public string ID { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 使用者大頭貼
        /// </summary>
        public string ImageURL { get; set; }
    }
}