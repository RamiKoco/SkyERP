using AsamaGlobal.ERP.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using DevExpress.DataAccess.ObjectBinding;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbcYazilim.OgrenciTakip.Model.Dto.IletisimlerDto
{
    [NotMapped]
    public class IletisimBilgiL : IletisimBilgi, IBaseHareketEntity
    {
        public string Baslik { get; set; }
        public string UlkeKodu { get; set; }
        public string Numara { get; set; }
        public string DahiliNo { get; set; }
        public string EPosta { get; set; }
        public IletisimTuru IletisimTuruAdi { get; set; }
        public IletisimDurumu IzinDurumu { get; set; }
        public DateTime? IzinTarihi { get; set; }
        public string SosyalMedyaPlatformuAdi { get; set; }
        public string Kanallar { get; set; }
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
        public string Aciklama { get; set; }
        public string MeslekAdi { get; set; }
        public string IsyeriAdi { get; set; }
        public string GorevAdi { get; set; }
        public bool Insert { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }
    [HighlightedClass]
    public class IletisimBilgiR
    {
        public string Baslik { get; set; }
        public string UlkeKodu { get; set; }
        public string Numara { get; set; }
        public string DahiliNo { get; set; }
        public string EPosta { get; set; }
        public IletisimTuru IletisimTuru { get; set; }
        public IletisimDurumu IzinDurumu { get; set; }
        public DateTime? IzinTarihi { get; set; }
        public string SosyalMedyaPlatformuAdi { get; set; }
        public string Kanallar { get; set; }
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
        public string Aciklama { get; set; }
        public string MeslekAdi { get; set; }
        public string IsyeriAdi { get; set; }
        public string GorevAdi { get; set; }

    }
}
