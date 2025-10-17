using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariTurleri;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.Bll.General.CarilerBll.CariTurleriBll
{
    public class CariTuruBll : BaseGenelBll<CariTuru>, IBaseGenelBll, IBaseCommonBll
    {
        public CariTuruBll() : base(KartTuru.CariTuru) { }
        public CariTuruBll(Control ctrl) : base(ctrl, KartTuru.CariTuru) { }
    }
}
