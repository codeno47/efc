@CLS
@ECHO OFF

REM
REM  PrepareEnvironment.bat
REM
REM  Goal : populating the '..\Workspace\test' folder with all dependencies's binaries needed for execution.
REM
REM         This script must be launched from the 'libs' folder.
REM

IF NOT EXIST ..\Workspace\nul (
	MD ..\Workspace\nul
)


:
: (1) EFC
:
xcopy EnterpriseLibrary  	..\Workspace\test\ /y
xcopy EntityFramework	..\Workspace\test\ /y
xcopy MvvmLight	..\Workspace\test\ /y
xcopy PostSharp          ..\Workspace\test\ /y
xcopy Rhino.Mocks        ..\Workspace\test\ /y
xcopy MvvmLigh-Win8        ..\Workspace\test\ /y
xcopy MvvmLigh-WPhone8        ..\Workspace\test\ /y
xcopy NUnit        ..\Workspace\test\ /y
:---

GOTO End


:BadLocation
ECHO ---
ECHO --- : PrepareEnvironment.bat
ECHO       The destination directory (..\Workspace\test\) does not exist !
ECHO       Copy processing is canceled...
ECHO ---
ECHO ---
PAUSE
EXIT

:End
ECHO ---
ECHO --- : PrepareEnvironment.bat
ECHO       The '..\Workspace\test' folder has been populated with all dependencies's binaries needed for execution.
ECHO ---
ECHO ---
PAUSE

REM
REM End Of Script
REM
