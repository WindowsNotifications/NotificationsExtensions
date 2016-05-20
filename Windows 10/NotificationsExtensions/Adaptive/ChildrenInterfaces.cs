using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions
{
    /// <summary>
    /// Elements that can be direct children of adaptive content, including (<see cref="AdaptiveText"/>, <see cref="AdaptiveImage"/>, and <see cref="AdaptiveGroup"/>).
    /// </summary>
    public interface IAdaptiveChild : ITileAdaptiveChild
    {
        // Blank interface simply for compile-enforcing the child types in the list.


    }

    /// <summary>
    /// Elements that can be direct children of an <see cref="AdaptiveSubgroup"/>, including  (<see cref="AdaptiveText"/> and <see cref="AdaptiveImage"/>).
    /// </summary>
    public interface IAdaptiveSubgroupChild
    {
        // Blank interface simply for compile-enforcing the child types in the list.
    }
}
