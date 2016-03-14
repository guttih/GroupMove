@echo off
set SolDir=%~1
set ConfigFileTo="%SolDir%Setup\download.config"
set ConfigFile=download.config
set ConfigurationName=%2
set ConfigPath=%SolDir%Setup


if NOT %3x==x ( 
	REM FOR TESTING OTHER PARAMETERS
	echo param3: "%~3"
	dir "%~3"
	goto endir
)
if %1x==x (
	echo ERROR: No Parameter given
	goto endir
)
if NOT exist "%SolDir%\." (
	echo ERROR: Directory "%SolDir%" does not exist 
	goto endir
)
if exist %ConfigFileTo% (
	echo Deleting old config file.
	del %ConfigFileTo%
)
echo copying app.config to %ConfigFileTo%
Copy "%SolDir%GroupMove\app.config" %ConfigFileTo%

:: Extract version number information from the config file
cd %ConfigPath%

 set lineNr=
 for /f "delims=:" %%a in ('findstr /n /c:"<setting name=\"version\" serializeAs=\"String\">" %ConfigFile%') do (
 		SET lineNr=%%a
 )

 if %lineNr%x==x (
 	echo Error: Version not found! --setting string
 	goto endir
 )

 for /f "usebackq tokens=3 delims=<>" %%a in (`more +%lineNr% download.config`) DO (
   SET gVersion=%%a
   goto :versionInfo
 )

 :versionInfo
 	if %gVersion%x==x (
 		echo Error: Version not found! --version.number
 		goto endir
 	)
	
 	set gVersionFolder=	
 	for /F "tokens=1,2,3,4 delims=. " %%a in ("%gVersion%") do (set gVersionFolder=%%a_%%b_%%c_%%d)
 	if %gVersionFolder%x==x (
 		echo Error: Version not found! --version_folder 
 		goto endir
 	)
 	echo Version : %gVersion%
 	echo %gVersionFolder%
	mkdir %gVersionFolder%
	echo %gVersionFolder% > version.txt
	move %ConfigFileTo%  %gVersionFolder%
	if exist %gVersionFolder%\download.config (
	echo Success
	goto endir
)
	echo Error: ---- no configfile in version folder

:::::::::::::::::::::::::::::::::::

:endir
set SolDir=
set ConfigFileTo=

set lineNr=
set configFile=
SET gVersion=
SET ConfigPath=