using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Prism.Navigation;
using Xamarin.Auth;
using Xamarin.Forms;
using XF_FreeDiving.Helpers.Auth;

namespace XF_FreeDiving.ViewModels
{
    public class LoginPageViewModel : BindableBase
    {
        private Account account;
        private AccountStore store;

        private readonly INavigationService _navigationService;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPageViewModel"/> class.
        /// </summary>
        /// <param name="navigationService">The navigation service.</param>
        public LoginPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            store = AccountStore.Create();
        }

        private DelegateCommand _navigateCommand;
        private DelegateCommand _googlLoginCommand;

        public DelegateCommand NavigateCommand =>
            _navigateCommand ?? (_navigateCommand = new DelegateCommand(ExecuteNavigateCommand));

        /// <summary>
        /// Google Login 按鈕事件
        /// </summary>
        /// <value>
        /// The google login command.
        /// </value>
        public DelegateCommand GoogleLoginCommand =>
            _googlLoginCommand ?? (_googlLoginCommand = new DelegateCommand(ExecuteGoogleLoginCommand));

        /// <summary>
        /// 實作 Google Login
        /// </summary>
        private void ExecuteGoogleLoginCommand()
        {
            string clientId = null;
            string redirectUri = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = AppConstants.Constants.iOSClientId;
                    redirectUri = AppConstants.Constants.iOSRedirectUrl;
                    break;

                case Device.Android:
                    clientId = AppConstants.Constants.AndroidClientId;
                    redirectUri = AppConstants.Constants.AndroidRedirectUrl;
                    break;
            }

            account = store.FindAccountsForService(AppConstants.Constants.CALLBACK_SCHEME).FirstOrDefault();

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                AppConstants.Constants.Scope,
                new Uri(AppConstants.Constants.AuthorizeUrl),
                new Uri(redirectUri),
                new Uri(AppConstants.Constants.AccessTokenUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
            presenter.Login(authenticator);
        }

        /// <summary>
        /// 驗證完畢要做的事情
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AuthenticatorCompletedEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            User user = null;
            if (e.IsAuthenticated)
            {
                // If the user is authenticated, request their basic user data from Google
                // UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
                var request = new OAuth2Request("GET",
                    new Uri(AppConstants.Constants.UserInfoUrl),
                    null,
                    e.Account);

                var response = await request.GetResponseAsync();

                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }

                if (user != null)
                {
                    await _navigationService.NavigateAsync("AboutPage");
                }

                //await store.SaveAsync(account = e.Account, AppConstant.Constants.AppName);
                //await DisplayAlert("Email address", user.Email, "OK");
            }
        }

        /// <summary>
        /// 驗證失敗要做的事情
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="AuthenticatorErrorEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        private void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }

        private async void ExecuteNavigateCommand()
        {
            await _navigationService.NavigateAsync("/AboutPage");
        }
    }
}