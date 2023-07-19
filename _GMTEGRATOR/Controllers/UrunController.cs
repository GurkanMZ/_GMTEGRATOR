using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
            ViewBag.UrunID = STOK_KODU;
            return View();
        }


        [HttpPost]
        public ActionResult UrunKayitMethod(UrunDetayDAL UrunDetayDAL)
        {
            UrunISLEMLERI urunEkleme = new UrunISLEMLERI();
            UrunDetayDAL.GM_TBLSTSABIT.MAGAZA_ID = Convert.ToInt32(Session["MagazaID"].ToString());
            urunEkleme.UrunAdd(UrunDetayDAL.GM_TBLSTSABIT);
            if (UrunDetayDAL.gorsel != null)
            {
                klasorekaydet(UrunDetayDAL);
                ftpyukle1(UrunDetayDAL);
            }
            if (UrunDetayDAL.gorsel2.Count() > 0)
            {
                klasorekaydet2(UrunDetayDAL);
                ftpyukle2(UrunDetayDAL);
            }
            if (UrunDetayDAL.gorsel3 != null)
            {
                klasorekaydet3(UrunDetayDAL);
                ftpyukle3(UrunDetayDAL);
            }
            if (UrunDetayDAL.gorsel4 != null)
            {
                klasorekaydet4(UrunDetayDAL);
                ftpyukle4(UrunDetayDAL);
            }

            ResSqlKaydet(UrunDetayDAL);
            return RedirectToAction("Index", "Home");
        }




        public void klasorekaydet(UrunDetayDAL UrunDetayDAL)
        {
            var MagazaAdi = Session["MagazaAdi"];
            #region Dosyaya kaydet 1  
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



        public void klasorekaydet2(UrunDetayDAL UrunDetayDAL)
        {
            var MagazaAdi = Session["MagazaAdi"];
            #region Dosyaya kaydet 2  
            foreach (var i in UrunDetayDAL.gorsel2)
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



        public void klasorekaydet3(UrunDetayDAL UrunDetayDAL)
        {
            var MagazaAdi = Session["MagazaAdi"];
            #region Dosyaya kaydet 3  
            foreach (var i in UrunDetayDAL.gorsel3)
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




        public void klasorekaydet4(UrunDetayDAL UrunDetayDAL)
        {
            var MagazaAdi = Session["MagazaAdi"];
            #region Dosyaya kaydet 4  
            foreach (var i in UrunDetayDAL.gorsel4)
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


        // -------------   FTP KISMI *-***-*****************-------------------***************

        public void ftpsabit(string SadeDosyaAdi, String uzanti)
        {
            #region FTP için sabit olanların bulunduğu method
            FtpWebRequest request = null;
            string server, klasoradi, dosyadi, kadi, ksifre;
            server = "104.247.162.242";
            klasoradi = "httpdocs/IMAGES/PRODUCT_IMG";
            kadi = "deartech";
            ksifre = "2Syh11#0h";
            request = WebRequest.Create(new Uri($@"ftp://{server}/{klasoradi}/{SadeDosyaAdi}")) as FtpWebRequest;
            request.Method = WebRequestMethods.Ftp.UploadFile;
            request.UseBinary = true;
            request.UsePassive = true;
            request.KeepAlive = true;
            request.Credentials = new NetworkCredential(kadi, ksifre);
            //request.ConnectionGroupName = "group";

            FileInfo finfo = new FileInfo(uzanti);
            using (FileStream fs = finfo.OpenRead())
            {
                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                fs.Close();
                Stream requestStream = request.GetRequestStream();
                requestStream.Write(buffer, 0, buffer.Length);
                requestStream.Flush();
                requestStream.Close();
            }
            #endregion
        }
        protected void ftpyukle1(UrunDetayDAL UrunDetayDAL)
        {
            String uzanti = "";
            #region ftp
            // DOT KISMI 
            string destinationPath = string.Empty;
            var firma = Session["MagazaAdi"];
            //--------******************------------------------*********************----------------------
            /// GÖRSEL 1
            var resm = UrunDetayDAL.gorsel;
            var filePaths = new List<string>();
            if (resm != null)
            {
                foreach (var item in UrunDetayDAL.gorsel)
                {
                    string SadeDosyaAdi = item.FileName + "";
                    var isimkismi = "";
                    var turKismi = "";
                    isimkismi = item.FileName.Split('.').First();
                    turKismi = item.FileName.Split('.').Last();

                    uzanti = Path.Combine(Server.MapPath("~/image/" + firma), item.FileName);
                    SadeDosyaAdi = Session["KULLANICI_MAIL"].ToString() + "_" + firma + "_" + "." + turKismi;
                    Session["SadeDosyaAdi"] = SadeDosyaAdi;
                    ftpsabit(SadeDosyaAdi, uzanti);
                }
            }
            #endregion
        }

        protected void ftpyukle2(UrunDetayDAL UrunDetayDAL)
        {
            String uzanti = "";
            #region ftp
            // DOT KISMI 
            string destinationPath = string.Empty;
            var firma = Session["MagazaAdi"];
            //--------******************------------------------*********************----------------------
            /// GÖRSEL 1
            var resm = UrunDetayDAL.gorsel2;
            var filePaths = new List<string>();
            if (resm != null)
            {
                foreach (var item in UrunDetayDAL.gorsel2)
                {
                    string SadeDosyaAdi = item.FileName + "";
                    var isimkismi = "";
                    var turKismi = "";
                    isimkismi = item.FileName.Split('.').First();
                    turKismi = item.FileName.Split('.').Last();

                    uzanti = Path.Combine(Server.MapPath("~/image/" + firma), item.FileName);
                    SadeDosyaAdi = Session["KULLANICI_MAIL"].ToString() + "_" + firma + "_" + "." + turKismi;
                    Session["SadeDosyaAdi2"] = SadeDosyaAdi;
                    ftpsabit(SadeDosyaAdi, uzanti);
                }
            }
            #endregion
        }
        protected void ftpyukle3(UrunDetayDAL UrunDetayDAL)
        {
            String uzanti = "";
            #region ftp
            // DOT KISMI 
            string destinationPath = string.Empty;
            var firma = Session["MagazaAdi"];
            //--------******************------------------------*********************----------------------
            /// GÖRSEL 1
            var resm = UrunDetayDAL.gorsel3;
            var filePaths = new List<string>();
            if (resm != null)
            {
                foreach (var item in UrunDetayDAL.gorsel3)
                {
                    string SadeDosyaAdi = item.FileName + "";
                    var isimkismi = "";
                    var turKismi = "";
                    isimkismi = item.FileName.Split('.').First();
                    turKismi = item.FileName.Split('.').Last();

                    uzanti = Path.Combine(Server.MapPath("~/image/" + firma), item.FileName);
                    SadeDosyaAdi = Session["KULLANICI_MAIL"].ToString() + "_" + firma + "_" + "." + turKismi;
                    Session["SadeDosyaAdi3"] = SadeDosyaAdi;
                    ftpsabit(SadeDosyaAdi, uzanti);
                }
            }
            #endregion
        }
        protected void ftpyukle4(UrunDetayDAL UrunDetayDAL)
        {
            String uzanti = "";
            #region ftp
            // DOT KISMI 
            string destinationPath = string.Empty;
            var firma = Session["MagazaAdi"];
            //--------******************------------------------*********************----------------------
            /// GÖRSEL 1
            var resm = UrunDetayDAL.gorsel4;
            var filePaths = new List<string>();
            if (resm != null)
            {
                foreach (var item in UrunDetayDAL.gorsel4)
                {
                    string SadeDosyaAdi = item.FileName + "";
                    var isimkismi = "";
                    var turKismi = "";
                    isimkismi = item.FileName.Split('.').First();
                    turKismi = item.FileName.Split('.').Last();

                    uzanti = Path.Combine(Server.MapPath("~/image/" + firma), item.FileName);
                    SadeDosyaAdi = Session["KULLANICI_MAIL"].ToString() + "_" + firma + "_" + "." + turKismi;
                    Session["SadeDosyaAdi4"] = SadeDosyaAdi;
                    ftpsabit(SadeDosyaAdi, uzanti);
                }
            }
            #endregion
        }




        protected void ResSqlKaydet(UrunDetayDAL UrunDetayDAL)
        {
            try
            {
                GM_TBLSTRESIM urun = new GM_TBLSTRESIM();
                urun.MAGAZA_ID = Convert.ToInt32(Session["MagazaID"].ToString());

                if (UrunDetayDAL.gorsel != null)
                    urun.resim_url1 = "https://deartechnologies.com/IMAGES/PRODUCT_IMG" + Session["SadeDosyaAdi"].ToString();

                if (UrunDetayDAL.gorsel2 != null)
                    urun.resim_url2 = "https://deartechnologies.com/IMAGES/PRODUCT_IMG" + Session["SadeDosyaAdi2"].ToString();

                if (UrunDetayDAL.gorsel3 != null)
                    urun.resim_url3 = "https://deartechnologies.com/IMAGES/PRODUCT_IMG" + Session["SadeDosyaAdi3"].ToString();

                if (UrunDetayDAL.gorsel4 != null)
                    urun.resim_url4 = "https://deartechnologies.com/IMAGES/PRODUCT_IMG" + Session["SadeDosyaAdi4"].ToString();

                urun.STOK_KODU = UrunDetayDAL.GM_TBLSTSABIT.STOK_KODU;

                context.GM_TBLSTRESIM.Add(urun);
                context.SaveChanges();
            }
            catch { }
        }










    }
}