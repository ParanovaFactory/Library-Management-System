using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using PagedList;
using PagedList.Mvc;

namespace Kutuphane.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Admin
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var ktg = db.tblKategori.Where(x=>x.Durum == true).ToList().ToPagedList(sayfa, 10);
            
            return View(ktg);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tblKategori k)
        {
            k.Durum = true;
            db.tblKategori.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Getir(int id)
        {
            var ktg = db.tblKategori.Find(id);
            return View("Getir",ktg);
        }
        public ActionResult Guncelle(tblKategori k)
        {
            var ktg = db.tblKategori.Find(k.Id);
            ktg.Ad = k.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(tblKategori k)
        {
            var ktg = db.tblKategori.Find(k.Id);
            ktg.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}