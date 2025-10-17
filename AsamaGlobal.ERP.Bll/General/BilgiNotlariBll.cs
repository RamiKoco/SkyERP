using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;

namespace AsamaGlobal.ERP.Bll.General
{
    public class YorumlarBll : BaseHareketBll<Yorumlar, ERPContext>, IBaseHareketSelectBll<Yorumlar>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<Yorumlar, bool>> filter)
        {
            return List(filter, x => new YorumlarL
            {
                Id = x.Id,
                TahakkukId = x.TahakkukId,
                KisiId = x.KisiId,
                PersonelId=x.PersonelId,
                CarilerId = x.CarilerId,
                CariSubelerId = x.CariSubelerId,
                Tarih = x.Tarih,
                BilgiNotu = x.BilgiNotu             

            }).ToList();
        }

    }
}
