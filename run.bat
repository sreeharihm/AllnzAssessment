@ECHO off
start "Worker Service" cmd /k  runbackground.bat
start "Gateway Api" cmd /k  rungateway.bat
start "Ui" cmd /k  runui.bat
start "Unit Tests" cmd /k  runtest.bat
ECHO Startup executed