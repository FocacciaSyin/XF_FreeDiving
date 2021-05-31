using Microcharts;
using System;
using System.Collections.Generic;
using XF_FreeDiving.Repository.Entities;

namespace XF_FreeDiving.ViewModels.About
{
    public partial class AboutViewModel
    {
        #region User

        private List<User> _users;
        private User _selectedUser = null;

        public User SelectedUser
        {
            get { return _selectedUser; }
            set { if (_selectedUser != value) { _selectedUser = value; } }
        }

        public List<User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        #endregion User

        #region Type

        private List<LogType> _logTypes;
        private LogType _selectedLogType;

        public LogType SelectedLogType
        {
            get { return _selectedLogType; }
            set { if (_selectedLogType != value) { _selectedLogType = value; } }
        }

        public List<LogType> LogTypes
        {
            get { return _logTypes; }
            set { SetProperty(ref _logTypes, value); }
        }

        #endregion Type

        #region 按鈕顯示隱藏

        private bool _isStart = true;
        private bool _isStop = false;

        public bool IsStart
        {
            get { return _isStart; }
            set { SetProperty(ref _isStart, value); }
        }

        public bool IsStop
        {
            get { return _isStop; }
            set { SetProperty(ref _isStop, value); }
        }

        #endregion 按鈕顯示隱藏

        #region 計數器

        private TimeSpan _timer;

        public TimeSpan Timer
        {
            get { return _timer; }
            set { SetProperty(ref _timer, value); }
        }

        #endregion 計數器

        #region 歷史紀錄

        private List<DivingLog> _divingLogs;

        /// <summary>
        /// 歷史紀錄
        /// </summary>
        public List<DivingLog> DivingLogs
        {
            get { return _divingLogs; }
            set { SetProperty(ref _divingLogs, value); }
        }

        #endregion 歷史紀錄

        #region 圖表

        private LineChart _chartData;

        /// <summary>
        /// 取得圖表資料
        /// </summary>
        /// <value>
        /// The chart data.
        /// </value>
        public LineChart ChartData
        {
            get { return _chartData; }
            set { SetProperty(ref _chartData, value); }
        }

        #endregion 圖表
    }
}