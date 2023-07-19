using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _GMTEGRATOR.Models
{
    public class UrunDetayDAL
    {
        public IEnumerable<HttpPostedFileBase> gorsel { get; set; }
        public IEnumerable<HttpPostedFileBase> gorsel2 { get; set; }
        public IEnumerable<HttpPostedFileBase> gorsel3 { get; set; }
        public IEnumerable<HttpPostedFileBase> gorsel4 { get; set; }
        public GM_TBLSTSABIT GM_TBLSTSABIT { get; set; }
        public GM_TBLSTRESIM GM_TBLSTRESIM { get; set; }
    }
}