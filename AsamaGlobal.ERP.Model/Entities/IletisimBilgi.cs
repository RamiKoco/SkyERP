using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.Base;

namespace AbcYazilim.OgrenciTakip.Model.Entities
{
    public class IletisimBilgi : BaseHareketEntity
    {
        public long? KisiId { get; set; }
        public long? PersonelId { get; set; }
        public long IletisimlerId { get; set; }
        public bool Veli { get; set; }
        public IletisimTuru? IletisimTuru { get; set; }
        public Iletisimler Iletisimler { get; set; }
    }
}
