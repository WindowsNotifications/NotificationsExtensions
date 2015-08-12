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

        private int? _weight;
        public int? Weight
        {
            get { return _weight; }
            set
            {
                Element_TileSubgroup.CheckWeight(value);

                _weight = value;
            }
        }

        public TileTextStacking TextStacking { get; set; } = Element_TileSubgroup.DEFAULT_TEXT_STACKING;

        internal Element_TileSubgroup ConvertToElement()
        {
            var subgroup = new Element_TileSubgroup()
            {
                Weight = Weight,
                TextStacking = TextStacking
            };

            foreach (var child in Children)
            {
                subgroup.Children.Add(ConvertToSubgroupChildElement(child));
            }

            return subgroup;
        }

        private static IElement_TileSubgroupChild ConvertToSubgroupChildElement(ITileAdaptiveSubgroupChild child)
        {
            IElement_TileSubgroupChild converted = ConversionHelper.ConvertToElement(child) as IElement_TileSubgroupChild;

            if (converted == null)
                throw new NotImplementedException("Subgroup child must support converting to element subgroup.");

            return converted;
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
    }
}