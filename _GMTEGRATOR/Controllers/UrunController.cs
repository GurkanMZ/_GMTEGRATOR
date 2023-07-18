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
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

      
        [HttpPost]
        public ActionResult UrunDetay(string STOK_KODU)
        {
            //System.Web.Script.Serialization.JavaScriptSerializer jsSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            //ViewBag.UrunID = STOK_KODU;
            //var liste = context.GM_TBLSTSABIT.ToList();
            //return Json(liste, JsonRequestBehavior.AllowGet);
            return RedirectToAction("Index","Urun");
        }


        [HttpPost]
        public ActionResult UrunKayitMethod(GM_TBLSTSABIT stsabit)
        {
            UrunISLEMLERI urunEkleme = new UrunISLEMLERI();
            stsabit.MAGAZA_ID = Convert.ToInt32(Session["MagazaID"].ToString());
            urunEkleme.UrunAdd(stsabit);
            return RedirectToAction("Index","Urun");
        }


    }
}