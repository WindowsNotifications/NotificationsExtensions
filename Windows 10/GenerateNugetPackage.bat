@echo off

set files=NotificationsExtensions.Win10.Portable\bin\Release\NotificationsExtensions.Win10.Portable.dll
set files=%files% NotificationsExtensions.Win10.Portable\bin\Release\NotificationsExtensions.Win10.Portable.pdb
set files=%files% NotificationsExtensions.Win10.Portable\bin\Release\NotificationsExtensions.Win10.Portable.xml

set files=%files% NotificationsExtensions.Win10.WinRT\bin\Release\NotificationsExtensions.winmd
set files=%files% NotificationsExtensions.Win10.WinRT\bin\Release\NotificationsExtensions.pri
set files=%files% NotificationsExtensions.Win10.WinRT\bin\Release\NotificationsExtensions.pdb
set files=%files% NotificationsExtensions.Win10.WinRT\bin\Release\NotificationsExtensions.xml

set files=%files% NotificationsExtensions.Win10.NETCore\bin\Release\NotificationsExtensions.Win10.NETCore.dll
set files=%files% NotificationsExtensions.Win10.NETCore\bin\Release\NotificationsExtensions.Win10.NETCore.pdb
set files=%files% NotificationsExtensions.Win10.NETCore\bin\Release\NotificationsExtensions.Win10.NETCore.xml

FOR %%f IN (%files%) DO IF NOT EXIST %%f call :file_not_found %%f


echo Here are the current timestamps on the DLL's...
echo.

FOR %%f IN (%files%) DO ECHO %%~tf %%f

echo.

PAUSE



echo Welcome, let's create a new NuGet package for NotificationsExtensions.Win10!
echo.

set /p version="Enter Version Number (ex. 10240.0.0): "

if not exist "..\NugetPackages" mkdir "..\NugetPackages"

"C:\Program Files (x86)\NuGet\nuget.exe" pack -Version %version% -OutputDirectory "..\NugetPackages"

PAUSE

explorer ..\NugetPackages




exit
:file_not_found

echo File not found: %1
PAUSE
exit