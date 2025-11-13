using System.ComponentModel;

namespace AsamaGlobal.ERP.Common.Enums
{
    public enum KartTuru : byte
    {
        [Description("Okul Kartı")]
        Okul = 1,
        [Description("İl Kartı")]
        Il = 2,
        [Description("İlçe Kartı")]
        Ilce = 3,
        [Description("Filtre Kartı")]
        Filtre = 4,
        [Description("Aile Bilgi Kartı")]
        AileBilgi = 5,
        [Description("Iptal Nedeni Kartı")]
        IptalNedeni = 6,
        [Description("Yabancı Dil Kartı")]
        YabanciDil = 7,
        [Description("Teşvik Kartları")]
        Tesvik = 8,
        [Description("Kontenjan Kartları")]
        Kontenjan = 9,
        [Description("Rehber Kartları")]
        Rehber = 10,
        [Description("Sınıf Grup Kartları")]
        SinifGrup = 11,
        [Description("Meslek Kartı")]
        Meslek = 12,
        [Description("Yakınlık Kartı")]
        Yakinlik = 13,
        [Description("İşyeri Kartı")]
        Isyeri = 14,
        [Description("Görev Kartı")]
        Gorev= 15,
        [Description("İndirim Türü Kartı")]
        IndirimTuru = 16,
        [Description("Evrak Kartı")]
        Evrak = 17,
        [Description("Promosyon Kartı")]
        Promosyon = 18,
        [Description("Servis Yeri Kartı")]
        Servis = 19,
        [Description("Sınıf Kartı")]
        Sinif = 20,
        [Description("Hizmet Türü Kartı")]
        HizmetTuru = 21,
        [Description("Hizmet  Kartı")]
        Hizmet = 22,
        [Description("Özel Kod Kartı")]
        OzelKod=23,
        [Description("Kasa Kartı")]
        Kasa = 24,
        [Description("Banka Kartı")]
        Banka = 25,
        [Description("Banka Şube Kartı")]
        BankaSube = 26,
        [Description("Avukat Kartı")]
        Avukat = 27,
        [Description("Cari Kart2018")]
        Cari = 28,
        [Description("Ödeme Türü Kartı")]
        OdemeTuru = 29,
        [Description("Banka Hesap Kartı")]
        BankaHesap = 30,
        [Description("Iletişim Kartı")]
        Iletisim = 31,
        [Description("Öğrenci Kartı")]
        Ogrenci = 32,
        [Description("Indirim Kartı")]
        Indirim = 33,
        [Description("Tahakkuk Kartı")]
        Tahakkuk = 34,
        [Description("Makbuz Kartı")]
        Makbuz = 35,
        [Description("Belge Seçim Kartı")]
        BelgeSecim = 36,
        [Description("Belge Hareketleri")]
        BelgeHareketleri= 37,
        [Description("Rapor Kartı")]
        Rapor = 38,
        [Description("Rapor Tasarım")]
        RaporTasarim = 39,
        [Description("Öğrenci Kartı Raporu")]
        OgrenciKartiRaporu = 40,
        [Description("Banka Ödeme Planı Raporu")]
        BankaOdemePlaniRaporu = 41,
        [Description("Meb Kayıt Sözleşmesi Raporu")]
        MebKayitSozlesmesiRaporu = 42,
        [Description("İndirim Dilekçesi Raporu")]
        IndirimDilekcesiRaporu = 43,
        [Description("Kayıt Sözleşmesi Raporu")]
        KayitSozlesmesiRaporu = 44,
        [Description("Kredi Kartlı Ödeme Talimatı Raporu")]
        KrediKartliOdemeTalimatiRaporu = 45,
        [Description("Ödeme Senedi Raporu")]
        OdemeSenediRaporu = 46,
        [Description("Kullanıcı Tanımlı Rapor")]
        KullaniciTanimliRapor = 47,
        [Description("Tahsilat Makbuzu")]
        TahsilatMakbuzu = 48,
        [Description("Teslimat Makbuzu")]
        TeslimatMakbuzu = 49,
        [Description("Geri İade Makbuzu")]
        GeriIadeMakbuzu = 50,
        [Description("Genel Makbuz")]
        GenelMakbuz = 51,
        [Description("Şube Kartı")]
        Sube = 52,
        [Description("Fatura Kartı")]
        Fatura = 53,
        [Description("Fatura Raporu")]
        FaturaRaporu = 54,
        [Description("Fatura Dönem İcmal Raporu")]
        FaturaDonemIcmalRaporu = 55,
        [Description("Fatura Öğrenci İcmal Raporu")]
        FaturaOgrenciIcmalRaporu = 56,
        [Description("Genel Amaçlı Rapor")]
        GenelAmacliRapor = 57,
        [Description("Sınıf Raporları")]
        SinifRaporlari = 58,
        [Description("Hizmet Alım Raporlaru")]
        HizmetAlimRaporu = 59,
        [Description("Net Ücret Raporu")]
        NetUcretRaporu = 60,
        [Description("Ücret ve Ödeme Raporu")]
        UcretVeOdemeRaporu = 61,
        [Description("İndirim Dağılım Raporu")]
        IndirimDagilimRaporu = 62,
        [Description("Mesleklere Göre Kayıt Raporu")]
        MesleklereGoreKayitRaporu = 63,
        [Description("Aylık Kayıt Raporu")]
        AylikKayitRaporu = 64,
        [Description("Gelir Dağılım Raporu")]
        GelirDagilimRaporu = 65,
        [Description("Ücret Ortalamaları Raporu")]
        UcretOrtalamalariRaporu = 66,
        [Description("Ödeme Belgeleri Raporu")]
        OdemeBelgeleriRaporu = 67,
        [Description("Tahsilat Raporu")]
        TahsilatRaporu = 68,
        [Description("Ödemesi Geciken Alacaklar Raporu")]
        OdemesiGecikenAlacaklarRaporu = 69,
        [Description("Açıklama Kartı")]
        Aciklama = 70,
        [Description("Kullanıcı Parametre Kartı")]
        KullaniciParametre = 71,
        [Description("Kurum Kartı")]
        Kurum = 72,
        [Description("Dönem Kartı")]
        Donem = 73,
        [Description("Rol Kartı")]
        Rol = 74,
        [Description("Yetki Kartı")]
        Yetki = 75,
        [Description("Kullanıcı Kartı")]
        Kullanici = 76,
        [Description("Kaynak Kartı")]
        KayitKaynak = 77,
        [Description("Grup Kartı")]
        KisiGrubu = 78,
        [Description("Kişi Kartı")]
        Kisi = 79,
        [Description("Renk Kartı")]
        Renk = 80,
        [Description("Etiket Kartı")]
        Etiket = 81,
        [Description("Ülke Kartı")]
        Ulke = 82,
        [Description("Adres Türleri")]
        AdresTurleri = 83,
        [Description("Adres Kartı")]
        AdresBilgileri = 84,
        [Description("Iletisimler Kartı")]
        Iletisimler = 85,
        [Description("Sosyal Medya Kartı")]
        SosyalMedyaPlatformu = 86,
        [Description("Departman Kartı")]
        Departman = 87,
        [Description("Kimlik Türleri")]
        KimlikTuru = 88,
        [Description("Uyruk Kartı")]
        Uyruk = 89,
        [Description("Pozisyon Kartı")]
        Pozisyon = 90,
        [Description("Personel Kartı")]
        Personel = 91,
        [Description("Belge Türleri")]
        BelgeTuru = 92,
        [Description("Kurum Türleri")]
        KurumTuru = 93,
        [Description("Kurum Kartları")]
        Kurumlar = 94,
        [Description("Personel Belge Kartları")]
        PersonelBelge = 95,
        [Description("Kişi İletişim Kartları")]
        KisiIletisim = 96,
        [Description("Kişi Adres Kartları")]
        KisiAdres = 97,
        [Description("Personel İletişim Kartları")]
        PersonelIletisim = 98,
        [Description("Personel Adres Kartları")]
        PersonelAdres = 99,
        [Description("Cari Kart")]
        Cariler = 100,
        [Description("Cari Şube Kartı")]
        CariSubeler = 101,
        [Description("Cari İletişim Kartı")]
        CariIletisim = 102,
        [Description("Cari Adres Kartı")]
        CariAdres = 103,
        [Description("Cari-Şube Adres Kartı")]
        CariSubeAdres = 104,
        [Description("Cari-Şube İletişim Kartı")]
        CariSubeIletisim = 105,
        [Description("Genel İletişim Kartı")]
        GenelIletisim = 106,
        [Description("Genel Adres Kartı")]
        GenelAdres = 107,
        [Description("Vergi Dairesi")]
        VergiDairesi = 108,
        [Description("Cari Türü Kartı")]
        CariTuru = 109,
        [Description("Cari Gurubu Kartı")]
        CariGrubu = 110,
        [Description("Sektör Kartı")]
        Sektor = 111,
        [Description("Cari-Şube Grubu Kartı")]
        CariSubeGrubu = 112,
        [Description("Kişi Kayıt Türü Bağlantıları")]
        KisiKayitTuruBaglanti = 113,
    }
}