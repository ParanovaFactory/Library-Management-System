using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class DuyuruController : Controller
    {
        // GET: Duyuru
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var dgr = db.tblDuyurular.ToList();
            return View(dgr);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tblDuyurular t)
        {
            db.tblDuyurular.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Sil(int id)
        {
            var dyr = db.tblDuyurular.Find(id);
            db.tblDuyurular.Remove(dyr);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Detay(tblDuyurular p)
        {
            var dyr = db.tblDuyurular.Find(p.Id);
            return View("Detay", dyr);
        }
        public ActionResult Guncelle(tblDuyurular t)
        {
            var dyr = db.tblDuyurular.Find(t.Id);
            dyr.Kategori = t.Kategori;
            dyr.İçerik = t.İçerik;
            dyr.Tarih = t.Tarih;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}