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
    public class PersonelController : Controller
    {
        // GET: Personel
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(int sayfa=1)
        {
            var ktp = db.tblPersonel.Where(x=>x.Durum==true).ToList().ToPagedList(sayfa, 6);
            return View(ktp);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tblPersonel p)
        {
            db.tblPersonel.Add(p);
            p.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Getir(int id)
        {
            var prs = db.tblPersonel.Find(id);
            return View("Getir",prs);
        }
        public ActionResult Guncelle(tblPersonel p)
        {
            var per = db.tblPersonel.Find(p.Id);
            per.Ad = p.Ad;
            per.Soyad = p.Soyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(tblPersonel p)
        {
            var per = db.tblPersonel.Find(p.Id);
            per.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}