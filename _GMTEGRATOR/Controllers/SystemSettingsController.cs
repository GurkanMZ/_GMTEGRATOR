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
                con.Close();
            }
            catch (Exception ex)
            {
                ErrorMessages error = new ErrorMessages();
                TempData["alertMessage"] = error.GetErrorMessages("GET_SYSTEM_USER_SETTINGS")+" "+ ex.Message;
            }          
        }


     




    }
}