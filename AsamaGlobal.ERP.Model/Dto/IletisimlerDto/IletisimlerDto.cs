using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbcYazilim.OgrenciTakip.Model.Dto.IletisimlerDto
{
    [NotMapped]
    public class IletisimlerS : Iletisimler
    {
        public string KisiAdi { get; set; }
        public string PersonelAdi { get; set; }
        public string MeslekAdi { get; set; }
        public string KayitHesabiAdi
        {
            get
            {
                if (KayitTuru == KayitTuru.Kisi)
                    return KisiAdi;
                else if (KayitTuru == KayitTuru.Personel)
                    return PersonelAdi;
                else if (KayitTuru == KayitTuru.Meslek)
                    return MeslekAdi;
                else
                    return null;
            }
        }
        public string SosyalMedyaPlatformuAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }

    public class IletisimlerL : BaseEntity
    {
        public string KisiAdi { get; set; }
        public string PersonelAdi { get; set; }
        public string MeslekAdi { get; set; }
        public IletisimTuru IletisimTuru { get; set; }
        public IletisimDurumu IzinDurumu { get; set; }
        public IletisimKanalTipi IletisimKanalTipi { get; set; }
        public string Kanallar { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public string KayitHesabiAdi
        {
            get
            {
                if (KayitTuru == KayitTuru.Kisi)
                    return KisiAdi;
                else if (KayitTuru == KayitTuru.Personel)
                    return PersonelAdi;
                else if (KayitTuru == KayitTuru.Meslek)
                    return MeslekAdi;
                else
                    return null;
            }
        }
        public string Baslik { get; set; }
        public string UlkeKodu { get; set; }
        public string Numara { get; set; }
        public string DahiliNo { get; set; }
        public string EPosta { get; set; }
        public DateTime? IzinTarihi { get; set; }
        public string KullaniciAdi { get; set; }
        public string SosyalMedyaUrl { get; set; }
        public string SIPKullaniciAdi { get; set; }
        public string SIPServer { get; set; }
        public string Ilgili { get; set; }
        public short Oncelik { get; set; }
        public bool VoipMi { get; set; }
        public bool VarsayilanMi { get; set; }
        public bool AramaAktifMi { get; set; }
        public bool SmsAktifMi { get; set; }
        public bool WhatsAppAktifMi { get; set; }
        public bool EmailAktifMi { get; set; }
        public string Web { get; set; }
        public string SosyalMedyaPlatformuAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string Aciklama { get; set; }
    }
}
