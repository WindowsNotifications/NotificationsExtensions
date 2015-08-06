using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;

namespace NotificationsExtensions.SampleApp
{
    public static class XboxModernTile
    {
        public static XmlDocument Generate()
        {
            // Small content
            //var smallContent = TileContentFactory.SpecialTemplates.Contact.CreateSmall();
            //smallContent.Image = new TileImageSource("http://build2015-tile-polling.azurewebsites.net/assets/hipster.jpg");
            var smallContent = new TileContentAdaptive();


            // Medium content
            //var mediumContent = TileContentFactory.Adaptive.CreateMedium();

            var mediumContent = new TileContentAdaptive()
            {
                TextStacking = TileBindingTextStacking.Center,

                Children =
                {
                    new TileAdaptiveText()
                    {
                        Text = "Hi,",
                        Style = TileTextStyle.Base,
                        Align = TileTextAlign.Center
                    },

                    new TileAdaptiveText()
                    {
                        Text = "MasterHip",
                        Style = TileTextStyle.CaptionSubtle,
                        Align = TileTextAlign.Center
                    }
                }
            };



            // Wide content
            var wideContent = new TileContentAdaptive()
            {
                Children =
                {
                    new TileAdaptiveGroup()
                    {
                        Children =
                        {
                            new TileAdaptiveSubgroup()
                            {
                                Weight = 33,
                                Children =
                                {
                                    new TileAdaptiveImage()
                                    {
                                        Source = new TileImageSource("http://build2015-tile-polling.azurewebsites.net/assets/hipster.jpg"),
                                        Crop = TileImageCrop.Circle
                                    }
                                }
                            },

                            new TileAdaptiveSubgroup()
                            {
                                TextStacking = TileAdaptiveSubgroupTextStacking.Center,
                                Children =
                                {
                                    new TileAdaptiveText()
                                    {
                                        Text = "Hi,",
                                        Style = TileTextStyle.Title
                                    },

                                    new TileAdaptiveText()
                                    {
                                        Text = "MasterHip",
                                        Style = TileTextStyle.SubtitleSubtle
                                    }
                                }
                            }
                        }
                    }
                }
            };



            // Large content
            var largeContent = new TileContentAdaptive()
            {
                TextStacking = TileBindingTextStacking.Center,

                Children =
                {
                    new TileAdaptiveGroup()
                    {
                        Children =
                        {
                            // this is for left padding
                            new TileAdaptiveSubgroup() { Weight = 1 },

                            // this is the image itself
                            new TileAdaptiveSubgroup()
                            {
                                Weight = 2,
                                Children =
                                {
                                    new TileAdaptiveImage()
                                    {
                                        Source = new TileImageSource("http://build2015-tile-polling.azurewebsites.net/assets/hipster.jpg"),
                                        Crop = TileImageCrop.Circle
                                    }
                                }
                            },

                            // this is for right padding
                            new TileAdaptiveSubgroup() { Weight = 1 }
                        }
                    },

                    new TileAdaptiveText()
                    {
                        Text = "Hi,",
                        Style = TileTextStyle.Title,
                        Align = TileTextAlign.Center
                    },

                    new TileAdaptiveText()
                    {
                        Text = "MasterHip",
                        Style = TileTextStyle.SubtitleSubtle,
                        Align = TileTextAlign.Center
                    }
                }
            };

            
            


            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    Branding = TileBranding.Name,

                    TileSmall = new TileBinding()
                    {
                        Content = smallContent
                    },

                    TileMedium = new TileBinding()
                    {
                        Content = mediumContent
                    },

                    TileWide = new TileBinding()
                    {
                        Content = wideContent
                    },

                    TileLarge = new TileBinding()
                    {
                        Branding = TileBranding.NameAndLogo,
                        DisplayName = "Xbox - MasterHip",
                        Content = largeContent
                    }
                }
            };

            throw new NotImplementedException();
        }
    }
}
