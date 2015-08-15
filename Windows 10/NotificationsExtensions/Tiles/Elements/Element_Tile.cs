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

namespace NotificationsExtensions
{
    [NotificationXmlElement("tile")]
    internal sealed class Element_Tile : INotificationContent
    {
        public Element_TileVisual Visual { get; set; }

        /// <summary>
        /// Gets the XML, using UTF-8 encoding by default.
        /// </summary>
        /// <returns></returns>
        public string GetContent()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings()
                {
                    Encoding = Encoding.UTF8, // Use UTF-8 encoding to save space (it defaults to UTF-16 which is 2x the size)
                    Indent = false,
                    NewLineOnAttributes = false
                }))
                {
                    XmlWriterHelper.Write(writer, this);
                }

                stream.Position = 0;

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

#if !WINRT_NOT_PRESENT
        /// <summary>
        /// Retrieves the notification Xml content as a WinRT Xml document.
        /// </summary>
        /// <returns>The notification Xml content as a WinRT Xml document.</returns>
        public Windows.Data.Xml.Dom.XmlDocument GetXml()
        {
            Windows.Data.Xml.Dom.XmlDocument xml = new Windows.Data.Xml.Dom.XmlDocument();
            xml.LoadXml(GetContent());
            return xml;
        }
#endif
    }
}