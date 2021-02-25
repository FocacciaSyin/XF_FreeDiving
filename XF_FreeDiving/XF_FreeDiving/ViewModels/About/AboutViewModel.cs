using Prism.Navigation;
using Prism.Regions;
using Prism.Regions.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Service.Interfaces;

namespace XF_FreeDiving.ViewModels.About
{
    public partial class AboutViewModel : BaseViewModel, IInitialize
    {
        private readonly Stopwatch _stopwatch;

        private List<DivingLog> _divingLogs;

        private IDivingLogService _divingLogService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AboutViewModel"/> class.
        /// </summary>
        /// <param name="divingLogService">The diving log service.</param>
        public AboutViewModel(IDivingLogService divingLogService, IRegionManager regionManager)
        {
            Title = "計時";

            this._divingLogService = divingLogService;
            this._regionManager = regionManager;
            this._stopwatch = new Stopwatch();

            Task.Run(async () =>
            {
                DivingLogs = await _divingLogService.GetAllAsync();
                DivingLogs = DivingLogs.OrderByDescending(r => r.createDate).ToList();
            });

            Data = new ObservableCollection<Model>() {
                new Model("Jan", 50),
                new Model("Feb", 70),
                new Model("Mar", 65),
                new Model("Apr", 57),
                new Model("May", 48) };

            LogTypes = new List<LogType>()
            {
                new LogType(){ ID=1, Mode =  LogType.紀錄種類.碼表  , TypeName="碼表" },
                new LogType(){ ID=2, Mode = LogType.紀錄種類.目標計時 , TypeName="2:00" },
                new LogType(){ ID=3, Mode = LogType.紀錄種類.目標計時 , TypeName="2:30" },
            };

            Users = new List<User>()
            {
                new User(){ ID=1,UserName="Woody", ImagePath="Image/Man.png"},
                new User(){ ID=2,UserName="BenBen", ImagePath="Image/Woman.png"}
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

        public ObservableCollection<Model> Data { get; set; }

        #region Prism-Region 相關

        /// <summary>
        /// Prism-Regions
        /// </summary>
        /// <value>The region manager.</value>
        private IRegionManager _regionManager { get; }

        /// <summary>
        /// Prism-Regions Init
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Initialize(INavigationParameters parameters)
        {
            //_regionManager.RequestNavigate("UserRegion", "Users", RegionNavigationCallback);
            //_regionManager.RequestNavigate("TypeRegion", "Types", RegionNavigationCallback);
        }

        /// <summary>
        /// Prism-Regions 相關
        /// </summary>
        /// <param name="result"></param>
        private void RegionNavigationCallback(IRegionNavigationResult result)
        {
            // Handle any errors or anything else you need to here...
        }

        #endregion Prism-Region 相關
    }
}