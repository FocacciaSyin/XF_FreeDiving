using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using XF_FreeDiving.Models;
using System.Linq;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms.Internals;

namespace XF_FreeDiving.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {

        Stopwatch Stopwatch;

        #region 畫面元件

        private string _name;
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        #endregion

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
        #endregion



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
            TimeStopommand = new Command(ExecuteStopTimer);
        }

        /// <summary>
        /// 觸發停止
        /// </summary>
        private void ExecuteStopTimer()
        {
            Stopwatch.Stop();

            IsStart = true;
            IsStop = false;
            //執行 Insert
            DivingLog itemDivingLog = new DivingLog();
            itemDivingLog.ID = 0;
            itemDivingLog.name = Name;
            itemDivingLog.time = Timer;
            //寫入資料到 Sqlite;
            Task.Run(async () =>
            {
                await App.Database.SaveItemAsync(itemDivingLog);
                DivingLogs = await App.Database.GetItemsAsync();
                DivingLogs = DivingLogs.OrderByDescending(r => r.ID).ToList();
            });
        }

        private void ExecuteStartTimer()
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

        public ICommand OpenWebCommand { get; }
        public ICommand TimeStartCommand { get; set; }
        public ICommand TimeStopommand { get; set; }



    }
}