using AsamaGlobal.ERP.Bll.Base;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Dto.PersonelDto;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.PersonelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.Bll.General.PersonelBll
{
    public class PersonelBll : BaseGenelBll<Personel>, IBaseGenelBll, IBaseCommonBll
    {
        public PersonelBll() : base(KartTuru.Personel) { }
        public PersonelBll(Control ctrl) : base(ctrl, KartTuru.Personel) { }

        public override BaseEntity Single(Expression<Func<Personel, bool>> filter)
        {
            return BaseSingle(filter, x => new PersonelS
            {

                Id = x.Id,
                Kod = x.Kod,
                KimlikNo = x.KimlikNo,
                Ad = x.Ad,
                Soyad = x.Soyad,
                BabaAdi = x.BabaAdi,
                AnaAdi = x.AnaAdi,
                Cinsiyet = x.Cinsiyet,
                KanGrubu = x.KanGrubu,
                AskerlikDurumu = x.AskerlikDurumu,
                MedeniDurum = x.MedeniDurum,
                DogumTarihi = x.DogumTarihi,
                Resim = x.Resim,
                SGKSicilNo = x.SGKSicilNo,
                KayitTuru = x.KayitTuru,
                DepartmanId = x.DepartmanId,
                DepartmanAdi = x.Departman.Ad,
                PozisyonId = x.PozisyonId,
                PozisyonAdi = x.Pozisyon.Ad,
                KimlikTuruId = x.KimlikTuruId,
                KimlikTuruAdi = x.KimlikTuru.KimlikAdi,
                MeslekId = x.MeslekId,
                MeslekAdi = x.Meslek.Ad,
                UyrukId = x.UyrukId,
                UyrukAdi = x.Uyruk.Ad,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Personel, bool>> filter)
        {
            return BaseList(filter, x => new PersonelL
            {
                Id = x.Id,
                Kod = x.Kod,
                KimlikNo = x.KimlikNo,
                Ad = x.Ad,
                Soyad = x.Soyad,
                BabaAdi = x.BabaAdi,
                AnaAdi = x.AnaAdi,
                Cinsiyet = x.Cinsiyet,
                KanGrubu = x.KanGrubu,
                AskerlikDurumu = x.AskerlikDurumu,
                MedeniDurum = x.MedeniDurum,
                DogumTarihi = x.DogumTarihi,
                Resim = x.Resim,
                SGKSicilNo = x.SGKSicilNo,
                KayitTuru = x.KayitTuru,
                DepartmanAdi = x.Departman.Ad,
                PozisyonAdi = x.Pozisyon.Ad,
                KimlikTuruAdi = x.KimlikTuru.KimlikAdi,
                MeslekAdi = x.Meslek.Ad,
                UyrukAdi = x.Uyruk.Ad,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama

            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
