using Prism.DryIoc;
using Prism.Ioc;
using Xamarin.Forms;
using XF_FreeDiving.Implements;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Repository.Helpers.Firebase;
using XF_FreeDiving.Repository.Helpers.Interfaces;
using XF_FreeDiving.Repository.Helpers.SQLite;
using XF_FreeDiving.Repository.Implements;
using XF_FreeDiving.Repository.Interfaces;
using XF_FreeDiving.Service.Impements;
using XF_FreeDiving.Service.Interfaces;
using XF_FreeDiving.ViewModels;
using XF_FreeDiving.ViewModels.About;
using XF_FreeDiving.Views;
using XF_FreeDiving.Views.Controls;

namespace XF_FreeDiving
{
    public partial class App
    {
        public App()
        {
        }

        /// <summary>
        /// Called when the PrismApplication has completed it's initialization process.
        /// </summary>
        protected override async void OnInitialized()
        {
            InitializeComponent();

            if (!string.IsNullOrEmpty(Settings.Email))
            {
                await NavigationService.NavigateAsync("AboutPage");
            }
            else
            {
                await NavigationService.NavigateAsync("LoginPage");
            }
            
        }

        /// <summary>
        /// [DI]注入相關都寫在這裡
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<AboutPage, AboutViewModel>();
            //[Repository]
            containerRegistry.RegisterScoped<ISQLiteHelper, DivingLogSQLiteHelper>();
            containerRegistry.RegisterScoped<IFirebaseHelper, DivingLogFirebaseHelper>();
            containerRegistry.RegisterScoped<IDataStore<DivingLog>, DivingLogFirebaseRepostiry>();

            //[Service]
            containerRegistry.RegisterScoped<IDivingLogService, DivingLogService>();

            //[Regions]
            containerRegistry.RegisterRegionServices();
            containerRegistry.RegisterForNavigation<LoginPage, LoginPageViewModel>();
        }
    }
}