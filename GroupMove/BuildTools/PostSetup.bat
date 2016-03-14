@echo off
set SolDir=%~1
set Configuration=%2
set FromDir=%SolDir%%Configuration%
set SetupFile="setup.msi"
set ver=

echo SolDir=%SolDir%
echo Configuration=%Configuration%


type version.txt
for /f "delims=" %%i in ('type version.txt') do set ver=%%i

IF NOT EXIST %ver% (
	echo Version folder not found
	goto endir
)

cd %ver%
copy ..\%Configuration%\%SetupFile% .
echo ver er = %ver%

:endir
set SolDir=
set Configuration=
set FromDir=
set ver=
set SetupFile=