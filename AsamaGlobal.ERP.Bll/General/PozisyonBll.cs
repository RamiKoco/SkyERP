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
    public class PozisyonBll : BaseGenelBll<Pozisyon>, IBaseGenelBll, IBaseCommonBll
    {
        public PozisyonBll() : base(KartTuru.Pozisyon) { }
        public PozisyonBll(Control ctrl) : base(ctrl, KartTuru.Pozisyon) { }

        public override BaseEntity Single(Expression<Func<Pozisyon, bool>> filter)
        {
            return BaseSingle(filter, x => new PozisyonS
            {

                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                RenkId = x.RenkId,
                RenkAdi = x.Renk.RenkAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Pozisyon, bool>> filter)
        {
            return BaseList(filter, x => new PozisyonL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                RenkAdi = x.Renk.RenkAdi,
                Aciklama = x.Aciklama

            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
