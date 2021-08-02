using System;
using System.Diagnostics;
using System.Linq;
using Newtonsoft.Json;
using Prism.Navigation;
using Xamarin.Auth;
using Xamarin.Forms;
using XF_FreeDiving.Helpers.Auth;

namespace XF_FreeDiving.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Google Login
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        /// <exception cref="NotImplementedException"></exception>
        private void Button_OnClicked(object sender, EventArgs e)
        {
        }

        private async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
        }

        private void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
        }
    }
}