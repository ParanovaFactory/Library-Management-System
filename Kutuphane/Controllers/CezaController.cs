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
    public class CezaController : Controller
    {
        // GET: Ceza
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Index(int sayfa = 1)
        {
            var cz = db.tblCeza.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 10);
            return View(cz);
        }
        public ActionResult Ode(tblCeza c)
        {
            var cz = db.tblCeza.Find(c.Id);
            cz.Durum = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}