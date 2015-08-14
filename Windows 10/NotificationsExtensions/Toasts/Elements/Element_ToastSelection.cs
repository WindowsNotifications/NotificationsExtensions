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
    [NotificationXmlElement("selection")]
    internal sealed class Element_ToastSelection : IElement_ToastInputChild
    {
        /// <summary>
        /// The id attribute is required and it is for apps to retrieve back the user selected input after the app is activated.
        /// </summary>
        [NotificationXmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// The text to display for this selection element.
        /// </summary>
        [NotificationXmlAttribute("content")]
        public string Content { get; set; }
    }
}