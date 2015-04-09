@CLS
@ECHO OFF

REM
REM  PrepareEnvironment.bat
REM
REM  Goal : populating the '..\Workspace\bin' folder with all dependencies's binaries needed for execution.
REM
REM         This script must be launched from the 'libs' folder.
REM

IF NOT EXIST ..\Workspace\nul (
	MD ..\Workspace\nul
)


:
: (1) EFC
:
xcopy EnterpriseLibrary  	..\Workspace\bin\ /y
xcopy EntityFramework	..\Workspace\bin\ /y
xcopy MvvmLight	..\Workspace\bin\ /y
xcopy PostSharp          ..\Workspace\bin\ /y
xcopy Rhino.Mocks        ..\Workspace\bin\ /y
xcopy MvvmLigh-Win8        ..\Workspace\bin\ /y
xcopy MvvmLigh-WPhone8        ..\Workspace\bin\ /y
:---

GOTO End


:BadLocation
ECHO ---
ECHO --- : PrepareEnvironment.bat
ECHO       The destination directory (..\Workspace\bin\) does not exist !
ECHO       Copy processing is canceled...
ECHO ---
ECHO ---
PAUSE
EXIT

:End
ECHO ---
ECHO --- : PrepareEnvironment.bat
ECHO       The '..\Workspace\bin' folder has been populated with all dependencies's binaries needed for execution.
ECHO ---
ECHO ---
PAUSE

REM
REM End Of Script
REM
