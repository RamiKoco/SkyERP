using System.ComponentModel.DataAnnotations;
using AbcYazilim.OgrenciTakip.Common.Enums;

namespace AbcYazilim.OgrenciTakip.Model.Entities
{
    public class EtiketKayitTuruBaglanti
    {
        [Key]
        public long Id { get; set; }

        public long EtiketId { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public long KayitId { get; set; }

    }
} 