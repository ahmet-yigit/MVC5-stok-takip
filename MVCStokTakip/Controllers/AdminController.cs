using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCStokTakip.Models.Entity;

namespace MVCStokTakip.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        DbMvcStokTakipEntities db = new DbMvcStokTakipEntities();
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult YeniAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniAdmin(TBLAdmin p)
        {
            db.TBLAdmin.Add(p);
            return RedirectToAction("Index");
        }
    }
}