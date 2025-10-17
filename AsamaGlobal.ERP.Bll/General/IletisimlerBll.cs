using AbcYazilim.OgrenciTakip.Model.Dto.IletisimlerDto;
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
    public class IletisimlerBll : BaseGenelBll<Iletisimler>, IBaseGenelBll, IBaseCommonBll
    {
        public IletisimlerBll() : base(KartTuru.Iletisimler) { }
        public IletisimlerBll(Control ctrl) : base(ctrl, KartTuru.Iletisimler) { }

        public override BaseEntity Single(Expression<Func<Iletisimler, bool>> filter)
        {
            return BaseSingle(filter, x => new IletisimlerS
            {
                Id = x.Id,
                Kod = x.Kod,
                Baslik = x.Baslik,
                KayitTuru = x.KayitTuru,
                IletisimTuru = x.IletisimTuru,
                IzinDurumu = x.IzinDurumu,
                IletisimKanalTipi = x.IletisimKanalTipi,
                Kanallar = x.Kanallar,
                KisiId = x.KisiId,
                KisiAdi = x.Kisi.Ad,
                PersonelId = x.PersonelId,
                PersonelAdi = x.Personel.Ad,
                MeslekId = x.MeslekId,
                MeslekAdi = x.Meslek.MeslekAdi,
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
                VarsayilanMi = x.VarsayilanMi,
                AramaAktifMi = x.AramaAktifMi,
                SmsAktifMi = x.SmsAktifMi,
                WhatsAppAktifMi = x.WhatsAppAktifMi,
                EmailAktifMi = x.EmailAktifMi,
                SosyalMedyaPlatformuId = x.SosyalMedyaPlatformuId,
                SosyalMedyaPlatformuAdi = x.SosyalMedyaPlatformu.Ad,
                IzinTarihi = x.IzinTarihi,
                Web = x.Web,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum
            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Iletisimler, bool>> filter)
        {
            return BaseList(filter, x => new IletisimlerL
            {
                Id = x.Id,
                Kod = x.Kod,
                Baslik = x.Baslik,
                IletisimTuru = x.IletisimTuru,
                KayitTuru = x.KayitTuru,
                KisiAdi = x.Kisi.Ad,
                PersonelAdi = x.Personel.Ad,
                MeslekAdi = x.Meslek.MeslekAdi,
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
                VarsayilanMi = x.VarsayilanMi,
                IzinDurumu = x.IzinDurumu,
                IletisimKanalTipi = x.IletisimKanalTipi,
                Kanallar = x.Kanallar,
                AramaAktifMi = x.AramaAktifMi,
                SmsAktifMi = x.SmsAktifMi,
                WhatsAppAktifMi = x.WhatsAppAktifMi,
                EmailAktifMi = x.EmailAktifMi,
                SosyalMedyaPlatformuAdi = x.SosyalMedyaPlatformu.Ad,
                IzinTarihi = x.IzinTarihi,
                Web = x.Web,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
