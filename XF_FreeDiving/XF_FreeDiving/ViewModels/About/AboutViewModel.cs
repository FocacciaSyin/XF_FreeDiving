using Microcharts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_FreeDiving.Implements;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Service.Interfaces;

namespace XF_FreeDiving.ViewModels.About
{
    public partial class AboutViewModel : BaseViewModel
    {
        private readonly Stopwatch _stopwatch;

        private readonly IDivingLogService _divingLogService;
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
        /// </summary>
        /// <param name="divingLogService">The diving log service.</param>
        public AboutViewModel(IDivingLogService divingLogService, IUserService userService)
        {
            Title = "計時";

            this._divingLogService = divingLogService;
            this._userService = userService;
            this._stopwatch = new Stopwatch();

            Init();

            LogTypes = new List<LogType>()
            {
                new LogType(){ ID=1, Mode =  LogType.紀錄種類.碼表  , TypeName="碼表" },
                new LogType(){ ID=2, Mode = LogType.紀錄種類.目標計時 , TypeName="2:00" },
                new LogType(){ ID=3, Mode = LogType.紀錄種類.目標計時 , TypeName="2:30" },
            };

            TimeStartCommand = new Command(ExecuteStartTimer);
            TimeStopCommand = new Command(ExecuteStopTimer);
        }

        private async void Init()
        {
            //取得使用者資料
            Users = await _userService.GetAllAsync();

            if (Users.Count == 0)
            {
                var result = await _userService.InsertAsync(new User
                {
                    ID = Settings.Key,
                    UserName = Settings.UserName,
                    Email = Settings.Email,
                    ImageURL = Settings.Picture
                });

                if (result)
                {
                    Users = await _userService.GetAllAsync();
                }
            }

            //取得所有歷史資料
            DivingLogs = await _divingLogService.GetAllAsync();

            //取得所有人歷史資料，並轉換成圖表格式
            ChartData = await _divingLogService.GetChartData();
        }
    }
}