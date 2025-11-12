using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using AsamaGlobal.ERP.Model.Entities.KisiEntity;
using DevExpress.DataAccess.ObjectBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Dto.KisiDto
{
    [NotMapped]
    public class CariKayitTuruBaglantiL: CariKayitTuruBaglanti, IBaseHareketEntity
    {
        public string CarilerAdi { get; set; }
        public string Kod { get; set; }
        public string PozisyonAdi { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }

    [HighlightedClass]
    public class CariKayitTuruBaglantiR
    {
        public string Kod { get; set; }
        public string CarilerAdi { get; set; }
        public string PozisyonAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
