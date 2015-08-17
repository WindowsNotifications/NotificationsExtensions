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
    /// Specify audio to be played when the toast notification is received.
    /// </summary>
    public sealed class ToastAudio
    {
        /// <summary>
        /// The media file to play in place of the default sound.
        /// </summary>
        public Uri Src { get; set; }

        /// <summary>
        /// Set to true if the sound should repeat as long as the toast is shown; false to play only once (default).
        /// </summary>
        public bool Loop { get; set; } = Element_ToastAudio.DEFAULT_LOOP;

        /// <summary>
        /// True to mute the sound; false to allow the toast notification sound to play (default).
        /// </summary>
        public bool Silent { get; set; } = Element_ToastAudio.DEFAULT_SILENT;

        internal Element_ToastAudio ConvertToElement()
        {
            return new Element_ToastAudio()
            {
                Src = Src,
                Loop = Loop,
                Silent = Silent
            };
        }
    }


}
