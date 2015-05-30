using GreatFriends.ThaiBahtText;
using Should;
using System;
using Xunit;

namespace GreatFriends.ThaiBahtTextFacts {

  public class ThaiBahtTextExtensionsFacts {
    
    [Fact]
    public void OneToTen() {
      (1M).ThaiBahtText().ShouldEqual("หนึ่งบาทถ้วน");
      (2M).ThaiBahtText().ShouldEqual("สองบาทถ้วน");
      (3M).ThaiBahtText().ShouldEqual("สามบาทถ้วน");
      (4M).ThaiBahtText().ShouldEqual("สี่บาทถ้วน");
      (5M).ThaiBahtText().ShouldEqual("ห้าบาทถ้วน");
      (6M).ThaiBahtText().ShouldEqual("หกบาทถ้วน");
      (7M).ThaiBahtText().ShouldEqual("เจ็ดบาทถ้วน");
      (8M).ThaiBahtText().ShouldEqual("แปดบาทถ้วน");
      (9M).ThaiBahtText().ShouldEqual("เก้าบาทถ้วน");
      (10M).ThaiBahtText().ShouldEqual("สิบบาทถ้วน");
    }

    [Fact]
    public void NullIsZero() {
      decimal? price = null;
      price.ThaiBahtText().ShouldEqual("ศูนย์บาทถ้วน");
    }

    [Fact]
    public void Zero() {
      (0M).ThaiBahtText().ShouldEqual("ศูนย์บาทถ้วน");
    }

    [Fact]
    public void AbsolutelyEt() {
      (11M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("สิบเอ็ดบาทถ้วน");
      (21M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("ยี่สิบเอ็ดบาทถ้วน");
      (31M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("สามสิบเอ็ดบาทถ้วน");
      (41M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("สี่สิบเอ็ดบาทถ้วน");
      (51M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("ห้าสิบเอ็ดบาทถ้วน");
      (61M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("หกสิบเอ็ดบาทถ้วน");
      (71M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("เจ็ดสิบเอ็ดบาทถ้วน");
      (81M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("แปดสิบเอ็ดบาทถ้วน");
      (91M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("เก้าสิบเอ็ดบาทถ้วน");

      (11M).ThaiBahtText(UsesEt.Always).ShouldEqual("สิบเอ็ดบาทถ้วน");
      (21M).ThaiBahtText(UsesEt.Always).ShouldEqual("ยี่สิบเอ็ดบาทถ้วน");
      (31M).ThaiBahtText(UsesEt.Always).ShouldEqual("สามสิบเอ็ดบาทถ้วน");
      (41M).ThaiBahtText(UsesEt.Always).ShouldEqual("สี่สิบเอ็ดบาทถ้วน");
      (51M).ThaiBahtText(UsesEt.Always).ShouldEqual("ห้าสิบเอ็ดบาทถ้วน");
      (61M).ThaiBahtText(UsesEt.Always).ShouldEqual("หกสิบเอ็ดบาทถ้วน");
      (71M).ThaiBahtText(UsesEt.Always).ShouldEqual("เจ็ดสิบเอ็ดบาทถ้วน");
      (81M).ThaiBahtText(UsesEt.Always).ShouldEqual("แปดสิบเอ็ดบาทถ้วน");
      (91M).ThaiBahtText(UsesEt.Always).ShouldEqual("เก้าสิบเอ็ดบาทถ้วน");
    }

    [Fact]
    public void SomeBigNumbers() {
      (12345M).ThaiBahtText()
        .ShouldEqual("หนึ่งหมื่นสองพันสามร้อยสี่สิบห้าบาทถ้วน");
      (12345678M).ThaiBahtText()
        .ShouldEqual("สิบสองล้านสามแสนสี่หมื่นห้าพันหกร้อยเจ็ดสิบแปดบาทถ้วน");
      (675001333111M).ThaiBahtText()
        .ShouldEqual("หกแสนเจ็ดหมื่นห้าพันหนึ่งล้านสามแสนสามหมื่นสามพันหนึ่งร้อยสิบเอ็ดบาทถ้วน");
    }

    [Fact]
    public void Satangs() {
      (0.05M).ThaiBahtText().ShouldEqual("ห้าสตางค์");
      (0.10M).ThaiBahtText().ShouldEqual("สิบสตางค์");
      (0.25M).ThaiBahtText().ShouldEqual("ยี่สิบห้าสตางค์");
      (0.50M).ThaiBahtText().ShouldEqual("ห้าสิบสตางค์");
      (0.75M).ThaiBahtText().ShouldEqual("เจ็ดสิบห้าสตางค์");
    }

    [Fact]
    public void BahtAndSatangs() {
      (11.90M).ThaiBahtText().ShouldEqual("สิบเอ็ดบาทเก้าสิบสตางค์");
      (560.83M).ThaiBahtText().ShouldEqual("ห้าร้อยหกสิบบาทแปดสิบสามสตางค์");
    }

    [Fact]
    public void NegativeAmounts() {
      (-1M).ThaiBahtText().ShouldEqual("ลบหนึ่งบาทถ้วน");
      (-11M).ThaiBahtText().ShouldEqual("ลบสิบเอ็ดบาทถ้วน");
      (-550.25M).ThaiBahtText().ShouldEqual("ลบห้าร้อยห้าสิบบาทยี่สิบห้าสตางค์");
    }

    [Fact]
    public void SatangUsesTwoDecimalPlacesAndUsesAwayFromZeroRounding() {
      (0.0550M).ThaiBahtText().ShouldEqual("หกสตางค์");
      (0.0650M).ThaiBahtText().ShouldEqual("เจ็ดสตางค์");
      (0.0750M).ThaiBahtText().ShouldEqual("แปดสตางค์");
      (0.0710M).ThaiBahtText().ShouldEqual("เจ็ดสตางค์");
      (0.0790M).ThaiBahtText().ShouldEqual("แปดสตางค์");
      (0.9950M).ThaiBahtText().ShouldEqual("หนึ่งบาทถ้วน");
      (1.9980M).ThaiBahtText().ShouldEqual("สองบาทถ้วน");
    }

    [Fact]
    public void TwoDecimalPlacesOnly_Negatives() {
      Assert.Equal("ลบหกสตางค์", ThaiBahtTextUtil.ThaiBahtText(-0.0550m));
      Assert.Equal("ลบเจ็ดสตางค์", ThaiBahtTextUtil.ThaiBahtText(-0.0650m));
      Assert.Equal("ลบแปดสตางค์", ThaiBahtTextUtil.ThaiBahtText(-0.0750m));
      Assert.Equal("ลบเจ็ดสตางค์", ThaiBahtTextUtil.ThaiBahtText(-0.0710m));
      Assert.Equal("ลบแปดสตางค์", ThaiBahtTextUtil.ThaiBahtText(-0.0790m));
      Assert.Equal("ลบหนึ่งบาทถ้วน", (-0.995m).ThaiBahtText());
      Assert.Equal("ลบสองบาทถ้วน", (-1.998m).ThaiBahtText());

      Assert.Equal("ลบหนึ่งสตางค์", (-0.009m).ThaiBahtText());
    }

    [Fact]
    public void ExtremeValues() {
      Assert.Throws<NotSupportedException>(() => {
        var s = ThaiBahtTextUtil.ThaiBahtText(5000000000000000000m);
      }); 
    }

    [Fact]
    public void ExtremeValues_Negatives() {
      Assert.Throws<NotSupportedException>(() => {
        var s = ThaiBahtTextUtil.ThaiBahtText(-5000000000000000000m);
      });
    }

    [Fact]
    public void ExtensionMethodUsage() {
      decimal price = 11.50m;
      decimal? total = null;

      Assert.Equal("สิบเอ็ดบาทห้าสิบสตางค์", price.ThaiBahtText());
      Assert.Equal("ศูนย์บาทถ้วน", total.ThaiBahtText());
      Assert.Equal("สิบเอ็ดบาทห้าสิบสตางค์", ThaiBahtTextUtil.ThaiBahtText(price));
    }

    [Fact]
    public void MinAndMaxValues() {
      Assert.Equal("เก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าล้านเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าล้านเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าบาทเก้าสิบเก้าสตางค์", 
        ThaiBahtTextUtil.MaxValue.ThaiBahtText());
      Assert.Equal("ลบเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าล้านเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าล้านเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าบาทเก้าสิบเก้าสตางค์", 
        ThaiBahtTextUtil.MinValue.ThaiBahtText());
    }

    [Fact]
    public void UsesEt_TensOnly() {
      Assert.Equal("สิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(11, UsesEt.TensOnly));
      Assert.Equal("ยี่สิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(21, UsesEt.TensOnly));
      Assert.Equal("สามสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(31, UsesEt.TensOnly));
      Assert.Equal("เก้าสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(91, UsesEt.TensOnly));
      Assert.Equal("หนึ่งร้อยหนึ่งบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(101, UsesEt.TensOnly));
      Assert.Equal("หนึ่งร้อยสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(111, UsesEt.TensOnly));
      Assert.Equal("สองร้อยหนึ่งบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(201, UsesEt.TensOnly));
      Assert.Equal("ห้าพันหนึ่งบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(5001, UsesEt.TensOnly));
    }


    [Fact]
    public void UsesEt_Always() {
      Assert.Equal("สิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(11, UsesEt.Always));
      Assert.Equal("ยี่สิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(21, UsesEt.Always));
      Assert.Equal("สามสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(31, UsesEt.Always));
      Assert.Equal("เก้าสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(91, UsesEt.Always));
      Assert.Equal("หนึ่งร้อยเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(101, UsesEt.Always));
      Assert.Equal("หนึ่งร้อยสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(111, UsesEt.Always));
      Assert.Equal("สองร้อยเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(201, UsesEt.Always));
      Assert.Equal("ห้าพันเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(5001, UsesEt.Always));
    }

    [Fact]
    public void DefaultIsUseEt_TensOnly() {
      (0101M).ThaiBahtText().ShouldEqual("หนึ่งร้อยหนึ่งบาทถ้วน");
      (1001M).ThaiBahtText().ShouldEqual("หนึ่งพันหนึ่งบาทถ้วน");
    }

    [Fact]
    public void JustMillionPart() {
      (5001000000M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("ห้าพันหนึ่งล้านบาทถ้วน");
      (5001000000M).ThaiBahtText(UsesEt.Always).ShouldEqual("ห้าพันเอ็ดล้านบาทถ้วน");
    }

    [Fact]
    public void JustMillionAndSatangParts() {
      (5001000000.11M).ThaiBahtText(UsesEt.TensOnly).ShouldEqual("ห้าพันหนึ่งล้านบาทสิบเอ็ดสตางค์");
      (5001000000.11M).ThaiBahtText(UsesEt.Always).ShouldEqual("ห้าพันเอ็ดล้านบาทสิบเอ็ดสตางค์");
    }
 
    [Fact]
    public void BUG_Issue19_OneStangWithEtAlways_ShouldNotGiven_EtSatang() {
      (0.01M).ThaiBahtText(UsesEt.Always).ShouldEqual("หนึ่งสตางค์");
      (0.01M).ThaiBahtText(UsesEt.Always).ShouldNotEqual("เอ็ดสตางค์");
    }

    [Fact]
    public void MillionMillion_Part0() {
      (25000000000000m).ThaiBahtText().ShouldEqual("ยี่สิบห้าล้านล้านบาทถ้วน");
    }

    [Fact]
    public void MillionMillion_AllParts() {
      (25005100000500.25m).ThaiBahtText().ShouldEqual("ยี่สิบห้าล้านห้าพันหนึ่งร้อยล้านห้าร้อยบาทยี่สิบห้าสตางค์");
    }

    [Fact]
    public void MillionMillion_Part0And1() {
      (2525000000000.00m).ThaiBahtText().ShouldEqual("สองล้านห้าแสนสองหมื่นห้าพันล้านบาทถ้วน");
      (25005100000000.00m).ThaiBahtText().ShouldEqual("ยี่สิบห้าล้านห้าพันหนึ่งร้อยล้านบาทถ้วน");
    }


    [Fact]
    public void MillionMillion_Part0And2() {
      (25000000000111.00m).ThaiBahtText().ShouldEqual("ยี่สิบห้าล้านล้านหนึ่งร้อยสิบเอ็ดบาทถ้วน");
      (-25000000000111.00m).ThaiBahtText().ShouldEqual("ลบยี่สิบห้าล้านล้านหนึ่งร้อยสิบเอ็ดบาทถ้วน");
    }

    [Fact]
    public void MillionMillion_Part0And3() {
      (25000000000000.89m).ThaiBahtText().ShouldEqual("ยี่สิบห้าล้านล้านบาทแปดสิบเก้าสตางค์");
      (-25000000000000.89m).ThaiBahtText().ShouldEqual("ลบยี่สิบห้าล้านล้านบาทแปดสิบเก้าสตางค์");
    }

  }
}
