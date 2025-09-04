using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Dto.KisiDto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.General;
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
        private BaseTablo _iletisimBilgileriTable;
        private BaseTablo _adreslerTable;
        private List<EtiketL> _tumEtiketler;
        private List<long> _oldEtiketIdListesi = new List<long>();
        private List<long> _guncelEtiketIdListesi = new List<long>();
        private EtiketHelper _etiketHelper;
        public KisiEditForm()
        {
            InitializeComponent();

            DataLayoutControls = new[] { DataLayoutGenel, DataLayoutGenelBilgiler };
            Bll = new KisiBll(DataLayoutGenelBilgiler);
            BaseKartTuru = KartTuru.Kisi;
            EventsLoad();
            txtCinsiyet.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<Cinsiyet>());
            _etiketHelper = new EtiketHelper();
            _etiketHelper.EtiketleriYukle(txtEtiket, KayitTuru.Kisi);
        }
        public override void Yukle()
        {
            EtiketleriYukle();
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new KisiS() : ((KisiBll)Bll).Single(FilterFunctions.Filter<Kisi>(Id));
            NesneyiKontrollereBagla();
            BagliTabloYukle();

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

            KisiyeAitEtiketleriYukle();
        }
        protected override void GuncelNesneOlustur()
        {
            var etiketValue = txtEtiket.EditValue;
            if (etiketValue is string str)
            {
                _guncelEtiketIdListesi = str
                    .Split(',')
                    .Select(x => long.TryParse(x, out var val) ? val : 0)
                    .Where(x => x > 0)
                    .ToList();
            }
            else
                _guncelEtiketIdListesi = new List<long>();

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
            ButonEnabledDurumu();
        }
        private void EtiketleriYukle()
        {
            var etiketBll = new EtiketBll();
            _tumEtiketler = etiketBll.List(x => x.Durum == true && x.KayitTuru == KayitTuru.Kisi).Cast<EtiketL>().ToList();
            txtEtiket.Properties.DataSource = _tumEtiketler;
            txtEtiket.Properties.DisplayMember = "EtiketAdi";
            txtEtiket.Properties.ValueMember = "Id";
        }
        private void KisiyeAitEtiketleriYukle()
        {
            using (var db = new ERPContext())
            {
                var seciliEtiketler = db.EtiketKayitTuruBaglanti
                    .Where(x => x.KayitTuru == KayitTuru.Kisi && x.KayitId == Id)
                    .Select(x => x.EtiketId)
                    .ToList();

                txtEtiket.EditValue = string.Join(",", seciliEtiketler);

                _oldEtiketIdListesi = seciliEtiketler;
            }
        }
        public override bool Kaydet(bool kapanis)
        {
            GuncelNesneOlustur();

            bool etiketDegisti = !_oldEtiketIdListesi?.SequenceEqual(_guncelEtiketIdListesi ?? new List<long>()) ?? false;
            bool entityDegisti = !OldEntity.Equals(CurrentEntity);

            if (kapanis && !entityDegisti && !etiketDegisti && !FarkliSubeIslemi)
                return true;

            if (kapanis)
            {
                var result = Messages.KapanisMesaj(); // sadece 1 kez sor
                switch (result)
                {
                    case DialogResult.Yes:
                        if (!BagliTabloKaydet()) return false;

                        _oldEtiketIdListesi = _guncelEtiketIdListesi.ToList();

                        // base.Kaydet yerine doğrudan kayıt işlemini sen yap
                        var sonuc = BaseIslemTuru == IslemTuru.EntityInsert
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

            // Menüden kaydet gibi durumlarda
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
            bool TableValueChanged(BaseTablo tablo)
            {
                return tablo.Tablo.DataController.ListSource.Cast<IBaseHareketEntity>()
                    .Any(x => x.Insert || x.Update || x.Delete);
            }
            if (_bilgiNotlariTable != null && TableValueChanged(_bilgiNotlariTable))
                _bilgiNotlariTable.Yukle();
            if (_iletisimBilgileriTable != null && TableValueChanged(_iletisimBilgileriTable))
                _iletisimBilgileriTable.Yukle();
            if (_adreslerTable != null && TableValueChanged(_adreslerTable))
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

            if (_iletisimBilgileriTable != null && _iletisimBilgileriTable.HataliGiris())
            {
                tabUst.SelectedPage = pageIletisimBilgileri;
                _iletisimBilgileriTable.Tablo.GridControl.Focus();
                return true;
            }

            if (_adreslerTable != null && _adreslerTable.HataliGiris())
            {
                tabUst.SelectedPage = pageAdresBilgileri;
                _adreslerTable.Tablo.GridControl.Focus();
                return true;
            }

            return false;
        }
        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;

            bool etiketDegisti = !_oldEtiketIdListesi?.SequenceEqual(_guncelEtiketIdListesi ?? new List<long>()) ?? false;



            bool TableValueChanged()
            {
                if (_iletisimBilgileriTable != null && _iletisimBilgileriTable.TableValueChanged) return true;
                if (_adreslerTable != null && _adreslerTable.TableValueChanged) return true;
                if (_bilgiNotlariTable != null && _bilgiNotlariTable.TableValueChanged) return true;

                return false;

            }

            if (FarkliSubeIslemi)
            {
                GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil);
            }
            else if (TableValueChanged())
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
            var seciliEtiketIdler = txtEtiket.EditValue as IEnumerable<long>
                         ?? txtEtiket.EditValue as long[]
                         ?? txtEtiket.EditValue?.ToString()
                         ?.Split(',')
                         ?.Select(x => long.TryParse(x, out var val) ? val : 0)
                         ?.Where(x => x > 0)
                         ?.ToArray();

            if (_adreslerTable != null && !_adreslerTable.Kaydet()) return false;
            if (_bilgiNotlariTable != null && !_bilgiNotlariTable.Kaydet()) return false;
            if (_iletisimBilgileriTable != null && !_iletisimBilgileriTable.Kaydet()) return false;

            if (seciliEtiketIdler != null)
            {
                using (var db = new ERPContext())
                {
                    var eskiBaglantilar = db.EtiketKayitTuruBaglanti
                        .Where(x => x.KayitTuru == KayitTuru.Kisi && x.KayitId == Id)
                        .ToList();
                    db.EtiketKayitTuruBaglanti.RemoveRange(eskiBaglantilar);

                    foreach (var etiketId in seciliEtiketIdler)
                    {
                        var baglanti = new EtiketKayitTuruBaglanti
                        {
                            EtiketId = etiketId,
                            KayitTuru = KayitTuru.Kisi,
                            KayitId = Id
                        };
                        db.EtiketKayitTuruBaglanti.Add(baglanti);
                    }
                    db.SaveChanges();
                }
            }

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

    }
}