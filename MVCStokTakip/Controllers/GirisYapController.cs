using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;
using System.Web.Security;

namespace MVCStokTakip.Controllers
{
    public class GirisYapController : Controller
    {
        // GET: GirisYap
        DbMvcStokTakipEntities db = new DbMvcStokTakipEntities();
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(TBLAdmin p)
        {
            var bilgiler = db.TBLAdmin.FirstOrDefault(x => x.kullanici == p.kullanici && x.sifre == p.sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.kullanici, false);
                return RedirectToAction("Index", "Musteri");
            }
            return View();
        }
    }
}