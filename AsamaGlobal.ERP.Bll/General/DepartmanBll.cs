using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Common.Enums;
using System.Windows.Forms;

namespace AbcYazilim.OgrenciTakip.Bll.General
{
    public class DepartmanBll : BaseGenelBll<Departman>, IBaseGenelBll, IBaseCommonBll
    {
        public DepartmanBll() : base(KartTuru.Departman) { }
        public DepartmanBll(Control ctrl) : base(ctrl, KartTuru.Departman) { }
    }
}
