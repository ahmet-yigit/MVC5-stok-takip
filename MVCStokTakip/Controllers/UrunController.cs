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
        [Authorize]
        public ActionResult Index(string p)
        {
            //var dgr = db.TBLUrunler.Where(x => x.durum == true).ToList();
            //arama alanı için gerekli kod satırları
            var urunler = db.TBLUrunler.Where(x => x.durum == true);
            if (!string.IsNullOrEmpty(p))
            {
                urunler = urunler.Where(x => x.ad.Contains(p) && x.durum == true);
            }
            return View(urunler.ToList());
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> degerler = (from i in db.TBLKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.ad,
                                                 Value = i.id.ToString()
                                             }
                                           ).ToList();
            ViewBag.dgr = degerler;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(TBLUrunler p)
        {
            var ktgr = db.TBLKategori.Where(x => x.id == p.TBLKategori.id).FirstOrDefault();
            p.TBLKategori = ktgr;
            db.TBLUrunler.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult UrunGetir(int id)
        {
            List<SelectListItem> urunKtgr = (from x in db.TBLKategori.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = x.ad,
                                                 Value = x.id.ToString()
                                             }).ToList();
            var urun = db.TBLUrunler.Find(id);
            ViewBag.urunKtgr = urunKtgr;
            return View("UrunGetir", urun);
        }
        public ActionResult UrunGuncelle(TBLUrunler p)
        {
            var urun = db.TBLUrunler.Find(p.id);
            urun.marka = p.marka;
            urun.satisfiyat = p.satisfiyat;
            urun.alisfiyat = p.alisfiyat;
            urun.stok = p.stok;
            urun.ad = p.ad;
            var ktg = db.TBLKategori.Where(x => x.id == p.TBLKategori.id).FirstOrDefault();
            urun.kategori = ktg.id;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunSil(TBLUrunler p)
        {
            var urun = db.TBLUrunler.Find(p.id);
            urun.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}