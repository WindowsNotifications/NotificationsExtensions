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
    /// Phone-only. Supported on Small, Medium, and Wide.
    /// </summary>
    public sealed class TileBindingContentContact : ITileBindingContent
    {
        /// <summary>
        /// The image to display.
        /// </summary>
        public TileImageSource Image { get; set; }

        /// <summary>
        /// NOT DISPLAYED ON SMALL TILE SIZE. A line of text that is displayed.
        /// </summary>
        public TileBasicText Text { get; set; }

        internal TileTemplateNameV3 GetTemplateName(TileSize size)
        {
            return TileSizeToAdaptiveTemplateConverter.Convert(size);
        }

        internal void PopulateElement(Element_TileBinding binding, TileSize size)
        {
            binding.Presentation = TilePresentation.Contact;

            if (Image != null)
                binding.Children.Add(Image.ConvertToElement());

            // Small size doesn't display the text, so no reason to include it in the payload
            if (Text != null && size != TileSize.Small)
                binding.Children.Add(Text.ConvertToElement());
        }
    }
}