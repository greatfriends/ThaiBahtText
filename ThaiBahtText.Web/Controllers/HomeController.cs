using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using GreatFriends.ThaiBahtText;
using System.Reflection;

namespace ThaiBahtText.Web.Controllers {
  public class HomeController : Controller {

    public ActionResult Index() {
      string p = Server.MapPath("~/bin/ThaiBahtText.dll");
      Assembly asm = Assembly.LoadFrom(p);
      Version ver = asm.GetName().Version;

      ViewBag.Version = ver;
      ViewBag.Min = ThaiBahtTextUtil.MinValue;
      ViewBag.Max = ThaiBahtTextUtil.MaxValue;
      return View();
    }

    [HttpPost]
    public ActionResult ToThaiBahtText(decimal? amount) {
      if (amount == null) {
        amount = 0m;
      }
      var result = new{
        AmountText = amount.Value.ToString("n2"),
        ThaiBahtText = amount.ThaiBahtText()
      };
      return Json(result);
    } 

  }
}
