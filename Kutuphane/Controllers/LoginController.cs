using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;
using System.Web.Security;

namespace Kutuphane.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(tblUyeler p)
        {
            var blg = db.tblUyeler.FirstOrDefault(x => x.Mail == p.Mail && x.Sifre == p.Sifre);
            if (blg != null)
            {
                FormsAuthentication.SetAuthCookie(blg.Mail, false);
                Session["Mail"] = blg.Mail.ToString();
                Session["Ad"] = blg.Ad.ToString();
                Session["Soyad"] = blg.Soyad.ToString();
                return RedirectToAction("Index", "Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}