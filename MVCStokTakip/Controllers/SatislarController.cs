using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;

namespace MVCStokTakip.Controllers
{
    public class SatislarController : Controller
    {
        // GET: Satislar
        DbMvcStokTakipEntities db = new DbMvcStokTakipEntities();
        [Authorize]
        public ActionResult Index()
        {
            var satislar = db.TBLSatislar.ToList();
            return View(satislar);
        }


        [HttpGet]
        public ActionResult YeniSatis()
        {
            //ürünler
            List<SelectListItem> urun = (from i in db.TBLUrunler.ToList()
                                         select new SelectListItem
                                         {
                                             Text = i.ad,
                                             Value = i.id.ToString()
                                         }
                                           ).ToList();
            ViewBag.urun = urun;
            //personel
            List<SelectListItem> personel = (from i in db.TBLPersonel.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.ad + " " + i.soyad,
                                                 Value = i.id.ToString()
                                             }
                                           ).ToList();
            ViewBag.personel = personel;
            //müşteri
            List<SelectListItem> musteri = (from i in db.TBLMusteri.Where(x => x.durum == true).ToList()
                                            select new SelectListItem
                                            {
                                                Text = i.ad + " " + i.soyad,
                                                Value = i.id.ToString()
                                            }
                                           ).ToList();
            ViewBag.musteri = musteri;
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(TBLSatislar p)
        {
            var urun = db.TBLUrunler.Where(x => x.id == p.TBLUrunler.id).FirstOrDefault();
            var personel = db.TBLPersonel.Where(x => x.id == p.TBLPersonel.id).FirstOrDefault();
            var musteri = db.TBLMusteri.Where(x => x.id == p.TBLMusteri.id).FirstOrDefault();
            p.TBLUrunler = urun;
            p.TBLPersonel = personel;
            p.TBLMusteri = musteri;
            p.tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLSatislar.Add(p);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}