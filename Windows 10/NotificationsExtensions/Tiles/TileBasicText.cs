// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Text;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif

namespace NotificationsExtensions
{
    public sealed class TileBasicText
    {
        /// <summary>
        /// The text value that will be shown in the text field.
        /// </summary>
        public string Text { get; set; }

        public string Lang { get; set; }

        internal Element_TileText ConvertToElement()
        {
            return new Element_TileText()
            {
                Text = Text,
                Lang = Lang
            };
        }

        public override string ToString()
        {
            return Text;
        }
    }
}