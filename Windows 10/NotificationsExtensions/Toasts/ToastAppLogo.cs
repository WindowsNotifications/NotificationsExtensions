// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


namespace NotificationsExtensions.Toasts
{
    /// <summary>
    /// The logo that is displayed on your toast notification.
    /// </summary>
    public sealed class ToastAppLogo
    {
        /// <summary>
        /// Initializes a new instance of a toast app logo, which can override the logo displayed on your toast notification. 
        /// </summary>
        public ToastAppLogo() { }

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