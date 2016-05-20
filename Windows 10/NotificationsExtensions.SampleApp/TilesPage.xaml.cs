using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace NotificationsExtensions.SampleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TilesPage : Page
    {
        public TilesPage()
        {
            this.InitializeComponent();
        }

        private void ButtonCirclePeek_Click(object sender, RoutedEventArgs e)
        {
            UpdateMedium(new TileBindingContentAdaptive()
            {
                PeekImage = new TilePeekImage()
                {
                    Source = "https://unsplash.it/100",

                    HintCrop = TilePeekImageCrop.Circle
                },

                Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Matt Hidinger sent you a friend request.",
                        HintWrap = true
                    }
                }
            });
        }

        private void ButtonCirclePeek_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            UpdateMedium(new TileBindingContentAdaptive()
            {
                PeekImage = new TilePeekImage()
                {
                    Source = "https://unsplash.it/100",

                    HintCrop = TilePeekImageCrop.Circle
                },

                Children =
                {
                    new TileText()
                    {
                        Text = "Matt Hidinger sent you a friend request.",
                        Wrap = true
                    }
                }
            });
        }

        private async void UpdateMedium(TileBindingContentAdaptive mediumContent)
        {
            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    TileMedium = new TileBinding()
                    {
                        Content = mediumContent
                    }
                }
            };

            try
            {
                TileUpdateManager.CreateTileUpdaterForSecondaryTile("SecondaryTile").Update(new TileNotification(content.GetXml()));
            }

            catch
            {
                SecondaryTile tile = new SecondaryTile("SecondaryTile", "Example", "args", new Uri("ms-appx:///Assets/Logo.png"), TileSize.Default);
                tile.VisualElements.ShowNameOnSquare150x150Logo = true;
                tile.VisualElements.ShowNameOnSquare310x310Logo = true;
                tile.VisualElements.ShowNameOnWide310x150Logo = true;
                tile.VisualElements.BackgroundColor = Colors.Transparent;
                await tile.RequestCreateAsync();

                TileUpdateManager.CreateTileUpdaterForSecondaryTile("SecondaryTile").Update(new TileNotification(content.GetXml()));
            }
        }

        private void ButtonPeekAndBackground_Click(object sender, RoutedEventArgs e)
        {
            UpdateMedium(new TileBindingContentAdaptive()
            {
                PeekImage = new TilePeekImage()
                {
                    Source = "https://unsplash.it/100",
                    HintCrop = TilePeekImageCrop.Circle
                },

                BackgroundImage = new TileBackgroundImage()
                {
                    Source = "https://unsplash.it/100/?random"
                },

                Children =
                {
                    new AdaptiveText()
                    {
                        Text = "Matt updated his profile picture.",
                        HintWrap = true
                    }
                }
            });
        }

        private void ButtonPeekAndBackground_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            UpdateMedium(new TileBindingContentAdaptive()
            {
                PeekImage = new TilePeekImage()
                {
                    Source = "https://unsplash.it/100",
                    HintCrop = TilePeekImageCrop.Circle
                },

                BackgroundImage = new TileBackgroundImage()
                {
                    Source = "https://unsplash.it/100/?random"
                },

                Children =
                {
                    new TileText()
                    {
                        Text = "Matt updated his profile picture.",
                        Wrap = true
                    }
                }
            });
        }

        private void ButtonPeekOverlay_Click(object sender, RoutedEventArgs e)
        {
            UpdateMedium(new TileBindingContentAdaptive()
            {
                PeekImage = new TilePeekImage()
                {
                    Source = "Assets/Images/map.jpg",
                    HintOverlay = 20
                },

                Children =
                {
                    new AdaptiveText()
                    {
                        Text = "1600 NE 29th St, 98008",
                        HintWrap = true
                    }
                }
            });
        }

        private void ButtonPeekOverlay_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            UpdateMedium(new TileBindingContentAdaptive()
            {
                PeekImage = new TilePeekImage()
                {
                    Source = "Assets/Images/map.jpg",
                    HintOverlay = 20
                },

                Children =
                {
                    new TileText()
                    {
                        Text = "1600 NE 29th St, 98008",
                        Wrap = true
                    }
                }
            });
        }

        private void ButtonHeavyOverlay_Click(object sender, RoutedEventArgs e)
        {
            UpdateMedium(new TileBindingContentAdaptive()
            {
                PeekImage = new TilePeekImage()
                {
                    Source = "Assets/Images/map.jpg",
                    HintOverlay = 60
                },

                BackgroundImage = new TileBackgroundImage()
                {
                    Source = "https://unsplash.it/100",
                    HintOverlay = 60
                },

                Children =
                {
                    new AdaptiveText()
                    {
                        Text = "1600 NE 29th St, 98008",
                        HintWrap = true
                    }
                }
            });
        }
    }
}
