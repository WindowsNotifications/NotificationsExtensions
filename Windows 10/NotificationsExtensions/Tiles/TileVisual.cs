// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif

namespace NotificationsExtensions
{
    /// <summary>
    /// Contains multiple binding child elements, each of which defines a tile.
    /// </summary>
    public sealed class TileVisual
    {
        public int? Version { get; set; }

        public string Language { get; set; }

        public Uri BaseUri { get; set; }

        public TileBranding Branding { get; set; } = Element_TileVisual.DEFAULT_BRANDING;

        public bool AddImageQuery { get; set; } = Element_TileVisual.DEFAULT_ADD_IMAGE_QUERY;

        public string ContentId { get; set; }

        public string DisplayName { get; set; }

        /// <summary>
        /// Provide an optional small binding to specify content for the small tile size.
        /// </summary>
        public TileBinding TileSmall { get; set; }

        /// <summary>
        /// Provide an optional medium binding to specify content for the medium tile size.
        /// </summary>
        public TileBinding TileMedium { get; set; }

        /// <summary>
        /// Provide an optional wide binding to specify content for the wide tile size.
        /// </summary>
        public TileBinding TileWide { get; set; }

        /// <summary>
        /// Desktop-only. Provide an optional large binding to specify content for the large tile size.
        /// </summary>
        public TileBinding TileLarge { get; set; }




        public Element_TileVisual ConvertToElement()
        {
            var visual = new Element_TileVisual()
            {
                Version = Version,
                Language = Language,
                BaseUri = BaseUri,
                Branding = Branding,
                AddImageQuery = AddImageQuery,
                ContentId = ContentId,
                DisplayName = DisplayName
            };

            if (TileSmall != null)
                visual.Bindings.Add(TileSmall.ConvertToElement(TileTemplateNameV3.TileSmall));

            if (TileMedium != null)
                visual.Bindings.Add(TileMedium.ConvertToElement(TileTemplateNameV3.TileMedium));

            if (TileWide != null)
                visual.Bindings.Add(TileWide.ConvertToElement(TileTemplateNameV3.TileWide));

            if (TileLarge != null)
                visual.Bindings.Add(TileLarge.ConvertToElement(TileTemplateNameV3.TileLarge));

            return visual;
        }
    }


}