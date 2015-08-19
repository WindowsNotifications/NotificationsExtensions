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
using System.Reflection;
using System.Linq;
using System.Collections;
using System.IO;

namespace NotificationsExtensions.Tiles
{
    [NotificationXmlElement("text")]
    internal sealed class Element_TileText : IElement_TileBindingChild, IElement_TileSubgroupChild
    {
        internal const TileTextStyle DEFAULT_STYLE = TileTextStyle.Caption;
        internal const bool DEFAULT_WRAP = false;
        internal const int DEFAULT_MAX_LINES = int.MaxValue;
        internal const int DEFAULT_MIN_LINES = 1;
        internal const TileTextAlign DEFAULT_ALIGN = TileTextAlign.Auto;

        [NotificationXmlContent]
        public string Text { get; set; }

        [NotificationXmlAttribute("id")]
        public int? Id { get; set; }

        [NotificationXmlAttribute("lang")]
        public string Lang { get; set; }

        [NotificationXmlAttribute("hint-align", DEFAULT_ALIGN)]
        public TileTextAlign Align { get; set; } = DEFAULT_ALIGN;

        private int _maxLines = DEFAULT_MAX_LINES;
        [NotificationXmlAttribute("hint-maxLines", DEFAULT_MAX_LINES)]
        public int MaxLines
        {
            get { return _maxLines; }
            set
            {
                CheckMaxLinesValue(value);

                _maxLines = value;
            }
        }

        internal static void CheckMaxLinesValue(int value)
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException("MaxLines must be between 1 and int.MaxValue, inclusive.");
        }

        private int _minLines = DEFAULT_MIN_LINES;
        [NotificationXmlAttribute("hint-minLines", DEFAULT_MIN_LINES)]
        public int MinLines
        {
            get { return _minLines; }
            set
            {
                CheckMinLinesValue(value);

                _minLines = value;
            }
        }

        internal static void CheckMinLinesValue(int value)
        {
            if (value < 1)
                throw new ArgumentOutOfRangeException("MinLines must be between 1 and int.MaxValue, inclusive.");
        }

        [NotificationXmlAttribute("hint-style", DEFAULT_STYLE)]
        public TileTextStyle Style { get; set; } = DEFAULT_STYLE;

        [NotificationXmlAttribute("hint-wrap", DEFAULT_WRAP)]
        public bool Wrap { get; set; } = DEFAULT_WRAP;
    }
}