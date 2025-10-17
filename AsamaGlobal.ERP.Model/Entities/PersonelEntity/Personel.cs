using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Entities.PersonelEntity
{
    public class Personel : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [StringLength(14)]
        public string KimlikNo { get; set; }

        [Required, StringLength(30), ZorunluAlan("Adı", "txtAdi")]
        public string Ad { get; set; }

        [Required, StringLength(30), ZorunluAlan("SoyAdı", "txtSoyAdi")]
        public string Soyad { get; set; }
        public Cinsiyet Cinsiyet { get; set; } = Cinsiyet.Erkek;
        public KanGrubu KanGrubu { get; set; } = KanGrubu.Bos;
        public AskerlikDurumu AskerlikDurumu { get; set; } = AskerlikDurumu.Yapildi;
        public MedeniDurum MedeniDurum { get; set; } = MedeniDurum.Bekar;

        [StringLength(30)]
        public string BabaAdi { get; set; }

        [StringLength(30)]
        public string AnaAdi { get; set; }

        [StringLength(14)]
        public string SGKSicilNo { get; set; }

        public KayitTuru KayitTuru { get; set; } = KayitTuru.Personel;

        [Column(TypeName = "date")]
        public DateTime? DogumTarihi { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }

        [Column(TypeName = "image")]
        public byte[] Resim { get; set; }

        public long? DepartmanId { get; set; }
        public long? PozisyonId { get; set; }
        public long? KimlikTuruId { get; set; }
        public long? MeslekId { get; set; }
        public long? UyrukId { get; set; }
        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }

        public Departman Departman { get; set; }
        public Pozisyon Pozisyon { get; set; }
        public KimlikTuru KimlikTuru { get; set; }
        public Meslek Meslek { get; set; }
        public Uyruk Uyruk { get; set; }
        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }

        public virtual ICollection<EtiketKayitTuruBaglanti> EtiketKayitTuruBaglanti { get; set; }
  
    }
}
