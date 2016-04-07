using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
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
            ToastNotificationManager.CreateToastNotifier().Show(new ToastNotification(content.GetXml()));
        }
        
        private void ButtonCustomSnoozeTimes_Click(object sender, RoutedEventArgs e)
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
    }
}
