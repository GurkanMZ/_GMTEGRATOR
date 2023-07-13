using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _GMTEGRATOR.Models;

namespace _GMTEGRATOR.Controllers
{
    public class UrunController : Controller
    {
        deartech_3Entities context = new deartech_3Entities();
        // GET: Urun
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UrunKayitMethod(GM_TBLSTSABIT stsabit)
        {            
            context.GM_TBLSTSABIT.Add(stsabit);
            context.SaveChanges();
            return RedirectToAction("Index","Urun");
        }


    }
}