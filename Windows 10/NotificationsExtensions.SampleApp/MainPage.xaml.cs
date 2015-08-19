
using NotificationsExtensions.Tiles;
using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.DataTransfer;
using Windows.Data.Xml.Dom;
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

            SendToastNotification();
        }
        

        private void SendToastNotification()
        {
    ToastContent content = new ToastContent()
    {
        Launch = "lei",

        Visual = new ToastVisual()
        {
            TitleText = new ToastText()
            {
                Text = "New message from Lei"
            },

            BodyTextLine1 = new ToastText()
            {
                Text = "NotificationsExtensions is great!"
            },

            AppLogoOverride = new ToastAppLogo()
            {
                Crop = ToastImageCrop.Circle,
                Source = new ToastImageSource("http://messageme.com/lei/profile.jpg")
            }
        },
                
        Actions = new ToastActionsCustom()
        {
            Inputs =
            {
                new ToastTextBox("tbReply")
                {
                    PlaceholderContent = "Type a response"
                }
            },

            Buttons =
            {
                new ToastButton("reply", "reply")
                {
                    ActivationType = ToastActivationType.Background,
                    ImageUri = "Assets/QuickReply.png",
                    TextBoxId = "tbReply"
                }
            }
        },
                
        Audio = new ToastAudio()
        {
            Src = new Uri("ms-winsoundevent:Notification.IM")
        }
    };


            DataPackage dp = new DataPackage();
            dp.SetText(content.GetContent());
            Clipboard.SetContent(dp);

            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()));
        }

private TileGroup GenerateEmailGroup(string from, string subject)
{
    return new TileGroup()
    {
        Children =
        {
            new TileSubgroup()
            {
                Children =
                {
                    new TileText()
                    {
                        Text = from
                    },

                    new TileText()
                    {
                        Text = subject,
                        Style = TileTextStyle.CaptionSubtle
                    }
                }
            }
        }
    };
}

        private void ButtonSendTileNotification_Click(object sender, RoutedEventArgs e)
        {
TileBindingContentAdaptive bindingContent = new TileBindingContentAdaptive()
{
    Children =
    {
        GenerateEmailGroup("Jennifer Parker", "Photos from our trip"),
        GenerateEmailGroup("Steve Bosniak", "Want to go out for dinner after Build tonight?")
    }
};

TileBinding binding = new TileBinding()
{
    Content = bindingContent
};


TileContent content = new TileContent()
{
    Visual = new TileVisual()
    {
        TileMedium = binding
    }
};
            

            DataPackage dp = new DataPackage();
            dp.SetText(content.GetContent());
            Clipboard.SetContent(dp);
            return;


            string xmlAsString = content.GetContent();
            TileNotification notification = new TileNotification(content.GetXml());

            content.Visual.TileMedium = new TileBinding()
            {
                Branding = TileBranding.Logo,

                Content = new TileBindingContentAdaptive()
            };

            ComboBox comboBox = new ComboBox();
            //var tileContent = NotificationsExtensions.GenerateTileContent();
            //TileNotification notif = new TileNotification(null);
            //ITileSquareText01 tileContent = TileContentFactory.CreateTileSquareText01();
        }
    }
}
