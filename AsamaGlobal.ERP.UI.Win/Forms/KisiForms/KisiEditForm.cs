using AbcYazilim.OgrenciTakip.Model.Dto.KisiDto;
using AsamaGlobal.ERP.Bll.General.KisiBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Functions;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using AsamaGlobal.ERP.Model.Entities.KisiEntity;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.KisiEditFormTable;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace AsamaGlobal.ERP.UI.Win.Forms.KisiForms
{
    public partial class KisiEditForm : BaseEditForm
    {
        protected internal GridView Tablo;
        private BaseTablo _bilgiNotlariTable;
        private BaseTablo _cariBaglantiTable;
        private BaseTablo _iletisimBilgileriTable;
        private BaseTablo _adreslerTable;
        private List<long> _oldEtiketIdListesi = new List<long>();
        private List<long> _guncelEtiketIdListesi = new List<long>();
        private EtiketHelper _etiketHelper;
        public KisiEditForm()
        {
            InitializeComponent();

            DataLayoutControls = new[] { DataLayoutGenel, DataLayoutGenelBilgiler };
            Bll = new KisiBll(DataLayoutGenelBilgiler);
            BaseKartTuru = KartTuru.Kisi;          
            txtCinsiyet.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<Cinsiyet>());
            _etiketHelper = new EtiketHelper();
            _etiketHelper.EtiketleriYukle(txtContainer.TokenEditControl, KayitTuru.Kisi);
            txtContainer.TokenEditControl.EditValueChanged += (s, e) =>
            {
                _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue) ?? new List<long>();
                ButonEnabledDurumu();
            };
            EventsLoad();
        }
        public override void Yukle()
        {           
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new KisiS() : ((KisiBll)Bll).Single(FilterFunctions.Filter<Kisi>(Id));
            NesneyiKontrollereBagla();  
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KisiBll)Bll).YeniKodVer();
            txtAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KisiS)OldEntity;
            txtKod.Text = entity.Kod;
            txtAdi.Text = entity.Ad;
            txtSoyAdi.Text = entity.Soyad;
            txtCinsiyet.SelectedItem = entity.Cinsiyet.ToName();
            txtDogumTarihi.EditValue = entity.DogumTarihi;
            txtAciklama.Text = entity.Aciklama;
            txtSorumlu.Id = entity.PersonelId;
            txtSorumlu.Text = entity.PersonelAdi;
            txtKayitKaynak.Id = entity.KayitKaynakId;
            txtKayitKaynak.Text = entity.KayitKaynakAdi;
            txtMeslek.Id = entity.MeslekId;
            txtMeslek.Text = entity.MeslekAdi;
            txtKisiGrubu.Id = entity.KisiGrubuId;
            txtKisiGrubu.Text = entity.KisiGrubuAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            tglDurum.IsOn = entity.Durum;        
            BagliTabloYukle();
            EtiketleriYukle();
            ButonEnabledDurumu();
        }
        protected override void GuncelNesneOlustur()
        {            
            _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);

            CurrentEntity = new Kisi
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtAdi.Text,
                Soyad = txtSoyAdi.Text,
                Cinsiyet = txtCinsiyet.Text.GetEnum<Cinsiyet>(),
                DogumTarihi = (DateTime?)txtDogumTarihi.EditValue,
                Aciklama = txtAciklama.Text,
                PersonelId = txtSorumlu.Id,
                KayitKaynakId = txtKayitKaynak.Id,
                MeslekId = txtMeslek.Id,
                KisiGrubuId = txtKisiGrubu.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Durum = tglDurum.IsOn
            };
            BagliTabloYukle();
            ButonEnabledDurumu();
        }    
        private void EtiketleriYukle()
        {
            using (var db = new ERPContext())
            {
                var seciliEtiketler = db.EtiketKayitTuruBaglanti
                    .Where(x => x.KayitTuru == KayitTuru.Kisi && x.KayitId == Id)
                    .Select(x => x.EtiketId)
                    .ToList();

                // Sözlüğü yükle
                var etiketAdlari = db.Etiket
                    .Where(e => seciliEtiketler.Contains(e.Id))
                    .ToDictionary(e => e.Id, e => e.Ad);

                txtContainer.TokenEditControl.EtiketAdlariniYukle(etiketAdlari);

                txtContainer.TokenEditControl.EditValue = string.Join(",", seciliEtiketler);

                _oldEtiketIdListesi = seciliEtiketler;
            }
        }
        public override bool Kaydet(bool kapanis)
        {
            bool etiketDegisti = !_oldEtiketIdListesi.SequenceEqual(_guncelEtiketIdListesi ?? new List<long>());
            bool entityDegisti = !OldEntity.Equals(CurrentEntity);

            if (kapanis && !entityDegisti && !etiketDegisti && !FarkliSubeIslemi)
                return true;

            if (kapanis)
            {
                var result = Messages.KapanisMesaj(); // sadece 1 kez sor
                switch (result)
                {
                    case DialogResult.Yes:

                        _oldEtiketIdListesi = _guncelEtiketIdListesi.ToList();

                        // Kayıt işlemini doğrudan yap
                        bool sonuc = BaseIslemTuru == IslemTuru.EntityInsert
                          ? EntityInsert()
                          : EntityUpdate();

                        if (!sonuc) return false;

                        OldEntity = CurrentEntity;
                        RefleshYapilacak = true;

                        return true;

                    case DialogResult.No:
                        return true;

                    case DialogResult.Cancel:
                        return false;
                }
            }

            // Menüden kaydet gibi durumlar
            if (!BagliTabloKaydet()) return false;

            _oldEtiketIdListesi = _guncelEtiketIdListesi.ToList();
            return base.Kaydet(kapanis);
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtMeslek)
                    sec.Sec(txtMeslek);
                else if (sender == txtKisiGrubu)
                    sec.Sec(txtKisiGrubu);
                else if (sender == txtSorumlu)
                    sec.Sec(txtSorumlu);
                else if (sender == txtKayitKaynak)
                    sec.Sec(txtKayitKaynak);
                else if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Kisi);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Kisi);

        }
        protected override void BagliTabloYukle()
        {
            if (_bilgiNotlariTable != null && TabloDegisti())
                _bilgiNotlariTable.Yukle();
            if (_cariBaglantiTable != null && TabloDegisti())
                _cariBaglantiTable.Yukle();
            if (_iletisimBilgileriTable != null && TabloDegisti())
                _iletisimBilgileriTable.Yukle();
            if (_adreslerTable != null && TabloDegisti())
                _adreslerTable.Yukle();
        }
        protected override bool BagliTabloHataliGirisKontrol()
        {
            if (_bilgiNotlariTable != null && _bilgiNotlariTable.HataliGiris())
            {
                tabUst.SelectedPage = pageNotlar;
                _bilgiNotlariTable.Tablo.GridControl.Focus();
                return true;
            }
            if (_cariBaglantiTable != null && _cariBaglantiTable.HataliGiris())
            {
                tabUst.SelectedPage = pageBaglantilar;
                _cariBaglantiTable.Tablo.GridControl.Focus();
                return true;
            }    

            return false;
        }
        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;

            bool etiketDegisti = !(_oldEtiketIdListesi?.SequenceEqual(_guncelEtiketIdListesi ?? new List<long>()) ?? true);
          
            if (FarkliSubeIslemi)
            {
                GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil);
            }
            else if (TabloDegisti())
            {
                GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, OldEntity, CurrentEntity, true);
            }
            else
            {
                GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, OldEntity, CurrentEntity, etiketDegisti);
            }

        }
        protected override bool BagliTabloKaydet()
        {           
            if (_bilgiNotlariTable != null && !_bilgiNotlariTable.Kaydet()) return false;

            if (_cariBaglantiTable != null)
            {
                var cariTable = _cariBaglantiTable as CariKayitTuruBaglantiTable;
                if (cariTable != null && !cariTable.KaydetKontrollu())
                    return false;
            }

            var seciliEtiketIdler = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);
            _etiketHelper.BaglantilariGuncelle(KayitTuru.Kisi, Id, seciliEtiketIdler);
            _oldEtiketIdListesi = seciliEtiketIdler.ToList();
            return true;
        }
        protected override void Control_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
            if (e.Page == pageGenelBilgiler)
            {
                txtAdi.Focus();
                txtSoyAdi.SelectAll();
            }

            else if (e.Page == pageNotlar)
            {
                if (pageNotlar.Controls.Count == 0)
                {
                    _bilgiNotlariTable = new BilgiNotlariTable().AddTable(this);
                    pageNotlar.Controls.Add(_bilgiNotlariTable);
                    _bilgiNotlariTable.Yukle();

                }

                _bilgiNotlariTable.Tablo.GridControl.Focus();
            }
            else if (e.Page == pageBaglantilar)
            {                
                if (BaseIslemTuru == IslemTuru.EntityInsert)
                    return;

                if (pageBaglantilar.Controls.Count == 0)
                {
                    _cariBaglantiTable = new CariKayitTuruBaglantiTable().AddTable(this);
                    pageBaglantilar.Controls.Add(_cariBaglantiTable);
                    _cariBaglantiTable.Yukle();
                }

                _cariBaglantiTable.Tablo.GridControl.Focus();
            }

            else if (e.Page == pageIletisimBilgileri)
            {
                if (pageIletisimBilgileri.Controls.Count == 0)
                {
                    _iletisimBilgileriTable = new IletisimBilgileriTable().AddTable(this);
                    pageIletisimBilgileri.Controls.Add(_iletisimBilgileriTable);
                    _iletisimBilgileriTable.Yukle();

                }

                _iletisimBilgileriTable.Tablo.GridControl.Focus();
            }

            else if (e.Page == pageAdresBilgileri)
            {
                if (pageAdresBilgileri.Controls.Count == 0)
                {
                    _adreslerTable = new AdreslerTable().AddTable(this);
                    pageAdresBilgileri.Controls.Add(_adreslerTable);
                    _adreslerTable.Yukle();
                }

                _adreslerTable.Tablo.GridControl.Focus();
               
            }
        }   
        private bool TabloDegisti()
        {
            bool Degisti(BaseTablo tablo)
            {
                var list = tablo?.Tablo.DataController.ListSource;
                if (list == null)
                    return false;

                var hareketList = list as IEnumerable<IBaseHareketEntity>;
                if (hareketList == null)
                    return false;

                return hareketList.Any(x => x.Insert || x.Update || x.Delete);
            }

            if (Degisti(_bilgiNotlariTable)) return true;
            if (Degisti(_cariBaglantiTable)) return true;         

            return false;
        }
    }
}