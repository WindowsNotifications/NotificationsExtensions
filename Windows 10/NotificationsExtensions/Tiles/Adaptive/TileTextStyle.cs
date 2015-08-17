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

namespace NotificationsExtensions.Tiles
{
    /// <summary>
    /// Text style controls font size, weight, and opacity.
    /// </summary>
    public enum TileTextStyle
    {
        /// <summary>
        /// Default value. Paragraph font size, normal weight and opacity.
        /// </summary>
        [EnumString("caption")]
        Caption,

        /// <summary>
        /// Same as Caption but with subtle opacity.
        /// </summary>
        [EnumString("captionSubtle")]
        CaptionSubtle,

        /// <summary>
        /// H5 font size.
        /// </summary>
        [EnumString("body")]
        Body,

        /// <summary>
        /// Same as Body but with subtle opacity.
        /// </summary>
        [EnumString("bodySubtle")]
        BodySubtle,

        /// <summary>
        /// H5 font size, bold weight. Essentially the bold version of Body.
        /// </summary>
        [EnumString("base")]
        Base,

        /// <summary>
        /// Same as Base but with subtle opacity.
        /// </summary>
        [EnumString("baseSubtle")]
        BaseSubtle,

        /// <summary>
        /// H4 font size.
        /// </summary>
        [EnumString("subtitle")]
        Subtitle,

        /// <summary>
        /// Same as Subtitle but with subtle opacity.
        /// </summary>
        [EnumString("subtitleSubtle")]
        SubtitleSubtle,

        /// <summary>
        /// H3 font size.
        /// </summary>
        [EnumString("title")]
        Title,

        /// <summary>
        /// Same as Title but with subtle opacity.
        /// </summary>
        [EnumString("titleSubtle")]
        TitleSubtle,

        /// <summary>
        /// Same as Title but with top/bottom padding removed.
        /// </summary>
        [EnumString("titleNumeral")]
        TitleNumeral,

        /// <summary>
        /// H2 font size.
        /// </summary>
        [EnumString("subheader")]
        Subheader,

        /// <summary>
        /// Same as Subheader but with subtle opacity.
        /// </summary>
        [EnumString("subheaderSubtle")]
        SubheaderSubtle,

        /// <summary>
        /// Same as Subheader but with top/bottom padding removed.
        /// </summary>
        [EnumString("subheaderNumeral")]
        SubheaderNumeral,

        /// <summary>
        /// H1 font size.
        /// </summary>
        [EnumString("header")]
        Header,

        /// <summary>
        /// Same as Header but with subtle opacity.
        /// </summary>
        [EnumString("headerSubtle")]
        HeaderSubtle,

        /// <summary>
        /// Same as Header but with top/bottom padding removed.
        /// </summary>
        [EnumString("headerNumeral")]
        HeaderNumeral
    }
}