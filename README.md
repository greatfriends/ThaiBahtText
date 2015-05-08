# ThaiBahtText
ให้ข้อความจำนวนเงินภาษาไทย เช่น จำนวน 121.50 บาท จะให้ผลลัพธ์เป็น "หนึ่งร้อยยี่สิบเอ็ดบาทห้าสิบสตางค์"


## เริ่มต้นใช้งาน
```c#
using GreatFriends.ThaiBahtText;

...
decimal amount = 121.50m;
string  s = amount.ThaiBahtText(); // "หนึ่งร้อยยี่สิบเอ็ดบาทห้าสิบสตางค์"
```


## การติดตั้งและอับเดตเวอร์ชั่นล่าสุด

ติดตั้งผ่าน NuGet (พิมพ์ในวินโดว์ Package Manager Console)

```
PM> Install-Package ThaiBahtText
```	

การอับเดตให้เป็นเวอร์ชั่นล่าสุด

```
PM> Update-Package ThaiBahtText
```

การถอนการติดตั้งออก

```
PM> Uninstall-Package ThaiBahtText
```


## ตัวเลือก
เนื่องจากยังไม่สามารถหาข้อสรุปเกี่ยวกับการใช้คำว่า "เอ็ด" ได้ว่า หลักการที่ถูกต้องมีเพียงแบบเดียวหรือไม่
(จะดำเนินการสอบถามไปยังราชบัณฑิตต่อไป) จึงให้สามารถเลือกใช้ได้ตามต้องการ 2 รูปแบบต่อไปนี้
โดยส่งค่า enum `UsesEt` ให้กับพารามิเตอร์ `mode` ของเมธอด `ThaiBahtText`

### UsesEt.TensOnly
ThaiBahtText(`UsesEt.TensOnly`)
ใช้เอ็ดเฉพาะกับหลักสิบเท่านั้น (เฉพาะสิบเอ็ดถึงเก้าสิบเอ็ด) ถ้าไม่ระบุจะใช้ตัวเลือกนี้เป็นค่าเริ่มต้น

```c#
string s11 = (101m).ThaiBahtText(mode: UsesEt.TensOnly); // หนึ่งร้อย_หนึ่ง_บาทถ้วน
string s12 = (101m).ThaiBahtText();    // หนึ่งร้อยหนึ่งบาทถ้วน

string s13 = (11m).ThaiBahtText();     // สิบเอ็ดบาทถ้วน
string s14 = (211m).ThaiBahtText();    // สองร้อยสิบเอ็ดบาทถ้วน
string s15 = (1001m).ThaiBahtText(UsesEt.TensOnly); // หนึ่งพันหนึ่งบาทถ้วน
string s16 = (1001000000m).ThaiBahtText();          // หนึ่งพันหนึ่งล้านบาทถ้วน
```
    
### UsesEt.Always
ThaiBahtText(`UsesEt.Always`)
ใช้เอ็ดเสมอ สำหรับหลักหน่วยที่มีค่าเป็น 1 รวมถึงหลักล้านที่มีค่าเป็น 1 ด้วย

```c#
string s21 = (101m).ThaiBahtText(mode: UsesEt.Always);  // หนึ่งร้อย_เอ็ด_บาทถ้วน
string s22 = (101m).ThaiBahtText(UsesEt.Always);        // หนึ่งร้อยเอ็ดบาทถ้วน
    
string s23 = (11m).ThaiBahtText(UsesEt.Always);   // สิบเอ็ดบาทถ้วน
string s24 = (211m).ThaiBahtText(UsesEt.Always);  // สองร้อยสิบเอ็ดบาทถ้วน
string s25 = (1001m).ThaiBahtText(UsesEt.Always); // หนึ่งพันเอ็ดบาทถ้วน
string s26 = (1001000000m).ThaiBahtText(UsesEt.Always); // หนึ่งพันเอ็ดล้านบาทถ้วน
```

## ตารางผลลัพธ์
ดูที่ https://github.com/greatfriends/ThaiBahtText/wiki/Sample-Result