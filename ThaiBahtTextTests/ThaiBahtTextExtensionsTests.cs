using ThaiBahtText;
using System;
using Xunit;

namespace ThaiBahtTextTests
{
  public class ThaiBahtTextExtensionsTests
  {
    [Fact]
    public void OneToTen()
    {
      Assert.Equal((1M).ThaiBahtText(), "หนึ่งบาทถ้วน");
      Assert.Equal((2M).ThaiBahtText(), "สองบาทถ้วน");
      Assert.Equal((3M).ThaiBahtText(), "สามบาทถ้วน");
      Assert.Equal((4M).ThaiBahtText(), "สี่บาทถ้วน");
      Assert.Equal((5M).ThaiBahtText(), "ห้าบาทถ้วน");
      Assert.Equal((6M).ThaiBahtText(), "หกบาทถ้วน");
      Assert.Equal((7M).ThaiBahtText(), "เจ็ดบาทถ้วน");
      Assert.Equal((8M).ThaiBahtText(), "แปดบาทถ้วน");
      Assert.Equal((9M).ThaiBahtText(), "เก้าบาทถ้วน");
      Assert.Equal((10M).ThaiBahtText(), "สิบบาทถ้วน");
    }

    [Fact]
    public void NullIsZero()
    {
      decimal? price = null;
      Assert.Equal(price.ThaiBahtText(), "ศูนย์บาทถ้วน");
    }

    [Fact]
    public void Zero()
    {
      Assert.Equal((0M).ThaiBahtText(), "ศูนย์บาทถ้วน");
    }

    [Fact]
    public void AbsolutelyEt()
    {
      Assert.Equal((11M).ThaiBahtText(UsesEt.TensOnly), "สิบเอ็ดบาทถ้วน");
      Assert.Equal((21M).ThaiBahtText(UsesEt.TensOnly), "ยี่สิบเอ็ดบาทถ้วน");
      Assert.Equal((31M).ThaiBahtText(UsesEt.TensOnly), "สามสิบเอ็ดบาทถ้วน");
      Assert.Equal((41M).ThaiBahtText(UsesEt.TensOnly), "สี่สิบเอ็ดบาทถ้วน");
      Assert.Equal((51M).ThaiBahtText(UsesEt.TensOnly), "ห้าสิบเอ็ดบาทถ้วน");
      Assert.Equal((61M).ThaiBahtText(UsesEt.TensOnly), "หกสิบเอ็ดบาทถ้วน");
      Assert.Equal((71M).ThaiBahtText(UsesEt.TensOnly), "เจ็ดสิบเอ็ดบาทถ้วน");
      Assert.Equal((81M).ThaiBahtText(UsesEt.TensOnly), "แปดสิบเอ็ดบาทถ้วน");
      Assert.Equal((91M).ThaiBahtText(UsesEt.TensOnly), "เก้าสิบเอ็ดบาทถ้วน");

      Assert.Equal((11M).ThaiBahtText(UsesEt.Always), "สิบเอ็ดบาทถ้วน");
      Assert.Equal((21M).ThaiBahtText(UsesEt.Always), "ยี่สิบเอ็ดบาทถ้วน");
      Assert.Equal((31M).ThaiBahtText(UsesEt.Always), "สามสิบเอ็ดบาทถ้วน");
      Assert.Equal((41M).ThaiBahtText(UsesEt.Always), "สี่สิบเอ็ดบาทถ้วน");
      Assert.Equal((51M).ThaiBahtText(UsesEt.Always), "ห้าสิบเอ็ดบาทถ้วน");
      Assert.Equal((61M).ThaiBahtText(UsesEt.Always), "หกสิบเอ็ดบาทถ้วน");
      Assert.Equal((71M).ThaiBahtText(UsesEt.Always), "เจ็ดสิบเอ็ดบาทถ้วน");
      Assert.Equal((81M).ThaiBahtText(UsesEt.Always), "แปดสิบเอ็ดบาทถ้วน");
      Assert.Equal((91M).ThaiBahtText(UsesEt.Always), "เก้าสิบเอ็ดบาทถ้วน");
    }

    [Fact]
    public void SomeBigNumbers()
    {
      Assert.Equal((12345M).ThaiBahtText(), "หนึ่งหมื่นสองพันสามร้อยสี่สิบห้าบาทถ้วน");
      Assert.Equal((12345678M).ThaiBahtText(), "สิบสองล้านสามแสนสี่หมื่นห้าพันหกร้อยเจ็ดสิบแปดบาทถ้วน");
      Assert.Equal((675001333111M).ThaiBahtText(), "หกแสนเจ็ดหมื่นห้าพันเอ็ดล้านสามแสนสามหมื่นสามพันหนึ่งร้อยสิบเอ็ดบาทถ้วน");
    }

    [Fact]
    public void Satangs()
    {
      Assert.Equal((0.05M).ThaiBahtText(), "ห้าสตางค์");
      Assert.Equal((0.10M).ThaiBahtText(), "สิบสตางค์");
      Assert.Equal((0.25M).ThaiBahtText(), "ยี่สิบห้าสตางค์");
      Assert.Equal((0.50M).ThaiBahtText(), "ห้าสิบสตางค์");
      Assert.Equal((0.75M).ThaiBahtText(), "เจ็ดสิบห้าสตางค์");
    }

    [Fact]
    public void BahtAndSatangs()
    {
      Assert.Equal((11.90M).ThaiBahtText(), "สิบเอ็ดบาทเก้าสิบสตางค์");
      Assert.Equal((560.83M).ThaiBahtText(), "ห้าร้อยหกสิบบาทแปดสิบสามสตางค์");
    }

    [Fact]
    public void NegativeAmounts()
    {
      Assert.Equal((-1M).ThaiBahtText(), "ลบหนึ่งบาทถ้วน");
      Assert.Equal((-11M).ThaiBahtText(), "ลบสิบเอ็ดบาทถ้วน");
      Assert.Equal((-550.25M).ThaiBahtText(), "ลบห้าร้อยห้าสิบบาทยี่สิบห้าสตางค์");
    }

    [Fact]
    public void SatangUsesTwoDecimalPlacesAndUsesAwayFromZeroRounding()
    {
      Assert.Equal((0.0550M).ThaiBahtText(), "หกสตางค์");
      Assert.Equal((0.0650M).ThaiBahtText(), "เจ็ดสตางค์");
      Assert.Equal((0.0750M).ThaiBahtText(), "แปดสตางค์");
      Assert.Equal((0.0710M).ThaiBahtText(), "เจ็ดสตางค์");
      Assert.Equal((0.0790M).ThaiBahtText(), "แปดสตางค์");
      Assert.Equal((0.9950M).ThaiBahtText(), "หนึ่งบาทถ้วน");
      Assert.Equal((1.9980M).ThaiBahtText(), "สองบาทถ้วน");
    }

    [Fact]
    public void TwoDecimalPlacesOnly_Negatives()
    {
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
    public void ExtremeValues()
    {
      Assert.Throws<NotSupportedException>(() =>
      {
        var s = ThaiBahtTextUtil.ThaiBahtText(5000000000000000000m);
      });
    }

    [Fact]
    public void ExtremeValues_Negatives()
    {
      Assert.Throws<NotSupportedException>(() =>
      {
        var s = ThaiBahtTextUtil.ThaiBahtText(-5000000000000000000m);
      });
    }

    [Fact]
    public void ExtensionMethodUsage()
    {
      decimal price = 11.50m;
      decimal? total = null;

      Assert.Equal("สิบเอ็ดบาทห้าสิบสตางค์", price.ThaiBahtText());
      Assert.Equal("ศูนย์บาทถ้วน", total.ThaiBahtText());
      Assert.Equal("สิบเอ็ดบาทห้าสิบสตางค์", ThaiBahtTextUtil.ThaiBahtText(price));
    }

    [Fact]
    public void MinAndMaxValues()
    {
      Assert.Equal("เก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าล้านเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าล้านเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าบาทเก้าสิบเก้าสตางค์",
        ThaiBahtTextUtil.MaxValue.ThaiBahtText());
      Assert.Equal("ลบเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าล้านเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าล้านเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าบาทเก้าสิบเก้าสตางค์",
        ThaiBahtTextUtil.MinValue.ThaiBahtText());
    }

    [Fact]
    public void UsesEt_TensOnly()
    {
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
    public void UsesEt_Always()
    {
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
    public void JustMillionPart()
    {
      Assert.Equal((5001000000M).ThaiBahtText(UsesEt.TensOnly), "ห้าพันหนึ่งล้านบาทถ้วน");
      Assert.Equal((5001000000M).ThaiBahtText(UsesEt.Always), "ห้าพันเอ็ดล้านบาทถ้วน");
    }

    [Fact]
    public void JustMillionAndSatangParts()
    {
      Assert.Equal((5001000000.11M).ThaiBahtText(UsesEt.TensOnly), "ห้าพันหนึ่งล้านบาทสิบเอ็ดสตางค์");
      Assert.Equal((5001000000.11M).ThaiBahtText(UsesEt.Always), "ห้าพันเอ็ดล้านบาทสิบเอ็ดสตางค์");
    }

    [Fact]
    public void BUG_Issue19_OneStangWithEtAlways_ShouldNotGiven_EtSatang()
    {
      Assert.Equal((0.01M).ThaiBahtText(UsesEt.Always), "หนึ่งสตางค์");
      Assert.NotEqual((0.01M).ThaiBahtText(UsesEt.Always), "เอ็ดสตางค์");
    }

    [Fact]
    public void MillionMillion_TrillionOnly()
    {
      Assert.Equal((25000000000000m).ThaiBahtText(), "ยี่สิบห้าล้านล้านบาทถ้วน");
    }

    [Fact]
    public void MillionMillion_AllParts()
    {
      Assert.Equal((25005100000500.25m).ThaiBahtText(), "ยี่สิบห้าล้านห้าพันหนึ่งร้อยล้านห้าร้อยบาทยี่สิบห้าสตางค์");
    }

    [Fact]
    public void MillionMillion_TrillionAndMillion()
    {
      Assert.Equal((2525000000000.00m).ThaiBahtText(), "สองล้านห้าแสนสองหมื่นห้าพันล้านบาทถ้วน");
      Assert.Equal((25005100000000.00m).ThaiBahtText(), "ยี่สิบห้าล้านห้าพันหนึ่งร้อยล้านบาทถ้วน");
    }


    [Fact]
    public void MillionMillion_TrillionAndBaht()
    {
      Assert.Equal((25000000000111.00m).ThaiBahtText(), "ยี่สิบห้าล้านล้านหนึ่งร้อยสิบเอ็ดบาทถ้วน");
      Assert.Equal((-25000000000111.00m).ThaiBahtText(), "ลบยี่สิบห้าล้านล้านหนึ่งร้อยสิบเอ็ดบาทถ้วน");
    }

    [Fact]
    public void MillionMillion_TrillionAndSatang()
    {
      Assert.Equal((25000000000000.89m).ThaiBahtText(), "ยี่สิบห้าล้านล้านบาทแปดสิบเก้าสตางค์");
      Assert.Equal((-25000000000000.89m).ThaiBahtText(), "ลบยี่สิบห้าล้านล้านบาทแปดสิบเก้าสตางค์");
    }

    [Fact]
    public void UsingOptions_I()
    {
      var price = 11000111.50m;
      var options = new ThaiBahtTextOptions(UsesEt.TensOnly, Unit.Baht, appendBahtOnly: true);

      var s1 = price.ThaiBahtText(options);
      var s2 = price.ThaiBahtText(UsesEt.TensOnly, Unit.Baht, appendBahtOnly: true);

      Assert.Equal(s1, s2);
    }

    [Fact]
    public void UsingOptions_II()
    {
      var price = 11000111.50m;
      var options = new ThaiBahtTextOptions(UsesEt.Always, Unit.Million, appendBahtOnly: false);

      var s1 = price.ThaiBahtText(options);
      var s2 = price.ThaiBahtText(UsesEt.Always, Unit.Million, appendBahtOnly: false);

      Assert.Equal(s1, s2);
    }

    [Fact]
    public void BahtOnly()
    {
      var price = 11000111m;
      Assert.Equal(price.ThaiBahtText(appendBahtOnly: true), "สิบเอ็ดล้านหนึ่งร้อยสิบเอ็ดบาทถ้วน");
      Assert.Equal(price.ThaiBahtText(appendBahtOnly: false), "สิบเอ็ดล้านหนึ่งร้อยสิบเอ็ดบาท");

      price = 50.50m;
      Assert.Equal(price.ThaiBahtText(appendBahtOnly: true), "ห้าสิบบาทห้าสิบสตางค์");
      Assert.Equal(price.ThaiBahtText(appendBahtOnly: false), "ห้าสิบบาทห้าสิบสตางค์");
    }

    [Fact]
    public void BahtOnly_Zero()
    {
      Assert.Equal((0m).ThaiBahtText(appendBahtOnly: false), "ศูนย์บาท");
    }

    [Fact]
    public void DecimalPlacesIsIgnoredWhenUnitIsBahtAndAlwaysIsEqualToTwo()
    {
      var price = 12.345m;

      Assert.Equal(price.ThaiBahtText(unit: Unit.Baht, decimalPlaces: 1), "สิบสองบาทสามสิบห้าสตางค์");
    }

    [Fact]
    public void Unit_Million()
    {
      Assert.Equal((12345600.00m).ThaiBahtText(unit: Unit.Million, appendBahtOnly: false), "สิบสองจุดสามห้าล้านบาท");
      Assert.Equal((8500000m).ThaiBahtText(unit: Unit.Million, appendBahtOnly: false), "แปดจุดห้าล้านบาท");
      Assert.Equal((111200000m).ThaiBahtText(unit: Unit.Million, appendBahtOnly: false), "หนึ่งร้อยสิบเอ็ดจุดสองล้านบาท");
      Assert.Equal((9000000m).ThaiBahtText(unit: Unit.Million, appendBahtOnly: false), "เก้าล้านบาท");
    }

    [Fact]
    public void Unit_Billion()
    {
      Assert.Equal((12345600000.00m).ThaiBahtText(unit: Unit.Billion, appendBahtOnly: false), "สิบสองจุดสามห้าพันล้านบาท");
      Assert.Equal((8500000000m).ThaiBahtText(unit: Unit.Billion, appendBahtOnly: false), "แปดจุดห้าพันล้านบาท");
      Assert.Equal((111200000000m).ThaiBahtText(unit: Unit.Billion, appendBahtOnly: false), "หนึ่งร้อยสิบเอ็ดจุดสองพันล้านบาท");
      Assert.Equal((9000000000m).ThaiBahtText(unit: Unit.Billion, appendBahtOnly: false), "เก้าพันล้านบาท");
    }


    [Fact]
    public void Unit_Trillion()
    {
      Assert.Equal((12345600000000.00m).ThaiBahtText(unit: Unit.Trillion, appendBahtOnly: false), "สิบสองจุดสามห้าล้านล้านบาท");
      Assert.Equal((8500000000000m).ThaiBahtText(unit: Unit.Trillion, appendBahtOnly: false), "แปดจุดห้าล้านล้านบาท");
      Assert.Equal((111200000000000m).ThaiBahtText(unit: Unit.Trillion, appendBahtOnly: false), "หนึ่งร้อยสิบเอ็ดจุดสองล้านล้านบาท");
      Assert.Equal((9000000000000m).ThaiBahtText(unit: Unit.Trillion, appendBahtOnly: false), "เก้าล้านล้านบาท");
    }

    [Fact]
    public void BigZero()
    {
      Assert.Equal((0m).ThaiBahtText(unit: Unit.Million, appendBahtOnly: false), "ศูนย์ล้านบาท");
      Assert.Equal((0m).ThaiBahtText(unit: Unit.Billion, appendBahtOnly: false), "ศูนย์พันล้านบาท");
      Assert.Equal((0m).ThaiBahtText(unit: Unit.Trillion, appendBahtOnly: false), "ศูนย์ล้านล้านบาท");

      Assert.Equal((5000000m).ThaiBahtText(unit: Unit.Million, appendBahtOnly: false), "ห้าล้านบาท");
      Assert.Equal((5000000m).ThaiBahtText(unit: Unit.Billion, appendBahtOnly: false), "จุดศูนย์หนึ่งพันล้านบาท");
      Assert.Equal((5000000m).ThaiBahtText(unit: Unit.Billion, decimalPlaces: 4, appendBahtOnly: false), "จุดศูนย์ศูนย์ห้าพันล้านบาท");
    }


    [Fact]
    public void Unit_DecimalPlaces1()
    {
      Assert.Equal((12345600.00m).ThaiBahtText(unit: Unit.Million, decimalPlaces: 1, appendBahtOnly: false), "สิบสองจุดสามล้านบาท");
      Assert.Equal((8500000m).ThaiBahtText(unit: Unit.Million, decimalPlaces: 1, appendBahtOnly: false), "แปดจุดห้าล้านบาท");
      Assert.Equal((111200000m).ThaiBahtText(unit: Unit.Million, decimalPlaces: 1, appendBahtOnly: false), "หนึ่งร้อยสิบเอ็ดจุดสองล้านบาท");
    }

    [Fact]
    public void Unit_DecimalPlaces4()
    {
      Assert.Equal((12345600.00m).ThaiBahtText(unit: Unit.Million, decimalPlaces: 4, appendBahtOnly: false), "สิบสองจุดสามสี่ห้าหกล้านบาท");
      Assert.Equal((8500000m).ThaiBahtText(unit: Unit.Million, decimalPlaces: 4, appendBahtOnly: false), "แปดจุดห้าล้านบาท");
      Assert.Equal((111200000m).ThaiBahtText(unit: Unit.Million, decimalPlaces: 4, appendBahtOnly: false), "หนึ่งร้อยสิบเอ็ดจุดสองล้านบาท");
    }

    [Fact]
    public void Et_WithBigNumbers()
    {
      Assert.Equal((101000101.11m).ThaiBahtText(unit: Unit.Million), "หนึ่งร้อยเอ็ดล้านบาท");
      Assert.Equal((101000101.11m).ThaiBahtText(usesEt: UsesEt.Always, unit: Unit.Million), "หนึ่งร้อยเอ็ดล้านบาท");
    }

    [Fact]
    public void EtAlways_ShouldBeDefault()
    {
      Assert.Equal((501m).ThaiBahtText(), "ห้าร้อยเอ็ดบาทถ้วน");
      Assert.Equal((501000000m).ThaiBahtText(), "ห้าร้อยเอ็ดล้านบาทถ้วน");
    }

    [Fact]
    public void BUG_Issue45_OptionsNotUsedInSomeOverload()
    {
      decimal? m = 5101m;
      var s = m.ThaiBahtText(usesEt: UsesEt.TensOnly, appendBahtOnly: false);
      Assert.Equal(s, "ห้าพันหนึ่งร้อยหนึ่งบาท");
    }
  }
}
