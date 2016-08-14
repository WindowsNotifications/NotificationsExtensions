// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Runtime.CompilerServices;
#if WINDOWS_UWP
using Windows.Data.Xml.Dom;
#endif

namespace NotificationsExtensions.Toasts
{

    /// <summary>
    /// Base toast element, which contains at least a visual element.
    /// </summary>
    public sealed class ToastContent : INotificationContent
    {
        /// <summary>
        /// Initializes a new instance of toast content. You must then set the Visual property, which is required for a toast notification. You can optionally set Audio, Actions, and more.
        /// </summary>
        public ToastContent() { }

        /// <summary>
        /// The visual element is required.
        /// </summary>
        public ToastVisual Visual { get; set; }

        /// <summary>
        /// Specify custom audio options.
        /// </summary>
        public ToastAudio Audio { get; set; }

        /// <summary>
        /// Optionally create custom actions with buttons and inputs (using <see cref="ToastActionsCustom"/>) or optionally use the system-default snooze/dismiss controls (with <see cref="ToastActionsSnoozeAndDismiss"/>).
        /// </summary>
        public IToastActions Actions { get; set; }

        /// <summary>
        /// Specify the scenario, to make the toast behave like an alarm, reminder, or more.
        /// </summary>
        public ToastScenario Scenario { get; set; }

        /// <summary>
        /// The amount of time the toast should display. You typically should use the Scenario attribute instead, which impacts how long a toast stays on screen.
        /// </summary>
        public ToastDuration Duration { get; set; }

        /// <summary>
        /// A string that is passed to the application when it is activated by the toast. The format and contents of this string are defined by the app for its own use. When the user taps or clicks the toast to launch its associated app, the launch string provides the context to the app that allows it to show the user a view relevant to the toast content, rather than launching in its default way.
        /// </summary>
        public string Launch { get; set; }

        /// <summary>
        /// Specifies what activation type will be used when the user clicks the body of this toast.
        /// </summary>
        public ToastActivationType ActivationType { get; set; }

        /// <summary>
        /// Retrieves the notification XML content as a string, so that it can be sent with a HTTP POST in a push notification.
        /// </summary>
        /// <returns>The notification XML content as a string.</returns>
        public string GetContent()
        {
            return ConvertToElement().GetContent();
        }

#if WINDOWS_UWP

        /// <summary>
        /// Retrieves the notification XML content as a WinRT XmlDocument, so that it can be used with a local toast notification's constructor on either <see cref="Windows.UI.Notifications.ToastNotification"/> or <see cref="Windows.UI.Notifications.ScheduledToastNotification"/>.
        /// </summary>
        /// <returns>The notification XML content as a WinRT XmlDocument.</returns>
        public XmlDocument GetXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetContent());

            return doc;
        }

#endif

        internal Element_Toast ConvertToElement()
        {
            var toast = new Element_Toast()
            {
                ActivationType = ActivationType,
                Duration = Duration,
                Launch = Launch,
                Scenario = Scenario
            };

            if (Visual != null)
                toast.Visual = Visual.ConvertToElement();

            if (Audio != null)
                toast.Audio = Audio.ConvertToElement();

            if (Actions != null)
                toast.Actions = ConvertToActionsElement(Actions);
            

            return toast;
        }

        private static Element_ToastActions ConvertToActionsElement(IToastActions actions)
        {
            if (actions is ToastActionsCustom)
                return (actions as ToastActionsCustom).ConvertToElement();

            else if (actions is ToastActionsSnoozeAndDismiss)
                return (actions as ToastActionsSnoozeAndDismiss).ConvertToElement();

            throw new NotImplementedException("Unknown actions type: " + actions.GetType());
        }
    }
}