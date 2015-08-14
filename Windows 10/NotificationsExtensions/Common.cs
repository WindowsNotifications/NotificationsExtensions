// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Linq;
using System.Collections;
#if !WINRT_NOT_PRESENT
using Windows.Data.Xml.Dom;
#endif

namespace NotificationsExtensions
{
    internal sealed class LimitedList<T> : IList<T>
    {
        private List<T> _list;
        public int Limit { get; private set; }

        public LimitedList(int limit)
        {
            _list = new List<T>(limit);

            Limit = limit;
        }

        public T this[int index]
        {
            get
            {
                return _list[index];
            }

            set
            {
                _list[index] = value;
            }
        }

        public int Count
        {
            get
            {
                return _list.Count;
            }
        }

        public bool IsReadOnly
        {
            get
            {
                return false;
            }
        }

        public void Add(T item)
        {
            if (_list.Count >= Limit)
                throw new Exception("This list is limited to " + Limit + " items. You cannot add more items.");

            _list.Add(item);
        }

        public void Clear()
        {
            _list.Clear();
        }

        public bool Contains(T item)
        {
            return _list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            _list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return _list.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            _list.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return _list.Remove(item);
        }

        public void RemoveAt(int index)
        {
            _list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
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

    internal static class ConversionHelper
    {
        internal static object ConvertToElement(object obj)
        {
            MethodInfo convertToElement = GetMethod(obj.GetType(), "ConvertToElement");

            if (convertToElement == null)
                throw new NotImplementedException("Object must have ConvertToElement() method");

            if (convertToElement.ReturnType == typeof(void))
                throw new NotImplementedException("ConvertToElement() must return an object");

            return convertToElement.Invoke(obj, null);
        }

        internal static MethodInfo GetMethod(Type type, string name)
        {
            return type.GetMethod(name, BindingFlags.Instance | BindingFlags.NonPublic);

            //MethodInfo[] methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            //return methods.FirstOrDefault(i => i.Name.Equals(name));
        }
    }

    public interface IElementWithDescendants
    {
        IEnumerable<object> Descendants();
    }





    internal sealed class NotificationContentText : INotificationContentText
    {
        internal NotificationContentText() { }

        public string Text
        {
            get { return m_Text; }
            set { m_Text = value; }
        }

        public string Lang
        {
            get { return m_Lang; }
            set { m_Lang = value; }
        }

        private string m_Text;
        private string m_Lang;
    }

    internal sealed class NotificationContentImage : INotificationContentImage
    {
        internal NotificationContentImage() { }

        public string Src
        {
            get { return m_Src; }
            set { m_Src = value; }
        }

        public string Alt
        {
            get { return m_Alt; }
            set { m_Alt = value; }
        }

        public bool AddImageQuery
        {
            get
            {
                if (m_AddImageQueryNullable == null || m_AddImageQueryNullable.Value == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set { m_AddImageQueryNullable = value; }
        }

        public bool? AddImageQueryNullable
        {
            get { return m_AddImageQueryNullable; }
            set { m_AddImageQueryNullable = value; }
        }

        private string m_Src;
        private string m_Alt;
        private bool? m_AddImageQueryNullable;
    }

    internal static class Util
    {
        public const int NOTIFICATION_CONTENT_VERSION = 1;

        public static string HttpEncode(string value)
        {
            return value.Replace("&", "&amp;").Replace("<", "&lt;").Replace(">", "&gt;").Replace("\"", "&quot;").Replace("'", "&apos;");
        }
    }

    /// <summary>
    /// Base class for the notification content creation helper classes.
    /// </summary>
#if !WINRT_NOT_PRESENT
    internal abstract class NotificationBase
#else
    abstract partial class NotificationBase
#endif
    {
        protected NotificationBase(string templateName, int imageCount, int textCount)
        {
            m_TemplateName = templateName;

            m_Images = new NotificationContentImage[imageCount];
            for (int i = 0; i < m_Images.Length; i++)
            {
                m_Images[i] = new NotificationContentImage();
            }

            m_TextFields = new INotificationContentText[textCount];
            for (int i = 0; i < m_TextFields.Length; i++)
            {
                m_TextFields[i] = new NotificationContentText();
            }
        }

        public bool StrictValidation
        {
            get { return m_StrictValidation; }
            set { m_StrictValidation = value; }
        }
        public abstract string GetContent();

        public override string ToString()
        {
            return GetContent();
        }

#if !WINRT_NOT_PRESENT
        public Windows.Data.Xml.Dom.XmlDocument GetXml()
        {
            Windows.Data.Xml.Dom.XmlDocument xml = new Windows.Data.Xml.Dom.XmlDocument();
            xml.LoadXml(GetContent());
            return xml;
        }
#endif

        /// <summary>
        /// Retrieves the list of images that can be manipulated on the notification content.
        /// </summary>
        public INotificationContentImage[] Images
        {
            get { return m_Images; }
        }

        /// <summary>
        /// Retrieves the list of text fields that can be manipulated on the notification content.
        /// </summary>
        public INotificationContentText[] TextFields
        {
            get { return m_TextFields; }
        }

        /// <summary>
        /// The base Uri path that should be used for all image references in the notification.
        /// </summary>
        public string BaseUri
        {
            get { return m_BaseUri; }
            set
            {
                if (this.StrictValidation && !String.IsNullOrEmpty(value))
                {
                    Uri uri;
                    try
                    {
                        uri = new Uri(value);
                    }
                    catch (Exception e)
                    {
                        throw new ArgumentException("Invalid URI. Use a valid URI or turn off StrictValidation", e);
                    }
                    if (!(uri.Scheme.Equals("http", StringComparison.OrdinalIgnoreCase)
                        || uri.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase)
                        || uri.Scheme.Equals("ms-appx", StringComparison.OrdinalIgnoreCase)
                        || (uri.Scheme.Equals("ms-appdata", StringComparison.OrdinalIgnoreCase)
                            && (uri.AbsolutePath.StartsWith("/local/") || uri.AbsolutePath.StartsWith("local/"))))) // both ms-appdata:local/ and ms-appdata:/local/ are valid
                    {
                        throw new ArgumentException("The BaseUri must begin with http://, https://, ms-appx:///, or ms-appdata:///local/.", "value");
                    }
                }
                m_BaseUri = value;
            }
        }

        public string Lang
        {
            get { return m_Lang; }
            set { m_Lang = value; }
        }

        public bool AddImageQuery
        {
            get
            {
                if (m_AddImageQueryNullable == null || m_AddImageQueryNullable.Value == false)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            set { m_AddImageQueryNullable = value; }
        }

        public bool? AddImageQueryNullable
        {
            get { return m_AddImageQueryNullable; }
            set { m_AddImageQueryNullable = value; }
        }

        protected string SerializeProperties(string globalLang, string globalBaseUri, bool globalAddImageQuery)
        {
            globalLang = (globalLang != null) ? globalLang : String.Empty;
            globalBaseUri = String.IsNullOrWhiteSpace(globalBaseUri) ? null : globalBaseUri;

            StringBuilder builder = new StringBuilder(String.Empty);
            for (int i = 0; i < m_Images.Length; i++)
            {
                if (!String.IsNullOrEmpty(m_Images[i].Src))
                {
                    string escapedSrc = Util.HttpEncode(m_Images[i].Src);
                    if (!String.IsNullOrWhiteSpace(m_Images[i].Alt))
                    {
                        string escapedAlt = Util.HttpEncode(m_Images[i].Alt);
                        if (m_Images[i].AddImageQueryNullable == null || m_Images[i].AddImageQueryNullable == globalAddImageQuery)
                        {
                            builder.AppendFormat("<image id='{0}' src='{1}' alt='{2}'/>", i + 1, escapedSrc, escapedAlt);
                        }
                        else
                        {
                            builder.AppendFormat("<image addImageQuery='{0}' id='{1}' src='{2}' alt='{3}'/>", m_Images[i].AddImageQuery.ToString().ToLowerInvariant(), i + 1, escapedSrc, escapedAlt);
                        }
                    }
                    else
                    {
                        if (m_Images[i].AddImageQueryNullable == null || m_Images[i].AddImageQueryNullable == globalAddImageQuery)
                        {
                            builder.AppendFormat("<image id='{0}' src='{1}'/>", i + 1, escapedSrc);
                        }
                        else
                        {
                            builder.AppendFormat("<image addImageQuery='{0}' id='{1}' src='{2}'/>", m_Images[i].AddImageQuery.ToString().ToLowerInvariant(), i + 1, escapedSrc);
                        }
                    }
                }
            }

            for (int i = 0; i < m_TextFields.Length; i++)
            {
                if (!String.IsNullOrWhiteSpace(m_TextFields[i].Text))
                {
                    string escapedValue = Util.HttpEncode(m_TextFields[i].Text);
                    if (!String.IsNullOrWhiteSpace(m_TextFields[i].Lang) && !m_TextFields[i].Lang.Equals(globalLang))
                    {
                        string escapedLang = Util.HttpEncode(m_TextFields[i].Lang);
                        builder.AppendFormat("<text id='{0}' lang='{1}'>{2}</text>", i + 1, escapedLang, escapedValue);
                    }
                    else
                    {
                        builder.AppendFormat("<text id='{0}'>{1}</text>", i + 1, escapedValue);
                    }
                }
            }

            return builder.ToString();
        }

        public string TemplateName { get { return m_TemplateName; } }

        private bool m_StrictValidation = true;
        private NotificationContentImage[] m_Images;
        private INotificationContentText[] m_TextFields;

        private string m_Lang;
        private string m_BaseUri;
        private string m_TemplateName;
        private bool? m_AddImageQueryNullable;
    }

    /// <summary>
    /// Exception returned when invalid notification content is provided.
    /// </summary>
    internal sealed class NotificationContentValidationException : Exception
    {
        public NotificationContentValidationException(string message)
            : base(message)
        {
        }
    }
}