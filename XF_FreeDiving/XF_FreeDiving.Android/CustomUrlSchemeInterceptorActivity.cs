using System;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Auth;
using XF_FreeDiving.Droid;
using XF_FreeDiving.Helpers.Auth;

namespace RaleWears.Droid
{
    [Activity(Label = "CustomUrlSchemeInterceptorActivity", NoHistory = true, LaunchMode = LaunchMode.SingleTop)]
    [IntentFilter(
    new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataSchemes = new[] { "com.googleusercontent.apps.139360362028-fjqc829586ojhguhotm7rsb1rf36uv2u" },
    DataPath = "/oauth2redirect")]
    public class CustomUrlSchemeInterceptorActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            global::Android.Net.Uri uri_android = Intent.Data;

            //登入完因為會跳出一個 toast 這樣可以關掉
            CustomTabsConfiguration.CustomTabsClosingMessage = null;

            Uri uri_netfx = new Uri(uri_android.ToString());

            // load redirect_url Page
            AuthenticationState.Authenticator.OnPageLoading(uri_netfx);

            var intent = new Intent(this, typeof(MainActivity));
            intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.SingleTop);
            StartActivity(intent);

            this.Finish();

            return;
        }
    }
}