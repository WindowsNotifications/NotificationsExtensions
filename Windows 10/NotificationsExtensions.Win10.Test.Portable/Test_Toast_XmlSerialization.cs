using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NotificationsExtensions.Toasts;

namespace NotificationsExtensions.Win10.Test.Portable
{
    [TestClass]
    public class Test_Toast_XmlSerialization
    {
        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_Defaults()
        {
            AssertPayload("<toast />", new Element_Toast());
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_ActivationType_Foreground()
        {
            Element_Toast toast = new Element_Toast()
            {
                ActivationType = ToastActivationType.Foreground
            };

            AssertPayload(@"<toast />", toast);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_ActivationType_Background()
        {
            Element_Toast toast = new Element_Toast()
            {
                ActivationType = ToastActivationType.Background
            };

            AssertPayload(@"<toast activationType=""background"" />", toast);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_ActivationType_Protocol()
        {
            Element_Toast toast = new Element_Toast()
            {
                ActivationType = ToastActivationType.Protocol
            };

            AssertPayload(@"<toast activationType=""protocol"" />", toast);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_Duration_Short()
        {
            Element_Toast toast = new Element_Toast()
            {
                Duration = ToastDuration.Short
            };

            AssertPayload(@"<toast />", toast);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_Duration_Long()
        {
            Element_Toast toast = new Element_Toast()
            {
                Duration = ToastDuration.Long
            };

            AssertPayload(@"<toast duration=""long"" />", toast);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_Launch_Value()
        {
            Element_Toast toast = new Element_Toast()
            {
                Launch = "myArgs"
            };

            AssertPayload(@"<toast launch=""myArgs"" />", toast);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_Scenario_Default()
        {
            Element_Toast toast = new Element_Toast()
            {
                Scenario = ToastScenario.Default
            };

            AssertPayload(@"<toast />", toast);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_Scenario_Alarm()
        {
            Element_Toast toast = new Element_Toast()
            {
                Scenario = ToastScenario.Alarm
            };

            AssertPayload(@"<toast scenario=""alarm"" />", toast);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_Scenario_Reminder()
        {
            Element_Toast toast = new Element_Toast()
            {
                Scenario = ToastScenario.Reminder
            };

            AssertPayload(@"<toast scenario=""reminder"" />", toast);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Toast_Scenario_IncomingCall()
        {
            Element_Toast toast = new Element_Toast()
            {
                Scenario = ToastScenario.IncomingCall
            };

            AssertPayload(@"<toast scenario=""incomingCall"" />", toast);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Visual_Defaults()
        {
            AssertVisualPayload("<visual />", new Element_ToastVisual());
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Visual_Version_Value()
        {
            var visual = new Element_ToastVisual()
            {
                Version = 3
            };

            AssertVisualPayload(@"<visual version=""3"" />", visual);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Visual_Lang_Value()
        {
            var visual = new Element_ToastVisual()
            {
                Language = "en-US"
            };

            AssertVisualPayload(@"<visual lang=""en-US"" />", visual);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Visual_BaseUri_Value()
        {
            var visual = new Element_ToastVisual()
            {
                BaseUri = new Uri("http://msn.com")
            };

            // Note - Uri adds the extra slash. BaseUri requires the slash at the end of the BaseUri, otherwise the tile update won't work.
            AssertVisualPayload(@"<visual baseUri=""http://msn.com/"" />", visual);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Visual_AddImageQuery_False()
        {
            var visual = new Element_ToastVisual()
            {
                AddImageQuery = false
            };

            AssertVisualPayload(@"<visual />", visual);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Visual_AddImageQuery_True()
        {
            var visual = new Element_ToastVisual()
            {
                AddImageQuery = true
            };

            AssertVisualPayload(@"<visual addImageQuery=""True"" />", visual);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Binding_Defaults()
        {
            AssertBindingPayload(@"<binding template=""ToastGeneric"" />", new Element_ToastBinding(ToastTemplateType.ToastGeneric));
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Binding_Template_ToastText01()
        {
            var binding = new Element_ToastBinding(ToastTemplateType.ToastText01);

            AssertBindingPayload(@"<binding template=""ToastText01"" />", binding);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Binding_AddImageQuery_False()
        {
            var binding = new Element_ToastBinding(ToastTemplateType.ToastGeneric)
            {
                AddImageQuery = false
            };

            AssertBindingPayload(@"<binding template=""ToastGeneric"" />", binding);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Binding_AddImageQuery_True()
        {
            var binding = new Element_ToastBinding(ToastTemplateType.ToastGeneric)
            {
                AddImageQuery = true
            };

            AssertBindingPayload(@"<binding template=""ToastGeneric"" addImageQuery=""True"" />", binding);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Binding_BaseUri_Value()
        {
            var binding = new Element_ToastBinding(ToastTemplateType.ToastGeneric)
            {
                BaseUri = new Uri("http://msn.com")
            };

            AssertBindingPayload(@"<binding template=""ToastGeneric"" baseUri=""http://msn.com/"" />", binding);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Binding_Language_Value()
        {
            var binding = new Element_ToastBinding(ToastTemplateType.ToastGeneric)
            {
                Language = "en-US"
            };

            AssertBindingPayload(@"<binding template=""ToastGeneric"" lang=""en-US"" />", binding);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Text_Defaults()
        {
            var text = new Element_ToastText();

            AssertTextPayload(@"<text />", text);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Text_Content()
        {
            var text = new Element_ToastText()
            {
                Text = "Hello world"
            };

            AssertTextPayload(@"<text>Hello world</text>", text);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Text_Content_WithSpaces()
        {
            var text = new Element_ToastText()
            {
                Text = "  Hello world "
            };

            AssertTextPayload(@"<text>  Hello world </text>", text);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Text_Content_Escaped()
        {
            var text = new Element_ToastText()
            {
                Text = "Tom & Jerry > Flinstones"
            };

            AssertTextPayload(@"<text>Tom &amp; Jerry &gt; Flinstones</text>", text);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Text_Lang_Value()
        {
            var text = new Element_ToastText()
            {
                Lang = "en-US"
            };

            AssertTextPayload(@"<text lang=""en-US"" />", text);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Image_Defaults()
        {
            var image = new Element_ToastImage();

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Image_AddImageQuery_False()
        {
            var image = new Element_ToastImage()
            {
                AddImageQuery = false
            };

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Image_AddImageQuery_True()
        {
            var image = new Element_ToastImage()
            {
                AddImageQuery = true
            };

            AssertImagePayload(@"<image addImageQuery=""True"" />", image);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Image_Alt_Value()
        {
            var image = new Element_ToastImage()
            {
                Alt = "alternate text"
            };

            AssertImagePayload(@"<image alt=""alternate text"" />", image);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Image_Crop_None()
        {
            var image = new Element_ToastImage()
            {
                Crop = ToastImageCrop.None
            };

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Image_Crop_Circle()
        {
            var image = new Element_ToastImage()
            {
                Crop = ToastImageCrop.Circle
            };

            AssertImagePayload(@"<image hint-crop=""circle"" />", image);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Image_Placement_Inline()
        {
            var image = new Element_ToastImage()
            {
                Placement = ToastImagePlacement.Inline
            };

            AssertImagePayload(@"<image />", image);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Image_Placement_AppLogoOverride()
        {
            var image = new Element_ToastImage()
            {
                Placement = ToastImagePlacement.AppLogoOverride
            };

            AssertImagePayload(@"<image placement=""appLogoOverride"" />", image);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Image_Src_Value()
        {
            var image = new Element_ToastImage()
            {
                Src = "image.jpg"
            };

            AssertImagePayload(@"<image src=""image.jpg"" />", image);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Audio_Defaults()
        {
            var audio = new Element_ToastAudio();

            AssertAudioPayload("<audio />", audio);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Audio_Src_Value_AppX()
        {
            var audio = new Element_ToastAudio()
            {
                Src = new Uri("ms-appx:///Audio.mp3")
            };

            AssertAudioPayload(@"<audio src=""ms-appx:///Audio.mp3"" />", audio);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Audio_Src_Value_AppData()
        {
            var audio = new Element_ToastAudio()
            {
                Src = new Uri("ms-appdata:///Audio.mp3")
            };

            AssertAudioPayload(@"<audio src=""ms-appdata:///Audio.mp3"" />", audio);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Audio_Src_Value_MSWinSounds()
        {
            var audio = new Element_ToastAudio()
            {
                Src = new Uri("ms-winsoundevent:Notification.Looping.Call5")
            };

            AssertAudioPayload(@"<audio src=""ms-winsoundevent:Notification.Looping.Call5"" />", audio);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Audio_Loop_False()
        {
            var audio = new Element_ToastAudio()
            {
                Loop = false
            };

            AssertAudioPayload(@"<audio />", audio);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Audio_Loop_True()
        {
            var audio = new Element_ToastAudio()
            {
                Loop = true
            };

            AssertAudioPayload(@"<audio loop=""True"" />", audio);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Audio_Silent_False()
        {
            var audio = new Element_ToastAudio()
            {
                Silent = false
            };

            AssertAudioPayload(@"<audio />", audio);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Audio_Silent_True()
        {
            var audio = new Element_ToastAudio()
            {
                Silent = true
            };

            AssertAudioPayload(@"<audio silent=""True"" />", audio);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Audio_AllProperties()
        {
            var audio = new Element_ToastAudio()
            {
                Src = new Uri("ms-appx:///Audio.mp3"),
                Loop = true,
                Silent = true
            };

            AssertAudioPayload(@"<audio src=""ms-appx:///Audio.mp3"" loop=""True"" silent=""True"" />", audio);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Actions_Default()
        {
            AssertActionsPayload("<actions />", new Element_ToastActions());
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Actions_SystemCommand_None()
        {
            var actions = new Element_ToastActions()
            {
                SystemCommand = ToastSystemCommand.None
            };

            AssertActionsPayload("<actions />", actions);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Actions_SystemCommand_SnoozeAndDismiss()
        {
            var actions = new Element_ToastActions()
            {
                SystemCommand = ToastSystemCommand.SnoozeAndDismiss
            };

            AssertActionsPayload(@"<actions hint-systemCommand=""SnoozeAndDismiss"" />", actions);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Action_Defaults()
        {
            var action = new Element_ToastAction();

            AssertActionPayload(@"<action />", action);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Action_Content_Value()
        {
            var action = new Element_ToastAction()
            {
                Content = "My content"
            };

            AssertActionPayload(@"<action content=""My content"" />", action);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Action_Arguments_Value()
        {
            var action = new Element_ToastAction()
            {
                Arguments = "myArgs"
            };

            AssertActionPayload(@"<action arguments=""myArgs"" />", action);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Action_ActivationType_Foreground()
        {
            var action = new Element_ToastAction()
            {
                ActivationType = ToastActivationType.Foreground
            };

            AssertActionPayload(@"<action />", action);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Action_ActivationType_Background()
        {
            var action = new Element_ToastAction()
            {
                ActivationType = ToastActivationType.Background
            };

            AssertActionPayload(@"<action activationType=""background"" />", action);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Action_ActivationType_Protocol()
        {
            var action = new Element_ToastAction()
            {
                ActivationType = ToastActivationType.Protocol
            };

            AssertActionPayload(@"<action activationType=""protocol"" />", action);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Action_ImageUri_Value()
        {
            var action = new Element_ToastAction()
            {
                ImageUri = "image.jpg"
            };

            AssertActionPayload(@"<action imageUri=""image.jpg"" />", action);
        }

        [TestMethod]
        public void Test_Toast_XmlSerialization_Action_InputId_Value()
        {
            var action = new Element_ToastAction()
            {
                InputId = "myId"
            };

            AssertActionPayload(@"<action hint-inputId=""myId"" />", action);
        }










        private static void AssertImagePayload(string expectedImageXml, Element_ToastImage image)
        {
            var binding = new Element_ToastBinding(ToastTemplateType.ToastGeneric)
            {
                Children = { image }
            };

            AssertBindingPayload(@"<binding template=""ToastGeneric"">" + expectedImageXml + "</binding>", binding);
        }

        private static void AssertTextPayload(string expectedTextXml, Element_ToastText text)
        {
            var binding = new Element_ToastBinding(ToastTemplateType.ToastGeneric)
            {
                Children = { text }
            };

            AssertBindingPayload(@"<binding template=""ToastGeneric"">" + expectedTextXml + "</binding>", binding);
        }

        private static void AssertBindingPayload(string expectedBindingXml, Element_ToastBinding binding)
        {
            AssertVisualPayload("<visual>" + expectedBindingXml + "</visual>", new Element_ToastVisual()
            {
                Bindings =
                {
                    binding
                }
            });
        }

        private static void AssertVisualPayload(string expectedVisualXml, Element_ToastVisual visual)
        {
            AssertPayload("<toast>" + expectedVisualXml + "</toast>", new Element_Toast() { Visual = visual });
        }

        private static void AssertActionPayload(string expectedActionXml, Element_ToastAction action)
        {
            var actions = new Element_ToastActions()
            {
                Children = { action }
            };

            AssertActionsPayload("<actions>" + expectedActionXml + "</actions>", actions);
        }

        private static void AssertActionsPayload(string expectedActionsXml, Element_ToastActions actions)
        {
            AssertPayload("<toast>" + expectedActionsXml + "</toast>", new Element_Toast() { Actions = actions });
        }

        private static void AssertAudioPayload(string expectedAudioXml, Element_ToastAudio audio)
        {
            AssertPayload("<toast>" + expectedAudioXml + "</toast>", new Element_Toast() { Audio = audio });
        }

        private static void AssertPayload(string expectedXml, Element_Toast toast)
        {
            AssertHelper.AssertXml(expectedXml, toast.GetContent());
            //Assert.AreEqual("<?xml version=\"1.0\" encoding=\"utf-8\"?>" + expectedXml, toast.GetXml());
        }
    }
}
