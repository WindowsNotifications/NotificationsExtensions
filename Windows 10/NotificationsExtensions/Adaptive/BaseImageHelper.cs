using NotificationsExtensions.Adaptive.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions
{
    internal static class BaseImageHelper
    {
        internal static void SetSource(ref string destination, string value)
        {
            if (value == null)
                throw new ArgumentNullException("Source property cannot be null.");

            destination = value;
        }

        internal static Element_AdaptiveImage CreateBaseElement(IBaseImage curr)
        {
            if (curr.Source == null)
                throw new NullReferenceException("Source property is required.");

            return new Element_AdaptiveImage()
            {
                Src = curr.Source,
                Alt = curr.AlternateText,
                AddImageQuery = curr.AddImageQuery
            };
        }
    }
}
