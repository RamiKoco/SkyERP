using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Dto.KisiDto;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.KisiEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AsamaGlobal.ERP.Bll.General.KisiBll
{
    public class CariKayitTuruBaglantiBll : BaseHareketBll<CariKayitTuruBaglanti, ERPContext>, IBaseHareketSelectBll<CariKayitTuruBaglanti>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<CariKayitTuruBaglanti, bool>> filter)
        {
            return List(filter, x => new CariKayitTuruBaglantiL
            {
                Id = x.Id,
                KayitId = x.KayitId,
                KayitTuru = x.KayitTuru,
                Kod = x.Cariler.Kod,
                PozisyonId = x.PozisyonId,
                PozisyonAdi = x.Pozisyon.Ad,
                CarilerId = x.CarilerId,
                CarilerAdi = x.Cariler.Unvan,
                Aciklama = x.Aciklama,

            }).ToList();
        }
    }
}
