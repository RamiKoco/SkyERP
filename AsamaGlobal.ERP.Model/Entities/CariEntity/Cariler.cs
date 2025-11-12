using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariGrublari;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariSube;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariTurleri;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Entities.CariEntity
{
    public class Cariler : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [StringLength(30), ZorunluAlan("Ünvan", "txtUnvan")]
        public string Unvan { get; set; }
        [StringLength(14)]
        public string KimlikNo { get; set; }
        [StringLength(30)]
        public string Ad { get; set; }
        [StringLength(30)]
        public string Soyad { get; set; }
    
        [StringLength(20)]
        public string VergiNo { get; set; }
        public bool Sahis { get; set; }        
        [StringLength(500)]
        public string Aciklama { get; set; }
        public string SektorAdi { get; set; }
        public long? SektorId { get; set; }
        public long? CariGrubuId { get; set; }
        public long? CariTuruId { get; set; }
        public long? EtiketId { get; set; }
        public long? VergiDairesiId { get; set; }
        public long? KayitKaynakId { get; set; }
        public long? KimlikTuruId { get; set; }
        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }
        public long? OzelKod3Id { get; set; }
        public long? OzelKod4Id { get; set; }
        public long? OzelKod5Id { get; set; }
        public Sektor Sektor { get; set; }     
        public CariGrubu CariGrubu { get; set; }
        public CariTuru CariTuru { get; set; }
        public Etiket Etiket { get; set; }
        public VergiDairesi VergiDairesi { get; set; }
        public KayitKaynak KayitKaynak { get; set; }
        public KimlikTuru KimlikTuru { get; set; }
        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }
        public OzelKod OzelKod3 { get; set; }
        public OzelKod OzelKod4 { get; set; }
        public OzelKod OzelKod5 { get; set; }

        [InverseProperty("Cariler")]
        public ICollection<CariSubeler> CariSubeler { get; set; }
        [NotMapped]
        //[InverseProperty("Cariler")]
        public List<long> SektorIdListesi { get; set; } = new List<long>();
    }
}
