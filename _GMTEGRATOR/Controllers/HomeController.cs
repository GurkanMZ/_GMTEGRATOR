﻿using System;
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
        deartech_3Entities1 context = new deartech_3Entities1();
        // GET: Home
        public ActionResult Index()
        {
            if (Session["MagazaID"] == null)
                return RedirectToAction("Index", "Login");    
            return View();
        }
        [HttpGet]
        public JsonResult TumUrunlerList()
        {
            var MagazaID = Convert.ToInt32(Session["MagazaID"].ToString());
            ViewBag.MagazaAdi = Session["MagazaAdi"].ToString();
            var Urunlistesi = context.TUM_URUNLER_V.Where(m => m.MAGAZA_ID == MagazaID).ToList();
            return Json(Urunlistesi, JsonRequestBehavior.AllowGet);
        }
    }
}