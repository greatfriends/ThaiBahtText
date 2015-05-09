@echo off
Packages\xunit.runner.console.2.0.0\tools\xunit.console ^
	GFDN.ThaiBahtTextFacts\bin\Release\GreatFriends.ThaiBahtTextFacts.dll ^
	-parallel all ^
	-html Result.html ^
	-nologo -quiet
@echo on 