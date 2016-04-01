using NotificationsExtensions.Badges;
using NotificationsExtensions.Tiles;
using NotificationsExtensions.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Xml.Dom;
using Windows.Foundation.Metadata;

namespace NotificationsExtensions
{
    public static class GetXmlExtensions
    {
        /// <summary>
        /// Retrieves the notification XML content as a WinRT XmlDocument, so that it can be used with a local toast notification's constructor on either <see cref="Windows.UI.Notifications.ToastNotification"/> or <see cref="Windows.UI.Notifications.ScheduledToastNotification"/>.
        /// </summary>
        /// <returns>The notification XML content as a WinRT XmlDocument.</returns>
        [DefaultOverload]
        public static XmlDocument GetXml(this INotificationContent notification)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(notification.GetContent());

            return doc;
        }

        /// <summary>
        /// Retrieves the notification XML content as a WinRT XmlDocument, so that it can be used with a local toast notification's constructor on either <see cref="Windows.UI.Notifications.ToastNotification"/> or <see cref="Windows.UI.Notifications.ScheduledToastNotification"/>.
        /// </summary>
        /// <returns>The notification XML content as a WinRT XmlDocument.</returns>
        public static XmlDocument GetXml(this ToastContent notification)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(notification.GetContent());

            return doc;
        }

        /// <summary>
        /// Retrieves the notification XML content as a WinRT XmlDocument, so that it can be used with a local toast notification's constructor on either <see cref="Windows.UI.Notifications.ToastNotification"/> or <see cref="Windows.UI.Notifications.ScheduledToastNotification"/>.
        /// </summary>
        /// <returns>The notification XML content as a WinRT XmlDocument.</returns>
        public static XmlDocument GetXml(this TileContent notification)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(notification.GetContent());

            return doc;
        }

        /// <summary>
        /// Retrieves the notification XML content as a WinRT XmlDocument, so that it can be used with a local toast notification's constructor on either <see cref="Windows.UI.Notifications.ToastNotification"/> or <see cref="Windows.UI.Notifications.ScheduledToastNotification"/>.
        /// </summary>
        /// <returns>The notification XML content as a WinRT XmlDocument.</returns>
        public static XmlDocument GetXml(this BadgeNumericNotificationContent notification)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(notification.GetContent());

            return doc;
        }




        /// <summary>
        /// Retrieves the notification XML content as a WinRT XmlDocument, so that it can be used with a local toast notification's constructor on either <see cref="Windows.UI.Notifications.ToastNotification"/> or <see cref="Windows.UI.Notifications.ScheduledToastNotification"/>.
        /// </summary>
        /// <returns>The notification XML content as a WinRT XmlDocument.</returns>
        internal static XmlDocument GetXml(this BaseElement baseElement)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(baseElement.GetContent());

            return doc;
        }
    }
}
