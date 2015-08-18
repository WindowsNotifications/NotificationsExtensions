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

namespace NotificationsExtensions.Tiles
{
    /// <summary>
    /// An inline image to be displayed on the tile.
    /// </summary>
    public sealed class TileImage : ITileSubgroupChild, ITileAdaptiveChild
    {
        /// <summary>
        /// Provide the source of the image and other image source related properties.
        /// </summary>
        public TileImageSource Source { get; set; }

        /// <summary>
        /// Control the desired cropping of the image.
        /// </summary>
        public TileImageCrop Crop { get; set; } = Element_TileImage.DEFAULT_CROP;

        /// <summary>
        /// By default, images have an 8px margin around them. You can remove this margin by setting this property to true.
        /// </summary>
        public bool RemoveMargin { get; set; } = Element_TileImage.DEFAULT_REMOVE_MARGIN;

        /// <summary>
        /// The horizontal alignment of the image.
        /// </summary>
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

        /// <summary>
        /// Returns the image's source string.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if (Source == null)
                return "Source is null";

            return Source.ToString();
        }
    }

    /// <summary>
    /// A peek image that animates in from the top of the tile.
    /// </summary>
    public sealed class TilePeekImage
    {
        /// <summary>
        /// Provide the source of the image and other image source related properties.
        /// </summary>
        public TileImageSource Source { get; set; }

        internal Element_TileImage ConvertToElement()
        {
            Element_TileImage image = new Element_TileImage()
            {
                Placement = TileImagePlacement.Peek
            };

            if (Source != null)
                Source.PopulateElement(image);

            return image;
        }
    }

    /// <summary>
    /// A full-bleed background image that appears beneath the tile content.
    /// </summary>
    public sealed class TileBackgroundImage
    {
        /// <summary>
        /// Provide the source of the image and other image source related properties.
        /// </summary>
        public TileImageSource Source { get; set; }

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

        internal Element_TileImage ConvertToElement()
        {
            Element_TileImage image = new Element_TileImage()
            {
                Placement = TileImagePlacement.Background
            };

            if (Source != null)
                Source.PopulateElement(image);

            return image;
        }
    }

    /// <summary>
    /// Specifies the horizontal alignment for an image.
    /// </summary>
    public enum TileImageAlign
    {
        /// <summary>
        /// Default value. Image stretches to fill available width (and potentially available height too, depending on where the image is).
        /// </summary>
        Stretch,

        /// <summary>
        /// Align the image to the left, displaying the image at its native resolution.
        /// </summary>
        [EnumString("left")]
        Left,

        /// <summary>
        /// Align the image in the center horizontally, displaying the image at its native resolution.
        /// </summary>
        [EnumString("center")]
        Center,

        /// <summary>
        /// Align the image to the right, displaying the image at its native resolution.
        /// </summary>
        [EnumString("right")]
        Right
    }

    /// <summary>
    /// Specify the desired cropping of the image.
    /// </summary>
    public enum TileImageCrop
    {
        /// <summary>
        /// Default value. Image is not cropped.
        /// </summary>
        None,

        /// <summary>
        /// Image is cropped to a circle shape.
        /// </summary>
        [EnumString("circle")]
        Circle
    }
}