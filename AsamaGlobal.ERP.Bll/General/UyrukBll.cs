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
    public class UyrukBll : BaseGenelBll<Uyruk>, IBaseGenelBll, IBaseCommonBll
    {
        public UyrukBll() : base(KartTuru.Uyruk) { }
        public UyrukBll(Control ctrl) : base(ctrl, KartTuru.Uyruk) { }

        public override BaseEntity Single(Expression<Func<Uyruk, bool>> filter)
        {
            return BaseSingle(filter, x => new UyrukS
            {

                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                UlkeId = x.UlkeId,
                UlkeAdi = x.Ulke.UlkeAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Uyruk, bool>> filter)
        {
            return BaseList(filter, x => new UyrukL
            {
                Id = x.Id,
                Kod = x.Kod,
                Ad = x.Ad,
                UlkeAdi = x.Ulke.UlkeAdi,
                Aciklama = x.Aciklama

            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
