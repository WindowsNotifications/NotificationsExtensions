using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions
{

    /// <summary>
    /// TextStacking specifies the vertical alignment of content.
    /// </summary>
    public enum AdaptiveSubgroupTextStacking
    {
        /// <summary>
        /// Renderer automatically selects the default vertical alignment.
        /// </summary>
        Default,

        /// <summary>
        /// Vertical align to the top.
        /// </summary>
        [EnumString("top")]
        Top,

        /// <summary>
        /// Vertical align to the center.
        /// </summary>
        [EnumString("center")]
        Center,

        /// <summary>
        /// Vertical align to the bottom.
        /// </summary>
        [EnumString("bottom")]
        Bottom
    }
}
