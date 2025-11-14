using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbcYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class KimlikTuruS : KimlikTuru
    {
        public string UlkeAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }

    }
    public class KimlikTuruL : BaseEntity
    {
        public string Ad { get; set; }
        public string UlkeAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string Aciklama { get; set; }
        public string KarakterTipi { get; set; }
        public int Uzunluk { get; set; }
    }
}
