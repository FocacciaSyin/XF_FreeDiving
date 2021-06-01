using System;
using SQLite;

namespace XF_FreeDiving.Repository.Entities
{
    public class DivingLog
    {
        /// <summary>
        /// 編號
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [PrimaryKey, AutoIncrement]
        public Guid ID { get; set; }

        /// <summary>
        /// 序號
        /// </summary>
        /// <value>
        /// The sort.
        /// </value>
        public int sort { get; set; }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string name { get; set; }

        /// <summary>
        /// 憋氣時間
        /// </summary>
        /// <value>
        /// The time.
        /// </value>
        public TimeSpan time { get; set; }

        /// <summary>
        /// 建立日期
        /// </summary>
        /// <value>
        /// The create date.
        /// </value>
        public DateTime createDate { get; set; }

        /// <summary>
        /// 判斷比前一次是進步或是退步
        /// 設定 FontAwesomeIcons<br/>
        /// 
        /// 上升 : ChevronCircleUp<br/>
        /// 
        /// 下降 : ChevronDoubleDown
        /// </summary>
        /// <value>
        /// Up or down.
        /// </value>
        public string UpOrDown { get; set; }
    }
}