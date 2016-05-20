using NotificationsExtensions.Adaptive;
using NotificationsExtensions.Adaptive.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Toasts
{
    /// <summary>
    /// Constructs a hero image for the toast notification.
    /// </summary>
    public sealed class ToastGenericHeroImage : IBaseImage
    {
        /// <summary>
        /// Constructs a hero image for the toast notification.
        /// </summary>
        public ToastGenericHeroImage() { }

        private string _source;
        /// <summary>
        /// The URI of the image. Can be from your application package, application data, or the internet. Internet images must be less than 200 KB in size.
        /// </summary>
        public string Source
        {
            get { return _source; }
            set { BaseImageHelper.SetSource(ref _source, value); }
        }

        /// <summary>
        /// A description of the image, for users of assistive technologies.
        /// </summary>
        public string AlternateText { get; set; }

        /// <summary>
        /// Set to true to allow Windows to append a query string to the image URI supplied in the tile notification. Use this attribute if your server hosts images and can handle query strings, either by retrieving an image variant based on the query strings or by ignoring the query string and returning the image as specified without the query string. This query string specifies scale, contrast setting, and language.
        /// </summary>
        public bool? AddImageQuery { get; set; }

        internal Element_AdaptiveImage ConvertToElement()
        {
            Element_AdaptiveImage el = BaseImageHelper.CreateBaseElement(this);

            el.Placement = AdaptiveImagePlacement.Hero;

            return el;
        }
    }
}
