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
    public class MesajlarController : Controller
    {
        // GET: Mesajlar
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var deger = db.tblMesajlar.Where(x=>x.Alici == uyemail.ToString()).ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniMesaj()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniMesaj(tblMesajlar m)
        {
            var uyemail = (string)Session["Mail"].ToString();
            m.Gonderen = uyemail.ToString();
            m.Tarih=DateTime.Now.ToShortDateString();
            db.tblMesajlar.Add(m);
            db.SaveChanges();
            return View();
        }
        public ActionResult Gonderi()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var deger = db.tblMesajlar.Where(x => x.Gonderen == uyemail.ToString()).ToList();
            return View(deger);
        }
        public PartialViewResult Partial1()
        {
            var uyemail = (string)Session["Mail"].ToString();
            var gln = db.tblMesajlar.Where(x => x.Alici == uyemail).Count();
            ViewBag.d1 = gln;
            var gdn = db.tblMesajlar.Where(x => x.Alici == uyemail).Count();
            ViewBag.d2 = gdn;
            return PartialView();
        }
    }
}

//public ActionResult SatisSil(int id)
//{
//    var sts = db.tblsatislar.Find(id);
//    db.tblsatislar.Remove(sts);
//    db.SaveChanges();
//    return RedirectToAction("Index");
//}