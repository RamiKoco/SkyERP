using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.CariEntity;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Dto.CariDto
{
    [NotMapped]
    public class CarilerS : Cariler
    {
        public string VergiDairesiAdi { get; set; }
        public string KimlikTuruAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string OzelKod3Adi { get; set; }
        public string OzelKod4Adi { get; set; }
        public string OzelKod5Adi { get; set; }
    }
    public class CarilerL : BaseEntity
    {
        public string CariAdi { get; set; }
        public string Unvan { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string KimlikNo { get; set; }
        public bool Sahis { get; set; }
        //public string VergiDairesi { get; set; }
        public string VergiNo { get; set; }
        public string VergiKodu { get; set; }
        public string YetkiKodu { get; set; }
        public string HesapKodu { get; set; }
        public string ProjeKodu { get; set; }
        public string Aciklama { get; set; }
        public string VergiDairesiAdi { get; set; }
        public string KimlikTuruAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string OzelKod3Adi { get; set; }
        public string OzelKod4Adi { get; set; }
        public string OzelKod5Adi { get; set; }
    }
}
