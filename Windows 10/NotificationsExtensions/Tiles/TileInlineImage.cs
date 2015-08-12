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

namespace NotificationsExtensions
{
    /// <summary>
    /// Contains multiple binding child elements, each of which defines a tile.
    /// </summary>
    public sealed class TileAdaptiveImage : ITileAdaptiveSubgroupChild, ITileAdaptiveChild
    {
        /// <summary>
        /// Provide the source of the image and other image source related properties.
        /// </summary>
        public TileImageSource Source { get; set; }

        public TileImageCrop Crop { get; set; } = Element_TileImage.DEFAULT_CROP;

        public bool RemoveMargin { get; set; } = Element_TileImage.DEFAULT_REMOVE_MARGIN;

        public TileImageAlign Align { get; set; } = Element_TileImage.DEFAULT_ALIGN;

        internal Element_TileImage ConvertToElement()
        {
            Element_TileImage image = new Element_TileImage()
            {
                Crop = Crop,
                RemoveMargin = RemoveMargin,
                Align = Align,
                Placement = TileImagePlacement.Inline
            };

            if (Source != null)
                Source.PopulateElement(image);

            return image;
        }

        public override string ToString()
        {
            if (Source == null)
                return "Source is null";

            return Source.ToString();
        }
    }

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