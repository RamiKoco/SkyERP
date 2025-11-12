using AsamaGlobal.ERP.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.CariEntity;
using System.ComponentModel.DataAnnotations;

namespace AsamaGlobal.ERP.Model.Entities.KisiEntity
{
    public class CariKayitTuruBaglanti : BaseHareketEntity
    {
        public long KayitId { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public long? CarilerId { get; set; }
        public long? PozisyonId { get; set; }

        [StringLength(200)]
        public string Aciklama { get; set; }

        public Cariler Cariler { get; set; }
        public Pozisyon Pozisyon { get; set; }
    }
}
