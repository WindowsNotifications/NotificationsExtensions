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

namespace NotificationsExtensions.Tiles
{
    /// <summary>
    /// Supported on all sizes. This is the recommended way of specifying your Tile content. Adaptive Tile templates are the de-facto choice for Windows 10, and you can create a wide variety of custom Tiles through adaptive.
    /// </summary>
    public sealed class TileBindingContentAdaptive : ITileBindingContent
    {
        /// <summary>
        /// <see cref="TileText"/>, <see cref="TileImage"/>, and <see cref="TileGroup"/> objects can be added as children. The children are displayed in a vertical StackPanel fashion.
        /// </summary>
        public IList<ITileAdaptiveChild> Children { get; private set; } = new List<ITileAdaptiveChild>();

        /// <summary>
        /// An optional background image that gets displayed behind all the tile content, full bleed.
        /// </summary>
        public TileImageSource BackgroundImage { get; set; }

        /// <summary>
        /// An optional peek image that animates in from the top of the tile.
        /// </summary>
        public TileImageSource PeekImage { get; set; }

        /// <summary>
        /// Controls the text stacking (vertical alignment) of the entire binding element.
        /// </summary>
        public TileTextStacking TextStacking { get; set; } = Element_TileBinding.DEFAULT_TEXT_STACKING;
        

        internal TileTemplateNameV3 GetTemplateName(TileSize size)
        {
            return TileSizeToAdaptiveTemplateConverter.Convert(size);
        }

        internal void PopulateElement(Element_TileBinding binding, TileSize size)
        {
            // Assign properties
            binding.TextStacking = TextStacking;
            binding.Overlay = Overlay;

            // Add the background image if there's one
            if (BackgroundImage != null)
            {
                var el_bgImg = BackgroundImage.ConvertToElement();
                el_bgImg.Placement = TileImagePlacement.Background;
                binding.Children.Add(el_bgImg);
            }

            // Add the peek image if there's one
            if (PeekImage != null)
            {
                var el_peekImg = PeekImage.ConvertToElement();
                el_peekImg.Placement = TileImagePlacement.Peek;
                binding.Children.Add(el_peekImg);
            }

            // And then add all the children
            foreach (var child in Children)
            {
                binding.Children.Add(ConvertToBindingChildElement(child));
            }
        }

        private static IElement_TileBindingChild ConvertToBindingChildElement(ITileAdaptiveChild child)
        {
            IElement_TileBindingChild converted = ConversionHelper.ConvertToElement(child) as IElement_TileBindingChild;

            if (converted == null)
                throw new NotImplementedException("Tile adaptive child must support converting to TileBindingChild");

            return converted;
        }
    }

    public interface ITileAdaptiveChild
    {
    }
}