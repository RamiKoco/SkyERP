using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Dto.CariDto.CariSubeDto;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariSube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.Bll.General.CarilerBll
{
    public class CariSubelerBll : BaseGenelBll<CariSubeler>, IBaseGenelBll, IBaseCommonBll
    {
        public CariSubelerBll() : base(KartTuru.CariSubeler) { }

        public CariSubelerBll(Control ctrl) : base(ctrl, KartTuru.CariSubeler) { }

        public override BaseEntity Single(Expression<Func<CariSubeler, bool>> filter)
        {
            return BaseSingle(filter, x => new CariSubelerS
            {

                Id = x.Id,
                Kod = x.Kod,
                CariSubeAdi = x.CariSubeAdi,
                CariSubeGrubuId = x.CariSubeGrubuId,
                CariSubeGrubuAdi = x.CariSubeGrubu.Ad,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<CariSubeler, bool>> filter)
        {
            return BaseList(filter, x => new CariSubelerL
            {
                Id = x.Id,
                Kod = x.Kod,
                CariSubeAdi = x.CariSubeAdi,
                CariSubeGrubuAdi = x.CariSubeGrubu.Ad,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
