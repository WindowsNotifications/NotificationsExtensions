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
    public sealed class ToastButton
    {
        /// <summary>
        /// Constructs a toast button with the required properties.
        /// </summary>
        /// <param name="content">The text to display on the button.</param>
        /// <param name="arguments">App-defined string of arguments that the app can later retrieve once it is activated when the user clicks the button.</param>
        public ToastButton(string content, string arguments)
        {
            if (content == null)
                throw new ArgumentNullException("content");

            if (arguments == null)
                throw new ArgumentNullException("arguments");

            Content = content;
            Arguments = arguments;
        }

        /// <summary>
        /// Required. The text to display on the button.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Required. App-defined string of arguments that the app can later retrieve once it is activated when the user clicks the button.
        /// </summary>
        public string Arguments { get; private set; }

        /// <summary>
        /// Controls what type of activation this button will use when clicked. Defaults to Foreground.
        /// </summary>
        public ToastActivationType ActivationType { get; set; } = Element_ToastAction.DEFAULT_ACTIVATION_TYPE;

        /// <summary>
        /// An optional image icon for the button to display (required for buttons adjacent to inputs like quick reply).
        /// </summary>
        public string ImageUri { get; set; }

        /// <summary>
        /// Specify the ID of an existing <see cref="ToastTextBox"/> in order to have this button display to the right of the input, achieving a quick reply scenario.
        /// </summary>
        public string TextBoxId { get; set; }

        internal Element_ToastAction ConvertToElement()
        {
            return new Element_ToastAction()
            {
                Content = Content,
                Arguments = Arguments,
                ActivationType = ActivationType,
                ImageUri = ImageUri,
                InputId = TextBoxId
            };
        }
    }


}
