using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities.Base;

namespace AsamaGlobal.ERP.Model.Entities
{
    
   public class Il:BaseEntityDurum
    {
        [Index("IX_Kod",IsUnique = true)]
        public override string Kod { get; set; }

        [Required,StringLength(50),ZorunluAlan("İl Adı","txtIlAdi")]
        public string Ad { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        [InverseProperty("Il")]
        public ICollection<Ilce> Ilce { get; set; }
        
    }
}
