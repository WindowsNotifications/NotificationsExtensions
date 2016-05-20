using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationsExtensions.Toasts;
using NotificationsExtensions.Win10.Test;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Test
{
    [TestClass]
    public class Test_ToastV2_Xml
    {
        [TestMethod]
        public void Test_ToastV2_Visual_Defaults()
        {
            AssertPayload("<toast></toast>", new ToastContent());
        }

        [TestMethod]
        public void Test_ToastV2_Visual_AddImageQuery_False()
        {
            var visual = new ToastVisual()
            {
                AddImageQuery = false
            };

            AssertVisualPayloadProperties(@"addImageQuery='false'", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_AddImageQuery_True()
        {
            var visual = new ToastVisual()
            {
                AddImageQuery = true
            };

            AssertVisualPayloadProperties(@"addImageQuery=""true""", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_BaseUri_Value()
        {
            var visual = new ToastVisual()
            {
                BaseUri = new Uri("http://msn.com")
            };

            AssertVisualPayloadProperties(@"baseUri=""http://msn.com/""", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_Language_Value()
        {
            var visual = new ToastVisual()
            {
                Language = "en-US"
            };

            AssertVisualPayloadProperties(@"lang=""en-US""", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_AdaptiveText_Defaults()
        {
            AssertAdaptiveText(@"<text/>", new AdaptiveText());
        }

        [TestMethod]
        public void Test_ToastV2_Visual_AdaptiveText_All()
        {
            AssertAdaptiveText(@"<text lang=""en-US"" hint-align=""right"" hint-maxLines=""3"" hint-minLines=""2"" hint-style=""header"" hint-wrap=""true"">Hi, I am a title</text>", new AdaptiveText()
            {
                Text = "Hi, I am a title",
                Language = "en-US",
                HintAlign = AdaptiveTextAlign.Right,
                HintMaxLines = 3,
                HintMinLines = 2,
                HintStyle = AdaptiveTextStyle.Header,
                HintWrap = true
            });
        }

        [TestMethod]
        public void Test_ToastV2_Visual_BodyTextLine1_Defaults()
        {
            var visual = new ToastVisual()
            {
                BodyTextLine1 = new ToastText()
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text/><text/></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_BodyTextLine1_All()
        {
            var visual = new ToastVisual()
            {
                BodyTextLine1 = new ToastText()
                {
                    Text = "The first line of body text",
                    Language = "en-US"
                }
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text/><text lang='en-US'>The first line of body text</text></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_BodyTextLine2_Defaults()
        {
            var visual = new ToastVisual()
            {
                BodyTextLine2 = new ToastText()
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text/><text/><text/></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_BodyTextLine2_All()
        {
            var visual = new ToastVisual()
            {
                BodyTextLine2 = new ToastText()
                {
                    Text = "The second line of body text",
                    Language = "en-US"
                }
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text/><text/><text lang='en-US'>The second line of body text</text></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_AllTexts()
        {
            var visual = new ToastVisual()
            {
                TitleText = new ToastText()
                {
                    Text = "My title"
                },

                BodyTextLine1 = new ToastText()
                {
                    Text = "My body 1"
                },

                BodyTextLine2 = new ToastText()
                {
                    Text = "My body 2"
                }
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text>My title</text><text>My body 1</text><text>My body 2</text></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Xml_Attribution()
        {
            var visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "My title"
                        },

                        new AdaptiveText()
                        {
                            Text = "My body 1"
                        }
                    },

                    Attribution = new ToastGenericAttributionText()
                    {
                        Text = "cnn.com"
                    }
                }
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text>My title</text><text>My body 1</text><text placement='attribution'>cnn.com</text></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Xml_Attribution_Lang()
        {
            var visual = new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    Children =
                    {
                        new AdaptiveText()
                        {
                            Text = "My title"
                        },

                        new AdaptiveText()
                        {
                            Text = "My body 1"
                        }
                    },

                    Attribution = new ToastGenericAttributionText()
                    {
                        Text = "cnn.com",
                        Language = "en-US"
                    }
                }
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text>My title</text><text>My body 1</text><text placement='attribution' lang='en-US'>cnn.com</text></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_OneImage()
        {
            var visual = new ToastVisual()
            {
                InlineImages =
                {
                    new ToastImage()
                    {
                        Source = new ToastImageSource("http://msn.com/image.jpg")
                        {
                            AddImageQuery = true,
                            Alt = "alternate"
                        }
                    }

                }
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><image src='http://msn.com/image.jpg' addImageQuery='true' alt='alternate'/></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_TwoImages()
        {
            var visual = new ToastVisual()
            {
                InlineImages =
                {
                    new ToastImage()
                    {
                        Source = new ToastImageSource("http://msn.com/image.jpg")
                        {
                            AddImageQuery = true,
                            Alt = "alternate"
                        }
                    },

                    new ToastImage()
                    {
                        Source = new ToastImageSource("Assets/img2.jpg")
                    }
                }
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><image src='http://msn.com/image.jpg' addImageQuery='true' alt='alternate'/><image src='Assets/img2.jpg'/></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_ToastV2_BindingGeneric_BaseUri()
        {
            AssertBindingGenericProperty("baseUri", "http://msn.com/images/", new ToastBindingGeneric()
            {
                BaseUri = new Uri("http://msn.com/images/", UriKind.Absolute)
            });
        }

        [TestMethod]
        public void Test_ToastV2_BindingGeneric_AddImageQuery()
        {
            AssertBindingGenericProperty("addImageQuery", "false", new ToastBindingGeneric()
            {
                AddImageQuery = false
            });

            AssertBindingGenericProperty("addImageQuery", "true", new ToastBindingGeneric()
            {
                AddImageQuery = true
            });
        }

        [TestMethod]
        public void Test_ToastV2_BindingGeneric_Language()
        {
            AssertBindingGenericProperty("lang", "en-US", new ToastBindingGeneric()
            {
                Language = "en-US"
            });
        }

        [TestMethod]
        public void Test_ToastV2_BindingGeneric_DefaultNullValues()
        {
            AssertBindingGenericPayload("<binding template='ToastGeneric' />", new ToastBindingGeneric()
            {
                AddImageQuery = null,
                AppLogoOverride = null,
                Attribution = null,
                BaseUri = null,
                HeroImage = null,
                Language = null
            });
        }

        private static void AssertBindingGenericProperty(string expectedPropertyName, string expectedPropertyValue, ToastBindingGeneric binding)
        {
            AssertBindingGenericPayload($"<binding template='ToastGeneric' {expectedPropertyName}='{expectedPropertyValue}'/>", binding);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_SixImages()
        {
            var visual = new ToastVisual()
            {
                InlineImages =
                {
                    new ToastImage() { Source = new ToastImageSource("Assets/img1.jpg") },
                    new ToastImage() { Source = new ToastImageSource("Assets/img2.jpg") },
                    new ToastImage() { Source = new ToastImageSource("Assets/img3.jpg") },
                    new ToastImage() { Source = new ToastImageSource("Assets/img4.jpg") },
                    new ToastImage() { Source = new ToastImageSource("Assets/img5.jpg") },
                    new ToastImage() { Source = new ToastImageSource("Assets/img6.jpg") }
                }
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><image src='Assets/img1.jpg'/><image src='Assets/img2.jpg'/><image src='Assets/img3.jpg'/><image src='Assets/img4.jpg'/><image src='Assets/img5.jpg'/><image src='Assets/img6.jpg'/></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_ToastV2_Visual_SevenImages()
        {
            try
            {
                var visual = new ToastVisual()
                {
                    InlineImages =
                    {
                        new ToastImage(),
                        new ToastImage(),
                        new ToastImage(),
                        new ToastImage(),
                        new ToastImage(),
                        new ToastImage(),
                        new ToastImage()
                    }
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown, since adding more than 6 images is not allowed.");
        }

        [TestMethod]
        public void Test_ToastV2_AppLogo_Crop_None()
        {
            var appLogo = new ToastGenericAppLogo()
            {
                HintCrop = ToastGenericAppLogoCrop.None,
                Source = "img.png"
            };

            AssertAppLogoPayload(@"<image src='img.png' placement=""appLogoOverride"" hint-crop='none'/>", appLogo);
        }

        [TestMethod]
        public void Test_ToastV2_AppLogo_Crop_Circle()
        {
            var appLogo = new ToastGenericAppLogo()
            {
                HintCrop = ToastGenericAppLogoCrop.Circle,
                Source = "img.png"
            };

            AssertAppLogoPayload(@"<image src=""img.png"" placement=""appLogoOverride"" hint-crop=""circle""/>", appLogo);
        }

        [TestMethod]
        public void Test_ToastV2_AppLogo_Source_Defaults()
        {
            var appLogo = new ToastGenericAppLogo()
            {
                Source = "http://xbox.com/Avatar.jpg"
            };

            AssertAppLogoPayload(@"<image placement=""appLogoOverride"" src=""http://xbox.com/Avatar.jpg""/>", appLogo);
        }

        [TestMethod]
        public void Test_ToastV2_AppLogo_Source_Alt()
        {
            var appLogo = new ToastGenericAppLogo()
            {
                Source = "http://xbox.com/Avatar.jpg",
                AlternateText = "alternate"
            };

            AssertAppLogoPayload(@"<image placement=""appLogoOverride"" src=""http://xbox.com/Avatar.jpg"" alt=""alternate""/>", appLogo);
        }

        [TestMethod]
        public void Test_ToastV2_AppLogo_Source_AddImageQuery_False()
        {
            var appLogo = new ToastGenericAppLogo()
            {
                Source = "http://xbox.com/Avatar.jpg",
                AddImageQuery = false
            };

            AssertAppLogoPayload(@"<image placement=""appLogoOverride"" src=""http://xbox.com/Avatar.jpg"" addImageQuery='false'/>", appLogo);
        }

        [TestMethod]
        public void Test_ToastV2_AppLogo_Source_AddImageQuery_True()
        {
            var appLogo = new ToastGenericAppLogo()
            {
                Source = "http://xbox.com/Avatar.jpg",
                AddImageQuery = true
            };

            AssertAppLogoPayload(@"<image placement=""appLogoOverride"" src=""http://xbox.com/Avatar.jpg"" addImageQuery=""true""/>", appLogo);
        }

        [TestMethod]
        public void Test_ToastV2_Xml_HeroImage_Default()
        {
            var hero = new ToastGenericHeroImage();

            try
            {
                AssertHeroImagePayload("<image placement='hero'/>", hero);
            }

            catch (NullReferenceException)
            {
                return;
            }

            Assert.Fail("Exception should have been thrown since Source wasn't provided.");
        }

        [TestMethod]
        public void Test_ToastV2_Xml_HeroImage_WithSource()
        {
            var hero = new ToastGenericHeroImage()
            {
                Source = "http://food.com/peanuts.jpg"
            };

            AssertHeroImagePayload("<image placement='hero' src='http://food.com/peanuts.jpg'/>", hero);
        }

        [TestMethod]
        public void Test_ToastV2_Xml_HeroImage_Alt()
        {
            var hero = new ToastGenericHeroImage()
            {
                Source = "http://food.com/peanuts.jpg",
                AlternateText = "peanuts"
            };

            AssertHeroImagePayload("<image placement='hero' src='http://food.com/peanuts.jpg' alt='peanuts'/>", hero);
        }

        [TestMethod]
        public void Test_ToastV2_Xml_HeroImage_AddImageQuery()
        {
            var hero = new ToastGenericHeroImage()
            {
                Source = "http://food.com/peanuts.jpg",
                AddImageQuery = true
            };

            AssertHeroImagePayload("<image placement='hero' src='http://food.com/peanuts.jpg' addImageQuery='true'/>", hero);
        }

        [TestMethod]
        public void Test_ToastV2_Xml_HeroImage_AllProperties()
        {
            var hero = new ToastGenericHeroImage()
            {
                Source = "http://food.com/peanuts.jpg",
                AddImageQuery = true,
                AlternateText = "peanuts"
            };

            AssertHeroImagePayload("<image placement='hero' src='http://food.com/peanuts.jpg' addImageQuery='true' alt='peanuts'/>", hero);
        }

        private static ToastContent GenerateFromVisual(ToastVisual visual)
        {
            return new ToastContent()
            {
                Visual = visual
            };
        }

        /// <summary>
        /// Used for testing properties of visual without needing to specify the Generic binding
        /// </summary>
        /// <param name="expectedVisualProperties"></param>
        /// <param name="visual"></param>
        private static void AssertVisualPayloadProperties(string expectedVisualProperties, ToastVisual visual)
        {
            visual.BindingGeneric = new ToastBindingGeneric();

            AssertVisualPayload("<visual " + expectedVisualProperties + "><binding template='ToastGeneric'></binding></visual>", visual);
        }

        private static void AssertVisualPayload(string expectedVisualXml, ToastVisual visual)
        {
            AssertPayload("<toast>" + expectedVisualXml + "</toast>", GenerateFromVisual(visual));
        }

        private static void AssertBindingGenericPayload(string expectedBindingXml, ToastBindingGeneric binding)
        {
            AssertVisualPayload("<visual>" + expectedBindingXml + "</visual>", new ToastVisual()
            {
                BindingGeneric = binding
            });
        }

        private static void AssertAdaptiveText(string expectedAdaptiveTextXml, AdaptiveText text)
        {
            AssertBindingGenericPayload("<binding template='ToastGeneric'>" + expectedAdaptiveTextXml + "</binding>", new ToastBindingGeneric()
            {
                Children =
                {
                    text
                }
            });
        }

        private static void AssertPayload(string expectedXml, ToastContent toast)
        {
            AssertHelper.AssertXml(expectedXml, toast.GetContent());
        }

        private static void AssertAppLogoPayload(string expectedAppLogoXml, ToastGenericAppLogo appLogo)
        {
            AssertVisualPayload(@"<visual><binding template=""ToastGeneric"">" + expectedAppLogoXml + "</binding></visual>", new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    AppLogoOverride = appLogo
                }
            });
        }

        private static void AssertHeroImagePayload(string expectedHeroXml, ToastGenericHeroImage heroImage)
        {
            AssertVisualPayload(@"<visual><binding template=""ToastGeneric"">" + expectedHeroXml + "</binding></visual>", new ToastVisual()
            {
                BindingGeneric = new ToastBindingGeneric()
                {
                    HeroImage = heroImage
                }
            });
        }
    }
}
