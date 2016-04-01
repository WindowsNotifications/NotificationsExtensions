using System;
using System.Collections.Generic;
using System.Diagnostics;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using Windows.UI.Notifications;

namespace NotificationsExtensions
{
    /// <summary>
    /// Delegate to configure a binding when copied from a toast
    /// </summary>
    public delegate void ConfigureBindingHandler(XmlElement binding);


    /// <summary>
    /// Keep your Tile automatically in sync with the Toasts in Action Center. Simply send a ToastNotification like you normally would, and then call the SyncTileWithActionCenter method
    /// </summary>
    public sealed class NotificationMate
    {
        private static readonly CollectionChangedProcessor<ToastNotification> CacheProcessor;

        static NotificationMate()
        {
            TileUpdateManager.CreateTileUpdaterForApplication().EnableNotificationQueue(true);

            CacheProcessor = new CollectionChangedProcessor<ToastNotification>
            {
                LocalCache = ApplicationData.Current.LocalSettings
                    .CreateContainer("NotificationMateTiles", ApplicationDataCreateDisposition.Always),
                GetKeyFromItem = GetToastTag,
                OnNewItem = AddTileNotification,
                OnRemoveItem = RemoveTileNotification
            };

        }

        /// <summary>
        /// Use this action to customize the TileMedium binding that is generated from the ToastGeneric binding
        /// </summary>
        public static ConfigureBindingHandler ConfigureTileMediumBinding { get; set; }

        /// <summary>
        /// Use this action to customize the TileWide binding that is generated from the ToastGeneric binding
        /// </summary>
        public static ConfigureBindingHandler ConfigureTileWideBinding { get; set; }



        /// <summary>
        /// Update your Primary Tile to match the content of Action Center, as best it can
        /// The Badge value will be set to the number of Toasts in Action Center, and the Tile will cycle through up to 5 active toast notifications
        /// </summary>
        public static void SyncTileWithActionCenter()
        {
            try
            {
                var toastNotifications = ToastNotificationManager.History.GetHistory();
                UpdateBadge(toastNotifications);

                CacheProcessor.ProcessChanges(toastNotifications);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("NotificationMate failed to sync tile: " + ex.Message);
#if DEBUG
                throw;
#endif
            }
        }

        /// <summary>
        /// Remove the Tile Notification based on the Tag.
        /// Since there is no API to Remove, we try to be clever and send a new notification that expires in 1 second
        /// </summary>
        private static void RemoveTileNotification(string tag)
        {
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
            var xml = "<tile><visual><binding template='TileMedium'><text></text></binding><binding template='TileWide'><text></text></binding></visual></tile>";
            var doc = new XmlDocument();
            doc.LoadXml(xml);
            var tileNotification = new TileNotification(doc)
            {
                Tag = tag,
                ExpirationTime = DateTimeOffset.Now.AddSeconds(2)
            };

            tileUpdater.Update(tileNotification);
            Debug.WriteLine("REMOVING NOTIF " + tag);
        }


        /// <summary>
        /// Add a TileNotification that has the same content as the original ToastNotification
        /// </summary>
        /// <param name="toastNotification"></param>
        private static void AddTileNotification(ToastNotification toastNotification)
        {
            var tileUpdater = TileUpdateManager.CreateTileUpdaterForApplication();
            var tileNotification = CreateTilePayload(toastNotification);
            if (tileNotification != null)
            {
                tileNotification.ExpirationTime = toastNotification.ExpirationTime;
                tileNotification.Tag = GetToastTag(toastNotification);

                tileUpdater.Update(tileNotification);
                Debug.WriteLine("ADDING TILE NOTIF " + tileNotification.Tag);
            }

        }

        /// <summary>
        /// Update the Badge value to match the number of Toasts in Action Center
        /// </summary>
        private static void UpdateBadge(IReadOnlyList<ToastNotification> history)
        {
            string numberOfToasts = history.Count.ToString();

            var badgeXml = $"<badge value='{numberOfToasts}' />";

            var badgeDoc = new XmlDocument();
            badgeDoc.LoadXml(badgeXml);

            BadgeNotification badgeNotification = new BadgeNotification(badgeDoc);
            BadgeUpdateManager.CreateBadgeUpdaterForApplication().Update(badgeNotification);
        }


        /// <summary>
        /// Each Toast must have a unique Tag so that the TileNotification and ToastNotification can be kept in sync.
        /// </summary>
        private static string GetToastTag(ToastNotification toast)
        {
            var tag = toast.Tag;

            // If the Toast.Tag property is empty, we use the ToastNotifications Hashcode
            if (string.IsNullOrWhiteSpace(tag))
            {
                tag = toast.GetHashCode().ToString();
            }

            return tag;
        }

        /// <summary>
        /// Create a TileNotification that uses the same content that was inside the ToastNotification
        /// </summary>
        private static TileNotification CreateTilePayload(ToastNotification toastNotification)
        {
            // WORKAROUND: this XmlDocument cloning is to work around an exception when cloning the ToastNotification content directly
            var toastDoc = new XmlDocument();
            toastDoc.LoadXml(toastNotification.Content.GetXml());
            var toastBinding = toastDoc.SelectSingleNode("//binding[@template='ToastGeneric']");

            // This shouldn't happen, but if we can't find the ToastGeneric binding let's give up
            if (toastBinding == null)
            {
                return null;
            }

            // Create an XmlDocument for the TileNotification

            var doc = new XmlDocument();
            var tile = doc.CreateElement("tile");
            doc.AppendChild(tile);

            var visual = doc.CreateElement("visual");
            tile.AppendChild(visual);

            // Copy the ToastGeneric binding into a TileMedium binding
            var bindingMedium = (XmlElement)doc.ImportNode(toastBinding, true);
            bindingMedium.SetAttribute("template", "TileMedium");
            bindingMedium.SetAttribute("branding", "logo");
            ConfigureTileMediumBinding?.Invoke(bindingMedium);
            visual.AppendChild(bindingMedium);

            // Copy the ToastGeneric binding into a TileWide binding
            var bindingWide = (XmlElement)doc.ImportNode(toastBinding, true);
            bindingWide.SetAttribute("template", "TileWide");
            bindingWide.SetAttribute("branding", "nameAndLogo");
            ConfigureTileWideBinding?.Invoke(bindingMedium);
            visual.AppendChild(bindingWide);

            return new TileNotification(doc);
        }
    }
}