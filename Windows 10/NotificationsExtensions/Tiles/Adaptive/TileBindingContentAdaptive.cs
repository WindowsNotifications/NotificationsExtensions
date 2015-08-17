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
    /// Supported on all sizes. This is the recommended way of specifying your tile content. Adaptive tile templates are the de-facto choice for Windows 10, and you can create a wide variety of custom tiles through adaptive.
    /// </summary>
    public sealed class TileBindingContentAdaptive : ITileBindingContent
    {
        public IList<ITileAdaptiveChild> Children { get; private set; } = new List<ITileAdaptiveChild>();

        public TileImageSource BackgroundImage { get; set; }

        public TileImageSource PeekImage { get; set; }

        public TileTextStacking TextStacking { get; set; } = Element_TileBinding.DEFAULT_TEXT_STACKING;

        private int _overlay = Element_TileBinding.DEFAULT_OVERLAY;
        public int Overlay
        {
            get { return _overlay; }
            set
            {
                Element_TileBinding.CheckOverlayValue(value);

                _overlay = value;
            }
        }

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