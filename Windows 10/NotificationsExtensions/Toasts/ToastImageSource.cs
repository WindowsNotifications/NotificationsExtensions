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
using System.Linq;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif

namespace NotificationsExtensions.Toasts
{
    /// <summary>
    /// Contains multiple binding child elements, each of which defines a tile.
    /// </summary>
    public sealed class ToastImageSource
    {
        public ToastImageSource(string src)
        {
            if (src == null)
                throw new ArgumentNullException("src is required");

            Src = src;
        }

        public string Src { get; private set; }

        public string Alt { get; set; }

        public bool AddImageQuery { get; set; } = Element_ToastImage.DEFAULT_ADD_IMAGE_QUERY;

        internal Element_ToastImage ConvertToElement()
        {
            Element_ToastImage image = new Element_ToastImage();

            PopulateElement(image);

            return image;
        }

        internal void PopulateElement(Element_ToastImage image)
        {
            image.Src = Src;
            image.Alt = Alt;
            image.AddImageQuery = AddImageQuery;
        }

        public override string ToString()
        {
            return Src;
        }
    }


}