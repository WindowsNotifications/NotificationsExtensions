using NotificationsExtensions.Adaptive.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions
{
    internal class BaseTextHelper
    {
        internal static Element_AdaptiveText CreateBaseElement(IBaseText curr)
        {
            return new Element_AdaptiveText()
            {
                Text = curr.Text,
                Lang = curr.Language
            };
        }
    }
}
