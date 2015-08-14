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

    namespace ToastContent
    {
        /// <summary>
        /// Type representing the toast notification audio properties which is contained within
        /// a toast notification content object.
        /// </summary>
        public interface IToastAudio
        {
            /// <summary>
            /// The audio content that should be played when the toast is shown.
            /// </summary>
            ToastAudioContent Content { get; set; }

            /// <summary>
            /// Whether the audio should loop.  If this property is set to true, the toast audio content
            /// must be a looping sound.
            /// </summary>
            bool Loop { get; set; }
        }

        /// <summary>
        /// Base toast notification content interface.
        /// </summary>
        public interface IToastNotificationContent : INotificationContent
        {
            /// <summary>
            /// Whether strict validation should be applied when the Xml or notification object is created,
            /// and when some of the properties are assigned.
            /// </summary>
            bool StrictValidation { get; set; }

            /// <summary>
            /// The language of the content being displayed.  The language should be specified using the
            /// abbreviated language code as defined by BCP 47.
            /// </summary>
            string Lang { get; set; }

            /// <summary>
            /// The BaseUri that should be used for image locations.  Relative image locations use this
            /// field as their base Uri.  The BaseUri must begin with http://, https://, ms-appx:///, or 
            /// ms-appdata:///local/.
            /// </summary>
            string BaseUri { get; set; }

            /// <summary>
            /// Controls if query strings that denote the client configuration of contrast, scale, and language setting should be appended to the Src
            /// If true, Windows will append query strings onto images that exist in this template
            /// If false (the default, Windows will not append query strings onto images that exist in this template            
            /// Query string details:
            /// Parameter: ms-contrast
            ///     Values: standard, black, white
            /// Parameter: ms-scale
            ///     Values: 80, 100, 140, 180
            /// Parameter: ms-lang
            ///     Values: The BCP 47 language tag set in the notification xml, or if omitted, the current preferred language of the user
            /// </summary>
            bool AddImageQuery { get; set; }     

            /// <summary>
            /// The launch parameter passed into the metro application when the toast is activated.
            /// </summary>
            string Launch { get; set; }

            /// <summary>
            /// The audio that should be played when the toast is displayed.
            /// </summary>
            IToastAudio Audio { get; }

            /// <summary>
            /// The length that the toast should be displayed on screen.
            /// </summary>
            ToastDuration Duration { get; set; }

#if !WINRT_NOT_PRESENT
            /// <summary>
            /// Creates a WinRT ToastNotification object based on the content.
            /// </summary>
            /// <returns>A WinRT ToastNotification object based on the content.</returns>
            ToastNotification CreateNotification();
#endif
        }

        /// <summary>
        /// The audio options that can be played while the toast is on screen.
        /// </summary>
        public enum ToastAudioContent
        {
            /// <summary>
            /// The default toast audio sound.
            /// </summary>
            Default = 0,
            /// <summary>
            /// Audio that corresponds to new mail arriving.
            /// </summary>
            Mail,
            /// <summary>
            /// Audio that corresponds to a new SMS message arriving.
            /// </summary>
            SMS,
            /// <summary>
            /// Audio that corresponds to a new IM arriving.
            /// </summary>
            IM,
            /// <summary>
            /// Audio that corresponds to a reminder.
            /// </summary>
            Reminder,
            /// <summary>
            /// The default looping sound.  Audio that corresponds to a call.
            /// Only valid for toasts that are have the duration set to "Long".
            /// </summary>
            LoopingCall,
            /// <summary>
            /// Audio that corresponds to a call.
            /// Only valid for toasts that are have the duration set to "Long".
            /// </summary>
            LoopingCall2,
            /// <summary>
            /// Audio that corresponds to an alarm.
            /// Only valid for toasts that are have the duration set to "Long".
            /// </summary>
            LoopingAlarm,
            /// <summary>
            /// Audio that corresponds to an alarm.
            /// Only valid for toasts that are have the duration set to "Long".
            /// </summary>
            LoopingAlarm2,
            /// <summary>
            /// No audio should be played when the toast is displayed.
            /// </summary>
            Silent
        }

        /// <summary>
        /// The duration the toast should be displayed on screen.
        /// </summary>
        public enum ToastDuration
        {
            /// <summary>
            /// Default behavior.  The toast will be on screen for a short amount of time.
            /// </summary>
            Short = 0,
            /// <summary>
            /// The toast will be on screen for a longer amount of time.
            /// </summary>
            Long
        }

        /// <summary>
        /// A toast template that displays an image and a text field.
        /// </summary>
        public interface IToastImageAndText01 : IToastNotificationContent
        {
            /// <summary>
            /// The main image on the toast.
            /// </summary>
            INotificationContentImage Image { get; }

            /// <summary>
            /// A body text field.
            /// </summary>
            INotificationContentText TextBodyWrap { get; }
        }

        /// <summary>
        /// A toast template that displays an image and two text fields.
        /// </summary>
        public interface IToastImageAndText02 : IToastNotificationContent
        {
            /// <summary>
            /// The main image on the toast.
            /// </summary>
            INotificationContentImage Image { get; }

            /// <summary>
            /// A heading text field.
            /// </summary>
            INotificationContentText TextHeading { get; }

            /// <summary>
            /// A body text field.
            /// </summary>
            INotificationContentText TextBodyWrap { get; }
        }

        /// <summary>
        /// A toast template that displays an image and two text fields.
        /// </summary>
        public interface IToastImageAndText03 : IToastNotificationContent
        {
            /// <summary>
            /// The main image on the toast.
            /// </summary>
            INotificationContentImage Image { get; }

            /// <summary>
            /// A heading text field.
            /// </summary>
            INotificationContentText TextHeadingWrap { get; }

            /// <summary>
            /// A body text field.
            /// </summary>
            INotificationContentText TextBody { get; }
        }

        /// <summary>
        /// A toast template that displays an image and three text fields.
        /// </summary>
        public interface IToastImageAndText04 : IToastNotificationContent
        {
            /// <summary>
            /// The main image on the toast.
            /// </summary>
            INotificationContentImage Image { get; }

            /// <summary>
            /// A heading text field.
            /// </summary>
            INotificationContentText TextHeading { get; }

            /// <summary>
            /// A body text field.
            /// </summary>
            INotificationContentText TextBody1 { get; }

            /// <summary>
            /// A body text field.
            /// </summary>
            INotificationContentText TextBody2 { get; }
        }

        /// <summary>
        /// A toast template that displays a text fields.
        /// </summary>
        public interface IToastText01 : IToastNotificationContent
        {
            /// <summary>
            /// A body text field.
            /// </summary>
            INotificationContentText TextBodyWrap { get; }
        }

        /// <summary>
        /// A toast template that displays two text fields.
        /// </summary>
        public interface IToastText02 : IToastNotificationContent
        {
            /// <summary>
            /// A heading text field.
            /// </summary>
            INotificationContentText TextHeading { get; }

            /// <summary>
            /// A body text field.
            /// </summary>
            INotificationContentText TextBodyWrap { get; }
        }

        /// <summary>
        /// A toast template that displays two text fields.
        /// </summary>
        public interface IToastText03 : IToastNotificationContent
        {
            /// <summary>
            /// A heading text field.
            /// </summary>
            INotificationContentText TextHeadingWrap { get; }

            /// <summary>
            /// A body text field.
            /// </summary>
            INotificationContentText TextBody { get; }
        }

        /// <summary>
        /// A toast template that displays three text fields.
        /// </summary>
        public interface IToastText04 : IToastNotificationContent
        {
            /// <summary>
            /// A heading text field.
            /// </summary>
            INotificationContentText TextHeading { get; }

            /// <summary>
            /// A body text field.
            /// </summary>
            INotificationContentText TextBody1 { get; }

            /// <summary>
            /// A body text field.
            /// </summary>
            INotificationContentText TextBody2 { get; }
        }
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
