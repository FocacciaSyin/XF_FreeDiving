﻿using Xamarin.Forms;
using XF_FreeDiving.Data;
using XF_FreeDiving.Services;
using XF_FreeDiving.Views;

namespace XF_FreeDiving
{
    public partial class App : Application
    {
        private static DivingLogDatabase database;

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AboutPage();
        }

        /// <summary>
        /// SQLite設定
        /// </summary>
        public static DivingLogDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new DivingLogDatabase();
                }
                return database;
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}