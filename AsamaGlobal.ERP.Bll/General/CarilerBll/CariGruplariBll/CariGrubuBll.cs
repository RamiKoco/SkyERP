using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariGrublari;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.Bll.General.CarilerBll.CariGruplariBll
{
    public class CariGrubuBll : BaseGenelBll<CariGrubu>, IBaseGenelBll, IBaseCommonBll
    {
        public CariGrubuBll() : base(KartTuru.CariGrubu) { }
        public CariGrubuBll(Control ctrl) : base(ctrl, KartTuru.CariGrubu) { }
        public override BaseEntity Single(Expression<Func<CariGrubu, bool>> filter)
        {
            return BaseSingle(filter, x => new CariGrubuS
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
        public override IEnumerable<BaseEntity> List(Expression<Func<CariGrubu, bool>> filter)
        {
            return BaseList(filter, x => new CariGrubuL
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
