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

namespace NotificationsExtensions
{
    public static class TileSizeToAdaptiveTemplateConverter
    {
        public static TileTemplateNameV3 Convert(TileSize size)
        {
            switch (size)
            {
                case TileSize.Small:
                    return TileTemplateNameV3.TileSmall;

                case TileSize.Medium:
                    return TileTemplateNameV3.TileMedium;

                case TileSize.Wide:
                    return TileTemplateNameV3.TileWide;

                case TileSize.Large:
                    return TileTemplateNameV3.TileLarge;

                default:
                    throw new NotImplementedException();
            }
        }
    }

    public enum TileSize
    {
        Small,
        Medium,
        Wide,
        Large
    }
}