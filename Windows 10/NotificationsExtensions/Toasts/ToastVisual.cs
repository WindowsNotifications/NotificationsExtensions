// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Collections.Generic;

namespace NotificationsExtensions.Toasts
{
    /// <summary>
    /// Defines the visual aspects of a toast notification.
    /// </summary>
    public sealed class ToastVisual
    {
        /// <summary>
        /// Initializes a new instance that defines the visual aspects of a toast notification.
        /// </summary>
        public ToastVisual() { }

        /// <summary>
        /// The version of the tile XML schema this particular payload was developed for. Windows 10 ignores this property.
        /// </summary>
        public int? Version { get; set; }

        /// <summary>
        /// The target locale of the XML payload, specified as BCP-47 language tags such as "en-US" or "fr-FR". This locale is overridden by any locale specified in binding or text. If this value is a literal string, this attribute defaults to the user's UI language. If this value is a string reference, this attribute defaults to the locale chosen by Windows Runtime in resolving the string.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// A default base URI that is combined with relative URIs in image source attributes.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// Set to "true" to allow Windows to append a query string to the image URI supplied in the toast notification. Use this attribute if your server hosts images and can handle query strings, either by retrieving an image variant based on the query strings or by ignoring the query string and returning the image as specified without the query string. This query string specifies scale, contrast setting, and language.
        /// </summary>
        public bool AddImageQuery { get; set; } = Element_ToastVisual.DEFAULT_ADD_IMAGE_QUERY;

        

        /// <summary>
        /// The title text displayed on the toast notification, shown as the first line of text.
        /// </summary>
        public ToastText TitleText { get; set; }

        /// <summary>
        /// The first line of body text (after the title)
        /// </summary>
        public ToastText BodyTextLine1 { get; set; }

        /// <summary>
        /// The second line of body text
        /// </summary>
        public ToastText BodyTextLine2 { get; set; }

        /// <summary>
        /// Inline images to display after the lines of text. Only 6 images are allowed. Adding more than 6 will throw an exception.
        /// </summary>
        public IList<ToastImage> InlineImages { get; private set; } = new LimitedList<ToastImage>(6);

        /// <summary>
        /// An optional override of the logo displayed on the toast notification.
        /// </summary>
        public ToastAppLogo AppLogoOverride { get; set; }

        /// <summary>
        /// An optional hero image (a visually impactful image displayed on the toast notification).
        /// </summary>
        public ToastHeroImage HeroImage { get; set; }
        




        internal Element_ToastVisual ConvertToElement()
        {
            var visual = new Element_ToastVisual()
            {
                Version = Version,
                Language = Language,
                BaseUri = BaseUri,
                AddImageQuery = AddImageQuery
            };


            Element_ToastBinding binding = new Element_ToastBinding(ToastTemplateType.ToastGeneric);

            if (TitleText == null)
            {
                // If there's subsequent text, add a blank line of text
                if (BodyTextLine1 != null || BodyTextLine2 != null)
                    binding.Children.Add(new Element_ToastText());
            }

            else
                binding.Children.Add(TitleText.ConvertToElement());

            if (BodyTextLine1 == null)
            {
                // If there's subsequent text, add a blank line of text
                if (BodyTextLine2 != null)
                    binding.Children.Add(new Element_ToastText());
            }

            else
                binding.Children.Add(BodyTextLine1.ConvertToElement());

            if (BodyTextLine2 != null)
                binding.Children.Add(BodyTextLine2.ConvertToElement());



            // Add inline images
            foreach (var img in InlineImages)
                binding.Children.Add(img.ConvertToElement());


            // And if there's an app logo override, add it
            if (AppLogoOverride != null)
                binding.Children.Add(AppLogoOverride.ConvertToElement());

            // If there's hero, add it
            if (HeroImage != null)
                binding.Children.Add(HeroImage.ConvertToElement());



            
            // TODO: If a BaseUri wasn't provided, we can potentially optimize the payload size by calculating the best BaseUri


            visual.Bindings.Add(binding);

            return visual;
        }


    }


}