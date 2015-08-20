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
    /// <summary>
    /// Animates through a slideshow of photos. Supported on all sizes.
    /// </summary>
    public sealed class TileBindingContentPhotos : ITileBindingContent
    {
        /// <summary>
        /// Up to 12 images can be provided, which will be used for the slideshow. Adding more than 12 will throw an exception.
        /// </summary>
        public IList<TileImageSource> Images { get; private set; } = new LimitedList<TileImageSource>(12);

        internal TileTemplateNameV3 GetTemplateName(TileSize size)
        {
            return TileSizeToAdaptiveTemplateConverter.Convert(size);
        }

        internal void PopulateElement(Element_TileBinding binding, TileSize size)
        {
            binding.Presentation = TilePresentation.Photos;

            foreach (var img in Images)
                binding.Children.Add(img.ConvertToElement());
        }
    }
}