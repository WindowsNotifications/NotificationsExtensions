// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved



namespace NotificationsExtensions.Tiles
{
    [NotificationXmlElement("image")]
    internal sealed class Element_TileImage : IElement_TileBindingChild, IElement_TileSubgroupChild
    {
        internal const TileImagePlacement DEFAULT_PLACEMENT = TileImagePlacement.Inline;
        internal const TileImageCrop DEFAULT_CROP = TileImageCrop.None;
        internal const bool DEFAULT_REMOVE_MARGIN = false;
        internal const TileImageAlign DEFAULT_ALIGN = TileImageAlign.Stretch;

        [NotificationXmlAttribute("id")]
        public int? Id { get; set; }

        [NotificationXmlAttribute("src")]
        public string Src { get; set; }

        [NotificationXmlAttribute("alt")]
        public string Alt { get; set; }

        [NotificationXmlAttribute("addImageQuery")]
        public bool? AddImageQuery { get; set; }

        [NotificationXmlAttribute("placement", DEFAULT_PLACEMENT)]
        public TileImagePlacement Placement { get; set; } = DEFAULT_PLACEMENT;

        [NotificationXmlAttribute("hint-align", DEFAULT_ALIGN)]
        public TileImageAlign Align { get; set; } = DEFAULT_ALIGN;

        [NotificationXmlAttribute("hint-crop", DEFAULT_CROP)]
        public TileImageCrop Crop { get; set; } = DEFAULT_CROP;

        [NotificationXmlAttribute("hint-removeMargin", DEFAULT_REMOVE_MARGIN)]
        public bool RemoveMargin { get; set; } = DEFAULT_REMOVE_MARGIN;

        private int? _overlay;
        [NotificationXmlAttribute("hint-overlay")]
        public int? Overlay
        {
            get { return _overlay; }
            set
            {
                if (value != null)
                    Element_TileBinding.CheckOverlayValue(value.Value);

                _overlay = value;
            }
        }
    }
}