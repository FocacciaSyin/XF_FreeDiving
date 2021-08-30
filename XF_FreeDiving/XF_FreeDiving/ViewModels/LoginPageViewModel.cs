using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Windows.Input;
using Newtonsoft.Json;
using Prism.Navigation;
using Xamarin.Essentials;
using XF_FreeDiving.Constants;
using XF_FreeDiving.Implements;

namespace XF_FreeDiving.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private string authenticationUrl = "https://xffreedivingapi-essential-webauth.azurewebsites.net/mobileauth/";
        private JsonSerializer _serializer = new JsonSerializer();

        private string _AuthToken;

        public string AuthToken
        {
            get { return _AuthToken; }
            set
            {
                if (_AuthToken != value)
                {
                    _AuthToken = value;
                }
            }
        }

        private DelegateCommand _navigateCommand;
        private readonly INavigationService _navigationService;

        public LoginPageViewModel(INavigationService navigationService)
        {
            this._navigationService = navigationService;
        }

        /// <summary>
        /// 使用Google登入驗證
        /// </summary>
        /// <value>
        /// The google login command.
        /// </value>
        public DelegateCommand GoogleLoginCommand => _navigateCommand ?? (_navigateCommand = new DelegateCommand(GoogleLogin));

        /// <summary>
        /// 實作
        /// </summary>
        private async void GoogleLogin()
        {
            string scheme = "Google";

            try
            {
                WebAuthenticatorResult r = null;

                if (scheme.Equals("Apple")
                    && DeviceInfo.Platform == DevicePlatform.iOS
                    && DeviceInfo.Version.Major >= 13)
                {
                    r = await AppleSignInAuthenticator.AuthenticateAsync();
                }
                else if (scheme.Equals("Google"))
                {
                    var authUrl = new Uri(authenticationUrl + scheme);
                    var callbackUrl = new Uri("FreeDiving://");

                    r = await WebAuthenticator.AuthenticateAsync(authUrl, callbackUrl);
                }

                AuthToken = r?.AccessToken ?? r?.IdToken;
                GetUserInfoUsingToken(AuthToken);

                await _navigationService.NavigateAsync("AboutPage");
            }
            catch (Exception ex)
            {
                AuthToken = string.Empty;

                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "Ok");
            }
        }

        private async void GetUserInfoUsingToken(string authToken)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://www.googleapis.com/oauth2/v3/");
            var httpResponseMessage = await httpClient.GetAsync("userinfo?access_token=" + authToken);
            using (var stream = await httpResponseMessage.Content.ReadAsStreamAsync())
            using (var reader = new StreamReader(stream))
            using (var json = new JsonTextReader(reader))
            {
                var jsoncontent = _serializer.Deserialize<GoogleUserInfoResponseModel>(json);
                Settings.AccessToken = authToken;
                Settings.Email = jsoncontent.email;
                Settings.Picture = jsoncontent.picture;
                Settings.UserName = jsoncontent.name;
                Settings.Key = jsoncontent.sub;
            }
        }
    }
}