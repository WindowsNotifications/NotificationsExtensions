// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

#if WINRT
using Windows.Data.Xml.Dom;
#endif

namespace NotificationsExtensions
{
    /// <summary>
    /// Base notification content interface to retrieve notification Xml as a string.
    /// </summary>
    public interface INotificationContent
    {
        /// <summary>
        /// Retrieves the notification Xml content as a string.
        /// </summary>
        /// <returns>The notification Xml content as a string.</returns>
        string GetContent();

#if WINRT
        /// <summary>
        /// Retrieves the notification Xml content as a WinRT Xml document.
        /// </summary>
        /// <returns>The notification Xml content as a WinRT Xml document.</returns>
        XmlDocument GetXml();
#endif
    }

    namespace Badges
    {

        /// <summary>
        /// The types of glyphs that can be placed on a badge.
        /// </summary>
        public enum GlyphValue
        {
            /// <summary>
            /// No glyph.  If there is a numeric badge, or a glyph currently on the badge,
            /// it will be removed.
            /// </summary>
            None = 0,
            /// <summary>
            /// A glyph representing application activity.
            /// </summary>
            Activity,
            /// <summary>
            /// A glyph representing an alert.
            /// </summary>
            Alert,
            /// <summary>
            /// A glyph representing an alarm.
            /// </summary>
            Alarm,
            /// <summary>
            /// A glyph representing availability status.
            /// </summary>
            Available,
            /// <summary>
            /// A glyph representing away status
            /// </summary>
            Away,
            /// <summary>
            /// A glyph representing busy status.
            /// </summary>
            Busy,
            /// <summary>
            /// A glyph representing that a new message is available.
            /// </summary>
            NewMessage,
            /// <summary>
            /// A glyph representing that media is paused.
            /// </summary>
            Paused,
            /// <summary>
            /// A glyph representing that media is playing.
            /// </summary>
            Playing,
            /// <summary>
            /// A glyph representing unavailable status.
            /// </summary>
            Unavailable,
            /// <summary>
            /// A glyph representing an error.
            /// </summary>
            Error,
            /// <summary>
            /// A glyph representing attention status.
            /// </summary>
            Attention
        }
    }
}
