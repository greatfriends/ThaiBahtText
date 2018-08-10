using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatFriends.ThaiBahtText {

  /// <summary>
  /// หน่วยของจำนวนเงิน
  /// </summary>
  public enum Unit {

    /// <summary>
    /// จำนวนเงินมีหน่วยเป็น บาท
    /// </summary>
    Baht,
     
    /// <summary>
    /// จำนวนเงินมีหน่วยเป็น ล้านบาท
    /// </summary>
    Million,

    /// <summary>
    /// จำนวนเงินมีหน่วยเป็น พันล้านบาท
    /// </summary>
    Billion,

    /// <summary>
    /// จำนวนเงินมีหน่วยเป็น ล้านล้านบาท
    /// </summary>
    Trillion
  }
}
