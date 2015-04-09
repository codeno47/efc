@CLS
@ECHO OFF

REM
REM  PrepareEnvironment.bat
REM
REM  Goal : populating the '..\Workspace_Samples\bin' folder with all dependencies's binaries needed for execution.
REM
REM         This script must be launched from the 'libs' folder.
REM

IF NOT EXIST ..\Workspace_Samples\nul (
	MD ..\Workspace_Samples\nul
)


:
: (1) EFC
:
xcopy MvvmLigh-WPhone8        ..\Workspace_Samples\bin\ /y
xcopy Unity-WPhone8        ..\Workspace_Samples\bin\ /y
xcopy EFC        ..\Workspace_Samples\bin\ /y
xcopy Newtonsoft.Json.Phone        ..\Workspace_Samples\bin\ /y
:---

GOTO End


:BadLocation
ECHO ---
ECHO --- : PrepareEnvironment.bat
ECHO       The destination directory (..\Workspace_Samples\bin\) does not exist !
ECHO       Copy processing is canceled...
ECHO ---
ECHO ---
PAUSE
EXIT

:End
ECHO ---
ECHO --- : PrepareEnvironment.bat
ECHO       The '..\Workspace_Samples\bin' folder has been populated with all dependencies's binaries needed for execution.
ECHO ---
ECHO ---
PAUSE

REM
REM End Of Script
REM
