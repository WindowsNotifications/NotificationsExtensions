using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Adaptive.Elements
{
    internal enum AdaptiveImagePlacement
    {
        [EnumString("inline")]
        Inline,

        [EnumString("background")]
        Background,

        [EnumString("peek")]
        Peek,

        [EnumString("hero")]
        Hero,

        [EnumString("appLogoOverride")]
        AppLogoOverride
    }
}
