
namespace GreatFriends.ThaiBahtText {
  /// <summary>
  /// รูปแบบการใช้คำว่า 'เอ็ด' เมื่อมีค่าหนึ่งที่หลักหน่วย
  /// </summary>
  public enum UsesEt { 

    /// <summary>
    /// ใช้เอ็ดกับหลักสิบเท่านั้น (ยี่สิบเอ็ด-เก้าสิบเอ็ด)
    /// </summary>
    TensOnly = 0,

    /// <summary>
    /// ใช้เอ็ดเสมอ (รวมถึงร้อยเอ็ด พันเอ็ด ล้านเอ็ด เป็นต้น)
    /// เป็นรูปแบบที่ราชบัณฑิตยสภาแนะนำ
    /// </summary>
    Always = 1
  }
}
