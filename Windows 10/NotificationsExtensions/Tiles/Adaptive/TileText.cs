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

namespace NotificationsExtensions.Tiles
{
    /// <summary>
    /// An adaptive text element.
    /// </summary>
    public sealed class TileText : ITileSubgroupChild, ITileAdaptiveChild
    {
        /// <summary>
        /// The text to display.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The target locale of the XML payload, specified as a BCP-47 language tags such as "en-US" or "fr-FR". The locale specified here overrides any other specified locale, such as that in binding or visual. If this value is a literal string, this attribute defaults to the user's UI language. If this value is a string reference, this attribute defaults to the locale chosen by Windows Runtime in resolving the string.
        /// </summary>
        public string Lang { get; set; }

        /// <summary>
        /// The style controls the text's font size, weight, and opacity.
        /// </summary>
        public TileTextStyle Style { get; set; } = Element_TileText.DEFAULT_STYLE;

        /// <summary>
        /// Set this to true to enable text wrapping. False by default.
        /// </summary>
        public bool Wrap { get; set; } = Element_TileText.DEFAULT_WRAP;

        private int _maxLines = Element_TileText.DEFAULT_MAX_LINES;

        /// <summary>
        /// The maximum number of lines the text element is allowed to display.
        /// </summary>
        public int MaxLines
        {
            get { return _maxLines; }
            set
            {
                Element_TileText.CheckMaxLinesValue(value);

                _maxLines = value;
            }
        }

        private int _minLines = Element_TileText.DEFAULT_MIN_LINES;

        /// <summary>
        /// The minimum number of lines the text element must display.
        /// </summary>
        public int MinLines
        {
            get { return _minLines; }
            set
            {
                Element_TileText.CheckMinLinesValue(value);

                _minLines = value;
            }
        }

        /// <summary>
        /// The horizontal alignment of the text.
        /// </summary>
        public TileTextAlign Align { get; set; } = Element_TileText.DEFAULT_ALIGN;

        internal Element_TileText ConvertToElement()
        {
            return new Element_TileText()
            {
                Text = Text,
                Lang = Lang,
                Style = Style,
                Wrap = Wrap,
                MaxLines = MaxLines,
                MinLines = MinLines,
                Align = Align
            };
        }

        /// <summary>
        /// Returns the value of the Text property.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Text;
        }
    }
}