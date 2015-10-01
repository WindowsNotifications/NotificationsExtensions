// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF
// ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO
// THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//
// Copyright (c) Microsoft Corporation. All rights reserved


using System;
using System.Collections.Generic;

namespace NotificationsExtensions.Toasts
{

    /// <summary>
    /// Automatically constructs a selection box for snooze intervals, and snooze/dismiss buttons, all automatically localized, and snoozing logic is automatically handled by the system.
    /// </summary>
    public sealed class ToastActionsSnoozeAndDismiss : IToastActions
    {
        /// <summary>
        /// Automatically constructs a selection box for snooze intervals, and snooze/dismiss buttons, all automatically localized, and snoozing logic is automatically handled by the system.
        /// </summary>
        public ToastActionsSnoozeAndDismiss() { }

        internal Element_ToastActions ConvertToElement()
        {
            return new Element_ToastActions()
            {
                SystemCommands = ToastSystemCommand.SnoozeAndDismiss
            };
        }
    }

    /// <summary>
    /// Create your own custom actions, using controls like <see cref="ToastButton"/>, <see cref="ToastTextBox"/>, and <see cref="ToastSelectionBox"/>.
    /// </summary>
    public sealed class ToastActionsCustom : IToastActions
    {
        /// <summary>
        /// Initializes a new instance of custom actions, which can use controls like <see cref="ToastButton"/>, <see cref="ToastTextBox"/>, and <see cref="ToastSelectionBox"/>.
        /// </summary>
        public ToastActionsCustom() { }

        /// <summary>
        /// Inputs like <see cref="ToastTextBox"/> and <see cref="ToastSelectionBox"/> can be added to the toast. Only up to 5 inputs can be added; after that, an exception is thrown.
        /// </summary>
        public IList<IToastInput> Inputs { get; private set; } = new LimitedList<IToastInput>(5);

        /// <summary>
        /// Buttons are displayed after all the inputs (or adjacent to inputs if used as quick reply buttons). Only up to 5 buttons can be added; after that, an exception is thrown. You can add <see cref="ToastButton"/>, <see cref="ToastButtonSnooze"/>, or <see cref="ToastButtonDismiss"/>
        /// </summary>
        public IList<IToastButton> Buttons { get; private set; } = new LimitedList<IToastButton>(5);

        internal Element_ToastActions ConvertToElement()
        {
            var el = new Element_ToastActions();

            foreach (var input in Inputs)
                el.Children.Add(ConvertToInputElement(input));

            foreach (var button in Buttons)
                el.Children.Add(ConvertToActionElement(button));

            return el;
        }

        private static Element_ToastAction ConvertToActionElement(IToastButton button)
        {
            if (button is ToastButton)
                return (button as ToastButton).ConvertToElement();

            else if (button is ToastButtonDismiss)
                return (button as ToastButtonDismiss).ConvertToElement();

            else if (button is ToastButtonSnooze)
                return (button as ToastButtonSnooze).ConvertToElement();

            throw new NotImplementedException("Unknown button child: " + button.GetType());
        }

        private static Element_ToastInput ConvertToInputElement(IToastInput input)
        {
            if (input is ToastTextBox)
                return (input as ToastTextBox).ConvertToElement();

            else if (input is ToastSelectionBox)
                return (input as ToastSelectionBox).ConvertToElement();

            throw new NotImplementedException("Unknown input child: " + input.GetType());
        }
    }

    /// <summary>
    /// An input element on a toast notification. One of <see cref="ToastTextBox"/> or <see cref="ToastSelectionBox"/>.
    /// </summary>
    public interface IToastInput { }

    /// <summary>
    /// Actions to display on a toast notification. One of <see cref="ToastActionsCustom"/> or <see cref="ToastActionsSnoozeAndDismiss"/>.
    /// </summary>
    public interface IToastActions { }
}
