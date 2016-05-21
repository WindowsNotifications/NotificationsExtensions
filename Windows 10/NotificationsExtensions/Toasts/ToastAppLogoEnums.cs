using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Toasts
{
    /// <summary>
    /// Specify the desired cropping of the image.
    /// </summary>
    public enum ToastAppLogoCrop
    {
        /// <summary>
        /// Default value. Image is not cropped.
        /// </summary>
        None,

        /// <summary>
        /// Image is cropped to a circle shape.
        /// </summary>
        [EnumString("circle")]
        Circle
    }
}
