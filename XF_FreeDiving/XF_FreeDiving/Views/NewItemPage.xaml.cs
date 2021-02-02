using Xamarin.Forms;

using XF_FreeDiving.Models;
using XF_FreeDiving.ViewModels;

namespace XF_FreeDiving.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}