using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Common.Enums;
using System.Windows.Forms;

namespace AbcYazilim.OgrenciTakip.Bll.General
{
    public class KayitKaynakBll : BaseGenelBll<KayitKaynak>, IBaseGenelBll, IBaseCommonBll
    {
        public KayitKaynakBll() : base(KartTuru.KayitKaynak) { }
        public KayitKaynakBll(Control ctrl) : base(ctrl, KartTuru.KayitKaynak) { }
    }
}
