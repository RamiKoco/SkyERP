using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace AbcYazilim.OgrenciTakip.Bll.General
{
    public class RenkBll : BaseGenelBll<Renk>, IBaseGenelBll, IBaseCommonBll
    {
        public RenkBll() : base(KartTuru.Renk) { }
        public RenkBll(Control ctrl) : base(ctrl, KartTuru.Renk) { }

        public override BaseEntity Single(Expression<Func<Renk, bool>> filter)
        {
            return BaseSingle(filter, x => new RenkS
            {
                Id = x.Id,
                Kod = x.Kod,
                RenkAdi = x.RenkAdi,
                RGB = x.RGB,
                ForeColor = x.ForeColor,
                Aciklama = x.Aciklama,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Renk, bool>> filter)
        {
            return BaseList(filter, x => new RenkL
            {
                Id = x.Id,
                Kod = x.Kod,
                RenkAdi = x.RenkAdi,
                RGB = x.RGB,
                ForeColor = x.ForeColor,
                Aciklama = x.Aciklama,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,

            }).OrderBy(x => x.Kod).ToList();
        }

    }
}
