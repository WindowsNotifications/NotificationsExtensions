## NotificationsExtensions for Windows 10

This is the Windows 10 version of NotificationsExtensions. Andrew Bares, a PM on the Notifications team at Microsoft, re-wrote the existing NotificationsExtensions library, adding support for the new adaptive tiles and adaptive/interactive toast notifications in Windows 10.

### Getting Started

1. Clone this repository to your local hard drive
2. Open your own project (Windows 10 app, server code, etc)
3. **If you're writing a Windows 10 app, reference "Windows 10" -> "NotificationsExtensions.Win10.WinRT"**
4. If you're writing a server app (non-WinRT), reference "Windows 10" -> "NotificationsExtensions.Win10.Portable"
5. After the project is referenced, the namespace is "NotificationsExtensions" and each category of notifications are under their own namespace like "NotificationsExtensions.Tiles" or "Toasts" or "Badges".


### How to use it

Please [read our Wiki](https://github.com/anbare/NotificationsExtensions/wiki) to learn how to use NotificationsExtensions.
