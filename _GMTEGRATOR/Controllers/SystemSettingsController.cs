using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _GMTEGRATOR.Models;

namespace _GMTEGRATOR.Controllers
{
    public class SystemSettingsController : Controller
    {
        deartech_3Entities1 context = new deartech_3Entities1();

        // GET: SystemSettings
        public ActionResult Index()
        {
            if (Session["MagazaID"] == null)
                return RedirectToAction("Index", "Login");
            try
            {
                int magazaID = Convert.ToInt32(Session["MagazaID"].ToString());
                var liste = context.GM_USER_SYSTEM_SETTINGS.Where(a => a.MAGAZA_ID == magazaID).ToList();
                SettingsModel settingsModel = new SettingsModel();
                settingsModel.GM_USER_SYSTEM_SETTINGS = liste;
                GetSystemUserSettings();
                return View(settingsModel);
            }
            catch (Exception ex)
            {
                ErrorMessages error = new ErrorMessages();
                TempData["alertMessage"] = error.GetErrorMessages("GET_SYSTEM_USER_SETTINGS") + " " + ex.Message;
            }
            return View();
        }


        [HttpGet]
        public ActionResult SystemConnection()
        {
            if (Session["MagazaID"] == null)
                return RedirectToAction("Index", "Login");
            try
            {
                int magazaID = Convert.ToInt32(Session["MagazaID"].ToString());
                var liste = context.GM_USER_SYSTEM_SETTINGS.Where(a => a.MAGAZA_ID == magazaID).ToList();
                SettingsModel settingsModel = new SettingsModel();
                settingsModel.GM_USER_SYSTEM_SETTINGS = liste;
                return View(settingsModel);
            }
            catch (Exception ex)
            {
                ErrorMessages error = new ErrorMessages();
                TempData["alertMessage"] = error.GetErrorMessages("GET_SYSTEM_USER_SETTINGS") + " " + ex.Message;
            }
            return View();
        }

        [HttpPost]
        public ActionResult SystemConnection(SettingsModel user_settings)
        {
            if (Session["MagazaID"] == null)
                return RedirectToAction("Index", "Login");
            else
            {
                try
                {
                    int magazaID = Convert.ToInt32(Session["MagazaID"].ToString());
                    user_settings.USER_SYSTEM_SETTING.MAGAZA_ID = magazaID;
                    SystemDAL systemDAL = new SystemDAL();
                    systemDAL.SaveDBSystemConnectionSettings(user_settings.USER_SYSTEM_SETTING);

                    ErrorMessages error = new ErrorMessages();
                    TempData["alertMessage"] = error.GetErrorMessages("SAVE_SYSTEM_USER_SETTINGS");
                    return RedirectToAction("SystemConnection");
                }
                catch (Exception ex)
                {
                    ErrorMessages error = new ErrorMessages();
                    TempData["alertMessage"] = error.GetErrorMessages("GET_SYSTEM_USER_SETTINGS") + " " + ex.Message;
                }
            }
            return View();
        }



        public void GetSystemUserSettings()
        {
            try
            {
                int magazaID = Convert.ToInt32(Session["MagazaID"].ToString());
                var liste = context.GM_USER_SYSTEM_SETTINGS.Where(a => a.MAGAZA_ID == magazaID).ToList();
                SettingsModel settingsModel = new SettingsModel();
                settingsModel.GM_USER_SYSTEM_SETTINGS = liste;
                settingsModel.USER_SYSTEM_SETTING = context.GM_USER_SYSTEM_SETTINGS.FirstOrDefault(a => a.MAGAZA_ID == magazaID);
                GM_USER_SYSTEM_SETTINGS liste2 = new GM_USER_SYSTEM_SETTINGS();

                List<string> TABLO_VIEW_ISMI1 = new List<string>();
                if (settingsModel.USER_SYSTEM_SETTING!=null)
                {
                    SqlConnection con = new SqlConnection("Server=" + settingsModel.USER_SYSTEM_SETTING.SERVER_URL.ToString() + ";Database=" + settingsModel.USER_SYSTEM_SETTING.DBNAME.ToString() + ";User Id=" + settingsModel.USER_SYSTEM_SETTING.USER_NAME.ToString() + ";Password=" + settingsModel.USER_SYSTEM_SETTING.USER_PASSWORD.ToString() + "; connection timeout=3;");
                    con.Open();
                    SqlDataReader reader = new SqlCommand("select s.TABLO_VIEW_ISMI,TABLE_NAME as KAYNAK from INFORMATION_SCHEMA.TABLES left outer join gm_USER_SYSTEM_SETTINGS s (nolock) on s.TABLO_VIEW_ISMI =TABLE_NAME order by s.TABLO_VIEW_ISMI  desc", con)
                    {
                        CommandTimeout = 0x112a880
                    }.ExecuteReader();
                    while (reader.Read())
                    {
                        TABLO_VIEW_ISMI1.Add(reader["KAYNAK"].ToString());
                    }

                    ViewBag.TABLO_VIEW_ISMI1 = TABLO_VIEW_ISMI1;
                    if (TABLO_VIEW_ISMI1.Count >= 1)
                    {
                        GetSystemUserColumns();
                    }
                    con.Close();
                }
               
            }
            catch (Exception ex)
            {
                ErrorMessages error = new ErrorMessages();
                TempData["alertMessage"] = error.GetErrorMessages("GET_SYSTEM_USER_SETTINGS") + " " + ex.Message;
            }
        }



        public void GetSystemUserColumns()
        {
            List<string> STOK_KODU = new List<string>();
            List<string> STOK_ADI = new List<string>();
            List<string> STOK_ACIKLAMASI = new List<string>();
            List<string> STOK_FIYAT = new List<string>();
            List<string> STOK_ADEDI = new List<string>();
            List<string> STOK_AKTIF_PASIF = new List<string>();
            List<string> SELLER_STOK_KODU = new List<string>();
            List<string> N11_KATALOG_ID = new List<string>();
            List<string> HEPSIBURADA_SKU = new List<string>();
            List<string> MARKA = new List<string>();
            List<string> RESIM_URL1 = new List<string>();
            List<string> RESIM_URL2 = new List<string>();
            List<string> RESIM_URL3 = new List<string>();
            List<string> RESIM_URL4 = new List<string>();
            List<string> RESIM_URL5 = new List<string>();

            try
            {
                int magazaID = Convert.ToInt32(Session["MagazaID"].ToString());
                var liste = context.GM_USER_SYSTEM_SETTINGS.Where(a => a.MAGAZA_ID == magazaID).ToList();
                SettingsModel settingsModel = new SettingsModel();
                settingsModel.GM_USER_SYSTEM_SETTINGS = liste;
                settingsModel.USER_SYSTEM_SETTING = context.GM_USER_SYSTEM_SETTINGS.FirstOrDefault(a => a.MAGAZA_ID == magazaID);
                GM_USER_SYSTEM_SETTINGS liste2 = new GM_USER_SYSTEM_SETTINGS();
                
                STOK_KODU.Add(settingsModel.USER_SYSTEM_SETTING.STOK_KODU);
                STOK_ADI.Add(settingsModel.USER_SYSTEM_SETTING.STOK_ADI);
                STOK_ACIKLAMASI.Add(settingsModel.USER_SYSTEM_SETTING.STOK_ACIKLAMASI);
                STOK_FIYAT.Add(settingsModel.USER_SYSTEM_SETTING.STOK_FIYAT.ToString());
                STOK_ADEDI.Add(settingsModel.USER_SYSTEM_SETTING.STOK_ADEDI.ToString());
                STOK_AKTIF_PASIF.Add(settingsModel.USER_SYSTEM_SETTING.STOK_AKTIF_PASIF.ToString());
                SELLER_STOK_KODU.Add(settingsModel.USER_SYSTEM_SETTING.SELLER_STOK_KODU);
                N11_KATALOG_ID.Add(settingsModel.USER_SYSTEM_SETTING.N11_KATALOG_ID);
                HEPSIBURADA_SKU.Add(settingsModel.USER_SYSTEM_SETTING.HEPSIBURADA_SKU);
                MARKA.Add(settingsModel.USER_SYSTEM_SETTING.MARKA);
                RESIM_URL1.Add(settingsModel.USER_SYSTEM_SETTING.RESIM_URL1);
                RESIM_URL2.Add(settingsModel.USER_SYSTEM_SETTING.RESIM_URL2);
                RESIM_URL3.Add(settingsModel.USER_SYSTEM_SETTING.RESIM_URL3);
                RESIM_URL4.Add(settingsModel.USER_SYSTEM_SETTING.RESIM_URL4);
                RESIM_URL5.Add(settingsModel.USER_SYSTEM_SETTING.RESIM_URL5);




                SqlConnection con = new SqlConnection("Server=" + settingsModel.USER_SYSTEM_SETTING.SERVER_URL.ToString() + ";Database=" + settingsModel.USER_SYSTEM_SETTING.DBNAME.ToString() + ";User Id=" + settingsModel.USER_SYSTEM_SETTING.USER_NAME.ToString() + ";Password=" + settingsModel.USER_SYSTEM_SETTING.USER_PASSWORD.ToString() + "; connection timeout=3;");
                con.Open();
                SqlDataReader reader = new SqlCommand("SELECT COLUMN_NAME as KAYNAK FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'" + settingsModel.USER_SYSTEM_SETTING.TABLO_VIEW_ISMI + "'", con)
                {
                    CommandTimeout = 0x112a880
                }.ExecuteReader();
                while (reader.Read())
                {
                    if (reader["KAYNAK"].ToString()!= "STOK_KODU" || settingsModel.USER_SYSTEM_SETTING.STOK_KODU == null)                    
                        STOK_KODU.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "STOK_ADI" || settingsModel.USER_SYSTEM_SETTING.STOK_ADI ==null)
                        STOK_ADI.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "STOK_ACIKLAMASI" || settingsModel.USER_SYSTEM_SETTING.STOK_ACIKLAMASI == null)
                        STOK_ACIKLAMASI.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "STOK_FIYAT" || settingsModel.USER_SYSTEM_SETTING.STOK_FIYAT == null)
                        STOK_FIYAT.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "STOK_ADEDI" || settingsModel.USER_SYSTEM_SETTING.STOK_ADEDI == null)
                        STOK_ADEDI.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "STOK_AKTIF_PASIF" || settingsModel.USER_SYSTEM_SETTING.STOK_AKTIF_PASIF == null)
                        STOK_AKTIF_PASIF.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "SELLER_STOK_KODU" || settingsModel.USER_SYSTEM_SETTING.SELLER_STOK_KODU == null)
                        SELLER_STOK_KODU.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "N11_KATALOG_ID" || settingsModel.USER_SYSTEM_SETTING.N11_KATALOG_ID == null)
                        N11_KATALOG_ID.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "HEPSIBURADA_SKU" || settingsModel.USER_SYSTEM_SETTING.HEPSIBURADA_SKU == null)
                        HEPSIBURADA_SKU.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "MARKA" || settingsModel.USER_SYSTEM_SETTING.MARKA == null)
                        MARKA.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "RESIM_URL1" || settingsModel.USER_SYSTEM_SETTING.RESIM_URL1 == null)
                        RESIM_URL1.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "RESIM_URL2" || settingsModel.USER_SYSTEM_SETTING.RESIM_URL2 == null)
                        RESIM_URL2.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "RESIM_URL3" || settingsModel.USER_SYSTEM_SETTING.RESIM_URL3 == null)
                        RESIM_URL3.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "RESIM_URL4" || settingsModel.USER_SYSTEM_SETTING.RESIM_URL4 == null)
                        RESIM_URL4.Add(reader["KAYNAK"].ToString());

                    if (reader["KAYNAK"].ToString() != "RESIM_URL5" || settingsModel.USER_SYSTEM_SETTING.RESIM_URL5 == null)
                        RESIM_URL5.Add(reader["KAYNAK"].ToString());
                }
                ViewBag.STOK_KODU = STOK_KODU;
                ViewBag.STOK_ADI = STOK_ADI;
                ViewBag.STOK_ACIKLAMASI = STOK_ACIKLAMASI;
                ViewBag.STOK_FIYAT = STOK_FIYAT;
                ViewBag.STOK_ADEDI = STOK_ADEDI;
                ViewBag.STOK_AKTIF_PASIF = STOK_AKTIF_PASIF;
                ViewBag.SELLER_STOK_KODU = SELLER_STOK_KODU;
                ViewBag.N11_KATALOG_ID = N11_KATALOG_ID;
                ViewBag.HEPSIBURADA_SKU = HEPSIBURADA_SKU;
                ViewBag.MARKA = MARKA;
                ViewBag.RESIM_URL1 = RESIM_URL1;
                ViewBag.RESIM_URL2 = RESIM_URL2;
                ViewBag.RESIM_URL3 = RESIM_URL3;
                ViewBag.RESIM_URL4 = RESIM_URL4;
                ViewBag.RESIM_URL5 = RESIM_URL5;
                con.Close();
            }
            catch (Exception ex)
            {
                ErrorMessages error = new ErrorMessages();
                TempData["alertMessage"] = error.GetErrorMessages("GET_SYSTEM_USER_SETTINGS") + " " + ex.Message;
            }
        }






    }
}