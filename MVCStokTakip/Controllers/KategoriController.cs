using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;
namespace MVCStokTakip.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        DbMvcStokTakipEntities db = new DbMvcStokTakipEntities();
        [Authorize]
        public ActionResult Index()
        {
            var kategoriler = db.TBLKategori.ToList();
            return View(kategoriler);
        }

        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(TBLKategori p)
        {
            db.TBLKategori.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var ktg = db.TBLKategori.Find(id);
            db.TBLKategori.Remove(ktg);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var ktgr = db.TBLKategori.Find(id);
            return View("KategoriGetir", ktgr);
        }


        public ActionResult KategoriGüncelle(TBLKategori k)
        {
            var ktg = db.TBLKategori.Find(k.id);
            ktg.ad = k.ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}