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
    [NotificationXmlElement("actions")]
    internal sealed class Element_ToastActions
    {
        internal const ToastSystemCommand DEFAULT_SYSTEM_COMMAND = ToastSystemCommand.None;

        [NotificationXmlAttribute("hint-systemCommand", DEFAULT_SYSTEM_COMMAND)]
        public ToastSystemCommand SystemCommand { get; set; } = ToastSystemCommand.None;

        public IList<IElement_ToastActionsChild> Children { get; private set; } = new List<IElement_ToastActionsChild>();
    }

    internal interface IElement_ToastActionsChild { }

    internal enum ToastSystemCommand
    {
        None,
        SnoozeAndDismiss
    }
}