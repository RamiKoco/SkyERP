using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbcYazilim.OgrenciTakip.Model.Dto
{

    [NotMapped]
    public class PozisyonS : Pozisyon
    {
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string RenkAdi { get; set; }

    }

    public class PozisyonL : BaseEntity
    {
        public string Ad { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string Aciklama { get; set; }
        public string RenkAdi { get; set; }

    }
}
