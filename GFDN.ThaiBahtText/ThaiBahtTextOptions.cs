using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatFriends.ThaiBahtText {
  public class ThaiBahtTextOptions {

    public UsesEt Mode { get; set; }
    public Unit Unit { get; set; }
    public bool AppendBahtOnly { get; set; }

    public ThaiBahtTextOptions()
      : this(mode: UsesEt.TensOnly,
             unit: ThaiBahtText.Unit.Baht,
             appendBahtOnly: true) {
      //
    }

    public ThaiBahtTextOptions(UsesEt mode, Unit unit, bool appendBahtOnly) {
      this.Mode = mode;
      this.Unit = unit;
      this.AppendBahtOnly = appendBahtOnly;
    }
  }
}

