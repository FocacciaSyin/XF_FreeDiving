using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF_FreeDiving.ViewModels;

namespace XF_FreeDiving.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}