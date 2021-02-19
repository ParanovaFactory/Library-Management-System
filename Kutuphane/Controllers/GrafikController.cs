using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kutuphane.Models;

namespace Kutuphane.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult VisualizeKitapResult()
        {
            return Json(liste());
        }
        public List<Class1> liste()
        {
            List<Class1> cs = new List<Class1>();
            cs.Add(new Class1()
            {
                yayinevi = "Can Yayınları",
                sayi = 7
            });
            cs.Add(new Class1()
            {
                yayinevi = "Dergah",
                sayi = 3
            });
            cs.Add(new Class1()
            {
                yayinevi = "İnkılap Yayınevi",
                sayi = 7
            });
            return cs;
        }
    }
}