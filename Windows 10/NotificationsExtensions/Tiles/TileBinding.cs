// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;

namespace NotificationsExtensions.Tiles
{
    /// <summary>
    /// The binding element is a size-specific element, allowing you to specify different tile content for each size (like Medium or Wide).
    /// </summary>
    public sealed class TileBinding
    {
        /// <summary>
        /// The target locale of the XML payload, specified as a BCP-47 language tags such as "en-US" or "fr-FR". The locale specified here overrides that in visual, but can be overriden by that in text. If this value is a literal string, this attribute defaults to the user's UI language. If this value is a string reference, this attribute defaults to the locale chosen by Windows Runtime in resolving the string. See Remarks for when this value isn't specified.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// A default base URI that is combined with relative URIs in image source attributes. Defaults to null.
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// The form that the tile should use to display the app's brand..
        /// </summary>
        public TileBranding Branding { get; set; } = Element_TileBinding.DEFAULT_BRANDING;

        /// <summary>
        /// Defaults to false. Set to true to allow Windows to append a query string to the image URI supplied in the tile notification. Use this attribute if your server hosts images and can handle query strings, either by retrieving an image variant based on the query strings or by ignoring the query string and returning the image as specified without the query string. This query string specifies scale, contrast setting, and language; for instance, a value of
        /// 
        /// "www.website.com/images/hello.png"
        /// 
        /// included in the notification becomes
        /// 
        /// "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us"
        /// </summary>
        public bool AddImageQuery { get; set; } = Element_TileBinding.DEFAULT_ADD_IMAGE_QUERY;

        /// <summary>
        /// Set to a sender-defined string that uniquely identifies the content of the notification. This prevents duplicates in the situation where a large tile template is displaying the last three wide tile notifications.
        /// </summary>
        public string ContentId { get; set; }

        /// <summary>
        /// An optional string to override the tile's display name while showing this notification.
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// The actual content to be displayed. One of <see cref="TileBindingContentAdaptive"/>, <see cref="TileBindingContentIconic"/>, <see cref="TileBindingContentContact"/>, <see cref="TileBindingContentPeople"/>, or <see cref="TileBindingContentPhotos"/>
        /// </summary>
        public ITileBindingContent Content { get; set; }

        internal Element_TileBinding ConvertToElement(TileSize size)
        {
            TileTemplateNameV3 templateName = GetTemplateName(Content, size);
            

            Element_TileBinding binding = new Element_TileBinding(templateName)
            {
                Language = Language,
                BaseUri = BaseUri,
                Branding = Branding,
                AddImageQuery = AddImageQuery,
                DisplayName = DisplayName,
                ContentId = ContentId

                // LockDetailedStatus gets populated by TileVisual
            };

            PopulateElement(Content, binding, size);

            return binding;
        }

        private static void PopulateElement(ITileBindingContent bindingContent, Element_TileBinding binding, TileSize size)
        {
            if (bindingContent == null)
                return;

            if (bindingContent is TileBindingContentAdaptive)
                (bindingContent as TileBindingContentAdaptive).PopulateElement(binding, size);

            else if (bindingContent is TileBindingContentContact)
                (bindingContent as TileBindingContentContact).PopulateElement(binding, size);

            else if (bindingContent is TileBindingContentIconic)
                (bindingContent as TileBindingContentIconic).PopulateElement(binding, size);

            else if (bindingContent is TileBindingContentPeople)
                (bindingContent as TileBindingContentPeople).PopulateElement(binding, size);

            else if (bindingContent is TileBindingContentPhotos)
                (bindingContent as TileBindingContentPhotos).PopulateElement(binding, size);

            else
                throw new NotImplementedException("Unknown binding content type: " + bindingContent.GetType());
        }

        private static TileTemplateNameV3 GetTemplateName(ITileBindingContent bindingContent, TileSize size)
        {
            if (bindingContent == null)
                return TileSizeToAdaptiveTemplateConverter.Convert(size);


            if (bindingContent is TileBindingContentAdaptive)
                return (bindingContent as TileBindingContentAdaptive).GetTemplateName(size);

            else if (bindingContent is TileBindingContentContact)
                return (bindingContent as TileBindingContentContact).GetTemplateName(size);

            else if (bindingContent is TileBindingContentIconic)
                return (bindingContent as TileBindingContentIconic).GetTemplateName(size);

            else if (bindingContent is TileBindingContentPeople)
                return (bindingContent as TileBindingContentPeople).GetTemplateName(size);

            else if (bindingContent is TileBindingContentPhotos)
                return (bindingContent as TileBindingContentPhotos).GetTemplateName(size);

            throw new NotImplementedException("Unknown binding content type: " + bindingContent.GetType());
        }
    }

    

    public interface ITileBindingContent
    {
    }
    
    

    

    

    

    

    

    

    









    

    









    internal enum TileTemplate
    {
        TileSmall,
        TileMedium,
        TileWide,
        TileLarge
    }

    
    
    

    


    

    

    

    

    

    

    


    



}
