﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF_FreeDiving.Models;

namespace XF_FreeDiving.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private Stopwatch Stopwatch;

        private LogType _selectedLogType;

        public LogType SelectedLogType
        {
            get
            {
                return _selectedLogType;
            }
            set
            {
                if (_selectedLogType != value)
                {
                    _selectedLogType = value;
                }
            }
        }

        private User _selectedUser = null;

        public User SelectedUser
        {
            get
            {
                return _selectedUser;
            }
            set
            {
                if (_selectedUser != value)
                {
                    _selectedUser = value;
                }
            }
        }

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

        private List<LogType> _logTypes;

        public List<LogType> LogTypes
        {
            get { return _logTypes; }
            set { SetProperty(ref _logTypes, value); }
        }

        private List<User> _users;

        public List<User> Users
        {
            get { return _users; }
            set { SetProperty(ref _users, value); }
        }

        private TimeSpan _timer;

        public TimeSpan Timer
        {
            get { return _timer; }
            set { SetProperty(ref _timer, value); }
        }

        private List<DivingLog> _divingLogs;

        public List<DivingLog> DivingLogs
        {
            get { return _divingLogs; }
            set { SetProperty(ref _divingLogs, value); }
        }

        public AboutViewModel()
        {
            Stopwatch = new Stopwatch();
            Title = "計時";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));

            Task.Run(async () =>
            {
                DivingLogs = await App.Database.GetItemsAsync();
                DivingLogs = DivingLogs.OrderByDescending(r => r.ID).ToList();
            });

            Users = new List<User>()
            {
                 new User(){ID=1,UserName="Woody", ImagePath="Image/Man.png"},
                 new User(){ID=2,UserName="BenBen", ImagePath="Image/Woman.png"}
            };

            LogTypes = new List<LogType>()
            {
                new LogType(){ ID=1, Mode =  Models.LogType.紀錄種類.碼表  , TypeName="碼表" },
                new LogType(){ ID=2, Mode = Models.LogType.紀錄種類.目標計時 , TypeName="2:00" },
                new LogType(){ ID=3, Mode = Models.LogType.紀錄種類.目標計時 , TypeName="2:30" },
            };

            //DivingLogs = new ObservableCollection<DivingLog>()
            //{
            //    new DivingLog(){ ID=1, name="DAVID", time = new TimeSpan(0, 2, 30)},
            //    new DivingLog(){ ID=2, name="DAVID", time = new TimeSpan(0, 2, 10)},
            //    new DivingLog(){ ID=3, name="DAVID", time = new TimeSpan(0, 1, 30)},
            //    new DivingLog(){ ID=4, name="BENBEN", time = new TimeSpan(0, 2, 10)}
            //};
            //IsStart = true;
            //IsStop = false;

            TimeStartCommand = new Command(ExecuteStartTimer);
            TimeStopCommand = new Command(ExecuteStopTimer);
        }

        /// <summary>
        /// 觸發停止
        /// </summary>
        private async void ExecuteStopTimer()
        {
            Stopwatch.Stop();

            IsStart = true;
            IsStop = false;

            if (SelectedUser != null)
            {
                //執行 Insert
                DivingLog itemDivingLog = new DivingLog()
                {
                    ID = 0,
                    name = SelectedUser.UserName,
                    time = Timer,
                    createDate = DateTime.Now
                };

                //寫入資料到 Sqlite;
                await Task.Run(async () =>
                 {
                     await App.Database.SaveItemAsync(itemDivingLog);
                     DivingLogs = await App.Database.GetItemsAsync();
                     DivingLogs = DivingLogs.OrderByDescending(r => r.ID).ToList();
                 });
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("注意", "請先選擇使用者", "OK");
            }
        }

        /// <summary>
        /// 開始計時
        /// </summary>
        private async void ExecuteStartTimer()
        {
            if (SelectedUser != null)
            {
                Stopwatch.Restart();
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    Timer = Stopwatch.Elapsed;
                    return true;
                });

                IsStart = false;
                IsStop = true;
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("注意", "請先選擇使用者", "OK");
            }
        }

        public ICommand OpenWebCommand { get; }
        public ICommand TimeStartCommand { get; set; }
        public ICommand TimeStopCommand { get; set; }

        private ICommand _deleteCommand;

        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new Command<DivingLog>(async item =>
                    {
                        var result = await App.Current.MainPage.DisplayAlert("提示", $"是否確定刪除?({item.ID})", "OK", "Cancel");
                        if (result)
                        {
                            var itemDivingLog = await App.Database.GetItemAsync(item.ID);
                            if (itemDivingLog != null)
                            {
                                await App.Database.DeleteItemAsync(itemDivingLog);
                            }

                            DivingLogs = await App.Database.GetItemsAsync();
                            DivingLogs = DivingLogs.OrderByDescending(r => r.ID).ToList();
                        }
                    });
                }
                return _deleteCommand;
            }
        }
    }
}