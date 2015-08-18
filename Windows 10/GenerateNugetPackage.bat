@echo off

echo Welcome, let's create a new NuGet package for NotificationsExtensions.Win10!
echo.

set /p version="Enter Version Number (ex. 10240.0.0): "

"C:\Program Files (x86)\NuGet\nuget.exe" pack -Version %version%

PAUSE