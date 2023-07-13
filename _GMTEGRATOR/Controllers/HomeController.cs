using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Services;
using _GMTEGRATOR.Models;

namespace _GMTEGRATOR.Controllers
{
    public class HomeController : Controller
    {
        deartech_3Entities context = new deartech_3Entities();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult TumUrunlerList()
        {
            var Urunlistesi = context.GM_TBLSTSABIT.ToList();
            return Json(Urunlistesi, JsonRequestBehavior.AllowGet);
        }








    }
}