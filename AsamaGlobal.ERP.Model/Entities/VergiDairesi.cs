using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Entities
{
    public class VergiDairesi : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true), ZorunluAlan("Vergi Dairesi Kodu", "txtKod")]
        [Column("VergiDairesiKodu")]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Vergi Dairesi Adı", "txtAd")]
        public string Ad { get; set; }

        [ZorunluAlan("İl Adı", "txtIl")]
        public long IlId { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public Il Il { get; set; }

    }
}