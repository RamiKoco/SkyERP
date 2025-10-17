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
    public class EtiketBll : BaseGenelBll<Etiket>, IBaseGenelBll, IBaseCommonBll
    {
        public EtiketBll() : base(KartTuru.Etiket) { }
        public EtiketBll(Control ctrl) : base(ctrl, KartTuru.Etiket) { }

        public override BaseEntity Single(Expression<Func<Etiket, bool>> filter)
        {
            return BaseSingle(filter, x => new EtiketS
            {
                Id = x.Id,
                Kod = x.Kod,
                EtiketAdi = x.EtiketAdi,
                KayitTuru = x.KayitTuru,
                Aciklama = x.Aciklama,
                RenkId = x.RenkId,
                RenkAdi = x.Renk.RenkAdi,
                RenkRGB = x.Renk != null ? x.Renk.RGB : null,
                RenkForeColor = x.Renk != null ? x.Renk.ForeColor : (int?)null,
                YaziRgbKodu = x.YaziRgbKodu,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Etiket, bool>> filter)
        {
            return BaseList(filter, x => new EtiketL
            {
                Id = x.Id,
                Kod = x.Kod,
                EtiketAdi = x.EtiketAdi,
                KayitTuru = x.KayitTuru,
                Aciklama = x.Aciklama,
                RenkAdi = x.Renk.RenkAdi,
                RenkRGB = x.Renk != null ? x.Renk.RGB : null,
                RenkForeColor = x.Renk != null ? x.Renk.ForeColor : (int?)null,
                YaziRgbKodu = x.YaziRgbKodu,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,

            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
