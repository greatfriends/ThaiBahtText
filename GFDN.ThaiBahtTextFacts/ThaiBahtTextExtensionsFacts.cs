using GFDN.ThaiBahtText;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GFDN.ThaiBahtTextFacts {
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
    public void Zero() {
      Assert.Equal("ศูนย์บาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(0));
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
    }

    [Fact]
    public void BigNumbers() {
      Assert.Equal("หนึ่งหมื่นสองพันสามร้อยสี่สิบห้าบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(12345));
      Assert.Equal("สิบสองล้านสามแสนสี่หมื่นห้าพันหกร้อยเจ็ดสิบแปดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(12345678));
      Assert.Equal("ห้าพันหนึ่งล้านสามแสนสามหมื่นสามพันหนึ่งร้อยสิบเอ็ดบาทถ้วน", ThaiBahtTextUtil.ThaiBahtText(5001333111));
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

  }
}
