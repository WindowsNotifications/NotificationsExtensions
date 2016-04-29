using System;
using System.Linq;
using Windows.ApplicationModel.Background;

namespace NotificationsExtensions
{
    /// <summary>
    /// This class is an already-implemented background task for handling the <see cref="ToastNotificationHistoryChangedTrigger"/> to update your primary Live Tile and badge count. All you have to do is call the <see cref="NotificationMateBackgroundTask.RegisterBackgroundTask"/> method to register the background task.
    /// </summary>
    public sealed class NotificationMateBackgroundTask : IBackgroundTask
    {
        /// <summary>
        /// Gets a string representing the name used to register the background task. If you want to unregister the background task, you can find the background task with this given name and unregister it.
        /// </summary>
        public static string TaskName { get; } = "NotificationMateBackgroundTask";

        /// <summary>
        /// Register a background task to automatically keep your tile in sync when your Toast notifications are added or removed.
        /// NOTE: You must register the background task in your manifest for it to fire. See the remarks section for more details.
        /// The easiest way to implement NotificationMate is to call this method upon your app's initilization. It is safe to call this
        /// method multiple times - the method checks if the background task isn't registered yet before registering a new task.
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

        /// <summary>
        /// This method is executed when the background task is triggered as a result of a change in the app's notifications
        /// that wasn't caused by the app's local code sending a notification itself.
        /// </summary>
        /// <param name="taskInstance"></param>
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            NotificationMate.SyncTileWithActionCenter();
        }
    }
}