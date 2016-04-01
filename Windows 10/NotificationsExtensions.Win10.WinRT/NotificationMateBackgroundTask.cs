using System;
using System.Linq;
using Windows.ApplicationModel.Background;

namespace NotificationsExtensions
{
    public sealed class NotificationMateBackgroundTask : IBackgroundTask
    {
        public static string TaskName { get; } = "NotificationMateBackgroundTask";

        /// <summary>
        /// Register a background task to automatically keep your tile in sync when your Toast notifications are added or removed.
        /// NOTE: You must register the background task in your manifest for it to fire. See the remarks section for more details.
        /// </summary>
        /// <remarks>
        /// You must include the following entry in your manifest for background task registration to work.
        /// <code>
        /// &lt;Extensions&gt;
        ///   &lt;Extension Category="windows.backgroundTasks" EntryPoint="NotificationsExtensions.NotificationMateBackgroundTask"&gt;
        ///     &lt;BackgroundTasks&gt;
        ///       &lt;Task Type="systemEvent" /&gt;
        ///     &lt;/BackgroundTasks&gt;
        ///   &lt;/Extension&gt;
        /// &lt;/Extensions&gt;
        /// </code>
        /// </remarks>
        public static void RegisterBackgroundTask()
        {
            if (BackgroundTaskRegistration.AllTasks.Values
                .Any(m => m.Name.Equals(TaskName, StringComparison.OrdinalIgnoreCase)))
                return;

            try
            {
                BackgroundTaskBuilder builder = new BackgroundTaskBuilder();
                builder.Name = TaskName;
                builder.TaskEntryPoint = typeof(NotificationMateBackgroundTask).FullName;
                builder.SetTrigger(new ToastNotificationHistoryChangedTrigger());
                var taskToRegister = builder.Register();
            }
            catch (Exception ex) when (ex.Message.Contains("Class not registered"))
            {
                throw new Exception($"Unable to register {TaskName}. Did you remember to declare the background task in your manifest? See the Remarks section for details", ex);
            }
        }

        public void Run(IBackgroundTaskInstance taskInstance)
        {
            NotificationMate.SyncTileWithActionCenter();
        }
    }
}