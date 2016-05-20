// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using NotificationsExtensions.Adaptive.Elements;
using NotificationsExtensions.Tiles;

namespace NotificationsExtensions
{
    /// <summary>
    /// An adaptive text element.
    /// </summary>
    public sealed class AdaptiveText : IAdaptiveSubgroupChild, IAdaptiveChild, IBaseText, ITileAdaptiveChild
    {
        /// <summary>
        /// Initializes a new Adaptive text element.
        /// </summary>
        public AdaptiveText() { }

        /// <summary>
        /// The text to display.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// The target locale of the XML payload, specified as a BCP-47 language tags such as "en-US" or "fr-FR". The locale specified here overrides any other specified locale, such as that in binding or visual. If this value is a literal string, this attribute defaults to the user's UI language. If this value is a string reference, this attribute defaults to the locale chosen by Windows Runtime in resolving the string.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// The style controls the text's font size, weight, and opacity.
        /// </summary>
        public AdaptiveTextStyle HintStyle { get; set; }

        /// <summary>
        /// Set this to true to enable text wrapping. False by default.
        /// </summary>
        public bool? HintWrap { get; set; }

        private int? _hintMaxLines;

        /// <summary>
        /// The maximum number of lines the text element is allowed to display.
        /// </summary>
        public int? HintMaxLines
        {
            get { return _hintMaxLines; }
            set
            {
                if (value != null)
                    Element_AdaptiveText.CheckMaxLinesValue(value.Value);

                _hintMaxLines = value;
            }
        }

        private int? _hintMinLines;

        /// <summary>
        /// The minimum number of lines the text element must display.
        /// </summary>
        public int? HintMinLines
        {
            get { return _hintMinLines; }
            set
            {
                if (value != null)
                    Element_AdaptiveText.CheckMinLinesValue(value.Value);

                _hintMinLines = value;
            }
        }

        /// <summary>
        /// The horizontal alignment of the text.
        /// </summary>
        public AdaptiveTextAlign HintAlign { get; set; }

        internal Element_AdaptiveText ConvertToElement()
        {
            return new Element_AdaptiveText()
            {
                Text = Text,
                Lang = Language,
                Style = HintStyle,
                Wrap = HintWrap,
                MaxLines = HintMaxLines,
                MinLines = HintMinLines,
                Align = HintAlign
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
