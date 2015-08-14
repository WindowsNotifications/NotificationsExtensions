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
    [NotificationXmlElement("input")]
    internal sealed class Element_ToastInput : IElement_ToastActionsChild
    {
        /// <summary>
        /// The id attribute is required and is for developers to retrieve user inputs once the app is activated (in the foreground or background).
        /// </summary>
        [NotificationXmlAttribute("id")]
        public string Id { get; set; }

        [NotificationXmlAttribute("type")]
        public ToastInputType Type { get; set; }

        /// <summary>
        /// The title attribute is optional and is for developers to specify a title for the input for shells to render when there is affordance.
        /// </summary>
        [NotificationXmlAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// The placeholderContent attribute is optional and is the grey-out hint text for text input type. This attribute is ignored when the input type is not “text”.
        /// </summary>
        [NotificationXmlAttribute("placeHolderContent")]
        public string PlaceholderContent { get; set; }

        /// <summary>
        /// The defaultInput attribute is optional and it allows developer to provide a default input value.
        /// </summary>
        [NotificationXmlAttribute("defaultInput")]
        public string DefaultInput { get; set; }

        public IList<IElement_ToastInputChild> Children { get; private set; } = new List<IElement_ToastInputChild>();
    }

    internal interface IElement_ToastInputChild { }

    internal enum ToastInputType
    {
        [EnumString("text")]
        Text,

        [EnumString("selection")]
        Selection
    }
}