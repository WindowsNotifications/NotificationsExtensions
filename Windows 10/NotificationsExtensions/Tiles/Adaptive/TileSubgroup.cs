// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Collections.Generic;

namespace NotificationsExtensions.Tiles
{
    /// <summary>
    /// Subgroups are vertical columns that can contain text and images.
    /// </summary>
    [Obsolete("Use AdaptiveSubgroup instead.")]
    public sealed class TileSubgroup
    {
        /// <summary>
        /// Initializes a new subgroup. Subgroups are vertical columns that can contain text and images.
        /// </summary>
        public TileSubgroup() { }

        /// <summary>
        /// <see cref="TileText"/> and <see cref="TileImage"/> are valid children of subgroups.
        /// </summary>
        public IList<ITileSubgroupChild> Children { get; private set; } = new List<ITileSubgroupChild>();

        private int? _weight;

        /// <summary>
        /// Control the width of this subgroup column by specifying the weight, relative to the other subgroups.
        /// </summary>
        public int? Weight
        {
            get { return _weight; }
            set
            {
                Element_TileSubgroup.CheckWeight(value);

                _weight = value;
            }
        }

        /// <summary>
        /// Control the vertical alignment of this subgroup's content.
        /// </summary>
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

        private static IElement_TileSubgroupChild ConvertToSubgroupChildElement(ITileSubgroupChild child)
        {
            if (child is TileText)
                return (child as TileText).ConvertToElement();

            else if (child is TileImage)
                return (child as TileImage).ConvertToElement();

            else
                throw new NotImplementedException("Unknown child: " + child.GetType());
        }
    }


    /// <summary>
    /// Elements (<see cref="TileText"/>, <see cref="TileImage"/>) that can be direct children of a <see cref="TileSubgroup"/>.
    /// </summary>
    public interface ITileSubgroupChild
    {
    }
}