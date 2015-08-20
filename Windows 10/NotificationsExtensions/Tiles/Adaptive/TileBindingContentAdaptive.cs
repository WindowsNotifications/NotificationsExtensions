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
        public TileBackgroundImage BackgroundImage { get; set; }

        /// <summary>
        /// An optional peek image that animates in from the top of the tile.
        /// </summary>
        public TilePeekImage PeekImage { get; set; }

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

            // Add the background image if there's one
            if (BackgroundImage != null)
            {
                // We pull up the overlay value from there
                binding.Overlay = BackgroundImage.Overlay;
                
                // And add it as a child
                binding.Children.Add(BackgroundImage.ConvertToElement());
            }

            // Add the peek image if there's one
            if (PeekImage != null)
            {
                binding.Children.Add(PeekImage.ConvertToElement());
            }

            // And then add all the children
            foreach (var child in Children)
            {
                binding.Children.Add(ConvertToBindingChildElement(child));
            }
        }

        private static IElement_TileBindingChild ConvertToBindingChildElement(ITileAdaptiveChild child)
        {
            if (child is TileText)
                return (child as TileText).ConvertToElement();

            else if (child is TileImage)
                return (child as TileImage).ConvertToElement();

            else if (child is TileGroup)
                return (child as TileGroup).ConvertToElement();

            else
                throw new NotImplementedException("Unknown child: " + child.GetType());
        }
    }

    public interface ITileAdaptiveChild
    {
    }
}