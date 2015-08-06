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

namespace NotificationsExtensions
{
    /// <summary>
    /// Contains multiple binding child elements, each of which defines a tile.
    /// </summary>
    public sealed class TileAdaptiveSubgroup
    {
        public IList<ITileAdaptiveSubgroupChild> Children { get; private set; } = new List<ITileAdaptiveSubgroupChild>();

        public int? Weight { get; set; }

        public TileAdaptiveSubgroupTextStacking TextStacking { get; set; } = Element_TileSubgroup.DEFAULT_TEXT_STACKING;

        public Element_TileSubgroup ConvertToElement()
        {
            var subgroup = new Element_TileSubgroup()
            {
                Weight = Weight,
                TextStacking = TextStacking
            };

            foreach (var child in Children)
                subgroup.Children.Add(child.ConvertToElement());

            return subgroup;
        }
    }

    public enum TileAdaptiveSubgroupTextStacking
    {
        Top,

        [EnumString("center")]
        Center,

        [EnumString("bottom")]
        Bottom
    }

    public interface ITileAdaptiveSubgroupChild
    {
        IElement_TileSubgroupChild ConvertToElement();
    }
}