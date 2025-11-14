using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities.Base;

namespace AsamaGlobal.ERP.Model.Entities
{
   public class Ilce:BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)] 
        public override string Kod { get; set; }
        
        [Required,StringLength(50), ZorunluAlan("İlçe Adı", "txtIlceAdi")]
        public string Ad { get; set; }
        public long IlId { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
        public Il Il { get; set; }
    }
}
