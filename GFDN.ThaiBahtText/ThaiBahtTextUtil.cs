using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreatFriends.ThaiBahtText {

  /// <summary>
  /// Original Source Code: 
  /// http://greatfriends.biz/webboards/msg.asp?id=5331 (VB.NET)
  /// http://www.greatfriends.biz/webboards/msg.asp?id=5695 (C#)
  /// </summary>
  public static class ThaiBahtTextUtil {

    public static decimal MaxValue = 999999999999.99m;
    public static decimal MinValue = -999999999999.99m;

    private static readonly string[] rankThai = { "", "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
    private static readonly string[] digitThai = { "", "หนึ่ง", "สอง", "สาม", "สี่", 
                                                   "ห้า",  "หก", "เจ็ด", "แปด", "เก้า" };


    /// <summary>
    /// ให้ข้อความจำนวนเงินภาษาไทย
    /// </summary>
    /// <param name="amount">จำนวนเงิน</param>
    /// <returns>ข้อความจำนวนเงินภาษาไทย</returns>
    public static string ThaiBahtText(this decimal? amount, UsesEt mode = UsesEt.TensOnly) {
      if (amount == null) {
        return ThaiBahtText(0m);
      }
      else {
        return ThaiBahtText(amount.Value);
      }
    }


    /// <summary>
    /// ให้ข้อความจำนวนเงินภาษาไทย
    /// </summary>
    /// <param name="amount">จำนวนเงิน</param>
    /// <returns>ข้อความจำนวนเงินภาษาไทย</returns>
    public static string ThaiBahtText(this decimal amount, UsesEt mode = UsesEt.TensOnly) {

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

      var parts = decompose(amount);

      if (parts[0].Length > 0) {
        result.Append(speak(parts[0], mode));
        result.Append("ล้าน");
      }
      if (parts[1].Length > 0) {
        result.Append(speak(parts[1], mode));
        result.Append("บาท");
      }
      else {
        if (parts[0].Length > 0) {
          result.Append("บาท");
        }
      }
      if (parts[2].Length > 0) {
        result.Append(speak(parts[2], mode));
        result.Append("สตางค์");
      }
      else {
        result.Append("ถ้วน");
      }

      return result.ToString();
    }


    private static string[] decompose(decimal amount) {
      string text;
      string s1;
      string s2;
      string s3;
      int position;

      text = amount.ToString("0.00");

      position = text.IndexOf('.');
      if (position >= 0) {
        s1 = text.Substring(0, position);
        s3 = text.Substring(position + 1);
        if (s3 == "00") {
          s3 = string.Empty;
        }
      }
      else {
        s1 = text;
        s3 = string.Empty;
      }

      int length = s1.Length;
      if (length > 6) {
        s2 = s1.Substring(length - 6);
        s1 = s1.Substring(0, length - 6);
      }
      else {
        s2 = s1;
        s1 = string.Empty;
      }

      if ((s1.Length > 0) && (int.Parse(s1) == 0)) s1 = string.Empty;
      if ((s2.Length > 0) && (int.Parse(s2) == 0)) s2 = string.Empty;

      return new string[] { s1, s2, s3 };
    }


    private static string speak(string text, UsesEt mode) {

      if (string.IsNullOrWhiteSpace(text)) return string.Empty;

      int length = text.Length;
      string result = string.Empty;
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
              result += "หนึ่ง";
              return result;
            }
            if (mode == UsesEt.Always) {
              result += "เอ็ด";
            }
            else if (mode == UsesEt.TensOnly) {
              if (lastc == 0) {
                result += "หนึ่ง";
              }
              else {
                result += "เอ็ด";
              }
            }
          }
          else if ((i == length - 2) && (c == 2)) {
            result += "ยี่สิบ";
          }
          else if ((i == length - 2) && (c == 1)) {
            result += "สิบ";
          }
          else if (c != 0) {
            result += digitThai[c] + rankThai[length - i];
          }
        }
        lastc = c;
      }

      return result;
    }

  }
}
