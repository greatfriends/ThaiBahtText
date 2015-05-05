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

    /// <summary>
    /// ให้ข้อความจำนวนเงินภาษาไทย
    /// </summary>
    /// <param name="amount">จำนวนเงิน</param>
    /// <returns>ข้อความจำนวนเงินภาษาไทย</returns>
    public static string ThaiBahtText(this decimal? amount) {
      string result;

      if (amount == null || amount == 0) return ("ศูนย์บาทถ้วน");

      splitCurr(amount.Value);
      result = "";
      if (s1.Length > 0) {
        result = result + Speak(s1) + "ล้าน";
      }
      if (s2.Length > 0) {
        result = result + Speak(s2) + "บาท";
      }
      if (s3.Length > 0) {
        result = result + speakStang(s3) + "สตางค์";
      }
      else {
        result = result + "ถ้วน";
      }
      return (result);
    }

    private static string s1 = "";
    private static string s2 = "";
    private static string s3 = "";
    private static string[] suffix = { "", "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };
    private static string[] numSpeak = { "", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า" };



    private static void splitCurr(decimal m) {
      string s;
      int L;
      int position;

      s = System.Convert.ToString(m);
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
          result = result + "ลบ";
        }
        else {
          c = System.Convert.ToInt32(s.Substring(i, 1));
          if ((i == L - 1) && (c == 1)) {
            if (L == 1 || (negative && L == 2)) {
              result = result + "หนึ่ง";
              return result;
            }
            if ((L > 1) && (s.Substring(L - 1 - 1, 1) == "0")) {
              result = result + "หนึ่ง";
            }
            else {
              result = result + "เอ็ด";
            }
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

    private static string speakStang(string s) {
      int L, c;
      string result;

      L = s.Length;

      if (L == 0) return ("");

      if (L == 1) {
        s = s + "0";
        L = 2;
      }
      if (L > 2) {
        s = s.Substring(0, 2);
        L = 2;
      }
      result = "";
      for (int i = 0; i < 2; i++) {
        c = Convert.ToInt32(s.Substring(i, 1));
        if ((i == L - 1) && (c == 1)) {
          if (Convert.ToInt32(s.Substring(0, 1)) == 0)
            result = result + "หนึ่ง";
          else
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

      return (result);
    }


  }
}
