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
    public enum TileTextStyle
    {
        [EnumString("caption")]
        Caption,

        [EnumString("captionSubtle")]
        CaptionSubtle,

        [EnumString("body")]
        Body,

        [EnumString("bodySubtle")]
        BodySubtle,

        [EnumString("base")]
        Base,

        [EnumString("baseSubtle")]
        BaseSubtle,

        [EnumString("subtitle")]
        Subtitle,

        [EnumString("subtitleSubtle")]
        SubtitleSubtle,

        [EnumString("title")]
        Title,

        [EnumString("titleSubtle")]
        TitleSubtle,

        [EnumString("titleNumeral")]
        TitleNumeral,

        [EnumString("subheader")]
        Subheader,

        [EnumString("subheaderSubtle")]
        SubheaderSubtle,

        [EnumString("subheaderNumeral")]
        SubheaderNumeral,

        [EnumString("header")]
        Header,

        [EnumString("headerSubtle")]
        HeaderSubtle,

        [EnumString("headerNumeral")]
        HeaderNumeral
    }
}