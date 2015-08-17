using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationsExtensions.Tiles;

namespace NotificationsExtensions.Win10.Test.Portable
{
    [TestClass]
    public class TestWeather
    {
        private const string IMAGE_MOSTLY_CLOUDY = "Assets\\Tiles\\Mostly Cloudy.png";
        private const string IMAGE_SUNNY = "Assets\\Tiles\\Sunny.png";
        private const string IMAGE_CLOUDY = "Assets\\Tiles\\Cloudy.png";

        private const string BACKGROUND_IMAGE_MOSTLY_CLOUDY = "Assets\\Tiles\\Mostly Cloudy-Background.png";

        [TestCategory("EndToEnd/Weather")]
        [TestMethod]
        public void TestWeatherTile()
        {
            TileImageSource backgroundImage = new TileImageSource(BACKGROUND_IMAGE_MOSTLY_CLOUDY);
            int overlay = 30;

            TileBindingContentAdaptive smallContent = new TileBindingContentAdaptive()
            {
                TextStacking = TileTextStacking.Center,
                Overlay = overlay,
                BackgroundImage = backgroundImage,
                Children =
                {
                    new TileText()
                    {
                        Text = "Mon",
                        Style = TileTextStyle.Body,
                        Align = TileTextAlign.Center
                    },

                    new TileText()
                    {
                        Text = "63°",
                        Style = TileTextStyle.Base,
                        Align = TileTextAlign.Center
                    }
                }
            };


            TileBindingContentAdaptive mediumContent = new TileBindingContentAdaptive()
            {
                Overlay = overlay,
                BackgroundImage = backgroundImage,
                Children =
                {
                    new TileGroup()
                    {
                        Children =
                        {
                            GenerateMediumSubgroup("Mon", IMAGE_MOSTLY_CLOUDY, 63, 42),

                            GenerateMediumSubgroup("Tue", IMAGE_CLOUDY, 57, 38)
                        }
                    }
                }
            };



            TileBindingContentAdaptive wideContent = new TileBindingContentAdaptive()
            {
                Overlay = overlay,
                BackgroundImage = backgroundImage,
                Children =
                {
                    new TileGroup()
                    {
                        Children =
                        {
                            GenerateWideSubgroup("Mon", IMAGE_MOSTLY_CLOUDY, 63, 42),

                            GenerateWideSubgroup("Tue", IMAGE_CLOUDY, 57, 38),

                            GenerateWideSubgroup("Wed", IMAGE_SUNNY, 59, 43),

                            GenerateWideSubgroup("Thu", IMAGE_SUNNY, 62, 42),

                            GenerateWideSubgroup("Fri", IMAGE_SUNNY, 71, 66)
                        }
                    }
                }
            };




            TileBindingContentAdaptive largeContent = new TileBindingContentAdaptive()
            {
                Overlay = overlay,
                BackgroundImage = backgroundImage,
                Children =
                {
                    new TileGroup()
                    {
                        Children =
                        {
                            new TileSubgroup()
                            {
                                Weight = 30,
                                Children =
                                {
                                    new TileImage() { Source = new TileImageSource(IMAGE_MOSTLY_CLOUDY) }
                                }
                            },

                            new TileSubgroup()
                            {
                                Children =
                                {
                                    new TileText()
                                    {
                                        Text = "Monday",
                                        Style = TileTextStyle.Base
                                    },

                                    new TileText()
                                    {
                                        Text = "63° / 42°"
                                    },

                                    new TileText()
                                    {
                                        Text = "20% chance of rain",
                                        Style = TileTextStyle.CaptionSubtle
                                    },

                                    new TileText()
                                    {
                                        Text = "Winds 5 mph NE",
                                        Style = TileTextStyle.CaptionSubtle
                                    }
                                }
                            }
                        }
                    },

                    // For spacing
                    new TileText(),

                    new TileGroup()
                    {
                        Children =
                        {
                            GenerateLargeSubgroup("Tue", IMAGE_CLOUDY, 57, 38),

                            GenerateLargeSubgroup("Wed", IMAGE_SUNNY, 59, 43),

                            GenerateLargeSubgroup("Thu", IMAGE_SUNNY, 62, 42),

                            GenerateLargeSubgroup("Fri", IMAGE_SUNNY, 71, 66)
                        }
                    }
                }
            };




            TileContent content = new TileContent()
            {
                Visual = new TileVisual()
                {
                    DisplayName = "Seattle",

                    TileSmall = new TileBinding()
                    {
                        Content = smallContent
                    },

                    TileMedium = new TileBinding()
                    {
                        Content = mediumContent,
                        Branding = TileBranding.Name
                    },

                    TileWide = new TileBinding()
                    {
                        Content = wideContent,
                        Branding = TileBranding.NameAndLogo
                    },

                    TileLarge = new TileBinding()
                    {
                        Content = largeContent,
                        Branding = TileBranding.NameAndLogo
                    }
                }
            };



            string expectedPayload = $@"<?xml version=""1.0"" encoding=""utf-8""?><tile><visual displayName=""Seattle""><binding template=""TileSmall"" hint-overlay=""30"" hint-textStacking=""center"">{GenerateStringBackgroundImage()}<text hint-align=""center"" hint-style=""body"">Mon</text><text hint-align=""center"" hint-style=""base"">63°</text></binding><binding template=""TileMedium"" branding=""name"" hint-overlay=""30"">{GenerateStringBackgroundImage()}<group>";

            // Medium tile subgroups
            expectedPayload += GenerateStringMediumSubgroup("Mon", IMAGE_MOSTLY_CLOUDY, 63, 42);
            expectedPayload += GenerateStringMediumSubgroup("Tue", IMAGE_CLOUDY, 57, 38);

            expectedPayload += "</group></binding>";


            // Wide tile
            expectedPayload += @"<binding template=""TileWide"" branding=""nameAndLogo"" hint-overlay=""30"">";
            expectedPayload += GenerateStringBackgroundImage();
            expectedPayload += "<group>";

            // Wide tile subgroups
            expectedPayload += GenerateStringWideSubgroup("Mon", IMAGE_MOSTLY_CLOUDY, 63, 42);
            expectedPayload += GenerateStringWideSubgroup("Tue", IMAGE_CLOUDY, 57, 38);
            expectedPayload += GenerateStringWideSubgroup("Wed", IMAGE_SUNNY, 59, 43);
            expectedPayload += GenerateStringWideSubgroup("Thu", IMAGE_SUNNY, 62, 42);
            expectedPayload += GenerateStringWideSubgroup("Fri", IMAGE_SUNNY, 71, 66);

            expectedPayload += "</group></binding>";



            // Large tile
            expectedPayload += @"<binding template=""TileLarge"" branding=""nameAndLogo"" hint-overlay=""30"">";
            expectedPayload += GenerateStringBackgroundImage();
            expectedPayload += $@"<group><subgroup hint-weight=""30""><image src=""{IMAGE_MOSTLY_CLOUDY}"" /></subgroup><subgroup><text hint-style=""base"">Monday</text><text>63° / 42°</text><text hint-style=""captionSubtle"">20% chance of rain</text><text hint-style=""captionSubtle"">Winds 5 mph NE</text></subgroup></group>";

            expectedPayload += "<text />";
            expectedPayload += "<group>";

            // Large tile subgroups
            expectedPayload += GenerateStringLargeSubgroup("Tue", IMAGE_CLOUDY, 57, 38);
            expectedPayload += GenerateStringLargeSubgroup("Wed", IMAGE_SUNNY, 59, 43);
            expectedPayload += GenerateStringLargeSubgroup("Thu", IMAGE_SUNNY, 62, 42);
            expectedPayload += GenerateStringLargeSubgroup("Fri", IMAGE_SUNNY, 71, 66);

            expectedPayload += "</group></binding></visual></tile>";


            string actualPayload = content.GetContent();

            AssertHelper.AssertXml(expectedPayload, actualPayload);
            //Assert.AreEqual(expectedPayload, actualPayload);
        }

        private static string GenerateStringBackgroundImage()
        {
            return $@"<image src=""{BACKGROUND_IMAGE_MOSTLY_CLOUDY}"" placement=""background"" />";
        }

        private static string GenerateStringMediumSubgroup(string day, string image, int high, int low)
        {
            return $@"<subgroup><text hint-align=""center"">{day}</text><image src=""{image}"" hint-removeMargin=""True"" /><text hint-align=""center"">{high}°</text><text hint-align=""center"" hint-style=""captionSubtle"">{low}°</text></subgroup>";
        }

        private static string GenerateStringWideSubgroup(string day, string image, int high, int low)
        {
            return $@"<subgroup hint-weight=""1""><text hint-align=""center"">{day}</text><image src=""{image}"" hint-removeMargin=""True"" /><text hint-align=""center"">{high}°</text><text hint-align=""center"" hint-style=""captionSubtle"">{low}°</text></subgroup>";
        }

        private static string GenerateStringLargeSubgroup(string day, string image, int high, int low)
        {
            return $@"<subgroup hint-weight=""1""><text hint-align=""center"">{day}</text><image src=""{image}"" /><text hint-align=""center"">{high}°</text><text hint-align=""center"" hint-style=""captionSubtle"">{low}°</text></subgroup>";
        }

        private static TileSubgroup GenerateMediumSubgroup(string day, string image, int high, int low)
        {
            return new TileSubgroup()
            {
                Children =
                {
                    new TileText()
                    {
                        Text = day,
                        Align = TileTextAlign.Center
                    },

                    new TileImage()
                    {
                        Source = new TileImageSource(image),
                        RemoveMargin = true
                    },

                    new TileText()
                    {
                        Text = high + "°",
                        Align = TileTextAlign.Center
                    },

                    new TileText()
                    {
                        Text = low + "°",
                        Align = TileTextAlign.Center,
                        Style = TileTextStyle.CaptionSubtle
                    }
                }
            };
        }

        private static TileSubgroup GenerateWideSubgroup(string day, string image, int high, int low)
        {
            var subgroup = GenerateMediumSubgroup(day, image, high, low);

            subgroup.Weight = 1;

            return subgroup;
        }

        private static TileSubgroup GenerateLargeSubgroup(string day, string image, int high, int low)
        {
            var subgroup = GenerateWideSubgroup(day, image, high, low);

            (subgroup.Children[1] as TileImage).RemoveMargin = false;

            return subgroup;
        }
    }
}
