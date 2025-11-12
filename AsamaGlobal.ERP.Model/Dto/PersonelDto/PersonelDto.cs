using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.PersonelEntity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsamaGlobal.ERP.Model.Dto.PersonelDto
{
    [NotMapped]
    public class PersonelS : Personel
    {
        public string DepartmanAdi { get; set; }
        public string PozisyonAdi { get; set; }
        public string KimlikTuruAdi { get; set; }
        public string MeslekAdi { get; set; }
        public string UyrukAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }

    }
    public class PersonelL : BaseEntity
    {
        public override string Kod { get; set; }

        public string KimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
        public KanGrubu KanGrubu { get; set; }
        public AskerlikDurumu AskerlikDurumu { get; set; }
        public MedeniDurum MedeniDurum { get; set; }
        public string BabaAdi { get; set; }
        public string AnaAdi { get; set; }
        public string SGKSicilNo { get; set; }
        public DateTime? DogumTarihi { get; set; }
        public string Aciklama { get; set; }
        public byte[] Resim { get; set; }
        public KayitTuru KayitTuru { get; set; }
        public string DepartmanAdi { get; set; }
        public string PozisyonAdi { get; set; }
        public string KimlikTuruAdi { get; set; }
        public string MeslekAdi { get; set; }
        public string UyrukAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
    }
}
