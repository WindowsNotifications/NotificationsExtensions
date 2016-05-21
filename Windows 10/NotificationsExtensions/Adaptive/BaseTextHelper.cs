// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved

using NotificationsExtensions.Adaptive.Elements;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions
{
    internal class BaseTextHelper
    {
        internal static Element_AdaptiveText CreateBaseElement(IBaseText curr)
        {
            return new Element_AdaptiveText()
            {
                Text = curr.Text,
                Lang = curr.Language
            };
        }
    }
}
