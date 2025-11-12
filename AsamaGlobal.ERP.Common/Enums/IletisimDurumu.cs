using System.ComponentModel;

namespace AsamaGlobal.ERP.Common.Enums
{
    public enum IletisimDurumu : byte
    {
        [Description("Belirtilmedi")]
        Belirtilmedi = 1,
        [Description("Verildi")]
        Verildi = 2,
        [Description("Rededildi")]
        Rededildi = 3
    }
}
