using System.ComponentModel;

namespace AsamaGlobal.ERP.Common.Enums
{
    public enum IletisimKanalTipi : byte
    {
        [Description("Arama")]
        Arama = 1,
        [Description("SMS")]
        SMS = 2,      
        [Description("Whatsapp")]
        Whatsapp = 3
    }
    public enum IletisimKanalTipiEposta : byte
    {
        [Description("E-Posta")]
        EPosta = 1,
    
    }
}
