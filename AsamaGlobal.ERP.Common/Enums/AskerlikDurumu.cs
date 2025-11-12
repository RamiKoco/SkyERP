using System.ComponentModel;

namespace AsamaGlobal.ERP.Common.Enums
{
    public enum AskerlikDurumu : byte
    {
        [Description("Muaf")]
        Muaf = 1,
        [Description("Tecilli")]
        Tecilli = 2,
        [Description("Yapıldı")]
        Yapildi = 3,
        [Description("Yapılmadı")]
        Yapilmadi = 4
    }
}
