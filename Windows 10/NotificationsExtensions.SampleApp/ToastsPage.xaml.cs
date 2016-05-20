using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Popups;
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
    public sealed partial class ToastsPage : Page
    {
        public ToastsPage()
        {
            this.InitializeComponent();
        }

        private void ButtonQuickReply_Click(object sender, RoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText() { Text = "Andrew Bares" },
                            new AdaptiveText() { Text = "Hey, try out my new app!" }
                        }
                    }
                },

                Launch = "andrewbares",

                Actions = new ToastActionsCustom()
                {
                    Inputs =
                    {
                        new ToastTextBox("tbQuickReply")
                        {
                            PlaceholderContent = "type a reply"
                        }
                    },

                    Buttons =
                    {
                        new ToastButton("send", "send")
                        {
                            ImageUri = "Assets/next.png",
                            TextBoxId = "tbQuickReply",
                            ActivationType = ToastActivationType.Background
                        }
                    }
                }
            });
        }

        private void ButtonQuickReply_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    TitleText = new ToastText() { Text = "Andrew Bares" },
                    BodyTextLine1 = new ToastText() { Text = "Hey, try out my new app!" }
                },

                Launch = "andrewbares",

                Actions = new ToastActionsCustom()
                {
                    Inputs =
                    {
                        new ToastTextBox("tbQuickReply")
                        {
                            PlaceholderContent = "type a reply"
                        }
                    },

                    Buttons =
                    {
                        new ToastButton("send", "send")
                        {
                            ImageUri = "Assets/next.png",
                            TextBoxId = "tbQuickReply",
                            ActivationType = ToastActivationType.Background
                        }
                    }
                }
            });
        }

        private void Show(ToastContent content)
        {
            try
            {
                Debug.WriteLine(content.GetContent());
                ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()));
            }

            catch (Exception ex)
            {
                var dontWait = new MessageDialog(ex.ToString()).ShowAsync();
            }
        }
        
        private void ButtonCustomSnoozeTimes_Click(object sender, RoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Scenario = ToastScenario.Reminder,

                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText() { Text = "Daily Triage" },
                            new AdaptiveText() { Text = "10:00 AM - 10:30 AM" }
                        }
                    }
                },

                Launch = "392914",

                Actions = new ToastActionsCustom()
                {
                    Inputs =
                    {
                        new ToastSelectionBox("snoozeAmount")
                        {
                            Title = "Remind me...",
                            Items =
                            {
                                new ToastSelectionBoxItem("1", "Super soon (1 min)"),
                                new ToastSelectionBoxItem("5", "In a few mins"),
                                new ToastSelectionBoxItem("15", "When it starts"),
                                new ToastSelectionBoxItem("60", "After it's done")
                            },
                            DefaultSelectionBoxItemId = "1"
                        }
                    },

                    Buttons =
                    {
                        new ToastButtonSnooze()
                        {
                            SelectionBoxId = "snoozeAmount"
                        },

                        new ToastButtonDismiss()
                    }
                }
            });
        }

        private void ButtonCustomSnoozeTimes_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Scenario = ToastScenario.Reminder,

                Visual = new ToastVisual()
                {
                    TitleText = new ToastText() { Text = "Daily Triage" },
                    BodyTextLine1 = new ToastText() { Text = "10:00 AM - 10:30 AM" }
                },

                Launch = "392914",

                Actions = new ToastActionsCustom()
                {
                    Inputs =
                    {
                        new ToastSelectionBox("snoozeAmount")
                        {
                            Title = "Remind me...",
                            Items =
                            {
                                new ToastSelectionBoxItem("1", "Super soon (1 min)"),
                                new ToastSelectionBoxItem("5", "In a few mins"),
                                new ToastSelectionBoxItem("15", "When it starts"),
                                new ToastSelectionBoxItem("60", "After it's done")
                            },
                            DefaultSelectionBoxItemId = "1"
                        }
                    },

                    Buttons =
                    {
                        new ToastButtonSnooze()
                        {
                            SelectionBoxId = "snoozeAmount"
                        },

                        new ToastButtonDismiss()
                    }
                }
            });
        }

        private void ButtonCustomSnoozeAndDismissText_Click(object sender, RoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText() { Text = "Work" },
                            new AdaptiveText() { Text = "Wake up & go to work!!!" }
                        }
                    }
                },

                Launch = "394815",

                Scenario = ToastScenario.Alarm,

                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButtonSnooze("5 more mins plz"),
                        new ToastButtonDismiss("ok im awake")
                    }
                }
            });
        }

        private void ButtonCustomSnoozeAndDismissText_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    TitleText = new ToastText() { Text = "Work" },
                    BodyTextLine1 = new ToastText() { Text = "Wake up & go to work!!!" }
                },

                Launch = "394815",

                Scenario = ToastScenario.Alarm,

                Actions = new ToastActionsCustom()
                {
                    Buttons =
                    {
                        new ToastButtonSnooze("5 more mins plz"),
                        new ToastButtonDismiss("ok im awake")
                    }
                }
            });
        }

        private void ButtonSystemSnoozeDismiss_Click(object sender, RoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText() { Text = "Take Out Garbage" },
                            new AdaptiveText() { Text = "7:00 PM" }
                        }
                    }
                },

                Launch = "984910",

                Scenario = ToastScenario.Reminder,

                Actions = new ToastActionsSnoozeAndDismiss()
            });
        }

        private void ButtonSystemSnoozeDismiss_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    TitleText = new ToastText() { Text = "Take Out Garbage" },
                    BodyTextLine1 = new ToastText() { Text = "7:00 PM" }
                },

                Launch = "984910",

                Scenario = ToastScenario.Reminder,

                Actions = new ToastActionsSnoozeAndDismiss()
            });
        }

        private void ButtonLoopingAudio_Click(object sender, RoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText() { Text = "Looping Audio" },
                            new AdaptiveText() { Text = "Uses looping audio and long duration" }
                        }
                    }
                },

                Launch = "948908230",

                Duration = ToastDuration.Long,

                Audio = new ToastAudio()
                {
                    Src = new Uri("ms-winsoundevent:Notification.Default"),
                    Loop = true
                }
            });
        }

        private void ButtonLoopingAudio_RightTapped(object sender, RightTappedRoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    TitleText = new ToastText() { Text = "Looping Audio" },
                    BodyTextLine1 = new ToastText() { Text = "Uses looping audio and long duration" }
                },

                Launch = "948908230",

                Duration = ToastDuration.Long,

                Audio = new ToastAudio()
                {
                    Src = new Uri("ms-winsoundevent:Notification.Default"),
                    Loop = true
                }
            });
        }

        private void ButtonRS1StyleToast_Click(object sender, RoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Visual = new ToastVisual()
                {
                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText() { Text = "RS1 Style Toast with a long line of first text", HintMaxLines = 1 },
                            new AdaptiveText() { Text = "We use some new toast features here, like hero image, attribution text, context menu actions, larger app logo image, and max lines of 1 on the first text element." }
                        },

                        HeroImage = new ToastGenericHeroImage()
                        {
                            Source = "https://unsplash.it/400/300"
                        },

                        AppLogoOverride = new ToastGenericAppLogo()
                        {
                            Source = "https://unsplash.it/48",
                            HintCrop = ToastGenericAppLogoCrop.Circle
                        },

                        Attribution = new ToastGenericAttributionText()
                        {
                            Text = "messenger.com"
                        }
                    }
                },

                Actions = new ToastActionsCustom()
                {
                    ContextMenuItems =
                    {
                        new ToastContextMenuItem("Block notifications from this site", "args")
                    }
                }
            });
        }

        private void ButtonWeatherToast_Click(object sender, RoutedEventArgs e)
        {
            Show(new ToastContent()
            {
                Launch = "98008",

                Visual = new ToastVisual()
                {
                    BaseUri = new Uri("Assets/Apps/Weather/", UriKind.Relative),

                    BindingGeneric = new ToastBindingGeneric()
                    {
                        Children =
                        {
                            new AdaptiveText() { Text = "Today will be sunny with a high of 63 and a low of 42." },

                            new AdaptiveGroup()
                            {
                                Children =
                                {
                                    GenerateWeatherSubgroup("Mon", "Mostly Cloudy.png", 63, 42),
                                    GenerateWeatherSubgroup("Tue", "Cloudy.png", 57, 38),
                                    GenerateWeatherSubgroup("Wed", "Sunny.png", 59, 43),
                                    GenerateWeatherSubgroup("Thu", "Sunny.png", 62, 42),
                                    GenerateWeatherSubgroup("Fri", "Sunny.png", 71, 66)
                                }
                            }
                        }
                    }
                }
            });
        }

        private static AdaptiveSubgroup GenerateWeatherSubgroup(string day, string imageUri, int tempHi, int tempLo)
        {
            return new AdaptiveSubgroup()
            {
                HintWeight = 1,
                Children =
                {
                    new AdaptiveText() { Text = day, HintAlign = AdaptiveTextAlign.Center },
                    new AdaptiveImage() { Source = imageUri, HintRemoveMargin = true },
                    new AdaptiveText() { Text = tempHi + "°", HintAlign = AdaptiveTextAlign.Center },
                    new AdaptiveText() { Text = tempLo + "°", HintAlign = AdaptiveTextAlign.Center, HintStyle = AdaptiveTextStyle.CaptionSubtle }
                }
            };
        }
    }
}
