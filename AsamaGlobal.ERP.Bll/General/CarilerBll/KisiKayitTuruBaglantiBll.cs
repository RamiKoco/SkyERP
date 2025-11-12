using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.CariEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AsamaGlobal.ERP.Bll.General.CarilerBll
{
    public class KisiKayitTuruBaglantiBll : BaseHareketBll<KisiKayitTuruBaglanti, ERPContext>, IBaseHareketSelectBll<KisiKayitTuruBaglanti>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<KisiKayitTuruBaglanti, bool>> filter)
        {
            using (var context = new ERPContext())
            {
                var list = context.Set<KisiKayitTuruBaglanti>()
                    .Where(filter)
                    .Select(x => new KisiKayitTuruBaglantiL
                    {
                        Id = x.Id,
                        KayitId = x.KayitId,
                        KayitTuru = x.KayitTuru,
                        PozisyonId = x.PozisyonId,
                        PozisyonAdi = x.Pozisyon.Ad,
                        KisiId = x.KisiId,
                        Aciklama = x.Aciklama,
                        KodKisi = x.Kisi.Kod,
                        KisiAdi = x.Kisi != null
                                ? x.Kisi.Ad + " " + (x.Kisi.Soyad ?? "")
                                : null,
                        //Kod = x.KayitId != 0 ? context.Cariler.Where(c => c.Id == x.KayitId)
                        //                .Select(c => c.Kod)
                        //                .FirstOrDefault() : null,
                        //KayitHesabi = context.Cariler
                        //        .Where(c => c.Id == x.KayitId)
                        //        .Select(c => c.Unvan)
                        //        .FirstOrDefault(),

                        Kod = x.KayitId != 0 ? context.Cariler.Where(c => c.Id == x.KayitId)
                                        .Select(c => c.Kod)
                                        .Concat(context.CariSubeler.Where(s => s.Id == x.KayitId)
                                        .Select(s => s.Kod)).FirstOrDefault() : null,
                                         KayitHesabi = context.Cariler
                                        .Where(c => c.Id == x.KayitId)
                                        .Select(c => c.Unvan)
                                        .Concat(context.CariSubeler.Where(s => s.Id == x.KayitId)
                                        .Select(s => s.Ad)).FirstOrDefault(),    
                    }).ToList();

                return list;
            }
        }
    }
}