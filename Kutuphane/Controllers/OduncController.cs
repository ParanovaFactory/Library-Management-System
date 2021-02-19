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
    public class OduncController : Controller
    {
        // GET: Odunc
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var hrk = db.tblHareket.Where(x => x.İslemDurum == false).ToList().ToPagedList(sayfa, 10);
            return View(hrk);
        }
        public ActionResult Index1(int sayfa = 1)
        {
            var hrk1 = db.tblHareket.ToList().ToPagedList(sayfa, 10);
            return View("Index1", hrk1);
        }
        [HttpGet]
        public ActionResult Ekle()
        {
            List<SelectListItem> deger1 = (from x in db.tblUyeler.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad+" "+x.Soyad,
                                               Value = x.Id.ToString()
                                           }
                                          ).ToList();
            ViewBag.dgr1 = deger1;
            List<SelectListItem> deger2 = (from x in db.tblPersonel.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad + " " + x.Soyad,
                                               Value = x.Id.ToString()
                                           }
                                          ).ToList();
            ViewBag.dgr2 = deger2;
            List<SelectListItem> deger3 = (from x in db.tblKitap.Where(x=>x.Durum==true).ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Ad,
                                               Value = x.Id.ToString()
                                           }
                                         ).ToList();
            ViewBag.dgr3 = deger3;
            return View();
        }
        [HttpPost]
        public ActionResult Ekle(tblHareket h)
        {
            var d1 = db.tblUyeler.Where(x => x.Id == h.tblUyeler.Id).FirstOrDefault();
            var d2 = db.tblKitap.Where(x => x.Id == h.tblKitap.Id).FirstOrDefault();
            var d3 = db.tblPersonel.Where(x => x.Id == h.tblPersonel.Id).FirstOrDefault();
            h.tblUyeler = d1;
            h.tblKitap = d2;
            h.tblPersonel = d3;
            db.tblHareket.Add(h);
            h.İslemDurum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Iade(tblHareket p)
        {
            var odn = db.tblHareket.Find(p.Id);
            DateTime d1 = DateTime.Parse(odn.IadeTarihi.ToString());
            DateTime d2 = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;
            ViewBag.dgr = d3.TotalDays;
            return View("Iade", odn);
        }
        public ActionResult IadeEt(tblHareket p)
        {
            var h = db.tblHareket.Find(p.Id);
            h.UyeGetirTarihi = p.UyeGetirTarihi;
            h.İslemDurum = true;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}