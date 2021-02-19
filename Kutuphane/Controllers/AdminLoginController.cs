using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    [AllowAnonymous]
    public class AdminLoginController : Controller
    {
        // GET: AdminLogin
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblAdmin a)
        {
            var blg = db.tblAdmin.FirstOrDefault(x => x.MailAdresi == a.MailAdresi && x.Sifre == a.Sifre);
            if(blg != null)
            {
                FormsAuthentication.SetAuthCookie(blg.MailAdresi,false);
                Session["Mailadmn"] = blg.MailAdresi.ToString();
                return RedirectToAction("Index", "Istatistik");
            }
            else
            {
                return View();
            }
            
        }
    }
}