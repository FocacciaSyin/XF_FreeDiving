using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XF_FreeDiving.Implements
{
    /// <summary>
    /// 登入使用者設定檔
    /// </summary>
    public static class Settings
    {
        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        #endregion Setting Constants

        /// <summary>
        /// key
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public static string Key
        {
            get
            {
                return Preferences.Get("key", SettingsDefault);
            }
            set
            {
                Preferences.Set("key", value);
            }
        }

        /// <summary>
        /// 使用者名稱
        /// </summary>
        /// <value>
        /// The name of the user.
        /// </value>
        public static string UserName
        {
            get
            {
                return Preferences.Get("username", SettingsDefault);
            }
            set
            {
                Preferences.Set("username", value);
            }
        }

        /// <summary>
        /// Email
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public static string Email
        {
            get
            {
                return Preferences.Get("email", SettingsDefault);
            }
            set
            {
                Preferences.Set("email", value);
            }
        }

        public static string Picture
        {
            get
            {
                return Preferences.Get("picture", SettingsDefault);
            }
            set
            {
                Preferences.Set("picture", value);
            }
        }

        /// <summary>
        /// 使用者Token
        /// </summary>
        /// <value>
        /// The access token.
        /// </value>
        public static string AccessToken
        {
            get
            {
                return Preferences.Get("accestoken", SettingsDefault);
            }
            set
            {
                Preferences.Set("accestoken", value);
            }
        }
    }
}