using Microcharts;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Service.Interfaces;

namespace XF_FreeDiving.ViewModels.About
{
    public partial class AboutViewModel : BaseViewModel
    {
        private readonly Stopwatch _stopwatch;

        private List<DivingLog> _divingLogs;

        private readonly IDivingLogService _divingLogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
        /// </summary>
        /// <param name="divingLogService">The diving log service.</param>
        public AboutViewModel(IDivingLogService divingLogService)
        {
            Title = "計時";

            this._divingLogService = divingLogService;
            this._stopwatch = new Stopwatch();

            //取得所有歷史資料
            Task.Run(async () =>
            {
                _divingLogs = await _divingLogService.GetAllAsync();
                _divingLogs = _divingLogs.OrderByDescending(r => r.createDate).ToList();
            });

            //取得所有人歷史資料，並轉換成圖表格式
            Task.Run(async () =>
            {
                _chartData = await _divingLogService.GetChartData();
            });

            LogTypes = new List<LogType>()
            {
                new LogType(){ ID=1, Mode =  LogType.紀錄種類.碼表  , TypeName="碼表" },
                new LogType(){ ID=2, Mode = LogType.紀錄種類.目標計時 , TypeName="2:00" },
                new LogType(){ ID=3, Mode = LogType.紀錄種類.目標計時 , TypeName="2:30" },
            };

            Users = new List<User>()
            {
                new User(){ ID=1,UserName="Woody", ImagePath="Man.png"},
                new User(){ ID=2,UserName="BenBen", ImagePath="Woman.png"}
            };

            TimeStartCommand = new Command(ExecuteStartTimer);
            TimeStopCommand = new Command(ExecuteStopTimer);
        }

        /// <summary>
        /// 歷史紀錄
        /// </summary>
        public List<DivingLog> DivingLogs
        {
            get { return _divingLogs; }
            set { SetProperty(ref _divingLogs, value); }
        }

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
    }
}