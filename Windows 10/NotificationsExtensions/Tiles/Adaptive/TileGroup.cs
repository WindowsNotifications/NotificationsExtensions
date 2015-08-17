// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Collections.Generic;
using System.Text;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif

namespace NotificationsExtensions.Tiles
{
    /// <summary>
    /// Contains multiple binding child elements, each of which defines a tile.
    /// </summary>
    public sealed class TileGroup : ITileAdaptiveChild
    {
        public IList<TileSubgroup> Children { get; private set; } = new List<TileSubgroup>();
        
        internal Element_TileGroup ConvertToElement()
        {
            Element_TileGroup group = new Element_TileGroup();

            foreach (var subgroup in Children)
                group.Children.Add(subgroup.ConvertToElement());

            return group;
        }
    }
}