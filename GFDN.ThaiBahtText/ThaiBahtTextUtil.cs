using System;
using System.Diagnostics.Contracts;
using System.Text; 

namespace GreatFriends.ThaiBahtText {

  /// <summary>
  /// Original Source Code: 
  /// http://greatfriends.biz/webboards/msg.asp?id=5331 (VB.NET)
  /// http://www.greatfriends.biz/webboards/msg.asp?id=5695 (C#)
  /// </summary>
  [ContractVerification(true)]
  public static class ThaiBahtTextUtil {

    // Largest acceptable values is 999,999,999,999,999,999.99
    public const decimal MaxValue = 999999999999999999.99m;

    // Smallest acceptable values is -999,999,999,999,999,999.99
    public const decimal MinValue = -999999999999999999.99m;

    // This array may looks strange. Let's see example:
    // if value is "512", its length is 3
    //              ^-----so at hundreds' place will uses thaiPlaces[3] that is Roi.
    //               ^----at tens' place will be thaiPlaces[2] that is Sib.
    private static string[] thaiPlaces = new string[] { 
      string.Empty, string.Empty, "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" 
    };

    // Simply the number reading in Thai.
    private static string[] thaiNumbers = new string[] {
      string.Empty, "หนึ่ง", "สอง", "สาม", "สี่", "ห้า",  "หก", "เจ็ด", "แปด", "เก้า" 
    };


    /// <summary>
    /// ให้ข้อความจำนวนเงินภาษาไทย เช่น จำนวน 121.50 บาท จะให้ผลลัพธ์เป็น "หนึ่งร้อยยี่สิบเอ็ดบาทห้าสิบสตางค์"
    /// </summary>
    /// <param name="amount">จำนวนเงิน</param>
    /// <param name="mode">รูปแบบการใช้เอ็ดสำหรับค่าหนึ่งที่หลักหน่วย</param>
    /// <param name="unit">หน่วยของจำนวนเงิน</param>
    /// <param name="appendBahtOnly">เพิ่มคำว่า 'ถ้วน' ท้ายข้อความ</param>
    /// <returns>ข้อความจำนวนเงินภาษาไทย</returns>
    public static string ThaiBahtText(this decimal? amount,
                                      UsesEt mode = UsesEt.TensOnly,
                                      Unit unit = Unit.Baht,
                                      bool appendBahtOnly = true) {
      Contract.Ensures(Contract.Result<string>() != null);
      Contract.Ensures(Contract.Result<string>().Length > 0);

      return ThaiBahtText(amount.HasValue ? amount.Value : 0m);
    }


    /// <summary>
    /// ให้ข้อความจำนวนเงินภาษาไทย เช่น จำนวน 121.50 บาท จะให้ผลลัพธ์เป็น "หนึ่งร้อยยี่สิบเอ็ดบาทห้าสิบสตางค์"
    /// </summary>
    /// <param name="amount">จำนวนเงิน</param>
    /// <param name="mode">รูปแบบการใช้เอ็ดสำหรับค่าหนึ่งที่หลักหน่วย</param>
    /// <param name="unit">หน่วยของจำนวนเงิน</param>
    /// <param name="appendBahtOnly">เพิ่มคำว่า 'ถ้วน' ท้ายข้อความ</param>
    /// <returns>ข้อความจำนวนเงินภาษาไทย</returns>
    public static string ThaiBahtText(this decimal amount, 
                                      UsesEt mode = UsesEt.TensOnly, 
                                      Unit unit = Unit.Baht, 
                                      bool appendBahtOnly = true) {
      Contract.Ensures(Contract.Result<string>() != null);
      Contract.Ensures(Contract.Result<string>().Length > 0);

      if (amount == 0) {
        return "ศูนย์บาทถ้วน";
      }

      var result = new StringBuilder();

      amount = Math.Round(amount, 2, MidpointRounding.AwayFromZero);

      if (amount < MinValue || MaxValue < amount) {
        throw new NotSupportedException();
      }

      if (amount < 0) {
        result.Append("ลบ");
        amount = -amount;
      }

      string[] parts = decompose(amount);

      if (parts[0].Length > 0) {
        speakTo(result, parts[0], mode);
        result.Append("ล้าน");
      } 

      if (parts[1].Length > 0) {
        speakTo(result, parts[1], mode);
        result.Append("ล้าน");
      }
      
      if (parts[2].Length > 0) {
        speakTo(result, parts[2], mode);
        result.Append("บาท");
      }
      else if (parts[1].Length > 0) {
        result.Append("บาท");
      }

      if (parts[3].Length > 0) {
        speakTo(result, parts[3], mode);
        result.Append("สตางค์");
      }
      else {
        result.Append("ถ้วน");
      }

      return result.ToString();
    }


    private static string[] decompose(decimal amount) {
      Contract.Ensures(Contract.Result<string[]>().Length == 4);

      string text;
      string s1 = string.Empty;
      string s2 = string.Empty;  
      string s3;  
      string s4;   
      int position;

      text = amount.ToString("#.00");

      position = text.IndexOf('.');
     
      s3 = text.Substring(0, position);
      s4 = text.Substring(position + 1);
      if (s4 == "00") {
        s4 = string.Empty;
      }   

      int length = s3.Length;
      if (length > 6) {
        s2 = s3.Substring(0, length - 6);
        s3 = s3.Substring(length - 6);
      }
      
      length = s2.Length;
      if (length > 6) {
        s1 = s2.Substring(0, length - 6);
        s2 = s2.Substring(length - 6);
      }

      if ((s3.Length > 0) && (int.Parse(s3) == 0)) {
        s3 = string.Empty;
      }

      return new string[] { s1, s2, s3, s4 };
    }


    private static void speakTo(StringBuilder sb, string text, UsesEt mode) {
      Contract.Requires(text != null);
      Contract.Requires(text.Length > 0);
      
      int length = text.Length; 
      int c = 0;
      int lastc = -1;
      bool negative = false;

      for (int i = 0; i < length; i++) {
        if (text[i] == '-') {
          negative = true;
        }
        else {
          c = int.Parse(text[i].ToString());

          if ((i == length - 1) && (c == 1)) {
            if (length == 1                  //  1
              || (negative && length == 2)   // -1
              || (length == 2 && lastc == 0) // 01 (satang)
              ) {
              sb.Append("หนึ่ง");
              return;
            }
            if (mode == UsesEt.Always) {
              sb.Append("เอ็ด");
            }
            else { // if (mode == UsesEt.TensOnly) {
              if (lastc == 0) {
                sb.Append("หนึ่ง");
              }
              else {
                sb.Append("เอ็ด");
              }
            }
          }
          else if ((i == length - 2) && (c == 2)) {
            sb.Append("ยี่สิบ");
          }
          else if ((i == length - 2) && (c == 1)) {
            sb.Append("สิบ");
          }
          else if (c != 0) {
            sb.Append(thaiNumbers[c] + thaiPlaces[length - i]);
          }
        }
        lastc = c;
      }
    }

  }
}
