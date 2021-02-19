using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Sınıflarım;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    [AllowAnonymous]
    public class VitrinController : Controller
    {
        // GET: Vitrin
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        [HttpGet]
        public ActionResult Index()
        {
            Class1 cs = new Class1();
            cs.Deger1= db.tblKitap.ToList();
            cs.Deger2= db.tblHakkimizda.ToList();
            return View(cs);
        }
        [HttpPost]
        public ActionResult Index(tblIlestisim t)
        {
            db.tblIlestisim.Add(t);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}