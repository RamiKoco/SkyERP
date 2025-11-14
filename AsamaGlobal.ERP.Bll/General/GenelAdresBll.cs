using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;
namespace AsamaGlobal.ERP.Bll.General
{
    public class GenelAdresBll : BaseGenelBll<GenelAdres>, IBaseGenelBll, IBaseCommonBll
    {
        public GenelAdresBll() : base(KartTuru.GenelAdres) { }
        public GenelAdresBll(Control ctrl) : base(ctrl, KartTuru.GenelAdres) { }
        public override BaseEntity Single(Expression<Func<GenelAdres, bool>> filter)
        {
            return BaseSingle(filter, x => new GenelAdresS
            {
                Id = x.Id,
                Kod = x.Kod,
                KayitTuru = x.KayitTuru,
                Baslik = x.Baslik,
                AdresTipi = x.AdresTipi,
                AdresNotu = x.AdresNotu,
                Adres = x.Adres,
                Aciklama = x.Aciklama,
                PostaKodu = x.PostaKodu,
                Enlem = x.Enlem ?? 0,
                Boylam = x.Boylam ?? 0,
                VarsayilanMi = x.VarsayilanMi,
                VarsayilanFaturaMi = x.VarsayilanFaturaMi,
                VarsayilanSevkiyatMi = x.VarsayilanSevkiyatMi,
                UlkeId = x.UlkeId,
                UlkeAdi = x.Ulke.UlkeAdi,
                IlId = x.IlId,
                IlAdi = x.Il.Ad,
                IlceId = x.IlceId,
                IlceAdi = x.Ilce.Ad,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                AdresTurleriId = x.AdresTurleriId,
                AdresTurleriAdi = x.AdresTurleri.Ad,
                KisiId = x.KisiId,
                PersonelId = x.PersonelId,
                MeslekId = x.MeslekId,
                CarilerId = x.CarilerId,
                CariSubelerId = x.CariSubelerId,             
                Durum = x.Durum,
                AnaKayitId = x.AnaKayitId,
                KayitId = x.KayitId,
                KayitHesabiAdi =
                    x.KayitTuru == KayitTuru.Kisi ? x.Kisi.Ad :
                    x.KayitTuru == KayitTuru.Personel ? x.Personel.Ad :
                    x.KayitTuru == KayitTuru.Meslek ? x.Meslek.Ad :
                    x.KayitTuru == KayitTuru.Cari ? x.Cariler.Unvan :
                    x.KayitTuru == KayitTuru.CariSube ? x.CariSubeler.Cariler.Unvan :
                    null,

                // Şube adı ayrı alınıyor
                AnaKayitHesabiAdi = x.KayitTuru == KayitTuru.CariSube ? x.CariSubeler.Ad : null,
            });
        }
        public override IEnumerable<BaseEntity> List(Expression<Func<GenelAdres, bool>> filter)
        {
            return BaseList(filter, x => new GenelAdresL
            {
                Id = x.Id,
                Kod = x.Kod,
                KayitTuru = x.KayitTuru,
                Baslik = x.Baslik,
                AdresTipi = x.AdresTipi,
                AdresNotu = x.AdresNotu,
                Adres = x.Adres,
                Aciklama = x.Aciklama,
                PostaKodu = x.PostaKodu,
                Enlem = x.Enlem ?? 0,
                Boylam = x.Boylam ?? 0,
                VarsayilanMi = x.VarsayilanMi,
                VarsayilanFaturaMi = x.VarsayilanFaturaMi,
                VarsayilanSevkiyatMi = x.VarsayilanSevkiyatMi,
                UlkeAdi = x.Ulke.UlkeAdi,
                IlAdi = x.Il.Ad,
                IlceAdi = x.Ilce.Ad,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                AdresTurleriAdi = x.AdresTurleri.Ad,
                AnaKayitId = x.AnaKayitId,
                KayitId = x.KayitId,
                KayitHesabiAdi =
                x.KayitTuru == KayitTuru.Kisi ? x.Kisi.Ad :
                x.KayitTuru == KayitTuru.Personel ? x.Personel.Ad :
                x.KayitTuru == KayitTuru.Meslek ? x.Meslek.Ad :
                x.KayitTuru == KayitTuru.Cari ? x.Cariler.Unvan :
                x.KayitTuru == KayitTuru.CariSube ? (x.CariSubeler != null ? x.CariSubeler.Ad : null) :
                null,
                AnaKayitHesabiAdi =
                x.KayitTuru == KayitTuru.CariSube ? (x.CariSubeler != null && x.CariSubeler.Cariler != null ? x.CariSubeler.Cariler.Unvan : null) :
                null,

            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
