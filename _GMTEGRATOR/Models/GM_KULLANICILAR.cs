//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace _GMTEGRATOR.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class GM_KULLANICILAR
    {
        public int id { get; set; }
        public string KULLANICI_ADI_SOYADI { get; set; }
        public string KULLANICI_MAIL { get; set; }
        public string MAGAZA_ADI { get; set; }
        public Nullable<int> MAGAZA_ID { get; set; }
        public string KULLANICI_SIFRE { get; set; }
        public string KULLANICI_YETKI { get; set; }
        public Nullable<bool> KULLANICI_AKTIF { get; set; }
    }
}
