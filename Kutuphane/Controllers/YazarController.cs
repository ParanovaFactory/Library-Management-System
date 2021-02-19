using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class YazarController : Controller
    {
        // GET: Yazar
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var yzr = db.tblYazar.ToList().ToPagedList(sayfa, 10);
            return View(yzr);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tblYazar k)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            else
            {
                db.tblYazar.Add(k);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult Getir(int id)
        {
            var yzr = db.tblYazar.Find(id);
            return View("Getir",yzr);
        }
        public ActionResult Guncelle(tblYazar y)
        {
            if (!ModelState.IsValid)
            {
                return View("Getir");
            }
            else
            {
                var yzr = db.tblYazar.Find(y.Id);
                yzr.Ad = y.Ad;
                yzr.Soyad = y.Soyad;
                yzr.Detay = y.Detay;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
        }
        public ActionResult YazarKitaplar(int id)
        {
            var yzr = db.tblKitap.Where(x => x.Yazar == id).ToList();
            var yzrad = db.tblYazar.Where(y => y.Id == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
            ViewBag.yad = yzrad;
            return View(yzr);
        }
    }
}