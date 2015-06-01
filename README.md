[![Stories in Ready](https://badge.waffle.io/greatfriends/ThaiBahtText.png?label=ready&title=Ready)](https://waffle.io/greatfriends/ThaiBahtText)
[![Build status](https://ci.appveyor.com/api/projects/status/gdya3qrey5n3yb12?svg=true)](https://ci.appveyor.com/project/surrealist/thaibahttext)
[![Nuget Version](https://img.shields.io/nuget/v/ThaiBahtText.svg)](https://www.nuget.org/packages/ThaiBahtText)
[![Nuget Downloads](https://img.shields.io/nuget/dt/ThaiBahtText.svg)](https://www.nuget.org/packages/ThaiBahtText)

# ThaiBahtText
ให้ข้อความจำนวนเงินภาษาไทย เช่น จำนวน 121.50 บาท จะให้ผลลัพธ์เป็น "หนึ่งร้อยยี่สิบเอ็ดบาทห้าสิบสตางค์"


## เริ่มต้นใช้งาน

ภาษา C#

```c#
using GreatFriends.ThaiBahtText;

...
decimal amount = 121.50M;
string  s = amount.ThaiBahtText(); // หนึ่งร้อยยี่สิบเอ็ดบาทห้าสิบสตางค์
```

ภาษา Visual Basic

```vb
Imports GreatFriends.ThaiBahtText

...
Dim amount As Decimal = 121.50D
Dim s As String = amount.ThaiBahtText() ' หนึ่งร้อยยี่สิบเอ็ดบาทห้าสิบสตางค์
```

## การติดตั้งและอับเดตเวอร์ชั่นล่าสุด

คลิกเมนู TOOLS ใน Visual Studio เลือก NuGet Package Manager > Package Manager Console

```
PM> Install-Package ThaiBahtText
```	

ตรวจสอบและอับเดตให้เป็นเวอร์ชั่นล่าสุด

```
PM> Update-Package ThaiBahtText
```

การถอนการติดตั้งออก

```
PM> Uninstall-Package ThaiBahtText
```
 
Nuget Package Page: https://www.nuget.org/packages/ThaiBahtText/


## ตัวเลือก
ฟังก์ชั่น ThaiBahtText มี overloads ดังนี้

1. _amount_.**ThaiBahtText**(**UsesEt** mode, **Unit** unit, int decimalPlaces, bool includeBahtOnly);
2. _amount_.**ThaiBahtText**(**ThaiBahtTextOptions** options);

โดยที่ _amount_ อาจจะเป็น `decimal` หรือ `decimal?` ก็ได้

คลาส `ThaiBahtTextOptions` ใช้เพื่อส่งค่าตัวเลือกได้สะดวกขึ้น โดยมี properties ดังนี้

Property | Type     |Description
---------| ---------|---------------
UsesEt   | enum     | การใช้เอ็ดเมื่อมีค่าหนึ่งในหลักหน่วย กำหนดค่าเป็น `UsesEt.TensOnly` (เป็นค่าเริ่มต้น) เมื่อต้องการใช้เอ็ดในหลักสิบเท่านั้น และ  `UsesEt.Always` เมื่อต้องการใช้เอ็ดเสมอ
Unit     | enum     | กำหนดหน่วยของข้อความที่ต้องการว่า จะเป็น `Unit.Baht` บาท (เป็นค่าเริ่มต้น) `Unit.Million` ล้านบาท `Unit.Billion` พันล้านบาท หรือ `Unit.Trillion` ล้านล้านบาท
DecimalPlaces | int | จำนวนหน่วยทศนิยม (มีค่าเริ่มต้นเป็น 2) จะถูกนำไปใช้ก็ต่อเมื่อ Unit มีค่าไม่เท่ากับ `Unit.Baht`
appendBahtOnly | bool | เพิ่มคำว่าถ้วนหรือไม่ (มีค่าเริ่มต้นเป็น true) 
 

### UsesEt.TensOnly
ThaiBahtText(`UsesEt.TensOnly`)
ใช้เอ็ดเฉพาะกับหลักสิบเท่านั้น (เฉพาะสิบเอ็ดถึงเก้าสิบเอ็ด) ถ้าไม่ระบุจะใช้ตัวเลือกนี้เป็นค่าเริ่มต้น

```c#
string s11 = (101M).ThaiBahtText(mode: UsesEt.TensOnly); // หนึ่งร้อย_หนึ่ง_บาทถ้วน
string s12 = (101M).ThaiBahtText();    // หนึ่งร้อยหนึ่งบาทถ้วน

string s13 = (11M).ThaiBahtText();     // สิบเอ็ดบาทถ้วน
string s14 = (211M).ThaiBahtText();    // สองร้อยสิบเอ็ดบาทถ้วน
string s15 = (1001M).ThaiBahtText(UsesEt.TensOnly); // หนึ่งพันหนึ่งบาทถ้วน
string s16 = (1001000000M).ThaiBahtText();          // หนึ่งพันหนึ่งล้านบาทถ้วน
```
    
### UsesEt.Always
ThaiBahtText(`UsesEt.Always`)
ใช้เอ็ดเสมอ สำหรับหลักหน่วยที่มีค่าเป็น 1 รวมถึงหลักล้านที่มีค่าเป็น 1 ด้วย

```c#
string s21 = (101M).ThaiBahtText(mode: UsesEt.Always);  // หนึ่งร้อย_เอ็ด_บาทถ้วน
string s22 = (101M).ThaiBahtText(UsesEt.Always);        // หนึ่งร้อยเอ็ดบาทถ้วน
    
string s23 = (11M).ThaiBahtText(UsesEt.Always);   // สิบเอ็ดบาทถ้วน
string s24 = (211M).ThaiBahtText(UsesEt.Always);  // สองร้อยสิบเอ็ดบาทถ้วน
string s25 = (1001M).ThaiBahtText(UsesEt.Always); // หนึ่งพันเอ็ดบาทถ้วน
string s26 = (1001000000M).ThaiBahtText(UsesEt.Always); // หนึ่งพันเอ็ดล้านบาทถ้วน
```

### หน่วยของจำนวนเงิน
ค่าเริ่มต้นเป็น บาท แต่สามารถเปลี่ยนข้อความผลลัพธ์เป็นหน่วยอื่นได้ เช่น
```C#
var million = new ThaiBahtTextOptions(Unit.Million, appendBahtOnly: false);
var billion = new ThaiBahtTextOptions(Unit.Billion, appendBahtOnly: false);

var s1 = (123456000m).ThaiBahtText(million); // หนึ่งร้อยยี่สิบสามจุดสี่หกล้านบาท
var s2 = (123456000m).ThaiBahtText(billion); // ศูนย์จุดหนึ่งสองพันล้านบาท
```

## ตารางผลลัพธ์
ดูที่ https://github.com/greatfriends/ThaiBahtText/wiki/Sample-Result