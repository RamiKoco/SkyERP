using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.PersonelEntity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Entities.KisiEntity
{
    public class Kisi : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(30), ZorunluAlan("Adı", "txtAdi")]
        public string Ad { get; set; }

        [Required, StringLength(30), ZorunluAlan("SoyAdı", "txtSoyAdi")]
        public string Soyad { get; set; }
        public Cinsiyet Cinsiyet { get; set; } = Cinsiyet.Erkek;
        public KayitTuru KayitTuru { get; set; } = KayitTuru.Kisi;
        [Column(TypeName = "date")]
        public DateTime? DogumTarihi { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
 
        public long? EtiketId { get; set; }
        public long? KisiGrubuId { get; set; }
        public long? PersonelId { get; set; }
        public long? KayitKaynakId { get; set; }
        public long? MeslekId { get; set; }
        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }

        public Etiket Etiket { get; set; }
        public KisiGrubu KisiGrubu { get; set; }
        public Personel Personel { get; set; }
        public KayitKaynak KayitKaynak { get; set; }
        public Meslek Meslek { get; set; }
        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }

    }
}
