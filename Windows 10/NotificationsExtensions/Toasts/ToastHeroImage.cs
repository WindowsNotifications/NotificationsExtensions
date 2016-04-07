using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Toasts
{
    /// <summary>
    /// Constructs a hero image for the toast notification.
    /// </summary>
    public sealed class ToastHeroImage
    {
        /// <summary>
        /// Constructs a hero image for the toast notification.
        /// </summary>
        public ToastHeroImage() { }

        /// <summary>
        /// Specify the image source. Required.
        /// </summary>
        public ToastImageSource Source { get; set; }

        internal Element_ToastImage ConvertToElement()
        {
            Element_ToastImage el = new Element_ToastImage()
            {
                Placement = ToastImagePlacement.Hero
            };

            if (Source != null)
                Source.PopulateElement(el);
            else
                throw new InvalidOperationException("The Source property must be initialized.");

            return el;
        }
    }
}
