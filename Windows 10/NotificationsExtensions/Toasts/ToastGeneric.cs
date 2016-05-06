using System;
using System.Collections.Generic;
using System.Text;

namespace NotificationsExtensions.Toasts
{
    public sealed class ToastGeneric
    {
        public IList<ToastText> TextElements { get; private set; } = new List<ToastText>();


    }

    public interface ToastGenericAdaptive { }
}
