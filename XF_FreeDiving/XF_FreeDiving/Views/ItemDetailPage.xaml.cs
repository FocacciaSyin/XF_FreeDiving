using Xamarin.Forms;
using XF_FreeDiving.ViewModels;

namespace XF_FreeDiving.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}