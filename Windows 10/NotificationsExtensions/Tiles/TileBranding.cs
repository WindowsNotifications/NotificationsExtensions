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
    /// The form that the tile should use to display the app's brand.
    /// </summary>
    public enum TileBranding
    {
        /// <summary>
        /// The default choice. If ShowNameOn___ is true for the tile size being displayed, then branding will be "Name". Otherwise it will be "None".
        /// </summary>
        Auto,

        /// <summary>
        /// No branding will be displayed.
        /// </summary>
        [EnumString("none")]
        None,

        /// <summary>
        /// The DisplayName will be shown.
        /// </summary>
        [EnumString("name")]
        Name,

        /// <summary>
        /// Desktop-only. The Square44x44Logo will be shown. On Mobile, this will fallback to Name.
        /// </summary>
        [EnumString("logo")]
        Logo,

        /// <summary>
        /// Desktop-only. Both the DisplayName and Square44x44Logo will be shown. On Mobile, this will fallback to Name.
        /// </summary>
        [EnumString("nameAndLogo")]
        NameAndLogo
    }
}