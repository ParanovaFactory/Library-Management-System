using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class IstatistikController : Controller
    {
        // GET: Istatistik
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var deger1 = db.tblUyeler.Count();
            ViewBag.dgr1=deger1;
            var deger2 = db.tblKitap.Count();
            ViewBag.dgr2 = deger2;
            var deger3 = db.tblKitap.Where(x => x.Durum == false).Count();
            ViewBag.dgr3 = deger3;
            var deger4 = db.tblCeza.Sum(x => x.Para);
            ViewBag.dgr4 = deger4;
            return View();
        }
        public ActionResult Hava()
        {
            return View();
        }
        public ActionResult HavaKart()
        {
            return View();
        }
        public ActionResult Galeri()
        {
            var dgr = db.tblGaleri.ToList();
            return View(dgr);
        }
        public ActionResult LinqKart()
        {
            var deger1 = db.tblKitap.Count();
            ViewBag.dgr1 = deger1;
            var deger2 = db.tblUyeler.Count();
            ViewBag.dgr2 = deger2;
            var deger3 = db.tblCeza.Sum(x => x.Para);
            ViewBag.dgr3 = deger3;
            var deger4 = db.tblKitap.Where(x => x.Durum == false).Count();
            ViewBag.dgr4 = deger4;
            var deger5 = db.tblKategori.Count();
            ViewBag.dgr5 = deger5;
            var deger6 = db.EnAktifUye().FirstOrDefault();
            ViewBag.dgr6 = deger6;
            var deger7 = db.EnOkunan().FirstOrDefault();
            ViewBag.dgr7 = deger7;
            var deger8 = db.EnFazlaKitapYazar().FirstOrDefault();
            ViewBag.dgr8 = deger8;
            var deger9 = db.EnYayınEvi().FirstOrDefault();
            ViewBag.dgr9 = deger9;
            var deger10 = db.EnBaşarılıPer().FirstOrDefault();
            ViewBag.dgr10 = deger10;
            var deger11 = db.tblIlestisim.Count();
            ViewBag.dgr11 = deger11;
            var deger12 = db.BugunKitap().FirstOrDefault();
            ViewBag.dgr12 = deger12;

            return View();

            // grup by ile en iyi yayın evi çekme kodu
            //var deger13 = db.tblKitap.GroupBy(x => x.YayınEvi).OrderByDescending(z => z.Count()).
            //    Select(y => new { y.Key }).FirstOrDefault();
            //ViewBag.dgr13 = deger13;
        }




        // Resim Yükleme
        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
           if (dosya.ContentLength > 0)
           {
               string dosyayolu = VirtualPathUtility.Combine(Server.MapPath("~/web/web2/resimler"), VirtualPathUtility.GetFileName(dosya.FileName));
               dosya.SaveAs(dosyayolu);

          }
           return RedirectToAction("Galeri");
        }
    }
}