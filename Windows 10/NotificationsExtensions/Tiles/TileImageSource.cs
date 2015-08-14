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
    public sealed class TileImageSource
    {
        public TileImageSource(string src)
        {
            if (src == null)
                throw new ArgumentNullException("src is required");

            Src = src;
        }

        public string Src { get; private set; }

        public string Alt { get; set; }

        public bool AddImageQuery { get; set; } = Element_TileImage.DEFAULT_ADD_IMAGE_QUERY;

        internal Element_TileImage ConvertToElement()
        {
            Element_TileImage image = new Element_TileImage();

            PopulateElement(image);

            return image;
        }

        internal void PopulateElement(Element_TileImage image)
        {
            image.Src = Src;
            image.Alt = Alt;
            image.AddImageQuery = AddImageQuery;
        }

        public override string ToString()
        {
            return Src;
        }
    }
}