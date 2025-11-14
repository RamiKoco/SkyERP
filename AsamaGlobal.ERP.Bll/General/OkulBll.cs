using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Common.Enums;
using System.Linq;
using AsamaGlobal.ERP.Bll.Interfaces;

namespace AsamaGlobal.ERP.Bll.General
{
    public class OkulBll : BaseGenelBll<Okul>, IBaseGenelBll,IBaseCommonBll
    {
        public OkulBll() : base(KartTuru.Okul) { }

        public OkulBll(Control ctrl) : base(ctrl,KartTuru.Okul) { }


        public override BaseEntity Single(Expression<Func<Okul, bool>> filter)
        {
            return BaseSingle(filter, x => new OkulS
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlId = x.IlId,
                IlAdi = x.Il.Ad,
                IlceId = x.IlceId,
                IlceAdi = x.Ilce.Ad,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Okul, bool>> filter)
        {
            return BaseList(filter, x => new OkulL
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlAdi = x.Il.Ad,
                IlceAdi = x.Ilce.Ad,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
