// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif
using System.Reflection;
using System.Linq;
using System.Collections;
using System.IO;

namespace NotificationsExtensions
{
    [NotificationXmlElement("action")]
    internal sealed class Element_ToastAction : IElement_ToastActionsChild
    {
        internal const ToastActivationType DEFAULT_ACTIVATION_TYPE = ToastActivationType.Foreground;

        /// <summary>
        /// The text to be displayed on the button.
        /// </summary>
        [NotificationXmlAttribute("content")]
        public string Content { get; set; }

        /// <summary>
        /// The arguments attribute describes the app-defined data that the app can later retrieve once it is activated from user taking this action.
        /// </summary>
        [NotificationXmlAttribute("arguments")]
        public string Arguments { get; set; }

        [NotificationXmlAttribute("activationType", DEFAULT_ACTIVATION_TYPE)]
        public ToastActivationType ActivationType { get; set; } = DEFAULT_ACTIVATION_TYPE;

        /// <summary>
        /// imageUri is optional and is used to provide an image icon for this action to display inside the button alone with the text content.
        /// </summary>
        [NotificationXmlAttribute("imageUri")]
        public string ImageUri { get; set; }

        /// <summary>
        /// This is specifically used for the quick reply scenario. 
        /// </summary>
        [NotificationXmlAttribute("hint-inputId")]
        public string InputId { get; set; }
    }
}