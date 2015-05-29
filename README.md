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
เนื่องจากยังไม่สามารถหาข้อสรุปเกี่ยวกับการใช้คำว่า "เอ็ด" ได้ว่า หลักการที่ถูกต้องมีเพียงแบบเดียวหรือไม่
(จะดำเนินการสอบถามไปยังราชบัณฑิตต่อไป) จึงให้สามารถเลือกใช้ได้ตามต้องการ 2 รูปแบบต่อไปนี้
โดยส่งค่า enum `UsesEt` ให้กับพารามิเตอร์ `mode` ของเมธอด `ThaiBahtText`

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

## ตารางผลลัพธ์
ดูที่ https://github.com/greatfriends/ThaiBahtText/wiki/Sample-Result