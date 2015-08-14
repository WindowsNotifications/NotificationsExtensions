// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

#if !WINRT_NOT_PRESENT
using Windows.UI.Notifications;
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
        
    }

    /// <summary>
    /// A type contained by the tile and toast notification content objects that
    /// represents a text field in the template.
    /// </summary>
    public interface INotificationContentText
    {
        /// <summary>
        /// The text value that will be shown in the text field.
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// The language of the text field.  This proprety overrides the language provided in the
        /// containing notification object.  The language should be specified using the
        /// abbreviated language code as defined by BCP 47.
        /// </summary>
        string Lang { get; set; }
    }

    /// <summary>
    /// A type contained by the tile and toast notification content objects that
    /// represents an image in a template.
    /// </summary>
    public interface INotificationContentImage
    {
        /// <summary>
        /// The location of the image.  Relative image paths use the BaseUri provided in the containing
        /// notification object.  If no BaseUri is provided, paths are relative to ms-appx:///.
        /// Only png and jpg images are supported.  Images must be 1024x1024 pixels or less, and smaller than
        /// 200 kB in size.
        /// </summary>
        string Src { get; set; }

        /// <summary>
        /// Alt text that describes the image.
        /// </summary>
        string Alt { get; set; }

        /// <summary>
        /// Controls if query strings that denote the client configuration of contrast, scale, and language setting should be appended to the Src
        /// If true, Windows will append query strings onto the Src
        /// If false, Windows will not append query strings onto the Src
        /// Query string details:
        /// Parameter: ms-contrast
        ///     Values: standard, black, white
        /// Parameter: ms-scale
        ///     Values: 80, 100, 140, 180
        /// Parameter: ms-lang
        ///     Values: The BCP 47 language tag set in the notification xml, or if omitted, the current preferred language of the user
        /// </summary>
        bool AddImageQuery { get; set; }     
    }

    namespace BadgeContent
    {
        /// <summary>
        /// Base badge notification content interface.
        /// </summary>
        public interface IBadgeNotificationContent : INotificationContent
        {
#if !WINRT_NOT_PRESENT
            /// <summary>
            /// Creates a WinRT BadgeNotification object based on the content.
            /// </summary>
            /// <returns>A WinRT BadgeNotification object based on the content.</returns>
            BadgeNotification CreateNotification();
#endif
        }

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
