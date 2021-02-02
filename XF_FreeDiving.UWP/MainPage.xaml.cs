// 空白頁項目範本已記錄在 https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x404

namespace XF_FreeDiving.UWP
{
    /// <summary>
    /// 可以在本身使用或巡覽至框架內的空白頁面。
    /// </summary>
    public sealed partial class MainPage  // REMOVE ": Page"
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new XF_FreeDiving.App());
        }
    }
}