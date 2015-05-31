using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatFriends.ThaiBahtText {
  public class ThaiBahtTextOptions {

    public UsesEt Mode { get; set; }
    public Unit Unit { get; set; }
    public bool AppendBahtOnly { get; set; }

    public ThaiBahtTextOptions() {
      this.Mode = UsesEt.TensOnly;
      this.Unit = ThaiBahtText.Unit.Baht;
      this.AppendBahtOnly = true;
    }
  }
}

