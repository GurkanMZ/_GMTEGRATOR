using System;
using System.Collections.Generic;
using System.IO;
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
            ViewBag.UrunID = STOK_KODU;
            //var liste = context.GM_TBLSTSABIT.ToList();
            //return Json(liste, JsonRequestBehavior.AllowGet);
            return View();
        }


        [HttpPost]
        public ActionResult UrunKayitMethod(UrunDetayDAL UrunDetayDAL)
        {
            UrunISLEMLERI urunEkleme = new UrunISLEMLERI();
            UrunDetayDAL.GM_TBLSTSABIT.MAGAZA_ID = Convert.ToInt32(Session["MagazaID"].ToString());
            urunEkleme.UrunAdd(UrunDetayDAL.GM_TBLSTSABIT);
            klasorekaydet(UrunDetayDAL);
            return RedirectToAction("Index", "Home");
        }




        public void klasorekaydet(UrunDetayDAL UrunDetayDAL)
        {
            #region Dosyaya kaydet 1  
            var MagazaAdi = Session["MagazaAdi"];
            foreach (var i in UrunDetayDAL.gorsel)
            {
                if (i.ContentLength > 0)
                {
                    string filename = Path.GetFileName(i.FileName);
                    if (Server.MapPath("~/image/" + MagazaAdi + "").Count() > 0)
                    {
                        Directory.CreateDirectory(Server.MapPath("~/image/" + MagazaAdi + ""));
                        var path = Path.Combine(Server.MapPath("~/image/" + MagazaAdi + ""), filename);
                        i.SaveAs(path);

                    }
                    else
                    {
                        Directory.CreateDirectory(Server.MapPath("~/image/" + MagazaAdi + ""));
                        var path = Path.Combine(Server.MapPath("~/image/" + MagazaAdi + ""), filename);
                        i.SaveAs(path);

                    }
                }
            }
            #endregion
        }

    }
}