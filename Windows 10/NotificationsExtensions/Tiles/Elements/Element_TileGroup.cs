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
using System.Reflection;
using System.Linq;
using System.Collections;
using System.IO;

namespace NotificationsExtensions.Tiles
{
    [NotificationXmlElement("group")]
    internal sealed class Element_TileGroup : IElement_TileBindingChild, IElementWithDescendants
    {
        public IList<Element_TileSubgroup> Children { get; private set; } = new List<Element_TileSubgroup>();

        public IEnumerable<object> Descendants()
        {
            foreach (Element_TileSubgroup subgroup in Children)
            {
                // Return the subgroup
                yield return subgroup;

                // And also return its descendants
                foreach (object descendant in subgroup.Descendants())
                    yield return descendant;
            }
        }
    }
}