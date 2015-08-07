// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
using Windows.UI.Notifications;
#endif
using System.Reflection;
using System.Linq;
using System.Collections;
using System.IO;

namespace NotificationsExtensions
{
    public sealed class TileBinding
    {
        /// <summary>
        /// The target locale of the XML payload, specified as a BCP-47 language tags such as "en-US" or "fr-FR". The locale specified here overrides that in visual, but can be overriden by that in text. If this value is a literal string, this attribute defaults to the user's UI language. If this value is a string reference, this attribute defaults to the locale chosen by Windows Runtime in resolving the string. See Remarks for when this value isn't specified.
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// A default base URI that is combined with relative URIs in image source attributes.
        /// 
        /// Required: NO
        /// </summary>
        public Uri BaseUri { get; set; }

        /// <summary>
        /// The form that the tile should use to display the app's brand.
        /// 
        /// Required: No
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
        /// 
        /// Required: NO
        /// </summary>
        public string ContentId { get; set; }

        /// <summary>
        /// An optional string to override the tile's display name while showing this notification.
        /// </summary>
        public string DisplayName { get; set; }

        public ITileContent Content { get; set; }

        public Element_TileBinding ConvertToElement(TileSize size)
        {
            TileTemplateNameV3 templateName;

            if (Content != null)
                templateName = Content.GetTemplateName(size);

            else
                templateName = TileSizeToAdaptiveTemplateConverter.Convert(size);

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

            if (Content != null)
                Content.PopulateElement(binding, size);

            return binding;
        }
    }

    public static class TileSizeToAdaptiveTemplateConverter
    {
        public static TileTemplateNameV3 Convert(TileSize size)
        {
            switch (size)
            {
                case TileSize.Small:
                    return TileTemplateNameV3.TileSmall;

                case TileSize.Medium:
                    return TileTemplateNameV3.TileMedium;

                case TileSize.Wide:
                    return TileTemplateNameV3.TileWide;

                case TileSize.Large:
                    return TileTemplateNameV3.TileLarge;

                default:
                    throw new NotImplementedException();
            }
        }
    }

    public enum TileSize
    {
        Small,
        Medium,
        Wide,
        Large
    }

    public interface ITileContent
    {
        TileTemplateNameV3 GetTemplateName(TileSize size);

        void PopulateElement(Element_TileBinding binding, TileSize size);
    }

    /// <summary>
    /// Supported on all sizes. This is the recommended way of specifying your tile content. Adaptive tile templates are the de-facto choice for Windows 10, and you can create a wide variety of custom tiles through adaptive.
    /// </summary>
    public sealed class TileContentAdaptive : ITileContent
    {
        public IList<ITileAdaptiveChild> Children { get; private set; } =  new List<ITileAdaptiveChild>();

        public TileImageSource BackgroundImage { get; set; }

        public TileImageSource PeekImage { get; set; }

        public TileTextStacking TextStacking { get; set; } = Element_TileBinding.DEFAULT_TEXT_STACKING;

        public int Overlay { get; set; } = Element_TileBinding.DEFAULT_OVERLAY;

        public TileTemplateNameV3 GetTemplateName(TileSize size)
        {
            return TileSizeToAdaptiveTemplateConverter.Convert(size);
        }

        public void PopulateElement(Element_TileBinding binding, TileSize size)
        {
            // Assign properties
            binding.TextStacking = TextStacking;
            binding.Overlay = Overlay;

            // Add the background image if there's one
            if (BackgroundImage != null)
            {
                var el_bgImg = BackgroundImage.ConvertToElement();
                el_bgImg.Placement = TileImagePlacement.Background;
                binding.Children.Add(el_bgImg);
            }

            // Add the peek image if there's one
            if (PeekImage != null)
            {
                var el_peekImg = PeekImage.ConvertToElement();
                el_peekImg.Placement = TileImagePlacement.Peek;
                binding.Children.Add(el_peekImg);
            }

            // And then add all the children
            foreach (var child in Children)
                binding.Children.Add(child.ConvertToElement());
        }
    }

    public interface ITileAdaptiveChild
    {
        IElement_TileBindingChild ConvertToElement();
    }

    /// <summary>
    /// Supported on Small and Medium. Enables an iconic tile template, where you can have an icon and badge display next to each other on the tile, in true classic Windows Phone style. The number next to the icon is achieved through a separate badge notification.
    /// </summary>
    public sealed class TileContentIconic : ITileContent
    {
        /// <summary>
        /// At minimum, to support both Desktop and Phone, Small and Medium tiles, provide a square aspect ratio image with a resolution of 200x200, PNG format, with transparency and no color other than white. For more info see: http://blogs.msdn.com/b/tiles_and_toasts/archive/2015/07/31/iconic-tile-template-for-windows-10.aspx
        /// </summary>
        public TileImageSource Icon { get; set; }

        public TileTemplateNameV3 GetTemplateName(TileSize size)
        {
            switch (size)
            {
                case TileSize.Small:
                    return TileTemplateNameV3.TileSquare71x71IconWithBadge;

                case TileSize.Medium:
                    return TileTemplateNameV3.TileSquare150x150IconWithBadge;

                default:
                    throw new ArgumentException("The Iconic template is only supported on Small and Medium tiles.");
            }
        }

        public void PopulateElement(Element_TileBinding binding, TileSize size)
        {
            if (Icon != null)
            {
                var element = Icon.ConvertToElement();
                element.Id = 1;
                binding.Children.Add(element);
            }
        }
    }

    /// <summary>
    /// Animates through a slideshow of photos.
    /// </summary>
    public sealed class TileContentPhotos : ITileContent
    {
        /// <summary>
        /// Up to 10 images can be provided, which will be used for the slideshow.
        /// </summary>
        public IList<TileImageSource> Images { get; private set; } = new List<TileImageSource>();

        public TileTemplateNameV3 GetTemplateName(TileSize size)
        {
            return TileSizeToAdaptiveTemplateConverter.Convert(size);
        }

        public void PopulateElement(Element_TileBinding binding, TileSize size)
        {
            binding.Presentation = TilePresentation.Photos;

            foreach (var img in Images)
                binding.Children.Add(img.ConvertToElement());
        }
    }

    /// <summary>
    /// Phone-only. Supported on Medium and Wide.
    /// </summary>
    public sealed class TileContentPeople : ITileContent
    {
        /// <summary>
        /// Images that will roll around as circles.
        /// </summary>
        public IList<TileImageSource> Images { get; private set; } = new List<TileImageSource>();

        public TileTemplateNameV3 GetTemplateName(TileSize size)
        {
            return TileSizeToAdaptiveTemplateConverter.Convert(size);
        }

        public void PopulateElement(Element_TileBinding binding, TileSize size)
        {
            binding.Presentation = TilePresentation.People;

            foreach (var img in Images)
                binding.Children.Add(img.ConvertToElement());
        }
    }

    /// <summary>
    /// Phone-only. Supported on Small, Medium, and Wide.
    /// </summary>
    public sealed class TileContentContact : ITileContent
    {
        public TileImageSource Image { get; set; }

        /// <summary>
        /// NOT DISPLAYED ON SMALL TILE SIZE. A line of text that is displayed.
        /// </summary>
        public BasicTileText Text { get; set; }

        public TileTemplateNameV3 GetTemplateName(TileSize size)
        {
            return TileSizeToAdaptiveTemplateConverter.Convert(size);
        }

        public void PopulateElement(Element_TileBinding binding, TileSize size)
        {
            binding.Presentation = TilePresentation.Contact;

            if (Image != null)
                binding.Children.Add(Image.ConvertToElement());

            // Small size doesn't display the text, so no reason to include it in the payload
            if (Text != null && size != TileSize.Small)
                binding.Children.Add(Text.ConvertToElement());
        }
    }

    public enum TileImageAlign
    {
        Stretch,

        [EnumString("left")]
        Left,

        [EnumString("center")]
        Center,

        [EnumString("right")]
        Right
    }

    public enum TileImageCrop
    {
        None,

        [EnumString("circle")]
        Circle
    }

    public enum TileTextStacking
    {
        [EnumString("top")]
        Top,

        [EnumString("center")]
        Center,

        [EnumString("bottom")]
        Bottom
    }









    public enum TilePresentation
    {
        [EnumString("people")]
        People,

        [EnumString("photos")]
        Photos,

        [EnumString("contact")]
        Contact
    }

    public enum TileImagePlacement
    {
        [EnumString("inline")]
        Inline,

        [EnumString("background")]
        Background,

        [EnumString("peek")]
        Peek
    }









    internal enum TileTemplate
    {
        TileSmall,
        TileMedium,
        TileWide,
        TileLarge
    }

    [NotificationXmlElement("tile")]
    public sealed class Element_Tile
    {
        public Element_TileVisual Visual { get; set; }

        /// <summary>
        /// Gets the XML, using UTF-8 encoding by default.
        /// </summary>
        /// <returns></returns>
        public string GetXml()
        {
            using (MemoryStream stream = new MemoryStream())
            {
                using (XmlWriter writer = XmlWriter.Create(stream, new XmlWriterSettings()
                {
                    Encoding = Encoding.UTF8, // Use UTF-8 encoding to save space (it defaults to UTF-16 which is 2x the size)
                    Indent = false,
                    NewLineOnAttributes = false
                }))
                {
                    XmlWriterHelper.Write(writer, this);
                }

                stream.Position = 0;

                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
    
    internal sealed class NotificationXmlAttributeAttribute : Attribute
    {
        public string Name { get; private set; }

        public object DefaultValue { get; private set; }

        public NotificationXmlAttributeAttribute(string name, object defaultValue = null)
        {
            Name = name;
            DefaultValue = defaultValue;
        }
    }

    internal sealed class NotificationXmlElementAttribute : Attribute
    {
        public string Name { get; private set; }

        public NotificationXmlElementAttribute(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentNullException("name cannot be null or whitespace");

            Name = name;
        }
    }

    /// <summary>
    /// This attribute should be specified at most one time on an Element class. The property's value will be written as a string in the element's body.
    /// </summary>
    internal sealed class NotificationXmlContentAttribute : Attribute
    {

    }

    internal sealed class EnumStringAttribute : Attribute
    {
        public string String { get; private set; }

        public EnumStringAttribute(string s)
        {
            if (s == null)
                throw new ArgumentNullException("string cannot be null");

            String = s;
        }

        public override string ToString()
        {
            return String;
        }
    }


    [NotificationXmlElement("visual")]
    public sealed class Element_TileVisual
    {
        internal const TileBranding DEFAULT_BRANDING = TileBranding.Auto;
        internal const bool DEFAULT_ADD_IMAGE_QUERY = false;

        [NotificationXmlAttribute("addImageQuery", DEFAULT_ADD_IMAGE_QUERY)]
        public bool AddImageQuery { get; set; } = DEFAULT_ADD_IMAGE_QUERY;

        [NotificationXmlAttribute("baseUri")]
        public Uri BaseUri { get; set; }

        [NotificationXmlAttribute("branding", DEFAULT_BRANDING)]
        public TileBranding Branding { get; set; } = DEFAULT_BRANDING;

        [NotificationXmlAttribute("contentId")]
        public string ContentId { get; set; }

        [NotificationXmlAttribute("displayName")]
        public string DisplayName { get; set; }

        [NotificationXmlAttribute("lang")]
        public string Language { get; set; }

        [NotificationXmlAttribute("version")]
        public int? Version { get; set; }

        public IList<Element_TileBinding> Bindings { get; private set; } = new List<Element_TileBinding>();
    }

    internal static class XmlWriterHelper
    {
        public static void Write(XmlWriter writer, object element)
        {
            NotificationXmlElementAttribute elAttr = GetElementAttribute(element.GetType());

            // If it isn't an element attribute, don't write anything
            if (elAttr == null)
                return;

            writer.WriteStartElement(elAttr.Name);



            IEnumerable<PropertyInfo> properties = GetProperties(element.GetType());

            List<object> elements = new List<object>();
            object content = null;

            // Write the attributes first
            foreach (PropertyInfo p in properties)
            {
                IEnumerable<Attribute> attributes = GetCustomAttributes(p);

                NotificationXmlAttributeAttribute attr = attributes.OfType<NotificationXmlAttributeAttribute>().FirstOrDefault();

                object propertyValue = GetPropertyValue(p, element);

                // If it's an attribute
                if (attr != null)
                {
                    object defaultValue = attr.DefaultValue;

                    // If the value is not the default value (and it's not null) we'll write it
                    if (!object.Equals(propertyValue, defaultValue) && propertyValue != null)
                        writer.WriteAttributeString(attr.Name, PropertyValueToString(propertyValue));
                }

                // If it's a content attribute
                else if (attributes.OfType<NotificationXmlContentAttribute>().Any())
                {
                    content = propertyValue;
                }

                // Otherwise it's an element or collection of elements
                else
                {
                    if (propertyValue != null)
                        elements.Add(propertyValue);
                }
            }

            // Then write children
            foreach (object el in elements)
            {
                // If it's a collection of children
                if (el is IEnumerable)
                { 
                    foreach (object child in (el as IEnumerable))
                        Write(writer, child);

                    continue;
                }

                // Otherwise just write the single element
                Write(writer, el);
            }

            // Then write any content if there is content
            if (content != null)
            {
                string contentString = content.ToString();
                if (!string.IsNullOrWhiteSpace(contentString))
                    writer.WriteString(contentString);
            }




            writer.WriteEndElement();
        }

        private static object GetPropertyValue(PropertyInfo propertyInfo, object obj)
        {
#if WINRT_NOT_PRESENT
            return propertyInfo.GetValue(obj, null);
#else
            return propertyInfo.GetValue(obj);
#endif
        }

        private static string PropertyValueToString(object propertyValue)
        {
            Type type = propertyValue.GetType();

            if (IsEnum(type))
            {
                EnumStringAttribute enumStringAttr = GetEnumStringAttribute(propertyValue as Enum);

                if (enumStringAttr != null)
                    return enumStringAttr.String;
            }

            return propertyValue.ToString();
        }

        private static EnumStringAttribute GetEnumStringAttribute(Enum enumValue)
        {
#if WINRT_NOT_PRESENT
            MemberInfo[] memberInfo = enumValue.GetType().GetMember(enumValue.ToString());

            if (memberInfo != null && memberInfo.Length > 0)
            {
                object[] attrs = memberInfo[0].GetCustomAttributes(typeof(EnumStringAttribute), false);

                if (attrs != null && attrs.Length > 0)
                    return attrs[0] as EnumStringAttribute;
            }

            return null;
#else
            return enumValue.GetType().GetTypeInfo().GetDeclaredField(enumValue.ToString()).GetCustomAttribute<EnumStringAttribute>();
#endif
        }

        private static bool IsEnum(Type type)
        {
#if WINRT_NOT_PRESENT
            return type.IsEnum;
#else
            return type.GetTypeInfo().IsEnum;
#endif
        }

        private static IEnumerable<PropertyInfo> GetProperties(Type type)
        {
#if WINRT_NOT_PRESENT
            return type.GetProperties();
#else
            return type.GetTypeInfo().DeclaredProperties;
#endif
        }

        private static NotificationXmlElementAttribute GetElementAttribute(Type type)
        {
            return GetCustomAttributes(type).OfType<NotificationXmlElementAttribute>().FirstOrDefault();
        }

        private static IEnumerable<Attribute> GetCustomAttributes(Type type)
        {
#if WINRT_NOT_PRESENT
            return type.GetCustomAttributes(true).OfType<Attribute>();
#else
            return type.GetTypeInfo().GetCustomAttributes();
#endif
        }

        private static IEnumerable<Attribute> GetCustomAttributes(PropertyInfo propertyInfo)
        {
#if WINRT_NOT_PRESENT
            return propertyInfo.GetCustomAttributes(true).OfType<Attribute>();
#else
            return propertyInfo.GetCustomAttributes();
#endif
        }
    }

    [NotificationXmlElement("binding")]
    public sealed class Element_TileBinding : IElementWithDescendants
    {
        internal const TileBranding DEFAULT_BRANDING = TileBranding.Auto;
        internal const bool DEFAULT_ADD_IMAGE_QUERY = false;
        internal const TileTextStacking DEFAULT_TEXT_STACKING = TileTextStacking.Top;
        internal const int DEFAULT_OVERLAY = 20;

        public Element_TileBinding(TileTemplateNameV3 template)
        {
            Template = template;
        }

        [NotificationXmlAttribute("template")]
        public TileTemplateNameV3 Template { get; private set; }

        [NotificationXmlAttribute("fallback")]
        public TileTemplateNameV1? Fallback { get; set; }

        /// <summary>
        /// Set to true to allow Windows to append a query string to the image URI supplied in the tile notification. Use this attribute if your server hosts images and can handle query strings, either by retrieving an image variant based on the query strings or by ignoring the query string and returning the image as specified without the query string. This query string specifies scale, contrast setting, and language; for instance, a value of
        /// 
        /// "www.website.com/images/hello.png"
        /// 
        /// included in the notification becomes
        /// 
        /// "www.website.com/images/hello.png?ms-scale=100&ms-contrast=standard&ms-lang=en-us"
        /// </summary>
        [NotificationXmlAttribute("addImageQuery", DEFAULT_ADD_IMAGE_QUERY)]
        public bool AddImageQuery { get; set; } = DEFAULT_ADD_IMAGE_QUERY;

        /// <summary>
        /// A default base URI that is combined with relative URIs in image source attributes.
        /// </summary>
        [NotificationXmlAttribute("baseUri")]
        public Uri BaseUri { get; set; }

        /// <summary>
        /// The form that the tile should use to display the app's brand.
        /// </summary>
        [NotificationXmlAttribute("branding", DEFAULT_BRANDING)]
        public TileBranding Branding { get; set; } = DEFAULT_BRANDING;

        /// <summary>
        /// Set to a sender-defined string that uniquely identifies the content of the notification. This prevents duplicates in the situation where a large tile template is displaying the last three wide tile notifications.
        /// 
        /// Required: NO
        /// </summary>
        [NotificationXmlAttribute("contentId")]
        public string ContentId { get; set; }

        /// <summary>
        /// An optional string to override the tile's display name while showing this notification.
        /// </summary>
        [NotificationXmlAttribute("displayName")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The target locale of the XML payload, specified as a BCP-47 language tags such as "en-US" or "fr-FR". The locale specified here overrides that in visual, but can be overriden by that in text. If this value is a literal string, this attribute defaults to the user's UI language. If this value is a string reference, this attribute defaults to the locale chosen by Windows Runtime in resolving the string. See Remarks for when this value isn't specified.
        /// </summary>
        [NotificationXmlAttribute("lang")]
        public string Language { get; set; }

        [NotificationXmlAttribute("hint-lockDetailedStatus1")]
        public string LockDetailedStatus1 { get; set; }

        [NotificationXmlAttribute("hint-lockDetailedStatus2")]
        public string LockDetailedStatus2 { get; set; }

        [NotificationXmlAttribute("hint-lockDetailedStatus3")]
        public string LockDetailedStatus3 { get; set; }

        private int _overlay = DEFAULT_OVERLAY;
        [NotificationXmlAttribute("hint-overlay", DEFAULT_OVERLAY)]
        public int Overlay
        {
            get { return _overlay; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Overlay must be between 0 and 100, inclusive.");

                _overlay = value;
            }
        }

        [NotificationXmlAttribute("hint-presentation")]
        public TilePresentation? Presentation { get; set; }

        [NotificationXmlAttribute("hint-textStacking", DEFAULT_TEXT_STACKING)]
        public TileTextStacking TextStacking { get; set; } = DEFAULT_TEXT_STACKING;
        

        public IList<IElement_TileBindingChild> Children { get; private set; } = new List<IElement_TileBindingChild>();

        /// <summary>
        /// Generates an enumerable collection of children and all those children's children
        /// </summary>
        /// <returns></returns>
        public IEnumerable<object> Descendants()
        {
            foreach (IElement_TileBindingChild child in Children)
            {
                // Return the child
                yield return child;

                // And if it has descendants, return the descendants
                if (child is IElementWithDescendants)
                {
                    foreach (object descendant in (child as IElementWithDescendants).Descendants())
                        yield return descendant;
                }
            }
        }
    }

    public interface IElementWithDescendants
    {
        IEnumerable<object> Descendants();
    }

    [NotificationXmlElement("image")]
    public sealed class Element_TileImage : IElement_TileBindingChild, IElement_TileSubgroupChild
    {
        internal const TileImagePlacement DEFAULT_PLACEMENT = TileImagePlacement.Inline;
        internal const bool DEFAULT_ADD_IMAGE_QUERY = false;
        internal const TileImageCrop DEFAULT_CROP = TileImageCrop.None;
        internal const bool DEFAULT_REMOVE_MARGIN = false;
        internal const TileImageAlign DEFAULT_ALIGN = TileImageAlign.Stretch;

        [NotificationXmlAttribute("id")]
        public int? Id { get; set; }

        [NotificationXmlAttribute("src")]
        public string Src { get; set; }

        [NotificationXmlAttribute("alt")]
        public string Alt { get; set; }

        [NotificationXmlAttribute("addImageQuery", DEFAULT_ADD_IMAGE_QUERY)]
        public bool AddImageQuery { get; set; } = DEFAULT_ADD_IMAGE_QUERY;

        [NotificationXmlAttribute("placement", DEFAULT_PLACEMENT)]
        public TileImagePlacement Placement { get; set; } = DEFAULT_PLACEMENT;

        [NotificationXmlAttribute("hint-align", DEFAULT_ALIGN)]
        public TileImageAlign Align { get; set; } = DEFAULT_ALIGN;

        [NotificationXmlAttribute("hint-crop", DEFAULT_CROP)]
        public TileImageCrop Crop { get; set; } = DEFAULT_CROP;

        [NotificationXmlAttribute("hint-removeMargin", DEFAULT_REMOVE_MARGIN)]
        public bool RemoveMargin { get; set; } = DEFAULT_REMOVE_MARGIN;
    }

    [NotificationXmlElement("text")]
    public sealed class Element_TileText : IElement_TileBindingChild, IElement_TileSubgroupChild
    {
        internal const TileTextStyle DEFAULT_STYLE = TileTextStyle.Caption;
        internal const bool DEFAULT_WRAP = false;
        internal const int DEFAULT_MAX_LINES = int.MaxValue;
        internal const int DEFAULT_MIN_LINES = 1;
        internal const TileTextAlign DEFAULT_ALIGN = TileTextAlign.Auto;

        [NotificationXmlContent]
        public string Text { get; set; }

        [NotificationXmlAttribute("id")]
        public int? Id { get; set; }

        [NotificationXmlAttribute("lang")]
        public string Language { get; set; }

        [NotificationXmlAttribute("hint-align", DEFAULT_ALIGN)]
        public TileTextAlign Align { get; set; } = DEFAULT_ALIGN;

        private int _maxLines = DEFAULT_MAX_LINES;
        [NotificationXmlAttribute("hint-maxLines", DEFAULT_MAX_LINES)]
        public int MaxLines
        {
            get { return _maxLines; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("MaxLines must be between 1 and int.MaxValue, inclusive.");

                _maxLines = value;
            }
        }

        private int _minLines = DEFAULT_MIN_LINES;
        [NotificationXmlAttribute("hint-minLines", DEFAULT_MIN_LINES)]
        public int MinLines
        {
            get { return _minLines; }
            set
            {
                if (value < 1)
                    throw new ArgumentOutOfRangeException("MinLines must be between 1 and int.MaxValue, inclusive.");

                _minLines = value;
            }
        }

        [NotificationXmlAttribute("hint-style", DEFAULT_STYLE)]
        public TileTextStyle Style { get; set; } = DEFAULT_STYLE;

        [NotificationXmlAttribute("hint-wrap", DEFAULT_WRAP)]
        public bool Wrap { get; set; } = DEFAULT_WRAP;
    }

    [NotificationXmlElement("group")]
    public sealed class Element_TileGroup : IElement_TileBindingChild, IElementWithDescendants
    {
        public IList<Element_TileSubgroup> Children { get; private set; } = new List<Element_TileSubgroup>();

        public IEnumerable<object> Descendants()
        {
            foreach (Element_TileSubgroup subgroup in Children)
            {
                // Return the subgroup
                yield return subgroup;

                // And also return its descendants
                foreach (object descendant in subgroup.Descendants())
                    yield return descendant;
            }
        }
    }

    public interface IElement_TileSubgroupChild { }

    public interface IElement_TileBindingChild { }

    [NotificationXmlElement("subgroup")]
    public sealed class Element_TileSubgroup : IElementWithDescendants
    {
        internal const TileAdaptiveSubgroupTextStacking DEFAULT_TEXT_STACKING = TileAdaptiveSubgroupTextStacking.Top;

        [NotificationXmlAttribute("hint-textStacking", DEFAULT_TEXT_STACKING)]
        public TileAdaptiveSubgroupTextStacking TextStacking { get; set; } = DEFAULT_TEXT_STACKING;

        private int? _weight;
        [NotificationXmlAttribute("hint-weight")]
        public int? Weight
        {
            get { return _weight; }

            set
            {
                if (value != null && value < 1)
                    throw new ArgumentOutOfRangeException("Weight must be between 1 and int.MaxValue, inclusive (or null)");

                _weight = value;
            }
        }

        public IList<IElement_TileSubgroupChild> Children { get; private set; } = new List<IElement_TileSubgroupChild>();

        public IEnumerable<object> Descendants()
        {
            foreach (IElement_TileSubgroupChild child in Children)
            {
                // Return each child (we know there's no further descendants)
                yield return child;
            }
        }
    }



}
