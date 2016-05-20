using NotificationsExtensions.Tiles;
using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Adaptive.Elements
{

    [NotificationXmlElement("group")]
    internal sealed class Element_AdaptiveGroup : IElement_TileBindingChild, IElement_ToastBindingChild, IElementWithDescendants
    {
        public IList<Element_AdaptiveSubgroup> Children { get; private set; } = new List<Element_AdaptiveSubgroup>();

        public IEnumerable<object> Descendants()
        {
            foreach (Element_AdaptiveSubgroup subgroup in Children)
            {
                // Return the subgroup
                yield return subgroup;

                // And also return its descendants
                foreach (object descendant in subgroup.Descendants())
                    yield return descendant;
            }
        }
    }
}
