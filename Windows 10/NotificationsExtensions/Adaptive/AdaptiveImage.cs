using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Adaptive
{
    public sealed class AdaptiveImage : ITileSubgroupChild, ITileAdaptiveChild
    {
        /// <summary>
        /// Initializes a new inline image.
        /// </summary>
        public AdaptiveImage() { }

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
}