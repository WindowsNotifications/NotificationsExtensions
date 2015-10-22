using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationsExtensions.Toasts;

namespace NotificationsExtensions.Win10.Test.Portable
{
    [TestClass]
    public class Test_Toast_Xml
    {
        [TestMethod]
        public void Test_Toast_XML_Toast_Defaults()
        {
            AssertPayload("<toast/>", new ToastContent());
        }

        [TestMethod]
        public void Test_Toast_XML_Toast_Launch_Value()
        {
            var toast = new ToastContent()
            {
                Launch = "tacos"
            };

            AssertPayload("<toast launch='tacos'/>", toast);
        }

        [TestMethod]
        public void Test_Toast_XML_Toast_ActivationType_Foreground()
        {
            var toast = new ToastContent()
            {
                ActivationType = ToastActivationType.Foreground
            };

            AssertPayload("<toast />", toast);
        }

        [TestMethod]
        public void Test_Toast_XML_Toast_ActivationType_Background()
        {
            var toast = new ToastContent()
            {
                ActivationType = ToastActivationType.Background
            };

            AssertPayload("<toast activationType='background' />", toast);
        }

        [TestMethod]
        public void Test_Toast_XML_Toast_ActivationType_Protocol()
        {
            var toast = new ToastContent()
            {
                ActivationType = ToastActivationType.Protocol
            };

            AssertPayload("<toast activationType='protocol' />", toast);
        }

        [TestMethod]
        public void Test_Toast_XML_Toast_Duration_Short()
        {
            var toast = new ToastContent()
            {
                Duration = ToastDuration.Short
            };

            AssertPayload("<toast />", toast);
        }

        [TestMethod]
        public void Test_Toast_XML_Toast_Duration_Long()
        {
            var toast = new ToastContent()
            {
                Duration = ToastDuration.Long
            };

            AssertPayload("<toast duration='long' />", toast);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_Defaults()
        {
            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""/></visual>", new ToastVisual());
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_AddImageQuery_False()
        {
            var visual = new ToastVisual()
            {
                AddImageQuery = false
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""/></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_AddImageQuery_True()
        {
            var visual = new ToastVisual()
            {
                AddImageQuery = true
            };

            AssertVisualPayload(@"<visual addImageQuery=""True""><binding template=""ToastGeneric""/></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_BaseUri_Value()
        {
            var visual = new ToastVisual()
            {
                BaseUri = new Uri("http://msn.com")
            };

            AssertVisualPayload(@"<visual baseUri=""http://msn.com/""><binding template=""ToastGeneric""/></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_Language_Value()
        {
            var visual = new ToastVisual()
            {
                Language = "en-US"
            };

            AssertVisualPayload(@"<visual lang=""en-US""><binding template=""ToastGeneric""/></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_Version_Value()
        {
            var visual = new ToastVisual()
            {
                Version = 3
            };

            AssertVisualPayload(@"<visual version=""3""><binding template=""ToastGeneric""/></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_TitleText_Defaults()
        {
            var visual = new ToastVisual()
            {
                TitleText = new ToastText()
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text/></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_TitleText_All()
        {
            var visual = new ToastVisual()
            {
                TitleText = new ToastText()
                {
                    Text = "Hi, I am a title",
                    Language = "en-US"
                }
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text lang='en-US'>Hi, I am a title</text></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_BodyTextLine1_Defaults()
        {
            var visual = new ToastVisual()
            {
                BodyTextLine1 = new ToastText()
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text/><text/></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_BodyTextLine1_All()
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
        public void Test_Toast_XML_Visual_BodyTextLine2_Defaults()
        {
            var visual = new ToastVisual()
            {
                BodyTextLine2 = new ToastText()
            };

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><text/><text/><text/></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_BodyTextLine2_All()
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
        public void Test_Toast_XML_Visual_AllTexts()
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
        public void Test_Toast_XML_Visual_OneImage()
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

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><image src='http://msn.com/image.jpg' addImageQuery='True' alt='alternate'/></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_TwoImages()
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

            AssertVisualPayload(@"<visual><binding template=""ToastGeneric""><image src='http://msn.com/image.jpg' addImageQuery='True' alt='alternate'/><image src='Assets/img2.jpg'/></binding></visual>", visual);
        }

        [TestMethod]
        public void Test_Toast_XML_Visual_SixImages()
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
        public void Test_Toast_XML_Visual_SevenImages()
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
        public void Test_Toast_XML_AppLogo_Crop_None()
        {
            var appLogo = new ToastAppLogo()
            {
                Crop = ToastImageCrop.None
            };

            AssertAppLogoPayload(@"<image placement=""appLogoOverride""/>", appLogo);
        }

        [TestMethod]
        public void Test_Toast_XML_AppLogo_Crop_Circle()
        {
            var appLogo = new ToastAppLogo()
            {
                Crop = ToastImageCrop.Circle
            };

            AssertAppLogoPayload(@"<image placement=""appLogoOverride"" hint-crop=""circle""/>", appLogo);
        }

        [TestMethod]
        public void Test_Toast_XML_AppLogo_Source_Defaults()
        {
            var appLogo = new ToastAppLogo()
            {
                Source = new ToastImageSource("http://xbox.com/Avatar.jpg")
            };

            AssertAppLogoPayload(@"<image placement=""appLogoOverride"" src=""http://xbox.com/Avatar.jpg""/>", appLogo);
        }

        [TestMethod]
        public void Test_Toast_XML_AppLogo_Source_Alt()
        {
            var appLogo = new ToastAppLogo()
            {
                Source = new ToastImageSource("http://xbox.com/Avatar.jpg")
                {
                    Alt = "alternate"
                }
            };

            AssertAppLogoPayload(@"<image placement=""appLogoOverride"" src=""http://xbox.com/Avatar.jpg"" alt=""alternate""/>", appLogo);
        }

        [TestMethod]
        public void Test_Toast_XML_AppLogo_Source_AddImageQuery_False()
        {
            var appLogo = new ToastAppLogo()
            {
                Source = new ToastImageSource("http://xbox.com/Avatar.jpg")
                {
                    AddImageQuery = false
                }
            };

            AssertAppLogoPayload(@"<image placement=""appLogoOverride"" src=""http://xbox.com/Avatar.jpg""/>", appLogo);
        }

        [TestMethod]
        public void Test_Toast_XML_AppLogo_Source_AddImageQuery_True()
        {
            var appLogo = new ToastAppLogo()
            {
                Source = new ToastImageSource("http://xbox.com/Avatar.jpg")
                {
                    AddImageQuery = true
                }
            };

            AssertAppLogoPayload(@"<image placement=""appLogoOverride"" src=""http://xbox.com/Avatar.jpg"" addImageQuery=""True""/>", appLogo);
        }

        [TestMethod]
        public void Test_Toast_Xml_Audio_Defaults()
        {
            var audio = new ToastAudio();

            AssertAudioPayload("<audio />", audio);
        }

        [TestMethod]
        public void Test_Toast_Xml_Audio_Loop_False()
        {
            var audio = new ToastAudio()
            {
                Loop = false
            };

            AssertAudioPayload("<audio />", audio);
        }

        [TestMethod]
        public void Test_Toast_Xml_Audio_Loop_True()
        {
            var audio = new ToastAudio()
            {
                Loop = true
            };

            AssertAudioPayload("<audio loop='True'/>", audio);
        }

        [TestMethod]
        public void Test_Toast_Xml_Audio_Silent_False()
        {
            var audio = new ToastAudio()
            {
                Silent = false
            };

            AssertAudioPayload("<audio/>", audio);
        }

        [TestMethod]
        public void Test_Toast_Xml_Audio_Silent_True()
        {
            var audio = new ToastAudio()
            {
                Silent = true
            };

            AssertAudioPayload("<audio silent='True'/>", audio);
        }

        [TestMethod]
        public void Test_Toast_Xml_Audio_Src_Value()
        {
            var audio = new ToastAudio()
            {
                Src = new Uri("ms-appx:///Assets/audio.mp3")
            };

            AssertAudioPayload("<audio src='ms-appx:///Assets/audio.mp3'/>", audio);
        }

        [TestMethod]
        public void Test_Toast_Xml_Actions_SnoozeAndDismiss()
        {
            AssertActionsPayload("<actions hint-systemCommands='SnoozeAndDismiss'/>", new ToastActionsSnoozeAndDismiss());
        }

        [TestMethod]
        public void Test_Toast_Xml_Actions_Custom_Defaults()
        {
            AssertActionsPayload("<actions/>", new ToastActionsCustom());
        }

        [TestMethod]
        public void Test_Toast_Xml_Actions_TextBoxAndButton()
        {
            AssertActionsPayload("<actions><input id='tb1' type='text'/><action content='Click me!' arguments='clickArgs'/></actions>", new ToastActionsCustom()
            {
                Buttons =
                {
                    new ToastButton("Click me!", "clickArgs")
                },

                Inputs =
                {
                    new ToastTextBox("tb1")
                }
            });
        }

        [TestMethod]
        public void Test_Toast_Xml_Actions_TwoTextBoxes()
        {
            AssertActionsPayload("<actions><input id='tb1' type='text'/><input id='tb2' type='text'/></actions>", new ToastActionsCustom()
            {
                Inputs =
                {
                    new ToastTextBox("tb1"),
                    new ToastTextBox("tb2")
                }
            });
        }

        [TestMethod]
        public void Test_Toast_Xml_Actions_FiveTextBoxes()
        {
            AssertActionsPayload("<actions><input id='tb1' type='text'/><input id='tb2' type='text'/><input id='tb3' type='text'/><input id='tb4' type='text'/><input id='tb5' type='text'/></actions>", new ToastActionsCustom()
            {
                Inputs =
                {
                    new ToastTextBox("tb1"),
                    new ToastTextBox("tb2"),
                    new ToastTextBox("tb3"),
                    new ToastTextBox("tb4"),
                    new ToastTextBox("tb5")
                }
            });
        }

        [TestMethod]
        public void Test_Toast_Xml_Actions_SixTextBoxes()
        {
            try
            {
                new ToastActionsCustom()
                {
                    Inputs =
                    {
                        new ToastTextBox("tb1"),
                        new ToastTextBox("tb2"),
                        new ToastTextBox("tb3"),
                        new ToastTextBox("tb4"),
                        new ToastTextBox("tb5"),
                        new ToastTextBox("tb6")
                    }
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_Actions_SelectionAndButton()
        {
            AssertActionsPayload("<actions><input id='s1' type='selection'><selection id='1' content='First'/><selection id='2' content='Second'/></input><action content='Click me!' arguments='clickArgs'/></actions>", new ToastActionsCustom()
            {
                Inputs =
                {
                    new ToastSelectionBox("s1")
                    {
                        Items =
                        {
                            new ToastSelectionBoxItem("1", "First"),
                            new ToastSelectionBoxItem("2", "Second")
                        }
                    }
                },

                Buttons =
                {
                    new ToastButton("Click me!", "clickArgs")
                }
            });
        }

        [TestMethod]
        public void Test_Toast_Xml_Actions_TwoButtons()
        {
            AssertActionsPayload("<actions><action content='Button 1' arguments='1'/><action content='Button 2' arguments='2'/></actions>", new ToastActionsCustom()
            {
                Buttons =
                {
                    new ToastButton("Button 1", "1"),
                    new ToastButton("Button 2", "2")
                }
            });
        }

        [TestMethod]
        public void Test_Toast_Xml_Actions_FiveButtons()
        {
            AssertActionsPayload("<actions><action content='Button 1' arguments='1'/><action content='Button 2' arguments='2'/><action content='Button 3' arguments='3'/><action content='Button 4' arguments='4'/><action content='Button 5' arguments='5'/></actions>", new ToastActionsCustom()
            {
                Buttons =
                {
                    new ToastButton("Button 1", "1"),
                    new ToastButton("Button 2", "2"),
                    new ToastButton("Button 3", "3"),
                    new ToastButton("Button 4", "4"),
                    new ToastButton("Button 5", "5")
                }
            });
        }

        [TestMethod]
        public void Test_Toast_Xml_Actions_SixButtons()
        {
            try
            {
                new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButton("Button 1", "1"),
                        new ToastButton("Button 2", "2"),
                        new ToastButton("Button 3", "3"),
                        new ToastButton("Button 4", "4"),
                        new ToastButton("Button 5", "5"),
                        new ToastButton("Button 6", "6")
                    }
                };
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_Button_Defaults()
        {
            ToastButton button = new ToastButton("my content", "myArgs");

            AssertButtonPayload("<action content='my content' arguments='myArgs' />", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_Button_NullContent()
        {
            try
            {
                new ToastButton(null, "args");
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_Button_NullArguments()
        {
            try
            {
                new ToastButton("content", null);
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_Button_ActivationType_Foreground()
        {
            ToastButton button = new ToastButton("my content", "myArgs")
            {
                ActivationType = ToastActivationType.Foreground
            };

            AssertButtonPayload("<action content='my content' arguments='myArgs' />", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_Button_ActivationType_Background()
        {
            ToastButton button = new ToastButton("my content", "myArgs")
            {
                ActivationType = ToastActivationType.Background
            };

            AssertButtonPayload("<action content='my content' arguments='myArgs' activationType='background' />", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_Button_ActivationType_Protocol()
        {
            ToastButton button = new ToastButton("my content", "myArgs")
            {
                ActivationType = ToastActivationType.Protocol
            };

            AssertButtonPayload("<action content='my content' arguments='myArgs' activationType='protocol' />", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_Button_ImageUri_Value()
        {
            ToastButton button = new ToastButton("my content", "myArgs")
            {
                ImageUri = "Assets/button.png"
            };

            AssertButtonPayload("<action content='my content' arguments='myArgs' imageUri='Assets/button.png' />", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_Button_TextBoxId_Value()
        {
            ToastButton button = new ToastButton("my content", "myArgs")
            {
                TextBoxId = "myTextBox"
            };

            AssertButtonPayload("<action content='my content' arguments='myArgs' hint-inputId='myTextBox' />", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_ButtonSnooze_Defaults()
        {
            ToastButtonSnooze button = new ToastButtonSnooze();

            AssertButtonPayload("<action activationType='system' arguments='snooze' content=''/>", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_ButtonSnooze_CustomContent()
        {
            ToastButtonSnooze button = new ToastButtonSnooze("my snooze");

            AssertButtonPayload("<action activationType='system' arguments='snooze' content='my snooze'/>", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_ButtonSnooze_SelectionId()
        {
            ToastButtonSnooze button = new ToastButtonSnooze()
            {
                SelectionBoxId = "snoozeId"
            };

            AssertButtonPayload("<action activationType='system' arguments='snooze' content='' hint-inputId='snoozeId'/>", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_ButtonDismiss_Defaults()
        {
            ToastButtonDismiss button = new ToastButtonDismiss();

            AssertButtonPayload("<action activationType='system' arguments='dismiss' content=''/>", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_ButtonDismiss_CustomContent()
        {
            ToastButtonDismiss button = new ToastButtonDismiss("my dismiss");

            AssertButtonPayload("<action activationType='system' arguments='dismiss' content='my dismiss'/>", button);
        }

        [TestMethod]
        public void Test_Toast_Xml_TextBox_Defaults()
        {
            var textBox = new ToastTextBox("myId");

            AssertInputPayload("<input id='myId' type='text' />", textBox);
        }

        [TestMethod]
        public void Test_Toast_Xml_TextBox_DefaultTextInput_Value()
        {
            var textBox = new ToastTextBox("myId")
            {
                DefaultInput = "Default text input"
            };

            AssertInputPayload("<input id='myId' type='text' defaultInput='Default text input' />", textBox);
        }

        [TestMethod]
        public void Test_Toast_Xml_TextBox_PlaceholderContent_Value()
        {
            var textBox = new ToastTextBox("myId")
            {
                PlaceholderContent = "My placeholder content"
            };

            AssertInputPayload("<input id='myId' type='text' placeHolderContent='My placeholder content' />", textBox);
        }

        [TestMethod]
        public void Test_Toast_Xml_TextBox_Title_Value()
        {
            var textBox = new ToastTextBox("myId")
            {
                Title = "My title"
            };

            AssertInputPayload("<input id='myId' type='text' title='My title' />", textBox);
        }

        [TestMethod]
        public void Test_Toast_Xml_TextBox_NullId()
        {
            try
            {
                new ToastTextBox(null);
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_TextBox_EmptyId()
        {
            var textBox = new ToastTextBox("");

            AssertInputPayload("<input id='' type='text' />", textBox);
        }

        [TestMethod]
        public void Test_Toast_Xml_RatingControl_Defaults()
        {
            var ratingControl = new ToastRatingControl("rating", new string[] { "1 star", "2 stars", "3 stars", "4 stars", "5 stars" });

            AssertInputPayload("<input id='rating' type='selection' hint-selectionType='rating'><selection id='0.200000' content='1 star'/><selection id='0.400000' content='2 stars'/><selection id='0.600000' content='3 stars'/><selection id='0.800000' content='4 stars'/><selection id='1.000000' content='5 stars'/></input>", ratingControl);
        }

        [TestMethod]
        public void Test_Toast_Xml_RatingControl_Title()
        {
            var ratingControl = new ToastRatingControl("rating", new string[] { "1 star", "2 stars", "3 stars", "4 stars", "5 stars" })
            {
                Title = "Rate me"
            };

            AssertInputPayload("<input id='rating' type='selection' hint-selectionType='rating' title='Rate me'><selection id='0.200000' content='1 star'/><selection id='0.400000' content='2 stars'/><selection id='0.600000' content='3 stars'/><selection id='0.800000' content='4 stars'/><selection id='1.000000' content='5 stars'/></input>", ratingControl);
        }

        [TestMethod]
        public void Test_Toast_Xml_RatingControl_DefaultRating()
        {
            var ratingControl = new ToastRatingControl("rating", new string[] { "1 star", "2 stars", "3 stars", "4 stars", "5 stars" })
            {
                Title = "Rate me",
                DefaultRating = 0.2f
            };

            AssertInputPayload("<input id='rating' type='selection' hint-selectionType='rating' title='Rate me' defaultInput='0.200000'><selection id='0.200000' content='1 star'/><selection id='0.400000' content='2 stars'/><selection id='0.600000' content='3 stars'/><selection id='0.800000' content='4 stars'/><selection id='1.000000' content='5 stars'/></input>", ratingControl);

            ratingControl.DefaultRating = 0.4f;

            AssertInputPayload("<input id='rating' type='selection' hint-selectionType='rating' title='Rate me' defaultInput='0.400000'><selection id='0.200000' content='1 star'/><selection id='0.400000' content='2 stars'/><selection id='0.600000' content='3 stars'/><selection id='0.800000' content='4 stars'/><selection id='1.000000' content='5 stars'/></input>", ratingControl);

            ratingControl.DefaultRating = 0.6f;
            AssertInputPayload("<input id='rating' type='selection' hint-selectionType='rating' title='Rate me' defaultInput='0.600000'><selection id='0.200000' content='1 star'/><selection id='0.400000' content='2 stars'/><selection id='0.600000' content='3 stars'/><selection id='0.800000' content='4 stars'/><selection id='1.000000' content='5 stars'/></input>", ratingControl);

            ratingControl.DefaultRating = 0.8f;

            AssertInputPayload("<input id='rating' type='selection' hint-selectionType='rating' title='Rate me' defaultInput='0.800000'><selection id='0.200000' content='1 star'/><selection id='0.400000' content='2 stars'/><selection id='0.600000' content='3 stars'/><selection id='0.800000' content='4 stars'/><selection id='1.000000' content='5 stars'/></input>", ratingControl);

            ratingControl.DefaultRating = 1.0f;

            AssertInputPayload("<input id='rating' type='selection' hint-selectionType='rating' title='Rate me' defaultInput='1.000000'><selection id='0.200000' content='1 star'/><selection id='0.400000' content='2 stars'/><selection id='0.600000' content='3 stars'/><selection id='0.800000' content='4 stars'/><selection id='1.000000' content='5 stars'/></input>", ratingControl);
        }

        [TestMethod]
        public void Test_Toast_Xml_RatingControl_Nulls()
        {
            try
            {
                new ToastRatingControl(null, new string[] { "1 star", "2 stars", "3 stars", "4 stars", "5 stars" });
            }

            catch
            {
                try
                {
                    new ToastRatingControl("rating", null);
                }

                catch
                {
                    try
                    {
                        new ToastRatingControl("rating", new string[] { "1 star", null, "3 stars", "4 stars", "5 stars" });
                    }

                    catch
                    {
                        try
                        {
                            new ToastRatingControl("rating", new string[] { "1 star", "2 stars", null, "4 stars", "5 stars" });
                        }

                        catch
                        {
                            try
                            {
                                new ToastRatingControl("rating", new string[] { "1 star", "2 stars", "3 stars", null, "5 stars" });
                            }

                            catch
                            {
                                try
                                {
                                    new ToastRatingControl("rating", new string[] { "1 star", "2 stars", "3 stars", "4 stars", null });
                                }

                                catch { return; }
                            }
                        }
                    }
                }
            }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_RatingControl_WrongNumberOfAltContents()
        {
            try
            {
                new ToastRatingControl(null, new string[] { "1 star", "2 stars", "3 stars", "4 stars", "5 stars", "6 stars" });
            }

            catch
            {
                try
                {
                    new ToastRatingControl("rating", new string[] { null, "1 stars", "2 stars", "3 stars", "4 stars", "5 stars" });
                }

                catch
                {
                    try
                    {
                        new ToastRatingControl("rating", new string[] { });
                    }

                    catch
                    {
                        try
                        {
                            new ToastRatingControl("rating", new string[] { "1 star", "2 stars", "3 stars" });
                        }

                        catch
                        {
                            try
                            {
                                new ToastRatingControl("rating", new string[] { "1 star", "2 stars", "3 stars", "4 stars", "5 stars", "6 stars", "7 stars", "8 stars" });
                            }

                            catch
                            {
                                try
                                {
                                    new ToastRatingControl("rating", new string[] { "1 star" });
                                }

                                catch { return; }
                            }
                        }
                    }
                }
            }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_RatingControl_BadDefaultRating()
        {
            try
            {
                new ToastRatingControl("rating", new string[] { "1 star", "2 stars", "3 stars", "4 stars", "5 stars" })
                {
                    DefaultRating = 0.1f
                };
            }

            catch
            {
                try
                {
                    new ToastRatingControl("rating", new string[] { "1 star", "2 stars", "3 stars", "4 stars", "5 stars" })
                    {
                        DefaultRating = -1f
                    };
                }

                catch
                {
                    try
                    {
                        new ToastRatingControl("rating", new string[] { "1 star", "2 stars", "3 stars", "4 stars", "5 stars" })
                        {
                            DefaultRating = 1.5f
                        };
                    }

                    catch { return; }
                }
            }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_RatingControl_Emptys()
        {
            var ratingControl = new ToastRatingControl("", new string[] { "", "", "", "", "" });

            AssertInputPayload("<input id='' type='selection' hint-selectionType='rating'><selection id='0.200000' content=''/><selection id='0.400000' content=''/><selection id='0.600000' content=''/><selection id='0.800000' content=''/><selection id='1.000000' content=''/></input>", ratingControl);
        }

        [TestMethod]
        public void Test_Toast_Xml_RatingControl_Parsing()
        {
            Assert.AreEqual(0.0f, ToastRatingControl.ParseRating(null));

            Assert.AreEqual(0.0f, ToastRatingControl.ParseRating("0.000000"));

            Assert.AreEqual(0.2f, ToastRatingControl.ParseRating("0.200000"));

            Assert.AreEqual(0.4f, ToastRatingControl.ParseRating("0.400000"));

            Assert.AreEqual(0.6f, ToastRatingControl.ParseRating("0.600000"));

            Assert.AreEqual(0.8f, ToastRatingControl.ParseRating("0.800000"));

            Assert.AreEqual(1.0f, ToastRatingControl.ParseRating("1.000000"));

            Assert.AreEqual(0.0f, ToastRatingControl.ParseRating("0.0"));

            Assert.AreEqual(0.2f, ToastRatingControl.ParseRating("0.2"));

            Assert.AreEqual(0.4f, ToastRatingControl.ParseRating("0.4"));

            Assert.AreEqual(0.6f, ToastRatingControl.ParseRating("0.6"));

            Assert.AreEqual(0.8f, ToastRatingControl.ParseRating("0.8"));

            Assert.AreEqual(1.0f, ToastRatingControl.ParseRating("1.0"));
        }

        [TestMethod]
        public void Test_Toast_Xml_RatingControl_ParsingInvalids()
        {
            try
            {
                ToastRatingControl.ParseRating(0.2f);
            }

            catch
            {
                try
                {
                    ToastRatingControl.ParseRating("-1");
                }

                catch
                {
                    try
                    {
                        ToastRatingControl.ParseRating("0.1");
                    }

                    catch
                    {
                        try
                        {
                            ToastRatingControl.ParseRating("1.1");
                        }

                        catch { return; }
                    }
                }
            }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_SelectionBox_Defaults()
        {
            var selectionBox = new ToastSelectionBox("myId");

            AssertInputPayload("<input id='myId' type='selection' />", selectionBox);
        }

        [TestMethod]
        public void Test_Toast_Xml_SelectionBox_EmptyId()
        {
            var selectionBox = new ToastSelectionBox("");

            AssertInputPayload("<input id='' type='selection' />", selectionBox);
        }

        [TestMethod]
        public void Test_Toast_Xml_SelectionBox_NullId()
        {
            try
            {
                new ToastSelectionBox(null);
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_SelectionBox_DefaultSelectionBoxItemId_Value()
        {
            var selectionBox = new ToastSelectionBox("myId")
            {
                DefaultSelectionBoxItemId = "2"
            };

            AssertInputPayload("<input id='myId' type='selection' defaultInput='2' />", selectionBox);
        }

        [TestMethod]
        public void Test_Toast_Xml_SelectionBox_Title_Value()
        {
            var selectionBox = new ToastSelectionBox("myId")
            {
                Title = "My title"
            };

            AssertInputPayload("<input id='myId' type='selection' title='My title' />", selectionBox);
        }

        [TestMethod]
        public void Test_Toast_Xml_SelectionBoxItem()
        {
            var selectionBoxItem = new ToastSelectionBoxItem("myId", "My content");

            AssertSelectionPayload("<selection id='myId' content='My content' />", selectionBoxItem);
        }

        [TestMethod]
        public void Test_Toast_Xml_SelectionBoxItem_NullId()
        {
            try
            {
                new ToastSelectionBoxItem(null, "My content");
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_SelectionBoxItem_NullContent()
        {
            try
            {
                new ToastSelectionBoxItem("myId", null);
            }

            catch { return; }

            Assert.Fail("Exception should have been thrown.");
        }

        [TestMethod]
        public void Test_Toast_Xml_SelectionBoxItem_EmptyId()
        {
            var selectionBoxItem = new ToastSelectionBoxItem("", "My content");

            AssertSelectionPayload("<selection id='' content='My content' />", selectionBoxItem);
        }

        [TestMethod]
        public void Test_Toast_Xml_SelectionBoxItem_EmptyContent()
        {
            var selectionBoxItem = new ToastSelectionBoxItem("myId", "");

            AssertSelectionPayload("<selection id='myId' content='' />", selectionBoxItem);
        }

        private static void AssertAppLogoPayload(string expectedAppLogoXml, ToastAppLogo appLogo)
        {
            AssertVisualPayload(@"<visual><binding template=""ToastGeneric"">" + expectedAppLogoXml + "</binding></visual>", new ToastVisual()
            {
                AppLogoOverride = appLogo
            });
        }

        private static void AssertSelectionPayload(string expectedSelectionXml, ToastSelectionBoxItem selectionItem)
        {
            AssertInputPayload("<input id='myId' type='selection'>" + expectedSelectionXml + "</input>", new ToastSelectionBox("myId")
            {
                Items = { selectionItem }
            });
        }

        private static void AssertInputPayload(string expectedInputXml, IToastInput textBox)
        {
            AssertActionsPayload("<actions>" + expectedInputXml + "</actions>", new ToastActionsCustom()
            {
                Inputs = { textBox }
            });
        }

        private static void AssertButtonPayload(string expectedButtonXml, IToastButton button)
        {
            AssertActionsPayload("<actions>" + expectedButtonXml + "</actions>", new ToastActionsCustom()
            {
                Buttons = { button }
            });
        }

        private static void AssertActionsPayload(string expectedActionsXml, IToastActions actions)
        {
            AssertPayload("<toast>" + expectedActionsXml + "</toast>", new ToastContent()
            {
                Actions = actions
            });
        }

        private static void AssertAudioPayload(string expectedAudioXml, ToastAudio audio)
        {
            AssertPayload("<toast>" + expectedAudioXml + "</toast>", new ToastContent()
            {
                Audio = audio
            });
        }

        private static void AssertVisualPayload(string expectedVisualXml, ToastVisual visual)
        {
            AssertPayload("<toast>" + expectedVisualXml + "</toast>", new ToastContent()
            {
                Visual = visual
            });
        }

        private static void AssertPayload(string expectedXml, ToastContent toast)
        {
            AssertHelper.AssertXml(expectedXml, toast.GetContent());
        }
    }
}
