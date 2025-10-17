using AbcYazilim.OgrenciTakip.Common.Enums;
using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Entities
{
    public class Sektor : BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }
        [Required, StringLength(50), ZorunluAlan("Ad", "txtAd")]
        public string Ad { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public string Aciklama { get; set; }     
    }
}