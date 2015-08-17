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
    [NotificationXmlElement("toast")]
    internal sealed class Element_Toast : BaseElement
    {
        internal const ToastScenario DEFAULT_SCENARIO = ToastScenario.Default;
        internal const ToastActivationType DEFAULT_ACTIVATION_TYPE = ToastActivationType.Foreground;
        internal const ToastDuration DEFAULT_DURATION = ToastDuration.Short;

        [NotificationXmlAttribute("activationType", DEFAULT_ACTIVATION_TYPE)]
        public ToastActivationType ActivationType { get; set; } = DEFAULT_ACTIVATION_TYPE;

        [NotificationXmlAttribute("duration", DEFAULT_DURATION)]
        public ToastDuration Duration { get; set; } = DEFAULT_DURATION;

        [NotificationXmlAttribute("launch")]
        public string Launch { get; set; }

        [NotificationXmlAttribute("scenario", DEFAULT_SCENARIO)]
        public ToastScenario Scenario { get; set; } = DEFAULT_SCENARIO;

        public Element_ToastVisual Visual { get; set; }

        public Element_ToastAudio Audio { get; set; }

        public Element_ToastActions Actions { get; set; }
    }

    public enum ToastDuration
    {
        Short,
        
        [EnumString("long")]
        Long
    }

    public enum ToastScenario
    {
        Default,

        [EnumString("alarm")]
        Alarm,

        [EnumString("reminder")]
        Reminder,

        [EnumString("incomingCall")]
        IncomingCall
    }
}