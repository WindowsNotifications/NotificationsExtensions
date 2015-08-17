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

namespace NotificationsExtensions.Toasts
{
    /// <summary>
    /// Decides the type of activation that will be used when the user interacts with the toast notification.
    /// </summary>
    public enum ToastActivationType
    {
        /// <summary>
        /// Default value. Your foreground app is launched.
        /// </summary>
        Foreground,

        /// <summary>
        /// Your corresponding background task (assuming you set everything up) is triggered, and you can execute code in the background (like sending the user's quick reply message) without interrupting the user.
        /// </summary>
        [EnumString("background")]
        Background,

        /// <summary>
        /// Launch a different app using protocol activation.
        /// </summary>
        [EnumString("protocol")]
        Protocol
    }
}
