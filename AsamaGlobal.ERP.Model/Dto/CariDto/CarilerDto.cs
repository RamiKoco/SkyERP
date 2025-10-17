using AbcYazilim.OgrenciTakip.Common.Enums;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.CariEntity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Dto.CariDto
{
    [NotMapped]
    public class CarilerS : Cariler
    {
        public string CariGrubuAdi { get; set; }
        public string CariTuruAdi { get; set; }
        public string EtiketAdi { get; set; }
        public string SektorAdi { get; set; }
        public string VergiDairesiAdi { get; set; }
        public string KayitKaynakAdi { get; set; }
        public string KimlikTuruAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string OzelKod3Adi { get; set; }
        public string OzelKod4Adi { get; set; }
        public string OzelKod5Adi { get; set; }
        //[NotMapped]
        //public List<Sektor> Sektorler { get; set; }
    }
    public class CarilerL : BaseEntity
    {
        public string Unvan { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KimlikNo { get; set; }
        public bool Sahis { get; set; }
        public string VergiNo { get; set; }      
        public string Aciklama { get; set; }
        public string EtiketAdi { get; set; }
        public string SektorAdi { get; set; }
        public string CariGrubuAdi { get; set; }
        public string CariTuruAdi { get; set; }
        public string VergiDairesiAdi { get; set; }
        public string KayitKaynakAdi { get; set; }
        public string KimlikTuruAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string OzelKod3Adi { get; set; }
        public string OzelKod4Adi { get; set; }
        public string OzelKod5Adi { get; set; }
    }
}
