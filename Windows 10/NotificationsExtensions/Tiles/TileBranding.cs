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
    /// Contains multiple binding child elements, each of which defines a tile.
    /// </summary>
    public enum TileBranding
    {
        /// <summary>
        /// The default choice. If ShowNameOn___ is true for the tile size being displayed, then branding will be "Name". Otherwise it will be "None".
        /// </summary>
        Auto,

        [EnumString("none")]
        None,

        [EnumString("name")]
        Name,

        [EnumString("logo")]
        Logo,

        [EnumString("nameAndLogo")]
        NameAndLogo
    }
}