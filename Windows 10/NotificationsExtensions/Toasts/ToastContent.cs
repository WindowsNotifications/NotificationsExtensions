// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Runtime.CompilerServices;
using System.Text;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif

[assembly: InternalsVisibleTo("NotificationsExtensions.Win10.Test.Portable")]

namespace NotificationsExtensions
{

    /// <summary>
    /// Base tile element, which contains a single visual element.
    /// </summary>
    public sealed class ToastContent : INotificationContent
    {
        /// <summary>
        /// The visual element is required.
        /// </summary>
        public ToastVisual Visual { get; set; }

        public ToastAudio Audio { get; set; }

        /// <summary>
        /// Optionally create custom actions with buttons and inputs (using <see cref="ToastActionsCustom"/>) or optionally use the system-default snooze/dismiss controls (with <see cref="ToastActionsSnoozeAndDismiss"/>).
        /// </summary>
        public IToastActions Actions { get; set; }

        public string GetContent()
        {
            return ConvertToElement().GetContent();
        }

#if !WINRT_NOT_PRESENT

        public XmlDocument GetXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetContent());

            return doc;
        }

#endif

        internal Element_Toast ConvertToElement()
        {
            var toast = new Element_Toast();

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
            Element_ToastActions converted = ConversionHelper.ConvertToElement(actions) as Element_ToastActions;

            if (converted == null)
                throw new NotImplementedException("Toast actions must support converting to Element_ToastActions");

            return converted;
        }
    }
}