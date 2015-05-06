# ThaiBahtText
Generate money amount text in Thai language for example: from 121.50 will be "หนึ่งร้อยยี่สิบเอ็ดบาทห้าสิบสตางค์"

## How to test
This project use xUnit 2.0 console runner. You can run test by execute `test.bat` in your command prompt. 
The test result also generated to `Result.html` file

## Original 
Pick the source code from my post in GreatFriends.Biz web site since 1996.
At first post in the web in VB.NET language (http://greatfriends.biz/webboards/msg.asp?id=5331)
and then convert to C# language (http://www.greatfriends.biz/webboards/msg.asp?id=5695).

## How to use
1. Add reference to GreatFriends.ThaiBahtText.Dll (download from Releases tab)
2. See below sample code and apply as needed:

		using GreatFriends.ThaiBahtText;
		
		...
		decimal price = 11.50;
		decimal? total = null;
		
		string s1 = price.ThaiBahtText(); // สิบเอ็ดบาทห้าสิบสตางค์ (ใช้ในรูปแบบ extension method)
		string s2 = total.ThaiBahtText(); // ศูนย์บาทถ้วน
		string s3 = ThaiBahtTextUtil.ThaiBahtText(total); // ใช้ในรูปแบบปกติ
