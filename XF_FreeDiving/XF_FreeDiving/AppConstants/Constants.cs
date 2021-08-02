using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XF_FreeDiving.AppConstants
{
    public class Constants
    {
        public const string CALLBACK_SCHEME = "OAuthNativeFlow";

        // OAuth
        // For Google login, configure at https://console.developers.google.com/
        public static string iOSClientId = "139360362028-b34obqughdqaq7gi1lpd6cn5s0vp7ln7.apps.googleusercontent.com";

        public static string AndroidClientId = "139360362028-fjqc829586ojhguhotm7rsb1rf36uv2u.apps.googleusercontent.com";

        // These values do not need changing
        public static string Scope = "https://www.googleapis.com/auth/userinfo.email";

        public static string AuthorizeUrl = "https://accounts.google.com/o/oauth2/auth";
        public static string AccessTokenUrl = "https://www.googleapis.com/oauth2/v4/token";
        public static string UserInfoUrl = "https://www.googleapis.com/oauth2/v2/userinfo";

        //同Info.Plist設定, with :/oauth2redirect appended
        public static string iOSRedirectUrl = "com.googleusercontent.apps.139360362028-b34obqughdqaq7gi1lpd6cn5s0vp7ln7:/oauth2redirect";

        //同 CustomUrlSchemeInterceptorActivity.cs 設定
        public static string AndroidRedirectUrl = "com.googleusercontent.apps.139360362028-fjqc829586ojhguhotm7rsb1rf36uv2u:/oauth2redirect";
    }
}