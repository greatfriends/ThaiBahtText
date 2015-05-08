using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xunit;
using GreatFriends.ThaiBahtText;

namespace GreatFriends.ThaiBahtTextFacts {
  public class ThaiBahtTextExtensionsFacts {


    [Fact]
    public void OneDigit() {
      Assert.Equal("หนึ่งบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(1));
      Assert.Equal("สองบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(2));
      Assert.Equal("สามบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(3));
      Assert.Equal("สี่บาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(4));
      Assert.Equal("ห้าบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(5));
      Assert.Equal("หกบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(6));
      Assert.Equal("เจ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(7));
      Assert.Equal("แปดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(8));
      Assert.Equal("เก้าบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(9));
      Assert.Equal("สิบบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(10));
    }


    [Fact]
    public void NullAmount() {
      decimal? price = null;

      Assert.Equal("ศูนย์บาทถ้วน", price.ThaiBahtText());
    }

    [Fact]
    public void Zero() {
      Assert.Equal("ศูนย์บาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(0.0m));
    }

    [Fact]
    public void Ed() {
      Assert.Equal("สิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(11));
      Assert.Equal("ยี่สิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(21));
      Assert.Equal("สามสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(31));
      Assert.Equal("สี่สิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(41));
      Assert.Equal("เก้าสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(91));
      Assert.Equal("หนึ่งร้อยหนึ่งบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(101));
      Assert.Equal("หนึ่งร้อยสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(111));
      Assert.Equal("หนึ่งร้อยยี่สิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(121));

      Assert.Equal("หนึ่งพันหนึ่งบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(1001));
      Assert.Equal("ห้าพันหนึ่งล้านห้าร้อยบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(5001000500));
    }

    [Fact]
    public void BigNumbers() {
      Assert.Equal("หนึ่งหมื่นสองพันสามร้อยสี่สิบห้าบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(12345));
      Assert.Equal("สิบสองล้านสามแสนสี่หมื่นห้าพันหกร้อยเจ็ดสิบแปดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(12345678));
      Assert.Equal("หกแสนเจ็ดหมื่นห้าพันหนึ่งล้านสามแสนสามหมื่นสามพันหนึ่งร้อยสิบเอ็ดบาทถ้วน",
                   ThaiBahtTextUtil.ThaiBahtText(675001333111));
    }

    [Fact]
    public void Satang() {
      Assert.Equal("ห้าสตางค์", ThaiBahtTextUtil.ThaiBahtText(0.05m));
      Assert.Equal("สิบสตางค์", ThaiBahtTextUtil.ThaiBahtText(0.1m));
      Assert.Equal("ยี่สิบห้าสตางค์", ThaiBahtTextUtil.ThaiBahtText(0.25m));
      Assert.Equal("ห้าสิบสตางค์", ThaiBahtTextUtil.ThaiBahtText(0.50m));
      Assert.Equal("เจ็ดสิบห้าสตางค์", ThaiBahtTextUtil.ThaiBahtText(0.75m));
      Assert.Equal("สิบเอ็ดบาทเก้าสิบสตางค์", ThaiBahtTextUtil.ThaiBahtText(11.90m));
      Assert.Equal("ห้าร้อยหกสิบบาทแปดสิบสามสตางค์", ThaiBahtTextUtil.ThaiBahtText(560.83m));
    }


    [Fact]
    public void NegativeAmounts() {
      Assert.Equal("ลบหนึ่งบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(-1));
      Assert.Equal("ลบสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(-11));
      Assert.Equal("ลบห้าร้อยห้าสิบบาทยี่สิบห้าสตางค์", ThaiBahtTextUtil.ThaiBahtText(-550.25m));
    }

    [Fact]
    public void TwoDecimalPlacesOnly() {
      Assert.Equal("หกสตางค์", ThaiBahtTextUtil.ThaiBahtText(0.0550m));
      Assert.Equal("เจ็ดสตางค์", ThaiBahtTextUtil.ThaiBahtText(0.0650m));
      Assert.Equal("แปดสตางค์", ThaiBahtTextUtil.ThaiBahtText(0.0750m));
      Assert.Equal("เจ็ดสตางค์", ThaiBahtTextUtil.ThaiBahtText(0.0710m));
      Assert.Equal("แปดสตางค์", ThaiBahtTextUtil.ThaiBahtText(0.0790m));
    }

    [Fact]
    public void TwoDecimalPlacesOnly_Negatives() {
      Assert.Equal("ลบหกสตางค์", ThaiBahtTextUtil.ThaiBahtText(-0.0550m));
      Assert.Equal("ลบเจ็ดสตางค์", ThaiBahtTextUtil.ThaiBahtText(-0.0650m));
      Assert.Equal("ลบแปดสตางค์", ThaiBahtTextUtil.ThaiBahtText(-0.0750m));
      Assert.Equal("ลบเจ็ดสตางค์", ThaiBahtTextUtil.ThaiBahtText(-0.0710m));
      Assert.Equal("ลบแปดสตางค์", ThaiBahtTextUtil.ThaiBahtText(-0.0790m));
    }

    [Fact]
    public void ExtremeValues() {
      Assert.Throws<NotSupportedException>(() => {
        var s = ThaiBahtTextUtil.ThaiBahtText(1990100200200m);
      }); 
    }

    [Fact]
    public void ExtremeValues_Negatives() {
      Assert.Throws<NotSupportedException>(() => {
        var s = ThaiBahtTextUtil.ThaiBahtText(-1990100200200m);
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
      Assert.Equal("เก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าล้านเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าบาทเก้าสิบเก้าสตางค์", ThaiBahtTextUtil.MaxValue.ThaiBahtText());
      Assert.Equal("ลบเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าล้านเก้าแสนเก้าหมื่นเก้าพันเก้าร้อยเก้าสิบเก้าบาทเก้าสิบเก้าสตางค์", ThaiBahtTextUtil.MinValue.ThaiBahtText());
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
    public void JustMillionPart() {
      Assert.Equal("ห้าพันหนึ่งล้านบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(5001000000, UsesEt.TensOnly));
      Assert.Equal("ห้าพันเอ็ดล้านบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(5001000000, UsesEt.Always));
    }

    [Fact]
    public void JustMillionAndSatangs() {
      Assert.Equal("ห้าพันหนึ่งล้านบาทสิบเอ็ดสตางค์", ThaiBahtTextUtil.ThaiBahtText(5001000000.11m, UsesEt.TensOnly));
      Assert.Equal("ห้าพันเอ็ดล้านบาทสิบเอ็ดสตางค์", ThaiBahtTextUtil.ThaiBahtText(5001000000.11m, UsesEt.Always));
    }
 
  }
}
