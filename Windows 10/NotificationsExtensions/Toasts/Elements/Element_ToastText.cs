// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved



namespace NotificationsExtensions.Toasts
{
    [NotificationXmlElement("text")]
    internal sealed class Element_ToastText : IElement_ToastBindingChild
    {
        [NotificationXmlContent]
        public string Text { get; set; }
        
        [NotificationXmlAttribute("lang")]
        public string Lang { get; set; }


        [NotificationXmlAttribute("hint-wrap")]
        public bool Wrap { get; set; }
    }
}