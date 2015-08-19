// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Tiles
{
    /// <summary>
    /// Groups semantically identify that the content in the group must either be displayed as a whole, or not displayed if it cannot fit. Groups also allow creating multiple columns.
    /// </summary>
    public sealed class TileGroup : ITileAdaptiveChild
    {
        /// <summary>
        /// The only valid children of groups are <see cref="TileSubgroup"/>. Each subgroup is displayed as a separate vertical column.
        /// </summary>
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