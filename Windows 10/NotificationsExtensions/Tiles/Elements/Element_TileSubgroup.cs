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
    [NotificationXmlElement("subgroup")]
    internal sealed class Element_TileSubgroup : IElementWithDescendants
    {
        internal const TileTextStacking DEFAULT_TEXT_STACKING = TileTextStacking.Top;

        [NotificationXmlAttribute("hint-textStacking", DEFAULT_TEXT_STACKING)]
        public TileTextStacking TextStacking { get; set; } = DEFAULT_TEXT_STACKING;

        private int? _weight;
        [NotificationXmlAttribute("hint-weight")]
        public int? Weight
        {
            get { return _weight; }

            set
            {
                CheckWeight(value);

                _weight = value;
            }
        }

        internal static void CheckWeight(int? weight)
        {
            if (weight != null && weight.Value < 1)
                throw new ArgumentOutOfRangeException("Weight must be between 1 and int.MaxValue, inclusive (or null)");
        }

        public IList<IElement_TileSubgroupChild> Children { get; private set; } = new List<IElement_TileSubgroupChild>();

        public IEnumerable<object> Descendants()
        {
            foreach (IElement_TileSubgroupChild child in Children)
            {
                // Return each child (we know there's no further descendants)
                yield return child;
            }
        }
    }

    internal interface IElement_TileSubgroupChild { }
}