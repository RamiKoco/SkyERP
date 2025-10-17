using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace AbcYazilim.OgrenciTakip.Model.Dto
{
    [NotMapped]
    public class AdresBilgileriS : AdresBilgileri
    {
        public string KisiAdi { get; set; }
        public string PersonelAdi { get; set; }
        public string MeslekAdi { get; set; }
        //public string KayitHesabiAdi => KayitTuru == KayitTuru.Kisi ? KisiAdi : MeslekAdi;     
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
        public string UlkeAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string AdresTurleriAdi { get; set; }
    }
    public class AdresBilgileriL : BaseEntity
    {
        public string KisiAdi { get; set; }
        public string PersonelAdi { get; set; }
        public string MeslekAdi { get; set; }
        //public string KayitHesabiAdi =>
        //KayitTuru == KayitTuru.Kisi ? KisiAdi : MeslekAdi;
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
        public string UlkeAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string AdresTurleriAdi { get; set; }
        public string Aciklama { get; set; }
        public string Baslik { get; set; }
        public string AdresNotu { get; set; }
        public string PostaKodu { get; set; }
        public string Adres { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public AdresTipi AdresTipi { get; set; }
        public decimal Enlem { get; set; }
        public decimal Boylam { get; set; }
        public bool VarsayilanMi { get; set; }
        public bool VarsayilanFaturaMi { get; set; }
        public bool VarsayilanSevkiyatMi { get; set; }
    }
}
