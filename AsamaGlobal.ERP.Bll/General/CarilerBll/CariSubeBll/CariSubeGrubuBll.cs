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

namespace AsamaGlobal.ERP.Bll.General.CarilerBll.CariSubeBll
{
    public class CariSubeGrubuBll : BaseGenelBll<CariSubeGrubu>, IBaseCommonBll, IBaseGenelBll

    {
        public CariSubeGrubuBll() : base(KartTuru.CariSubeGrubu) { }
        public CariSubeGrubuBll(Control ctrl) : base(ctrl, KartTuru.CariSubeGrubu) { }
        public override BaseEntity Single(Expression<Func<CariSubeGrubu, bool>> filter)
        {
            return BaseSingle(filter, x => new CariSubeGrubuS
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<CariSubeGrubu, bool>> filter)
        {
            return BaseList(filter, x => new CariSubeGrubuL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}