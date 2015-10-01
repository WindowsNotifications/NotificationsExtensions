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
    [NotificationXmlElement("binding")]
    internal sealed class Element_TileBinding : IElementWithDescendants
    {
        internal const TileBranding DEFAULT_BRANDING = TileBranding.Auto;
        internal const bool DEFAULT_ADD_IMAGE_QUERY = false;
        internal const TileTextStacking DEFAULT_TEXT_STACKING = TileTextStacking.Top;
        internal const int DEFAULT_OVERLAY = 20;

        public Element_TileBinding(TileTemplateNameV3 template)
        {
            Template = template;
        }

        [NotificationXmlAttribute("template")]
        public TileTemplateNameV3 Template { get; private set; }

        [NotificationXmlAttribute("fallback")]
        public TileTemplateNameV1? Fallback { get; set; }

        /// <summary>
        /// Set to true to allow Windows to append a query string to the image URI supplied in the tile notification. Use this attribute if your server hosts images and can handle query strings, either by retrieving an image variant based on the query strings or by ignoring the query string and returning the image as specified without the query string. This query string specifies scale, contrast setting, and language; for instance, a value of
        /// 
        /// "www.website.com/images/hello.png"
        /// 
        /// included in the notification becomes
        /// 
        /// "www.website.com/images/hello.png?ms-scale=100&amp;ms-contrast=standard&amp;ms-lang=en-us"
        /// </summary>
        [NotificationXmlAttribute("addImageQuery", DEFAULT_ADD_IMAGE_QUERY)]
        public bool AddImageQuery { get; set; } = DEFAULT_ADD_IMAGE_QUERY;

        /// <summary>
        /// A default base URI that is combined with relative URIs in image source attributes.
        /// </summary>
        [NotificationXmlAttribute("baseUri")]
        public Uri BaseUri { get; set; }

        /// <summary>
        /// The form that the tile should use to display the app's brand.
        /// </summary>
        [NotificationXmlAttribute("branding", DEFAULT_BRANDING)]
        public TileBranding Branding { get; set; } = DEFAULT_BRANDING;

        /// <summary>
        /// Set to a sender-defined string that uniquely identifies the content of the notification. This prevents duplicates in the situation where a large tile template is displaying the last three wide tile notifications.
        /// 
        /// Required: NO
        /// </summary>
        [NotificationXmlAttribute("contentId")]
        public string ContentId { get; set; }

        /// <summary>
        /// An optional string to override the tile's display name while showing this notification.
        /// </summary>
        [NotificationXmlAttribute("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The target locale of the XML payload, specified as a BCP-47 language tags such as "en-US" or "fr-FR". The locale specified here overrides that in visual, but can be overriden by that in text. If this value is a literal string, this attribute defaults to the user's UI language. If this value is a string reference, this attribute defaults to the locale chosen by Windows Runtime in resolving the string. See Remarks for when this value isn't specified.
        /// </summary>
        [NotificationXmlAttribute("lang")]
        public string Language { get; set; }

        [NotificationXmlAttribute("hint-lockDetailedStatus1")]
        public string LockDetailedStatus1 { get; set; }

        [NotificationXmlAttribute("hint-lockDetailedStatus2")]
        public string LockDetailedStatus2 { get; set; }

        [NotificationXmlAttribute("hint-lockDetailedStatus3")]
        public string LockDetailedStatus3 { get; set; }

        private int _overlay = DEFAULT_OVERLAY;
        [NotificationXmlAttribute("hint-overlay", DEFAULT_OVERLAY)]
        public int Overlay
        {
            get { return _overlay; }
            set
            {
                CheckOverlayValue(value);

                _overlay = value;
            }
        }

        /// <summary>
        /// Throws exception if value is invalid
        /// </summary>
        /// <param name="value">Overlay value (0-100)</param>
        internal static void CheckOverlayValue(int value)
        {
            if (value < 0 || value > 100)
                throw new ArgumentOutOfRangeException("Overlay must be between 0 and 100, inclusive.");
        }

        [NotificationXmlAttribute("hint-presentation")]
        public TilePresentation? Presentation { get; set; }

        [NotificationXmlAttribute("hint-textStacking", DEFAULT_TEXT_STACKING)]
        public TileTextStacking TextStacking { get; set; } = DEFAULT_TEXT_STACKING;


        public IList<IElement_TileBindingChild> Children { get; private set; } = new List<IElement_TileBindingChild>();

        /// <summary>
        /// Generates an enumerable collection of children and all those children's children
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> Descendants()
        {
            foreach (IElement_TileBindingChild child in Children)
            {
                // Return the child
                yield return child;

                // And if it has descendants, return the descendants
                if (child is IElementWithDescendants)
                {
                    foreach (object descendant in (child as IElementWithDescendants).Descendants())
                        yield return descendant;
                }
            }
        }
    }

    internal interface IElement_TileBindingChild { }
}