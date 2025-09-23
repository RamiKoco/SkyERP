using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariSube;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Entities.CariEntity
{
    public class Cariler : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("Cari Adı", "txtCariAdi")]
        public string CariAdi { get; set; }
        [StringLength(30)]
        public string Unvan { get; set; }
        [StringLength(14)]
        public string KimlikNo { get; set; }
        [Required, StringLength(30), ZorunluAlan("Adı", "txtAdi")]
        public string Ad { get; set; }
        [Required, StringLength(30), ZorunluAlan("SoyAdı", "txtSoyAdi")]
        public string Soyad { get; set; }
        //[StringLength(50)]
        //public string VergiDairesi { get; set; }
        [StringLength(20)]
        public string VergiNo { get; set; }
        [StringLength(20)]
        public string VergiKodu { get; set; }
        [StringLength(20)]
        public string YetkiKodu { get; set; }
        [StringLength(20)]
        public string HesapKodu { get; set; }
        [StringLength(20)]
        public string ProjeKodu { get; set; }
        public bool Sahis { get; set; }
        [StringLength(500)]
        public string Aciklama { get; set; }
        public long? VergiDairesiId { get; set; }
        public long? KimlikTuruId { get; set; }
        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }
        public long? OzelKod3Id { get; set; }
        public long? OzelKod4Id { get; set; }
        public long? OzelKod5Id { get; set; }

        public VergiDairesi VergiDairesi { get; set; }
        public KimlikTuru KimlikTuru { get; set; }
        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }
        public OzelKod OzelKod3 { get; set; }
        public OzelKod OzelKod4 { get; set; }
        public OzelKod OzelKod5 { get; set; }

        [InverseProperty("Cariler")]
        public ICollection<CariSubeler> CariSubeler { get; set; } 
    }
}
