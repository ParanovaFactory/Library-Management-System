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
    public class KitapController : Controller
    {
        // GET: Kitap
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var ktp = db.tblKitap.ToList().ToPagedList(sayfa, 6);
            return View(ktp);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> ktg = (from x in db.tblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad,
                                            Value = x.Id.ToString()
                                        }
                                       ).ToList();
            ViewBag.drop = ktg;
            List<SelectListItem> yzr = (from x in db.tblYazar.ToList()
                                        select new SelectListItem
                                        {
                                            Text = x.Ad + " " + x.Soyad,
                                            Value = x.Id.ToString()
                                        }
                                       ).ToList();
            ViewBag.drop1 = yzr;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tblKitap k)
        {
            var ktg = db.tblKategori.Where(x => x.Id == k.tblKategori.Id).FirstOrDefault();
            var yzr = db.tblYazar.Where(x => x.Id == k.tblYazar.Id).FirstOrDefault();
            k.tblKategori = ktg;
            k.tblYazar = yzr;
            k.Durum = true;
            db.tblKitap.Add(k);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Getir(int id)
        {
            List<SelectListItem> ktg = (from y in db.tblKategori.ToList()
                                        select new SelectListItem
                                        {
                                            Text = y.Ad,
                                            Value = y.Id.ToString()
                                        }
                                       ).ToList();
            ViewBag.drop = ktg;
            List<SelectListItem> yzr = (from y in db.tblYazar.ToList()
                                        select new SelectListItem
                                        {
                                            Text = y.Ad + " " + y.Soyad,
                                            Value = y.Id.ToString()
                                        }
                                       ).ToList();

            var ktp = db.tblKitap.Find(id);
            ViewBag.drop1 = yzr;
            return View("Getir", ktp);
        }
        public ActionResult Guncelle(tblKitap k)
        {
            var ktp = db.tblKitap.Find(k.Id);
            ktp.Ad = k.Ad;
            var ktg = db.tblKategori.Where(x => x.Id == ktp.tblKategori.Id).FirstOrDefault();
            var yzr = db.tblYazar.Where(y => y.Id == ktp.tblYazar.Id).FirstOrDefault();
            ktp.Basımyıl = k.Basımyıl;
            ktp.Sayfa = k.Sayfa;
            ktp.Hakkinda = k.Hakkinda;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(tblKitap k)
        {
            var ktg = db.tblKitap.Find(k.Id);
            ktg.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Gir(tblKitap k)
        {
            var ktg = db.tblKitap.Find(k.Id);
            ktg.Durum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}