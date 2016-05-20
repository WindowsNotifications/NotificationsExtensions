using NotificationsExtensions.Adaptive.Elements;
using NotificationsExtensions.Tiles;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions
{
    /// <summary>
    /// Groups semantically identify that the content in the group must either be displayed as a whole, or not displayed if it cannot fit. Groups also allow creating multiple columns.
    /// </summary>
    public sealed class AdaptiveGroup : IAdaptiveChild, ITileAdaptiveChild
    {
        /// <summary>
        /// Initializes a new group. Groups semantically identify that the content in the group must either be displayed as a whole, or not displayed if it cannot fit. Groups also allow creating multiple columns.
        /// </summary>
        public AdaptiveGroup() { }

        /// <summary>
        /// The only valid children of groups are <see cref="AdaptiveSubgroup"/>. Each subgroup is displayed as a separate vertical column. Note that you must include at least one subgroup in your group, otherwise an <see cref="InvalidOperationException"/> will be thrown when you try to retrieve the XML for the notification.
        /// </summary>
        public IList<AdaptiveSubgroup> Children { get; private set; } = new List<AdaptiveSubgroup>();

        internal Element_AdaptiveGroup ConvertToElement()
        {
            if (Children.Count == 0)
                throw new InvalidOperationException("Groups must have at least one child subgroup. The Children property had zero items in it.");

            Element_AdaptiveGroup group = new Element_AdaptiveGroup();

            foreach (var subgroup in Children)
                group.Children.Add(subgroup.ConvertToElement());

            return group;
        }
    }
}
