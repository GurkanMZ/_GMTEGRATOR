using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _GMTEGRATOR.Models
{
    public class SystemDAL
    {


        deartech_3Entities1 context = new deartech_3Entities1();
        public void SaveDBSystemConnectionSettings(GM_USER_SYSTEM_SETTINGS user_settings)
        {
            try
            {
                var usersetting = context.GM_USER_SYSTEM_SETTINGS.FirstOrDefault(a => a.MAGAZA_ID == user_settings.MAGAZA_ID );
                if (usersetting != null)
                {
                    usersetting.USER_NAME = user_settings.USER_NAME;
                    usersetting.USER_PASSWORD = user_settings.USER_PASSWORD;
                    usersetting.SERVER_URL = user_settings.SERVER_URL;
                    usersetting.DBNAME = user_settings.DBNAME;
                    context.SaveChanges();
                }
                else
                { AddDBSystemConnectionSettings(user_settings);

                }
            }
            catch (Exception exception)
            {
                //GM_STSABITLOG gM_STSABITLOG = new GM_STSABITLOG();
                //gM_STSABITLOG.MAGAZAID = stsabit.MAGAZA_ID;
                //gM_STSABITLOG.STOK_KODU = stsabit.STOK_KODU;
                //gM_STSABITLOG.HATA = "HATA: " + exception.Message + " >>>>";
                //gM_STSABITLOG.TARIH = DateTime.Now;
                //LogTut(gM_STSABITLOG);
            }
        }


        public bool AddDBSystemConnectionSettings(GM_USER_SYSTEM_SETTINGS user_settings)
        {
            bool varyok = false;
            try
            {

                context.GM_USER_SYSTEM_SETTINGS.Add(user_settings);
                    context.SaveChanges();
                    varyok = true;
             
            }
            catch (Exception exception)
            {
                //GM_STSABITLOG gM_STSABITLOG = new GM_STSABITLOG();
                //gM_STSABITLOG.MAGAZAID = stsabit.MAGAZA_ID;
                //gM_STSABITLOG.STOK_KODU = stsabit.STOK_KODU;
                //gM_STSABITLOG.HATA = "HATA: " + exception.Message + " >>>>";
                //gM_STSABITLOG.TARIH = DateTime.Now;
                //LogTut(gM_STSABITLOG);
            }
            return varyok;
        }

    }
}