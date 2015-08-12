using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NotificationsExtensions.Win10.Test.Portable
{
    [TestClass]
    public class TextXboxModern
    {
        [TestCategory("EndToEnd/XboxModern")]
        [TestMethod]
        public void TestXboxModernTile()
        {
            TileBinding medium = new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    TextStacking = TileTextStacking.Center,

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
                }
            };


            TileBinding wide = new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
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
                                            Source = new TileImageSource("http://xbox.com/MasterHip/profile.jpg"),
                                            Crop = TileImageCrop.Circle
                                        }
                                    }
                                },

                                new TileAdaptiveSubgroup()
                                {
                                    TextStacking = TileTextStacking.Center,
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
                }
            };




            TileBinding large = new TileBinding()
            {
                Content = new TileBindingContentAdaptive()
                {
                    TextStacking = TileTextStacking.Center,
                    Children =
                    {
                        new TileAdaptiveGroup()
                        {
                            Children =
                            {
                                new TileAdaptiveSubgroup() { Weight = 1 },
                                new TileAdaptiveSubgroup()
                                {
                                    Weight = 2,
                                    Children =
                                    {
                                        new TileAdaptiveImage()
                                        {
                                            Source = new TileImageSource("http://xbox.com/MasterHip/profile.jpg"),
                                            Crop = TileImageCrop.Circle
                                        }
                                    }
                                },
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
                }
            };



            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    Branding = TileBranding.NameAndLogo,

                    TileMedium = medium,
                    TileWide = wide,
                    TileLarge = large
                }
            };



            string expectedXml = $@"<?xml version=""1.0"" encoding=""utf-8""?><tile><visual branding=""nameAndLogo"">";

            // Medium
            expectedXml += @"<binding template=""TileMedium"" hint-textStacking=""center""><text hint-align=""center"" hint-style=""base"">Hi,</text><text hint-align=""center"" hint-style=""captionSubtle"">MasterHip</text></binding>";


            // Wide
            expectedXml += @"<binding template=""TileWide""><group><subgroup hint-weight=""33""><image src=""http://xbox.com/MasterHip/profile.jpg"" hint-crop=""circle"" /></subgroup><subgroup hint-textStacking=""center""><text hint-style=""title"">Hi,</text><text hint-style=""subtitleSubtle"">MasterHip</text></subgroup></group></binding>";


            // Large
            expectedXml += @"<binding template=""TileLarge"" hint-textStacking=""center""><group><subgroup hint-weight=""1"" /><subgroup hint-weight=""2""><image src=""http://xbox.com/MasterHip/profile.jpg"" hint-crop=""circle"" /></subgroup><subgroup hint-weight=""1"" /></group><text hint-align=""center"" hint-style=""title"">Hi,</text><text hint-align=""center"" hint-style=""subtitleSubtle"">MasterHip</text></binding>";


            expectedXml += "</visual></tile>";



            string actualXml = content.GetXml();

            Assert.AreEqual(expectedXml, actualXml);
        }
    }
}
