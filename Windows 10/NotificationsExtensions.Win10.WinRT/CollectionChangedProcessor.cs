using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace NotificationsExtensions
{
    internal class CollectionChangedProcessor<T>
    {
        /// <summary>
        /// The app data container that the local cache will be stored.
        /// THREADING NOTE: This has worked great in my tests, but I am still confirming whether or not an ApplicationDataContainer is threadsafe
        /// </summary>
        public ApplicationDataContainer LocalCache { get; set; }

        /// <summary>
        /// For item being processed we need a way to identify it by some key
        /// </summary>
        public Func<T, string> GetKeyFromItem { get; set; }

        /// <summary>
        /// The Action to take when an item has been added
        /// </summary>
        public Action<T> OnNewItem { get; set; }

        /// <summary>
        /// The Action to take when an item has been removed
        /// </summary>
        public Action<string> OnRemoveItem { get; set; }



        public void ProcessChanges(IEnumerable<T> current)
        {
            var comparisonCache = LocalCache.Values;

            // Copy the current Tile Notifications Tags in a temporary variable
            var toBeRemoved = new List<string>(comparisonCache.Select(m => m.Key));

            // For each toast in action center, update the tile accordingly
            foreach (var item in current)
            {
                var key = GetKeyFromItem(item);

                if (comparisonCache.ContainsKey(key))
                {
                    // We want to KEEP it displayed, so take it out of the list
                    // of notifications to remove.
                    toBeRemoved.Remove(key);
                }
                else
                {
                    // Othwerise it's a new notification
                    OnNewItem(item);
                    comparisonCache.Add(key, key);
                }
            }

            // Now our toBeRemoved list only contains notifications that are on the Tile, but NOT in Action Center
            foreach (var key in toBeRemoved)
            {
                OnRemoveItem(key);
                comparisonCache.Remove(key);
            }
        }
    }
}
