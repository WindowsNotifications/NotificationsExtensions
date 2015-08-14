// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif

namespace NotificationsExtensions
{
    /// <summary>
    /// Contains multiple binding child elements, each of which defines a tile.
    /// </summary>
    public sealed class ToastTextBox : IToastInput
    {
        /// <summary>
        /// Constructs a new Toast TextBox input control with the required elements.
        /// </summary>
        /// <param name="id">Developer-provided ID that the developer uses later to retrieve input when the toast is interacted with.</param>
        public ToastTextBox(string id)
        {
            if (id == null)
                throw new ArgumentNullException("id");

            Id = id;
        }

        /// <summary>
        /// The ID property is required, and is used so that developers can retrieve user input once the app is activated.
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// Title text to display above the text box.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Placeholder text to be displayed on the text box when the user hasn't typed any text yet.
        /// </summary>
        public string PlaceholderContent { get; set; }

        /// <summary>
        /// The initial text to place in the text box. Leave this null for a blank text box.
        /// </summary>
        public string DefaultInput { get; set; }

        internal Element_ToastInput ConvertToElement()
        {
            return new Element_ToastInput()
            {
                Id = Id,
                Type = ToastInputType.Text,
                DefaultInput = DefaultInput,
                PlaceholderContent = PlaceholderContent,
                Title = Title
            };
        }
    }


}