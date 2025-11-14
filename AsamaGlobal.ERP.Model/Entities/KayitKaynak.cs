using AsamaGlobal.ERP.Model.Attributes;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbcYazilim.OgrenciTakip.Model.Entities
{
    public class KayitKaynak: BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Kaynak Adı", "txtKayitKaynakAdi")]
        public string Ad { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}
