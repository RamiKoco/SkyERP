using System.ComponentModel;

namespace AsamaGlobal.ERP.Common.Enums
{
    public enum AdresTipi : byte
    {
        [Description("Genel")]
        Genel = 1,
        [Description("Fatura")]
        Fatura = 2,
        [Description("Sevkiyat")]
        Sevkiyat = 3,
        [Description("Depo")]
        Depo = 4,
        [Description("Ev")]
        Ev = 5,
        [Description("İş Yeri")]
        Isyeri = 6,
        [Description("Teslimat Noktası")]
        TeslimatNoktasi = 7,
        [Description("Üretim")]
        Uretim = 8,
        [Description("Fuar")]
        Fuar = 9,
        [Description("Kiralık")]
        Kiralik = 10,
        [Description("Yazlık")]
        Yazlik = 11,
        [Description("Vekil Adres")]
        VekilAdres = 12,
    }
}
