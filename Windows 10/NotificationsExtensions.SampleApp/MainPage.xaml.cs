
using NotificationsExtensions.BadgeContent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace NotificationsExtensions.SampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void ButtonSendTileNotification_Click(object sender, RoutedEventArgs e)
        {

            BadgeNumericNotificationContent badgeContent = new BadgeNumericNotificationContent(4);
            badgeContent.GetXml();

            ComboBox comboBox = new ComboBox();
            //var tileContent = NotificationsExtensions.GenerateTileContent();
            //TileNotification notif = new TileNotification(null);
            //ITileSquareText01 tileContent = TileContentFactory.CreateTileSquareText01();
        }
    }
}
