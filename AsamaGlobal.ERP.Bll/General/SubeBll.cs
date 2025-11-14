using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System;
using System.Windows.Forms;
using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;

namespace AsamaGlobal.ERP.Bll.General
{
    public class SubeBll : BaseGenelBll<Sube>, IBaseGenelBll,IBaseCommonBll
    {
        public SubeBll() : base(KartTuru.Sube) { }
        public SubeBll(Control ctrl) : base(ctrl, KartTuru.Sube) { }

        public override BaseEntity Single(Expression<Func<Sube, bool>> filter)
        {
            return BaseSingle(filter, x => new SubeS
            {
                Id = x.Id,
                Kod = x.Kod,
                SubeAdi = x.SubeAdi,
                Adres = x.Adres,
                AdresIlId = x.AdresIlId,
                AdresIlAdi = x.AdresIl.Ad,
                AdresIlceId = x.AdresIlceId,
                AdresIlceAdi = x.AdresIlce.Ad,
                Telefon = x.Telefon,
                Faks = x.Faks,
                IbanNo = x.IbanNo,
                GrupAdi = x.GrupAdi,
                SiraNo = x.SiraNo,
                Logo = x.Logo,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Sube, bool>> filter)
        {
            return BaseList(filter, x => new SubeL
            {
                Id = x.Id,
                Kod = x.Kod,
                SubeAdi = x.SubeAdi,
                Adres = x.Adres,
                AdresIlAdi = x.AdresIl.Ad,
                AdresIlceAdi = x.AdresIlce.Ad,
                Telefon = x.Telefon,
                Faks = x.Faks,
                IbanNo = x.IbanNo,
                GrupAdi = x.GrupAdi,
                SiraNo = x.SiraNo,
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
