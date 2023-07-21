using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _GMTEGRATOR.Models;

namespace _GMTEGRATOR.Models
{

    interface IUrunAdd
    {
        void UrunAdd(GM_TBLSTSABIT stsabit);
    }
    interface IUrunDelete
    {
        void UrunDelete(GM_TBLSTSABIT stsabit);
    }

    interface IUrunUpdate
    {
        void UrunUpdate(GM_TBLSTSABIT stsabit);
    }

    interface ILogTut
    {
        void LogTut(GM_STSABITLOG gM_STSABITLOG);
    }





    public class UrunISLEMLERI : IUrunAdd, IUrunDelete, IUrunUpdate, ILogTut
    {

        public void LogTut(GM_STSABITLOG gM_STSABITLOG)
        {

            try
            {
                deartech_3Entities context = new deartech_3Entities();
                context.GM_STSABITLOG.Add(gM_STSABITLOG);
                context.SaveChangesAsync();
            }
            catch { }
        }




        public void UrunAdd(GM_TBLSTSABIT stsabit)
        {
            deartech_3Entities context = new deartech_3Entities();
            try
            {
                var Urun = context.GM_TBLSTSABIT.FirstOrDefault(a => a.STOK_KODU == stsabit.STOK_KODU & a.MAGAZA_ID == stsabit.MAGAZA_ID);
                if (Urun ==null)
                {
                    context.GM_TBLSTSABIT.Add(stsabit);
                    context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                GM_STSABITLOG gM_STSABITLOG = new GM_STSABITLOG();
                gM_STSABITLOG.MAGAZAID = stsabit.MAGAZA_ID;
                gM_STSABITLOG.STOK_KODU = stsabit.STOK_KODU;
                gM_STSABITLOG.HATA = "HATA: " + exception.Message + " >>>>";
                gM_STSABITLOG.TARIH = DateTime.Now;
                LogTut(gM_STSABITLOG);
            }
        }

        public void UrunDelete(GM_TBLSTSABIT stsabit)
        {
            deartech_3Entities context = new deartech_3Entities();
            try
            {
                var Urun = context.GM_TBLSTSABIT.FirstOrDefault(a => a.STOK_KODU == stsabit.STOK_KODU & a.MAGAZA_ID == stsabit.MAGAZA_ID);
                if (Urun != null)
                {
                    context.GM_TBLSTSABIT.Remove(Urun);
                    context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                GM_STSABITLOG gM_STSABITLOG = new GM_STSABITLOG();
                gM_STSABITLOG.MAGAZAID = stsabit.MAGAZA_ID;
                gM_STSABITLOG.STOK_KODU = stsabit.STOK_KODU;
                gM_STSABITLOG.HATA = "HATA: " + exception.Message + " >>>>";
                gM_STSABITLOG.TARIH = DateTime.Now;
                LogTut(gM_STSABITLOG);
            }
        }



        public void UrunUpdate(GM_TBLSTSABIT stsabit)
        {
            deartech_3Entities context = new deartech_3Entities();
            try
            {
                var Urun = context.GM_TBLSTSABIT.FirstOrDefault(a => a.STOK_KODU == stsabit.STOK_KODU & a.MAGAZA_ID == stsabit.MAGAZA_ID);
                if (Urun != null)
                {
                    Urun = stsabit;
                    context.SaveChanges();
                }
            }
            catch (Exception exception)
            {
                GM_STSABITLOG gM_STSABITLOG = new GM_STSABITLOG();
                gM_STSABITLOG.MAGAZAID = stsabit.MAGAZA_ID;
                gM_STSABITLOG.STOK_KODU = stsabit.STOK_KODU;
                gM_STSABITLOG.HATA = "HATA: " + exception.Message + " >>>>";
                gM_STSABITLOG.TARIH = DateTime.Now;
                LogTut(gM_STSABITLOG);
            }
        }

    }







}
