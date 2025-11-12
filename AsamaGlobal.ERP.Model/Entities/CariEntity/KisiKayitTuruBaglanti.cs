using AsamaGlobal.ERP.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.KisiEntity;
using System.ComponentModel.DataAnnotations;

namespace AsamaGlobal.ERP.Model.Entities.CariEntity
{
    public class KisiKayitTuruBaglanti : BaseHareketEntity
    {
        public long KayitId { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public long? KisiId { get; set; }
        public long? PozisyonId { get; set; }

        [StringLength(200)]
        public string Aciklama { get; set; }

        public Kisi Kisi { get; set; }
        public Pozisyon Pozisyon { get; set; }
    }
}
