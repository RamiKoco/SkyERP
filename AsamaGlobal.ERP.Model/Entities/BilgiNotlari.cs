using System;
using System.ComponentModel.DataAnnotations;
using AsamaGlobal.ERP.Model.Entities.Base;

namespace AsamaGlobal.ERP.Model.Entities
{
    public class Yorumlar: BaseHareketEntity
    {
        
        public long TahakkukId { get; set; }
        public long KisiId { get; set; }
        public long PersonelId { get; set; }
        public long CarilerId { get; set; }
        public long CariSubelerId { get; set; }
        public DateTime Tarih { get; set; }

        [Required,StringLength(1000)]
        public string BilgiNotu { get; set; }
       
    }
}
