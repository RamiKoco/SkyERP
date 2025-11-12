using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using AsamaGlobal.ERP.Model.Entities.CariEntity;
using DevExpress.DataAccess.ObjectBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Dto.CariDto
{
    [NotMapped]
    public class KisiKayitTuruBaglantiL : KisiKayitTuruBaglanti, IBaseHareketEntity
    {
        public string KisiAdi { get; set; }
        public string KayitHesabi { get; set; }
        public string Kod { get; set; }
        public string KodKisi { get; set; }    
        public string PozisyonAdi { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }

    [HighlightedClass]
    public class KisiKayitTuruBaglantiR
    {
        public string Kod { get; set; }
        public string KisiAdi { get; set; }
        public string KayitHesabi { get; set; }
        public string PozisyonAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
