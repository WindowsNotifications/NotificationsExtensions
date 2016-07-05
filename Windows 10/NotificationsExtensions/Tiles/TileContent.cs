// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

#if WINDOWS_UWP
using Windows.Data.Xml.Dom;
#endif

namespace NotificationsExtensions.Tiles
{

    /// <summary>
    /// Base tile element, which contains a single visual element.
    /// </summary>
    public sealed class TileContent
    {
        /// <summary>
        /// Initializes a new instance of a tile notification's content. You must then set the Visual property, which is required for a tile notification.
        /// </summary>
        public TileContent() { }

        /// <summary>
        /// The visual element is required.
        /// </summary>
        public TileVisual Visual { get; set; }


        /// <summary>
        /// Retrieves the notification XML content as a string, so that it can be sent with a HTTP POST in a push notification.
        /// </summary>
        /// <returns>The notification XML content as a string.</returns>
        public string GetContent()
        {
            return ConvertToElement().GetContent();
        }

#if WINDOWS_UWP
        /// <summary>
        /// Retrieves the notification XML content as a WinRT XmlDocument, so that it can be used with a local tile notification's constructor on either <see cref="Windows.UI.Notifications.TileNotification"/> or <see cref="Windows.UI.Notifications.ScheduledTileNotification"/>.
        /// </summary>
        /// <returns>The notification XML content as a WinRT XmlDocument.</returns>
        public XmlDocument GetXml()
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(GetContent());

            return doc;
        }

#endif

        internal Element_Tile ConvertToElement()
        {
            var tile = new Element_Tile();

            if (Visual != null)
                tile.Visual = Visual.ConvertToElement();

            return tile;
        }
    }
}