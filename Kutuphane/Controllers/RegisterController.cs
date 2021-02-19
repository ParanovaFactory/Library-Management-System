using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models.Entity;

namespace Kutuphane.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        DbKutuphaneEntities db = new DbKutuphaneEntities();
        [HttpGet]
        public ActionResult Register( )
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tblUyeler u)
        {
            if (!ModelState.IsValid)
            {
                return View("Register");
            }
            db.tblUyeler.Add(u);
            db.SaveChanges();
            return View();
        }
    }
}