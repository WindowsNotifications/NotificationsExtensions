// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif

namespace NotificationsExtensions
{
    /// <summary>
    /// Contains multiple binding child elements, each of which defines a tile.
    /// </summary>
    public sealed class TileVisual
    {
        public int? Version { get; set; }

        public string Language { get; set; }

        public Uri BaseUri { get; set; }

        public TileBranding Branding { get; set; } = Element_TileVisual.DEFAULT_BRANDING;

        public bool AddImageQuery { get; set; } = Element_TileVisual.DEFAULT_ADD_IMAGE_QUERY;

        public string ContentId { get; set; }

        public string DisplayName { get; set; }

        /// <summary>
        /// If you specify this, you must also provide a Wide tile binding. This is the first line of text that will be displayed on the lock screen if the user has selected your tile as their detailed status app.
        /// </summary>
        public string LockDetailedStatus1 { get; set; }

        /// <summary>
        /// If you specify this, you must also provide a Wide tile binding. This is the second line of text that will be displayed on the lock screen if the user has selected your tile as their detailed status app.
        /// </summary>
        public string LockDetailedStatus2 { get; set; }

        /// <summary>
        /// If you specify this, you must also provide a Wide tile binding. This is the third line of text that will be displayed on the lock screen if the user has selected your tile as their detailed status app.
        /// </summary>
        public string LockDetailedStatus3 { get; set; }

        /// <summary>
        /// Provide an optional small binding to specify content for the small tile size.
        /// </summary>
        public TileBinding TileSmall { get; set; }

        /// <summary>
        /// Provide an optional medium binding to specify content for the medium tile size.
        /// </summary>
        public TileBinding TileMedium { get; set; }

        /// <summary>
        /// Provide an optional wide binding to specify content for the wide tile size.
        /// </summary>
        public TileBinding TileWide { get; set; }

        /// <summary>
        /// Desktop-only. Provide an optional large binding to specify content for the large tile size.
        /// </summary>
        public TileBinding TileLarge { get; set; }




        internal Element_TileVisual ConvertToElement()
        {
            var visual = new Element_TileVisual()
            {
                Version = Version,
                Language = Language,
                BaseUri = BaseUri,
                Branding = Branding,
                AddImageQuery = AddImageQuery,
                ContentId = ContentId,
                DisplayName = DisplayName
            };

            if (TileSmall != null)
                visual.Bindings.Add(TileSmall.ConvertToElement(TileSize.Small));

            if (TileMedium != null)
                visual.Bindings.Add(TileMedium.ConvertToElement(TileSize.Medium));

            if (TileWide != null)
            {
                Element_TileBinding wideBindingElement = TileWide.ConvertToElement(TileSize.Wide);

                // If lock detailed status was specified, add them
                if (LockDetailedStatus1 != null)
                {
                    // If we can't reuse existing text element, we'll have to use the hints
                    if (!TryReuseTextElementForLockDetailedText(1, LockDetailedStatus1, wideBindingElement))
                        wideBindingElement.LockDetailedStatus1 = LockDetailedStatus1;
                }

                if (LockDetailedStatus2 != null)
                {
                    if (!TryReuseTextElementForLockDetailedText(2, LockDetailedStatus2, wideBindingElement))
                        wideBindingElement.LockDetailedStatus2 = LockDetailedStatus2;
                }

                if (LockDetailedStatus3 != null)
                {
                    if (!TryReuseTextElementForLockDetailedText(3, LockDetailedStatus3, wideBindingElement))
                        wideBindingElement.LockDetailedStatus3 = LockDetailedStatus3;
                }

                visual.Bindings.Add(wideBindingElement);
            }

            // Otherwise if they specified lock values, throw an exception since lock values require wide
            else if (HasLockDetailedStatusValues())
                throw new Exception("To provide lock detailed status text strings, you must also provide a TileWide binding. Either provide a TileWide binding, or leave the detailed status values null.");
                

            if (TileLarge != null)
                visual.Bindings.Add(TileLarge.ConvertToElement(TileSize.Large));




            // TODO: If a BaseUri wasn't provided, we can potentially optimize the payload size by calculating the best BaseUri




            return visual;
        }

        private static void OptimizeBranding(Element_TileVisual visual)
        {

        }

        private bool HasLockDetailedStatusValues()
        {
            return LockDetailedStatus1 != null && LockDetailedStatus2 != null && LockDetailedStatus3 != null;
        }

        /// <summary>
        /// Attempts to find and re-use an existing text element inside the binding. Returns true if it could. Otherwise returns false, and the caller will have to specify the detailed status using the lock hint attribute.
        /// </summary>
        /// <param name="lineNumber"></param>
        /// <param name="lockText"></param>
        /// <param name="binding"></param>
        /// <returns></returns>
        private static bool TryReuseTextElementForLockDetailedText(int lineNumber, string lockText, Element_TileBinding binding)
        {
            if (lockText == null)
                throw new ArgumentNullException("lockText cannot be null");

            if (binding == null)
                throw new ArgumentNullException("binding cannot be null");


            // If a text element already has an id with the line number
            Element_TileText matchingIdTextElement = binding.Descendants().OfType<Element_TileText>().FirstOrDefault(i => i.Id != null && i.Id.Equals(lineNumber.ToString()));

            if (matchingIdTextElement != null)
            {
                // If the text in the element matches the lock text, then we're good, don't need to assign anything else!
                if (matchingIdTextElement.Text != null && matchingIdTextElement.Text.Equals(lockText))
                    return true;

                // Otherwise, we need to specify the lock text in the hint attribute, so we return false
                return false;
            }



            // Otherwise no text elements use that ID, so we could assign one if we find a text element that doesn't have an ID assigned and matches the lock text
            Element_TileText matchingTextTextElement = binding.Descendants().OfType<Element_TileText>().FirstOrDefault(i => i.Id == null && i.Text != null && i.Text.Equals(lockText));

            // If we found text that matched, we'll assign the id so it gets re-used for lock!
            if (matchingTextTextElement != null)
            {
                matchingTextTextElement.Id = lineNumber;
                return true;
            }

            // Otherwise we'll need to specify lock text in hint attribute, so return false
            return false;
        }
    }


}