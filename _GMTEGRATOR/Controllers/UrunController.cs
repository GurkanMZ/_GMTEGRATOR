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

        public ActionResult Index(GM_TBLSTSABIT stsabit)
        {
            ViewBag.UrunID = stsabit.STOK_KODU;
            return View();
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