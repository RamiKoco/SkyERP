using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;

namespace AbcYazilim.OgrenciTakip.Model.Entities
{
    public class AdresHareketleri : BaseHareketEntity
    {
        public long? KisiId { get; set; }
        public long? PersonelId { get; set; }
        public long AdresBilgileriId { get; set; }
        public long GenelAdresId { get; set; }
        public GenelAdres GenelAdres { get; set; }
    }
}
