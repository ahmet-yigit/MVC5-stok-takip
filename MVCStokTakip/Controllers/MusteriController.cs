using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;

namespace MVCStokTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokTakipEntities db = new DbMvcStokTakipEntities();
        public ActionResult Index()
        {
            var musteriListe = db.TBLMusteri.ToList();
            return View(musteriListe);
        }
    }
}