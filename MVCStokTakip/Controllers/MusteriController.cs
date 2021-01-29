using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace MVCStokTakip.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        DbMvcStokTakipEntities db = new DbMvcStokTakipEntities();
        [Authorize]
        public ActionResult Index(int sayfa = 1)
        {
            //var musteriListe = db.TBLMusteri.ToList();
            var musteriListe = db.TBLMusteri.Where(x => x.durum == true).ToList().ToPagedList(sayfa, 3);
            return View(musteriListe);
        }


        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMusteri p)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniMusteri");
            }
            p.durum = true;
            db.TBLMusteri.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSil(TBLMusteri p)
        {
            var musteriBul = db.TBLMusteri.Find(p.id);
            musteriBul.durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id)
        {
            var musteri = db.TBLMusteri.Find(id);
            return View("MusteriGetir", musteri);
        }

        public ActionResult MusteriGuncelle(TBLMusteri p)
        {
            var musteri = db.TBLMusteri.Find(p.id);
            musteri.ad = p.ad;
            musteri.soyad = p.soyad;
            musteri.sehir = p.sehir;
            musteri.bakiye = p.bakiye;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}