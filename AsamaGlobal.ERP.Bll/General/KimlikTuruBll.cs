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
    public class KimlikTuruBll : BaseGenelBll<KimlikTuru>, IBaseGenelBll, IBaseCommonBll
    {
        public KimlikTuruBll() : base(KartTuru.KimlikTuru) { }
        public KimlikTuruBll(Control ctrl) : base(ctrl, KartTuru.KimlikTuru) { }

        public override BaseEntity Single(Expression<Func<KimlikTuru, bool>> filter)
        {
            return BaseSingle(filter, x => new KimlikTuruS
            {

                Id = x.Id,
                Kod = x.Kod,
                KimlikAdi = x.KimlikAdi,
                UlkeId = x.UlkeId,
                UlkeAdi = x.Ulke.UlkeAdi,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                KarakterTipi = x.KarakterTipi,
                Uzunluk = x.Uzunluk,
                Durum = x.Durum

            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<KimlikTuru, bool>> filter)
        {
            return BaseList(filter, x => new KimlikTuruL
            {
                Id = x.Id,
                Kod = x.Kod,
                KimlikAdi = x.KimlikAdi,
                UlkeAdi = x.Ulke.UlkeAdi,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                KarakterTipi = x.KarakterTipi,
                Uzunluk = x.Uzunluk
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
