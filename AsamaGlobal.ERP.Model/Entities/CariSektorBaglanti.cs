using AbcYazilim.OgrenciTakip.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace AsamaGlobal.ERP.Model.Entities
{
    public class CariSektorBaglanti
    {
        [Key]
        public long Id { get; set; }

        public long SektorId { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public long KayitId { get; set; }
        public Sektor Sektor { get; set; }
    }
}
