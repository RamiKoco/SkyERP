using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.Linq.Expressions;
using System.Windows.Forms;
using System;

namespace AsamaGlobal.ERP.Bll.General
{
    public class KurumBilgileriBll : BaseGenelBll<KurumBilgileri>, IBaseGenelBll, IBaseCommonBll
    {
        public KurumBilgileriBll(Control ctrl) : base(ctrl) { }

        public override BaseEntity Single(Expression<Func<KurumBilgileri, bool>> filter)
        {
            return BaseSingle(filter, x => new KurumBilgileriS
            {
                Id = x.Id,
                Kod = x.Kod,
                KurumAdi = x.KurumAdi,
                VergiDairesi = x.VergiDairesi,
                VergiNo = x.VergiNo,
                IlId = x.IlId,
                IlAdi = x.Il.Ad,
                IlceId = x.IlceId,
                IlceAdi = x.Ilce.Ad

            });
        }
    }
}
