@CLS
@echo off
rem
rem  build.cmd
rem
rem  Goal : building the EFC Core solutions:
rem         - EFC.Framework
rem
rem         This script must be launched from the 'dev' folder.
rem

set MSBuildDir="C:\Program Files (x86)\MSBuild\12.0\Bin\"

"C:\Program Files (x86)\MSBuild\12.0\Bin\msbuild.exe" Experion.PMO\Build\Build.CI\Targets\PrivateBuild.proj
if not %ERRORLEVEL% equ 0 goto Error

goto End

:Error
echo ---
echo --- : build.cmd
echo       The build failed. See output messages for details.
echo ---
echo ---

:End
echo ---
echo --- : build.cmd
echo       The build succeeded.
echo ---
echo ---
pause

rem
rem EndOfScript
rem
