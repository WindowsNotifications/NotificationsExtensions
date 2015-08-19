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
using System.Reflection;
using System.Linq;
using System.Collections;
using System.IO;

namespace NotificationsExtensions.Toasts
{

    /// <summary>
    /// Automatically constructs a selection box for snooze intervals, and snooze/dismiss buttons, all automatically localized, and snoozing logic is automatically handled by the system.
    /// </summary>
    public sealed class ToastActionsSnoozeAndDismiss : IToastActions
    {
        internal Element_ToastActions ConvertToElement()
        {
            return new Element_ToastActions()
            {
                SystemCommand = ToastSystemCommand.SnoozeAndDismiss
            };
        }
    }

    /// <summary>
    /// Create your own custom actions, using controls like <see cref="ToastButton"/>, <see cref="ToastTextBox"/>, and <see cref="ToastSelectionBox"/>.
    /// </summary>
    public sealed class ToastActionsCustom : IToastActions
    {
        /// <summary>
        /// Inputs like <see cref="ToastTextBox"/> and <see cref="ToastSelectionBox"/> can be added to the toast. Only up to 5 inputs can be added; after that, an exception is thrown.
        /// </summary>
        public IList<IToastInput> Inputs { get; private set; } = new LimitedList<IToastInput>(5);

        /// <summary>
        /// Buttons are displayed after all the inputs (or adjacent to inputs if used as quick reply buttons). Only up to 5 buttons can be added; after that, an exception is thrown.
        /// </summary>
        public IList<ToastButton> Buttons { get; private set; } = new LimitedList<ToastButton>(5);

        internal Element_ToastActions ConvertToElement()
        {
            var el = new Element_ToastActions();

            foreach (var input in Inputs)
                el.Children.Add(ConvertToInputElement(input));

            foreach (var button in Buttons)
                el.Children.Add(button.ConvertToElement());

            return el;
        }

        private static Element_ToastInput ConvertToInputElement(IToastInput input)
        {
            Element_ToastInput converted = ConversionHelper.ConvertToElement(input) as Element_ToastInput;

            if (converted == null)
                throw new NotImplementedException("Toast input must support converting to Element_ToastInput");

            return converted;
        }
    }

    public interface IToastInput { }


    public interface IToastActions { }
}
