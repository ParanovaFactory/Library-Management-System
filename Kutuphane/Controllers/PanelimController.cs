using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using System.Web.Security;

namespace Kutuphane.Controllers
{
    public class PanelimController : Controller
    {
        // GET: Panelim
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        [HttpGet]
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"];
            // var dgr = db.tblUyeler.FirstOrDefault(x => x.Mail == uyemail);
            var dgr = db.tblDuyurular.ToList();
            var d1 = db.tblUyeler.Where(x => x.Mail == uyemail).Select(y => y.Ad).FirstOrDefault();
            var d2 = db.tblUyeler.Where(x => x.Mail == uyemail).Select(y => y.Soyad).FirstOrDefault();
            var d3 = db.tblUyeler.Where(x => x.Mail == uyemail).Select(y => y.Okul).FirstOrDefault();
            var d4 = db.tblUyeler.Where(x => x.Mail == uyemail).Select(y => y.Fotoğraf).FirstOrDefault();
            var d5 = db.tblUyeler.Where(x => x.Mail == uyemail).Select(y => y.Telefon).FirstOrDefault();
            var d6 = db.tblUyeler.Where(x => x.Mail == uyemail).Select(y => y.Mail).FirstOrDefault();

            var d7 = db.tblUyeler.Where(x => x.Mail == uyemail).Select(y => y.KullanıcıAdı).FirstOrDefault();
            var uyeid = db.tblUyeler.Where(x => x.Mail == uyemail).Select(y => y.Id).FirstOrDefault();
            
            var d8 = db.tblHareket.Where(x => x.Uye == uyeid).Count();
            var d9 = db.tblMesajlar.Where(x => x.Alici == uyemail).Count();
            var d10 = db.tblDuyurular.Count();
            ViewBag.d1 = d1;
            ViewBag.d2 = d2;
            ViewBag.d3 = d3;
            ViewBag.d4 = d4;
            ViewBag.d5 = d5;
            ViewBag.d6 = d6;
            ViewBag.d7 = d7;
            ViewBag.d8 = d8;
            ViewBag.d9 = d9;
            ViewBag.d10 = d10;
            return View(dgr);
        }
        [HttpPost]
        public ActionResult Index2(tblUyeler p)
        {
            var klnc = (string)Session["Mail"];
            var uye = db.tblUyeler.FirstOrDefault(x => x.Mail == klnc);
            uye.Sifre = p.Sifre;
            uye.Ad = p.Ad;
            uye.Soyad = p.Soyad;
            uye.KullanıcıAdı = p.KullanıcıAdı;
            uye.Fotoğraf = p.Fotoğraf;
            uye.Telefon = p.Telefon;
            uye.Okul = p.Okul;
            db.SaveChanges();
            return View("Index");
        }
        public ActionResult Kitaplarım()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var id = db.tblUyeler.Where(x => x.Mail == uyemail.ToString()).Select(z => z.Id).FirstOrDefault();
            var deg = db.tblHareket.Where(x => x.Uye == id ).ToList();
            return View(deg);
        }
        public ActionResult Duyurular()
        {
            var dyrlst = db.tblDuyurular.ToList();
            return View(dyrlst);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        public PartialViewResult Partial2()
        {
            var klnc = (string)Session["Mail"];
            var id = db.tblUyeler.Where(y => y.Mail == klnc).Select(x => x.Id).FirstOrDefault();
            var uyegetir = db.tblUyeler.Find(id);
            return PartialView("Partial2",uyegetir);
        }
    }
}