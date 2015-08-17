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
    public sealed class ToastVisual
    {
        public int? Version { get; set; }

        public string Language { get; set; }

        public Uri BaseUri { get; set; }

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
        public IList<ToastImageSource> InlineImages { get; private set; } = new LimitedList<ToastImageSource>(6);

        /// <summary>
        /// An optional override of the logo displayed on the toast notification.
        /// </summary>
        public ToastAppLogo AppLogoOverride { get; set; }
        




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



            
            // TODO: If a BaseUri wasn't provided, we can potentially optimize the payload size by calculating the best BaseUri


            visual.Bindings.Add(binding);

            return visual;
        }


    }


}