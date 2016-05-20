using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace NotificationsExtensions.Adaptive
{
    internal static class AdaptiveHelper
    {
        internal static object ConvertToElement(object obj)
        {
            if (obj is AdaptiveText)
                return (obj as AdaptiveText).ConvertToElement();

            else if (obj is AdaptiveImage)
                return (obj as AdaptiveImage).ConvertToElement();

            else if (obj is AdaptiveGroup)
                return (obj as AdaptiveGroup).ConvertToElement();

            else if (obj is AdaptiveSubgroup)
                return (obj as AdaptiveSubgroup).ConvertToElement();

            else
                throw new NotImplementedException("Unknown object: " + obj.GetType());
        }
    }
}
