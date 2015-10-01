using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Toasts
{
    /// <summary>
    /// An inline image displayed in your toast notification.
    /// </summary>
    public sealed class ToastImage
    {
        /// <summary>
        /// Constructs an inline image that can be displayed on a toast notification.
        /// </summary>
        public ToastImage() { }

        /// <summary>
        /// Specify the image source.
        /// </summary>
        public ToastImageSource Source { get; set; }

        internal Element_ToastImage ConvertToElement()
        {
            Element_ToastImage el = new Element_ToastImage()
            {
                Placement = ToastImagePlacement.Inline
            };

            if (Source != null)
                Source.PopulateElement(el);

            return el;
        }
    }
}
