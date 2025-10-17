using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.Bll.General
{
    public class SektorBll : BaseGenelBll<Sektor>, IBaseGenelBll, IBaseCommonBll
    {
        public SektorBll() : base(KartTuru.Sektor) { }
        public SektorBll(Control ctrl) : base(ctrl, KartTuru.Sektor) { }

        public List<Sektor> ListSimple()
        {
            using (var context = new ERPContext())
            {
                return context.Sektor
                              .OrderBy(x => x.Ad)
                              .ToList();
            }
        }
    }
}
