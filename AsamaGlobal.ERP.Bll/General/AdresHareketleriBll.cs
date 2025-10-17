using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AbcYazilim.OgrenciTakip.Bll.General
{
    public class AdresHareketleriBll : BaseHareketBll<AdresHareketleri, ERPContext>, IBaseHareketSelectBll<AdresHareketleri>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<AdresHareketleri, bool>> filter)
        {
            return List(filter, x => new AdresHareketleriL
            {
                Id = x.Id,
                KisiId = (long)x.AdresBilgileri.KisiId,
                PersonelId = (long)x.AdresBilgileri.PersonelId,
                AdresBilgileriId = x.AdresBilgileriId,
                Baslik = x.AdresBilgileri.Baslik,
                KayitTuru = x.AdresBilgileri.KayitTuru,
                AdresTipi = x.AdresBilgileri.AdresTipi,
                AdresNotu = x.AdresBilgileri.AdresNotu,
                Adres = x.AdresBilgileri.Adres,                
                PostaKodu = x.AdresBilgileri.PostaKodu,
                Enlem = x.AdresBilgileri.Enlem ?? 0,
                Boylam = x.AdresBilgileri.Boylam ?? 0,               
                UlkeAdi = x.AdresBilgileri.Ulke.UlkeAdi,
                IlAdi = x.AdresBilgileri.Il.IlAdi,
                IlceAdi = x.AdresBilgileri.Ilce.IlceAdi,                
                AdresTurleriAdi = x.AdresBilgileri.AdresTurleri.Ad

            }).ToList();
        }
    }
}
