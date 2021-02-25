using Microcharts;
using SkiaSharp;
using Xamarin.Forms;
using XF_FreeDiving.Repository.Entities;
using XF_FreeDiving.Service.Interfaces;
using XF_FreeDiving.ViewModels;

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
    }
}