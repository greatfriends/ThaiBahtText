@ECHO OFF

REM GIT Tag and Build nuget package   

IF "%1" == "" GOTO SyntaxError
IF "%2" == "" GOTO SyntaxError

REM main code
git tag -a %1 -m "%2"
cd GFDN.ThaiBahtText
nuget pack GFDN.ThaiBahtText.csproj ^
   -Version %1 ^
	 -Prop Configuration=Release ^
	 -OutputDirectory "Nuget Packages"
cd ..
@ECHO.
@ECHO Push to GitHub
git push origin master
git push origin --tags
@ECHO.
@ECHO Push to NuGet
nuget push "GFDN.ThaiBahtText\NuGet Packages\ThaiBahtText.%1.nupkg"
GOTO End

:SyntaxError
@ECHO Usage syntax:
@ECHO.
@ECHO nugetpack tag_number tag_name
@ECHO.
@ECHO Sample: 
@ECHO   nugetpack 0.1 baby-peter
GOTO End

:End
@ECHO ON 