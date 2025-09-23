using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Entities
{
    public class VergiDairesi : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Vergi Dairesi Adı", "txtVergiDairesiAdi")]
        public string VergiDairesiAdi { get; set; }

        [StringLength(20)]
        public string VergiKodu { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}
