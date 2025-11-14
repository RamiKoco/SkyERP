using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace AbcYazilim.OgrenciTakip.Model.Entities
{
    public class Etiket : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(80), ZorunluAlan("Etiket Adı", "txtEtiketAdi")]
        public string Ad { get; set; }
        [Required, ZorunluAlan("Kayıt Türü", "txtKayitTuru")]
        public KayitTuru? KayitTuru { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
        public int YaziRgbKodu { get; set; } = Color.Black.ToArgb();
        public long? RenkId { get; set; }
        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }

        public Renk Renk { get; set; }
        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }

    }
}
