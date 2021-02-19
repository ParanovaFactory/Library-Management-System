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
    public class UyeController : Controller
    {
        // GET: Uye
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var uye = db.tblUyeler.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 10);
            return View(uye);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tblUyeler uye)
        {
            db.tblUyeler.Add(uye);
            uye.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Getir(int id)
        {
            var uye = db.tblUyeler.Find(id);
            return View("Getir", uye);
        }
        public ActionResult Guncelle (tblUyeler u)
        {
            var uye = db.tblUyeler.Find(u.Id);
            uye.Ad = u.Ad;
            uye.Soyad = u.Soyad;
            uye.Mail = u.Mail;
            uye.KullanıcıAdı = u.KullanıcıAdı;
            uye.Sifre = u.Sifre;
            uye.Fotoğraf = u.Fotoğraf;
            uye.Telefon = u.Telefon;
            uye.Okul = u.Okul;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(tblUyeler u)
        {
            var uye = db.tblUyeler.Find(u.Id);
            uye.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UyeKitapGecmisi(int id)
        {
            var gms = db.tblHareket.Where(x => x.Uye == id).ToList();
            var uyead = db.tblUyeler.Where(y => y.Id == id).Select(z => z.Ad + " " + z.Soyad).FirstOrDefault();
            ViewBag.uad = uyead;
            return View(gms);
        }
    }
}