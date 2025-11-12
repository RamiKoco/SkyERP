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
    public class GenelIletisimBll : BaseGenelBll<GenelIletisim>, IBaseGenelBll, IBaseCommonBll
    {
        public GenelIletisimBll() : base(KartTuru.GenelIletisim) { }
        public GenelIletisimBll(Control ctrl) : base(ctrl, KartTuru.GenelIletisim) { }
        public override BaseEntity Single(Expression<Func<GenelIletisim, bool>> filter)
        {
            return BaseSingle(filter, x => new GenelIletisimS
            {

                Id = x.Id,
                Kod = x.Kod,
                KayitTuru = x.KayitTuru,
                IletisimTuru = x.IletisimTuru,
                IzinDurumu = x.IzinDurumu,
                IletisimKanalTipi = x.IletisimKanalTipi,
                Kanallar = x.Kanallar,
                Arama = x.Arama,
                Sms = x.Sms,
                Whatsapp = x.Whatsapp,
                EPBool = x.EPBool,
                VarsayilanYap = x.VarsayilanYap,
                Baslik = x.Baslik,
                UlkeKodu = x.UlkeKodu,
                Numara = x.Numara,
                DahiliNo = x.DahiliNo,
                EPosta = x.EPosta,
                KullaniciAdi = x.KullaniciAdi,
                SosyalMedyaUrl = x.SosyalMedyaUrl,
                SIPKullaniciAdi = x.SIPKullaniciAdi,
                SIPServer = x.SIPServer,
                Ilgili = x.Ilgili,
                Oncelik = x.Oncelik,
                VoipMi = x.VoipMi,
                KisiId = x.KisiId,
                PersonelId = x.PersonelId,
                MeslekId = x.MeslekId,
                CarilerId = x.CarilerId,
                CariSubelerId = x.CariSubelerId,
                SosyalMedyaPlatformuId = x.SosyalMedyaPlatformuId,
                SosyalMedyaPlatformuAdi = x.SosyalMedyaPlatformu.Ad,
                IzinTarihi = x.IzinTarihi,
                Web = x.Web,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
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
        public override IEnumerable<BaseEntity> List(Expression<Func<GenelIletisim, bool>> filter)
        {
            return BaseList(filter, x => new GenelIletisimL
            {
                Id = x.Id,
                Kod = x.Kod,
                Baslik = x.Baslik,
                KayitTuru = x.KayitTuru,
                IletisimTuru = x.IletisimTuru,
                UlkeKodu = x.UlkeKodu,
                Numara = x.Numara,
                DahiliNo = x.DahiliNo,
                EPosta = x.EPosta,
                KullaniciAdi = x.KullaniciAdi,
                SosyalMedyaUrl = x.SosyalMedyaUrl,
                SIPKullaniciAdi = x.SIPKullaniciAdi,
                SIPServer = x.SIPServer,
                Ilgili = x.Ilgili,
                Oncelik = x.Oncelik,
                VoipMi = x.VoipMi,
                IzinDurumu = x.IzinDurumu,
                IletisimKanalTipi = x.IletisimKanalTipi,
                Kanallar = x.Kanallar,
                Arama = x.Arama,
                Sms = x.Sms,
                Whatsapp = x.Whatsapp,
                EPBool = x.EPBool,
                VarsayilanYap = x.VarsayilanYap,
                SosyalMedyaPlatformuAdi = x.SosyalMedyaPlatformu.Ad,
                IzinTarihi = x.IzinTarihi,
                Web = x.Web,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,                
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
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
