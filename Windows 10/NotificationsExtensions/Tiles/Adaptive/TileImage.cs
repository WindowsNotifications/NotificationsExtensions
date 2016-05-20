// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved



using NotificationsExtensions.Adaptive.Elements;
using System;

namespace NotificationsExtensions.Tiles
{
    /// <summary>
    /// An inline image to be displayed on the tile.
    /// </summary>
    [Obsolete("Use AdaptiveImage instead.")]
    public sealed class TileImage : ITileSubgroupChild, ITileAdaptiveChild
    {
        /// <summary>
        /// Initializes a new inline image that can be displayed on a tile.
        /// </summary>
        public TileImage() { }

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

            if (Source == null)
                throw new NullReferenceException("Source property is required on TileImage");

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
    public sealed class TilePeekImage : IBaseImage
    {
        /// <summary>
        /// Initializes a peek image that animates in from the top of the tile.
        /// </summary>
        public TilePeekImage() { }

        private string _source;
        /// <summary>
        /// The URI of the image. Can be from your application package, application data, or the internet. Internet images must be less than 200 KB in size.
        /// </summary>
        public string Source
        {
            get { return _source; }
            set { BaseImageHelper.SetSource(ref _source, value); }
        }

        /// <summary>
        /// A description of the image, for users of assistive technologies.
        /// </summary>
        public string AlternateText { get; set; }

        /// <summary>
        /// Set to true to allow Windows to append a query string to the image URI supplied in the tile notification. Use this attribute if your server hosts images and can handle query strings, either by retrieving an image variant based on the query strings or by ignoring the query string and returning the image as specified without the query string. This query string specifies scale, contrast setting, and language.
        /// </summary>
        public bool? AddImageQuery { get; set; }

        private int? _hintOverlay;

        /// <summary>
        /// New in 1511: A black overlay on the peek image. This value controls the opacity of the black overlay, with 0 being no overlay and 100 being completely black. Defaults to 0.
        /// Previously for RTM: Did not exist, value will be ignored and peek image will be displayed with 0 overlay.
        /// </summary>
        public int? HintOverlay
        {
            get { return _hintOverlay; }
            set
            {
                if (value != null)
                    Element_TileBinding.CheckOverlayValue(value.Value);

                _hintOverlay = value;
            }
        }

        /// <summary>
        /// New in 1511: Control the desired cropping of the image.
        /// Previously for RTM: Did not exist, value will be ignored and peek image will be displayed without any cropping.
        /// </summary>
        public TilePeekImageCrop HintCrop { get; set; }

        internal Element_AdaptiveImage ConvertToElement()
        {
            Element_AdaptiveImage image = BaseImageHelper.CreateBaseElement(this);

            image.Placement = AdaptiveImagePlacement.Peek;
            image.Crop = GetAdaptiveImageCrop();
            image.Overlay = HintOverlay;

            return image;
        }

        private AdaptiveImageCrop GetAdaptiveImageCrop()
        {
            switch (HintCrop)
            {
                case TilePeekImageCrop.Circle:
                    return AdaptiveImageCrop.Circle;

                case TilePeekImageCrop.None:
                    return AdaptiveImageCrop.None;

                default:
                    return AdaptiveImageCrop.Default;
            }
        }
    }

    /// <summary>
    /// A full-bleed background image that appears beneath the tile content.
    /// </summary>
    public sealed class TileBackgroundImage : IBaseImage
    {
        /// <summary>
        /// Initializes a full-bleed background image that appears beneath the tile content.
        /// </summary>
        public TileBackgroundImage() { }

        private string _source;
        /// <summary>
        /// The URI of the image. Can be from your application package, application data, or the internet. Internet images must be less than 200 KB in size.
        /// </summary>
        public string Source
        {
            get { return _source; }
            set { BaseImageHelper.SetSource(ref _source, value); }
        }

        /// <summary>
        /// A description of the image, for users of assistive technologies.
        /// </summary>
        public string AlternateText { get; set; }

        /// <summary>
        /// Set to true to allow Windows to append a query string to the image URI supplied in the tile notification. Use this attribute if your server hosts images and can handle query strings, either by retrieving an image variant based on the query strings or by ignoring the query string and returning the image as specified without the query string. This query string specifies scale, contrast setting, and language.
        /// </summary>
        public bool? AddImageQuery { get; set; }

        private int? _hintOverlay;

        /// <summary>
        /// A black overlay on the background image. This value controls the opacity of the black overlay, with 0 being no overlay and 100 being completely black. Defaults to 20.
        /// </summary>
        public int? HintOverlay
        {
            get { return _hintOverlay; }
            set
            {
                if (value != null)
                    Element_TileBinding.CheckOverlayValue(value.Value);

                _hintOverlay = value;
            }
        }

        /// <summary>
        /// New in 1511: Control the desired cropping of the image.
        /// Previously for RTM: Did not exist, value will be ignored and background image will be displayed without any cropping.
        /// </summary>
        public TileBackgroundImageCrop HintCrop { get; set; }

        internal Element_AdaptiveImage ConvertToElement()
        {
            Element_AdaptiveImage image = BaseImageHelper.CreateBaseElement(this);

            image.Placement = AdaptiveImagePlacement.Background;
            image.Crop = GetAdaptiveImageCrop();
            image.Overlay = HintOverlay;

            return image;
        }

        private AdaptiveImageCrop GetAdaptiveImageCrop()
        {
            switch (HintCrop)
            {
                case TileBackgroundImageCrop.Circle:
                    return AdaptiveImageCrop.Circle;

                case TileBackgroundImageCrop.None:
                    return AdaptiveImageCrop.None;

                default:
                    return AdaptiveImageCrop.Default;
            }
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

    /// <summary>
    /// Specify the desired cropping of the image.
    /// </summary>
    public enum TileBackgroundImageCrop
    {
        /// <summary>
        /// Cropping style automatically determined by renderer.
        /// </summary>
        Default,

        /// <summary>
        /// Default value. Image is not cropped.
        /// </summary>
        [EnumString("none")]
        None,

        /// <summary>
        /// Image is cropped to a circle shape.
        /// </summary>
        [EnumString("circle")]
        Circle
    }

    /// <summary>
    /// Specify the desired cropping of the image.
    /// </summary>
    public enum TilePeekImageCrop
    {
        /// <summary>
        /// Cropping style automatically determined by renderer.
        /// </summary>
        Default,

        /// <summary>
        /// Default value. Image is not cropped.
        /// </summary>
        [EnumString("none")]
        None,

        /// <summary>
        /// Image is cropped to a circle shape.
        /// </summary>
        [EnumString("circle")]
        Circle
    }
}