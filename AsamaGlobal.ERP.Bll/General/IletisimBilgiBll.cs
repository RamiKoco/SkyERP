using AbcYazilim.OgrenciTakip.Model.Dto.IletisimlerDto;
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
    public class IletisimBilgiBll : BaseHareketBll<IletisimBilgi, ERPContext>, IBaseHareketSelectBll<IletisimBilgi>
    {
        public IEnumerable<BaseHareketEntity> List(Expression<Func<IletisimBilgi, bool>> filter)
        {
            return List(filter, x => new IletisimBilgiL
            {
                Id = x.Id,
                KisiId = (long)x.Iletisimler.KisiId,
                PersonelId = (long)x.Iletisimler.PersonelId,
                IletisimlerId = x.IletisimlerId,
                Baslik = x.Iletisimler.Baslik,
                UlkeKodu = x.Iletisimler.UlkeKodu,
                Numara = x.Iletisimler.Numara,
                DahiliNo = x.Iletisimler.DahiliNo,
                EPosta = x.Iletisimler.EPosta,
                Kanallar = x.Iletisimler.Kanallar,
                KullaniciAdi = x.Iletisimler.KullaniciAdi,
                SosyalMedyaUrl = x.Iletisimler.SosyalMedyaUrl,
                SIPKullaniciAdi = x.Iletisimler.SIPKullaniciAdi,
                SIPServer = x.Iletisimler.SIPServer,
                Ilgili = x.Iletisimler.Ilgili,
                Oncelik = x.Iletisimler.Oncelik,
                VoipMi = x.Iletisimler.VoipMi,
                VarsayilanMi = x.Iletisimler.VarsayilanMi,
                AramaAktifMi = x.Iletisimler.AramaAktifMi,
                SmsAktifMi = x.Iletisimler.SmsAktifMi,
                WhatsAppAktifMi = x.Iletisimler.WhatsAppAktifMi,
                EmailAktifMi = x.Iletisimler.EmailAktifMi,
                Web = x.Iletisimler.Web,
                Aciklama = x.Iletisimler.Aciklama,
                IletisimTuruAdi = x.Iletisimler.IletisimTuru,
                SosyalMedyaPlatformuAdi = x.Iletisimler.SosyalMedyaPlatformu.Ad,
                IzinTarihi = x.Iletisimler.IzinTarihi,
                IzinDurumu = x.Iletisimler.IzinDurumu,
                Veli = x.Veli,
                IletisimTuru = x.IletisimTuru

            }).ToList();
        }
    }
}
