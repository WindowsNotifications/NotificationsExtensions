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
    /// The logo that is displayed alongside your toast notification content.
    /// </summary>
    public sealed class ToastAppLogo
    {
        /// <summary>
        /// Specify the image source.
        /// </summary>
        public ToastImageSource Source { get; set; }

        /// <summary>
        /// Specify how you would like the image to be cropped.
        /// </summary>
        public ToastImageCrop Crop { get; set; } = Element_ToastImage.DEFAULT_CROP;

        internal Element_ToastImage ConvertToElement()
        {
            Element_ToastImage el = new Element_ToastImage()
            {
                Placement = ToastImagePlacement.AppLogoOverride,
                Crop = Crop
            };

            if (Source != null)
                Source.PopulateElement(el);

            return el;
        }
    }


}