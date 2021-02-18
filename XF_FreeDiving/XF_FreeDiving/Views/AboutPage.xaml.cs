using Microcharts;
using SkiaSharp;
using System.Threading.Tasks;
using Xamarin.Forms;
using XF_FreeDiving.Models;

namespace XF_FreeDiving.Views
{
    public partial class AboutPage : ContentPage
    {
        private readonly ChartEntry[] entries = new[] {
            new ChartEntry(212){ Label="UWP",ValueLabel="112",Color=SKColor.Parse("#2c3e50")},
            new ChartEntry(248){ Label="UWP",ValueLabel="112",Color=SKColor.Parse("#2c3e50")},
            new ChartEntry(128){ Label="UWP",ValueLabel="112",Color=SKColor.Parse("#2c3e50")},
            new ChartEntry(514){ Label="UWP",ValueLabel="112",Color=SKColor.Parse("#2c3e50")},
            new ChartEntry(120){ Label="UWP",ValueLabel="112",Color=SKColor.Parse("#2c3e50")}
        };

        public AboutPage()
        {
            InitializeComponent();
            chartView.Chart = new LineChart { Entries = entries };
        }

        private async void TapGestureRecognizer_Tapped(object sender, System.EventArgs e)
        {
            var label = (Label)sender;
            var item = (TapGestureRecognizer)label.GestureRecognizers[0];
            var id = item.CommandParameter;
            await DisplayAlert("Alert", $"是否確定要刪除此筆項目({id})", "OK", "False");
        }

        private void lvDivingLog_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = (DivingLog)e.SelectedItem;
            var id = item.name;
        }
    }
}