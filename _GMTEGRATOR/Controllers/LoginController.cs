using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using _GMTEGRATOR.Models;

namespace _GMTEGRATOR.Controllers
{
    public class LoginController : Controller
    {
        deartech_3Entities1 context = new deartech_3Entities1();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }






        [HttpPost]
        public ActionResult Login(GM_KULLANICILAR kullanicii)
        {
            kullanicii.KULLANICI_SIFRE = MD5Encryptor(kullanicii.KULLANICI_SIFRE);
            bool kullanici = context.GM_KULLANICILAR.Any(x => x.KULLANICI_MAIL == kullanicii.KULLANICI_MAIL && x.KULLANICI_SIFRE == kullanicii.KULLANICI_SIFRE);
            GM_KULLANICILAR kull = context.GM_KULLANICILAR.FirstOrDefault(x => x.KULLANICI_MAIL == kullanicii.KULLANICI_MAIL && x.KULLANICI_SIFRE == kullanicii.KULLANICI_SIFRE);

            if (kullanici)
            {
                FormsAuthentication.SetAuthCookie(kull.KULLANICI_MAIL, false);
                    //4
                Session["Kullanici_Yetki"] = kull.KULLANICI_YETKI.ToString();
                Session["MagazaID"] = kull.MAGAZA_ID.ToString();
                Session["KULLANICI_MAIL"] = kull.KULLANICI_MAIL.ToString();
                Session["MagazaAdi"] = kull.MAGAZA_ADI.ToString();
                if (kull.KULLANICI_YETKI == "standart")
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (kull.KULLANICI_YETKI == "ik")
                {
                    return RedirectToAction("Index", "OneriPanel");
                }
                else if (kull.KULLANICI_YETKI == "isg")
                {
                    return RedirectToAction("Index", "RamakKalaPanel");
                }
            }
            else
            {
                ViewBag.LoginError = "Hatalı mail adresi veya şifre.";
            }
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }


        [AllowAnonymous]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "LoginPanel");
        }
        [AllowAnonymous]
        private string MD5Encryptor(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));
            byte[] result = md5.Hash;
            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }


    }
}