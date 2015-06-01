using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreatFriends.ThaiBahtText {
  public class ThaiBahtTextOptions {

    public UsesEt UsesEt { get; set; }
    public Unit Unit { get; set; }
    public bool AppendBahtOnly { get; set; }
    public int DecimalPlaces { get; set; }

    public ThaiBahtTextOptions()
      : this(usesEt: UsesEt.TensOnly,
             unit: Unit.Baht,
             decimalPlaces: 2,
             appendBahtOnly: true) {
      //
    }

    public ThaiBahtTextOptions(UsesEt usesEt = UsesEt.TensOnly,
                               Unit unit = Unit.Baht,
                               int decimalPlaces = 2,
                               bool appendBahtOnly = true) {
      this.UsesEt = usesEt;
      this.Unit = unit;
      this.AppendBahtOnly = appendBahtOnly;
    }
  }
}

