// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System.Collections.Generic;

namespace NotificationsExtensions.Tiles
{
    /// <summary>
    /// Phone-only. Supported on Medium and Wide.
    /// </summary>
    public sealed class TileBindingContentPeople : ITileBindingContent
    {
        /// <summary>
        /// Phone-only. Supported on Medium and Wide.
        /// </summary>
        public TileBindingContentPeople() { }

        /// <summary>
        /// Images that will roll around as circles.
        /// </summary>
        public IList<TileImageSource> Images { get; private set; } = new List<TileImageSource>();

        internal TileTemplateNameV3 GetTemplateName(TileSize size)
        {
            return TileSizeToAdaptiveTemplateConverter.Convert(size);
        }

        internal void PopulateElement(Element_TileBinding binding, TileSize size)
        {
            binding.Presentation = TilePresentation.People;

            foreach (var img in Images)
                binding.Children.Add(img.ConvertToElement());
        }
    }
}