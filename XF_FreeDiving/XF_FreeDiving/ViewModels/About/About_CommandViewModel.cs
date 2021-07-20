using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XF_FreeDiving.Repository.Entities;

namespace XF_FreeDiving.ViewModels.About
{
    public partial class AboutViewModel
    {
        private ICommand _deleteCommand;

        /// <summary>
        /// 觸發開始按鈕
        /// </summary>
        public ICommand TimeStartCommand { get; set; }

        /// <summary>
        /// 觸發停止按鈕
        /// </summary>
        public ICommand TimeStopCommand { get; set; }

        /// <summary>
        /// 刪除按鈕
        /// </summary>
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
                            await _divingLogService.DeleteItemAsync(item.ID);

                            await LoadValue();
                        }
                    });
                }
                return _deleteCommand;
            }
        }

        /// <summary>
        /// 觸發停止
        /// </summary>
        private async void ExecuteStopTimer()
        {
            string _upOrDown = null;
            _stopwatch.Stop();

            IsStart = true;
            IsStop = false;

            if (SelectedUser != null)
            {
                //取得前一筆資料
                var lastData = await _divingLogService.GetUserLastDateAsync(SelectedUser.UserName);
                if (lastData != null)
                {
                    _upOrDown = (Timer > lastData.time) ? FontAwesomeIcons.ChevronCircleUp : FontAwesomeIcons.ChevronCircleDown;
                }

                //執行 Insert
                DivingLog itemDivingLog = new DivingLog()
                {
                    ID = Guid.NewGuid(),
                    name = SelectedUser.UserName,
                    time = Timer,
                    createDate = DateTime.Now,
                    UpOrDown = _upOrDown
                };

                //寫入資料;
                await _divingLogService.InsertAsync(itemDivingLog);
                await LoadValue();
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
                _stopwatch.Restart();
                Device.StartTimer(TimeSpan.FromMilliseconds(100), () =>
                {
                    Timer = _stopwatch.Elapsed;
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

        /// <summary>
        /// 取得當下最新資料
        /// </summary>
        private async Task LoadValue()
        {
            DivingLogs = await _divingLogService.GetAllAsync();
            ChartData = await _divingLogService.GetChartData(SelectedUser?.UserName);
        }
    }
}