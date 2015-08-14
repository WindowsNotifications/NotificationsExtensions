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
    /// <summary>
    /// An adaptive text element
    /// </summary>
    public sealed class TileText : ITileSubgroupChild, ITileAdaptiveChild
    {
        public string Text { get; set; }

        public string Lang { get; set; }

        public TileTextStyle Style { get; set; } = Element_TileText.DEFAULT_STYLE;

        public bool Wrap { get; set; } = Element_TileText.DEFAULT_WRAP;

        private int _maxLines = Element_TileText.DEFAULT_MAX_LINES;
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
        public int MinLines
        {
            get { return _minLines; }
            set
            {
                Element_TileText.CheckMinLinesValue(value);

                _minLines = value;
            }
        }

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

        public override string ToString()
        {
            return Text;
        }
    }
}