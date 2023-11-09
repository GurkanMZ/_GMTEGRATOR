using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _GMTEGRATOR.Models
{
    public class ErrorMessages
    {
        deartech_3Entities1 context = new deartech_3Entities1();
        public string GetErrorMessages(string HATA_KODU)
        {
            GM_ERROR_MESSAGES MESSAGES = context.GM_ERROR_MESSAGES.FirstOrDefault(m => m.HATA_KODU == HATA_KODU);
            string HATA_MESAJI = MESSAGES.HATA_MESAJI;
            return HATA_MESAJI;
        }
    }  
}