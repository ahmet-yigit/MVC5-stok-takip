using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;

namespace MVCStokTakip.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        DbMvcStokTakipEntities db = new DbMvcStokTakipEntities();
        public ActionResult Index()
        {
            var dgr = db.TBLUrunler.ToList();
            return View(dgr);
        }
    }
}