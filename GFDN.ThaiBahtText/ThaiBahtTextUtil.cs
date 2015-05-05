using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFDN.ThaiBahtText {

  /// <summary>
  /// Original Source Code: 
  /// http://greatfriends.biz/webboards/msg.asp?id=5331 (VB.NET)
  /// http://www.greatfriends.biz/webboards/msg.asp?id=5695 (C#)
  /// </summary>
  public static class ThaiBahtTextUtil {

    private static readonly string[] suffix = { "", "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
    private static readonly string[] numSpeak = { "", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };

    /// <summary>
    /// ให้ข้อความจำนวนเงินภาษาไทย
    /// </summary>
    /// <param name="amount">จำนวนเงิน</param>
    /// <returns>ข้อความจำนวนเงินภาษาไทย</returns>
    public static string ThaiBahtText(this decimal? amount) {

      if (amount == null || amount == 0) {
        return "ศูนย์บาทถ้วน";
      }

      var result = new StringBuilder();
      decimal amt;

      amt = Math.Round(amount.Value, 2, MidpointRounding.AwayFromZero);

      if (amt >= 1000000000000) {
        throw new NotSupportedException();
      }
      if (amt <= -1000000000000) {
        throw new NotSupportedException();
      }

      if (amt < 0) {
        result.Append("ลบ");
        amt = Math.Abs(amt);
      }

      var parts = splitCurr(amt);

      if (parts[0].Length > 0) {
        result.Append(Speak(parts[0]));
        result.Append("ล้าน");
      }
      if (parts[1].Length > 0) {
        result.Append(Speak(parts[1]));
        result.Append("บาท");
      }
      if (parts[2].Length > 0) {
        result.Append(Speak(parts[2]));
        result.Append("สตางค์");
      }
      else {
        result.Append("ถ้วน");
      }
      return result.ToString();
    }

    private static string[] splitCurr(decimal m) {
      string s1, s2, s3;
      string s;
      int L;
      int position;

      s = m.ToString("0.00"); // System.Convert.ToString(m);
      position = s.IndexOf(".");
      if ((position >= 0)) {
        s1 = s.Substring(0, position);
        s3 = s.Substring(position + 1);
        if (s3 == "00") {
          s3 = "";
        }
      }
      else {
        s1 = s;
        s3 = "";
      }
      L = s1.Length;
      if ((L > 6)) {
        s2 = s1.Substring(L - 6);
        s1 = s1.Substring(0, L - 6);
      }
      else {
        s2 = s1;
        s1 = "";
      }

      if ((s1 != "") && (Convert.ToInt32(s1) == 0)) s1 = "";
      if ((s2 != "") && (Convert.ToInt32(s2) == 0)) s2 = "";

      return new string[] { s1, s2, s3 };
    }

    private static string Speak(string s) {
      int L, c;
      string result;

      if (s == "") return ("");

      result = "";
      L = s.Length;

      bool negative = false;

      for (int i = 0; i < L; i++) {
        if ((s.Substring(i, 1) == "-")) {
          negative = true; 
        }
        else {
          c = System.Convert.ToInt32(s.Substring(i, 1));
          if ((i == L - 1) && (c == 1)) {
            if (L == 1 || (negative && L == 2)) {
              result = result + "หนึ่ง";
              return result;
            }
            result = result + "เอ็ด";
          }
          else if ((i == L - 2) && (c == 2)) {
            result = result + "ยี่สิบ";
          }
          else if ((i == L - 2) && (c == 1)) {
            result = result + "สิบ";
          }
          else {
            if (c != 0) {
              result = result + numSpeak[c] + suffix[L - i];
            }
          }
        }
      }
      return (result);
    }

  }
}
