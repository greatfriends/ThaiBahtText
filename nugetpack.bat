@ECHO OFF
@ECHO ------------------------
@ECHO GIT TAG AND NUGET PACKER
@ECHO ------------------------
@ECHO.

IF "%1" == "" GOTO SyntaxError

REM main code
git tag -a "v%1" -m "%1"
cd GreatFriends.ThaiBahtText
nuget pack GreatFriends.ThaiBahtText.csproj ^
   -Version "%1" ^
	 -Prop Configuration=Release ^
	 -OutputDirectory "Nuget Packages"
cd ..
@ECHO.
@ECHO Push to GitHub
git push origin master
git push origin --tags
@ECHO.
@ECHO Push to NuGet
nuget push "GreatFriends.ThaiBahtText\NuGet Packages\ThaiBahtText.%1.nupkg"
GOTO End

:SyntaxError
@ECHO Usage:
@ECHO.
@ECHO     nugetpack version
@ECHO.
@ECHO Sample:
@ECHO.
@ECHO     nugetpack 0.1.2
@ECHO.
@ECHO     will create tag 'v0.1.2'
@ECHO     and release and nuget package version '0.1.2'
GOTO End

:End
@ECHO ON
