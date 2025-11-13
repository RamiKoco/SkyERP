using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.General.CarilerBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using AsamaGlobal.ERP.Model.Entities.CariEntity;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.CariEditFormTable;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms
{
    public partial class CarilerEditForm : BaseEditForm
    {
        #region Variables
        private BaseTablo _yorumlarTable;
        private BaseTablo _cariBaglantiTable;
        private BaseTablo _cariSubelerTable;
        private List<long> _oldEtiketIdListesi = new List<long>();
        private List<long> _guncelEtiketIdListesi = new List<long>();
        private List<long> _oldSektorIdListesi = new List<long>();
        private List<long> _guncelSektorIdListesi = new List<long>();
        private EtiketHelper _etiketHelper;
        #endregion

        public CarilerEditForm()
        {
            InitializeComponent();
            DataLayoutControls = new[] { DataLayoutGenel, DataLayoutGenelBilgiler };
            Bll = new CarilerBll(DataLayoutGenelBilgiler);
            BaseKartTuru = KartTuru.Cariler;            
            EventsLoad();
            tglSahis.Toggled += tglSahis_Toggled;
            txtKimlikNo.Validating += TxtKimlikNo_Validating;
            txtKimlikTuru.EditValueChanged += TxtKimlikTuru_EditValueChanged;            
            _etiketHelper = new EtiketHelper();  
            _etiketHelper.EtiketleriYukle(txtContainer.TokenEditControl, KayitTuru.Cari);
            txtContainer.TokenEditControl.EditValueChanged += (s, e) =>
            {
                _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue) ?? new List<long>();
                ButonEnabledDurumu();
            };
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new CarilerS() : ((CarilerBll)Bll).Single(FilterFunctions.Filter<Cariler>(Id));          
            NesneyiKontrollereBagla();  
              
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((CarilerBll)Bll).YeniKodVer();
            txtUnvan.Focus();
        }  

        protected override void NesneyiKontrollereBagla()
        {          
            var entity = (CarilerS)OldEntity;    
            txtKod.Text = entity.Kod;
            txtKimlikNo.Text = entity.KimlikNo;
            txtAdi.Text = entity.Ad;
            txtSoyAdi.Text = entity.Soyad;            
            txtVergiNo.Text = entity.VergiNo;
            txtUnvan.Text = entity.Unvan;
            txtCariGrubu.Id = entity.CariGrubuId;
            txtCariGrubu.Text = entity.CariGrubuAdi;
            txtCariTuru.Id = entity.CariTuruId;
            txtCariTuru.Text = entity.CariTuruAdi;
            txtVergiDairesi.Id = entity.VergiDairesiId;
            txtVergiDairesi.Text = entity.VergiDairesiAdi;
            txtKayitKaynak.Id = entity.KayitKaynakId;
            txtKayitKaynak.Text = entity.KayitKaynakAdi;
            txtKimlikTuru.Id = entity.KimlikTuruId;
            TxtKimlikTuru_IdChanged(txtKimlikTuru, EventArgs.Empty);
            txtSektor.EditValueChanged += TxtSektor_EditValueChanged;
            txtKimlikTuru.Text = entity.KimlikTuruAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtOzelKod3.Id = entity.OzelKod3Id;
            txtOzelKod3.Text = entity.OzelKod3Adi;
            txtOzelKod4.Id = entity.OzelKod4Id;
            txtOzelKod4.Text = entity.OzelKod4Adi;
            txtOzelKod5.Id = entity.OzelKod5Id;
            txtOzelKod5.Text = entity.OzelKod5Adi;
            txtAciklama.Text = entity.Aciklama;
            tglSahis.IsOn = entity.Sahis;
            tglDurum.IsOn = entity.Durum;         
            KisiyeAitEtiketleriYukle();
            SahisDurumunuAyarla(entity.Sahis);
            SektorYukle();
        }  

        protected override void GuncelNesneOlustur()
        {          
            _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);

            CurrentEntity = new Cariler
            {
                Id = Id,
                Kod = txtKod.Text,
                KimlikNo = txtKimlikNo.Text,
                Ad = txtAdi.Text,
                Soyad = txtSoyAdi.Text,
                Unvan = txtUnvan.Text,
                VergiNo = txtVergiNo.Text,
                CariGrubuId = txtCariGrubu.Id,
                CariTuruId= txtCariTuru.Id,
                VergiDairesiId = txtVergiDairesi.Id,
                KayitKaynakId = txtKayitKaynak.Id,
                KimlikTuruId = txtKimlikTuru.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                OzelKod3Id = txtOzelKod3.Id,
                OzelKod4Id = txtOzelKod4.Id,
                OzelKod5Id = txtOzelKod5.Id,
                Aciklama = txtAciklama.Text,              
                Sahis = tglSahis.IsOn,
                Durum = tglDurum.IsOn,
                SektorIdListesi = txtSektor.SelectedIds.ToList(),               
            };
            BagliTabloYukle();
            ButonEnabledDurumu();
        }

        private void KisiyeAitEtiketleriYukle()
        {
            using (var db = new ERPContext())
            {
                var seciliEtiketler = db.EtiketKayitTuruBaglanti
                    .Where(x => x.KayitTuru == KayitTuru.Cari && x.KayitId == Id)
                    .Select(x => x.EtiketId)
                    .ToList();

                var etiketAdlari = db.Etiket
                    .Where(e => seciliEtiketler.Contains(e.Id))
                    .ToDictionary(e => e.Id, e => e.EtiketAdi);

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
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Cariler);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Cariler);
                else if (sender == txtOzelKod3)
                    sec.Sec(txtOzelKod3, KartTuru.Cariler);
                else if (sender == txtOzelKod4)
                    sec.Sec(txtOzelKod4, KartTuru.Cariler);
                else if (sender == txtOzelKod5)
                    sec.Sec(txtOzelKod5, KartTuru.Cariler);
                else if (sender == txtKimlikTuru)
                {
                    sec.Sec(txtKimlikTuru);

                    if (txtKimlikTuru.Id != null)
                    {
                        var bll = new KimlikTuruBll();
                        var secilen = bll.Single(x => x.Id == (long)txtKimlikTuru.Id) as KimlikTuru;
                        int yeniUzunluk = secilen?.Uzunluk ?? 11;
                        string karakterTipi = secilen?.KarakterTipi;

                        // Zorunlu uzunluk
                        txtKimlikNo.Properties.MaxLength = yeniUzunluk;

                        // Maske ayarları
                        txtKimlikNo.Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
                        txtKimlikNo.Properties.Mask.UseMaskAsDisplayFormat = true;

                        if (karakterTipi == "Numeric")
                        {
                            txtKimlikNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                            txtKimlikNo.Properties.Mask.EditMask = $@"\d{{{yeniUzunluk}}}";
                        }
                        else if (karakterTipi == "AlphaNumeric")
                        {
                            txtKimlikNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
                            txtKimlikNo.Properties.Mask.EditMask = $@"[a-zA-Z0-9]{{{yeniUzunluk}}}";
                        }
                        else
                        {
                            txtKimlikNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                            txtKimlikNo.Properties.Mask.EditMask = null;
                        }

                        // Giriş fazlaysa kırp
                        if (txtKimlikNo.Text.Length > yeniUzunluk)
                            txtKimlikNo.Text = txtKimlikNo.Text.Substring(0, yeniUzunluk);
                    }
                }

                else if (sender == txtVergiDairesi)
                    sec.Sec(txtVergiDairesi, KartTuru.VergiDairesi);
                else if (sender == txtCariTuru)
                    sec.Sec(txtCariTuru, KartTuru.CariTuru);
                else if (sender == txtCariGrubu)
                    sec.Sec(txtCariGrubu, KartTuru.CariGrubu);
                else if (sender == txtKayitKaynak)
                    sec.Sec(txtKayitKaynak);             
              
        }

        private void TxtKimlikTuru_IdChanged(object sender, EventArgs e)
        {
            if (txtKimlikTuru.Id == null)
                return;

            var bll = new KimlikTuruBll();
            var secilen = bll.Single(x => x.Id == (long)txtKimlikTuru.Id) as KimlikTuru;

            int yeniUzunluk = secilen?.Uzunluk ?? 11;
            txtKimlikNo.Properties.MaxLength = yeniUzunluk;

            if (txtKimlikNo.Text.Length > yeniUzunluk)
                txtKimlikNo.Text = txtKimlikNo.Text.Substring(0, yeniUzunluk);
        }

        private void TxtKimlikTuru_EditValueChanged(object sender, EventArgs e)
        {
            if (txtKimlikTuru.EditValue == null)
                return;

            var bll = new KimlikTuruBll();

            if (long.TryParse(txtKimlikTuru.EditValue.ToString(), out long secilenId))
            {
                var secilen = bll.Single(x => x.Id == secilenId) as KimlikTuru;
                if (secilen == null)
                    return;

                int yeniUzunluk = secilen.Uzunluk;

                // MaxLength ayarla
                txtKimlikNo.Properties.MaxLength = yeniUzunluk;

                // Mask kapalı, çünkü Validating ile kontrol ediyoruz
                txtKimlikNo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
                txtKimlikNo.Properties.Mask.EditMask = null;
            }
        }

        private void TxtKimlikNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtKimlikTuru.Id == null)
                return;

            var bll = new KimlikTuruBll();
            var secilen = bll.Single(x => x.Id == (long)txtKimlikTuru.Id) as KimlikTuru;

            if (secilen == null)
                return;

            int istenenUzunluk = secilen.Uzunluk;
            string karakterTipi = secilen.KarakterTipi;
            string girilen = txtKimlikNo.Text.Trim();

            // Uzunluk kontrolü
            if (girilen.Length != istenenUzunluk)
            {
                Messages.UyariMesaji($"Kimlik numarası {istenenUzunluk} karakter olmalıdır.");
                e.Cancel = true;
                return;
            }

            // Karakter tipi kontrolü
            if (karakterTipi == "Numeric")
            {
                // Sadece rakam kontrolü
                if (!System.Text.RegularExpressions.Regex.IsMatch(girilen, @"^\d+$"))
                {
                    Messages.UyariMesaji("Kimlik numarası sadece rakamlardan oluşmalıdır.");
                    e.Cancel = true;
                    return;
                }
            }
            else if (karakterTipi == "AlphaNumeric")
            {
                // Harf ve rakam kontrolü
                if (!System.Text.RegularExpressions.Regex.IsMatch(girilen, @"^[a-zA-Z0-9]+$"))
                {
                    Messages.UyariMesaji("Kimlik numarası sadece harf ve rakamlardan oluşmalıdır.");
                    e.Cancel = true;
                    return;
                }
            }
        }

        protected override void BagliTabloYukle()
        {
            if (_yorumlarTable != null && TabloDegisti())
                _yorumlarTable.Yukle();
            if (_cariBaglantiTable != null && TabloDegisti())
                _cariBaglantiTable.Yukle();
            if (_cariSubelerTable != null && TabloDegisti())
                _cariSubelerTable.Yukle();
        }
        protected override void Control_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
            if (e.Page == pageGenelBilgiler)
            {
                txtUnvan.Focus();
                txtKimlikNo.SelectAll();
            }

            else if (e.Page == pageYorumlar)
            {
                if (pageYorumlar.Controls.Count == 0)
                {
                    _yorumlarTable = new YorumlarTable().AddTable(this);
                    pageYorumlar.Controls.Add(_yorumlarTable);
                    _yorumlarTable.Yukle();

                }
                _yorumlarTable.Tablo.GridControl.Focus();
            }
            else if (e.Page == pageIlgiliKisiler)
            {
                if (BaseIslemTuru == IslemTuru.EntityInsert)
                    return;

                if (pageIlgiliKisiler.Controls.Count == 0)
                {
                    _cariBaglantiTable = new KisiKayitTuruBaglantiTable().AddTable(this);
                    pageIlgiliKisiler.Controls.Add(_cariBaglantiTable);
                    _cariBaglantiTable.Yukle();
                }

                _cariBaglantiTable.Tablo.GridControl.Focus();
            }
            else if (e.Page == pageSubeBilgileri)
            {
                if (pageSubeBilgileri.Controls.Count == 0)
                {
                    _cariSubelerTable = new CariSubelerTable().AddTable(this);
                    pageSubeBilgileri.Controls.Add(_cariSubelerTable);
                    _cariSubelerTable.Yukle();
                }

                _cariSubelerTable.Tablo.GridControl.Focus();

            }
        }

        protected override bool BagliTabloHataliGirisKontrol()
        { 
            if (_yorumlarTable != null && _yorumlarTable.HataliGiris())
            {
                tabUst.SelectedPage = pageYorumlar;
                _yorumlarTable.Tablo.GridControl.Focus();
                return true;
            }
            if (_cariBaglantiTable != null && _cariBaglantiTable.HataliGiris())
            {
                tabUst.SelectedPage = pageIlgiliKisiler;
                _cariBaglantiTable.Tablo.GridControl.Focus();
                return true;
            }

            return false;
        }

        protected internal override void ButonEnabledDurumu()
        {   

            if (!IsLoaded) return;

            bool etiketDegisti = !(_oldEtiketIdListesi?.SequenceEqual(_guncelEtiketIdListesi ?? new List<long>()) ?? true);

            bool SektorDegisti = !((_oldSektorIdListesi ?? new List<long>())
                 .SequenceEqual(_guncelSektorIdListesi ?? new List<long>()));

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
                GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, OldEntity, CurrentEntity, etiketDegisti || SektorDegisti);
            }

        }

        protected override bool BagliTabloKaydet()
        {
            if (_yorumlarTable != null && !_yorumlarTable.Kaydet()) return false;
            if (_cariBaglantiTable != null)
            {
                var cariTable = _cariBaglantiTable as KisiKayitTuruBaglantiTable;
                if (cariTable != null && !cariTable.KaydetKontrollu())
                    return false;
            }

            var seciliEtiketIdler = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);
            _etiketHelper.BaglantilariGuncelle(KayitTuru.Cari, Id, seciliEtiketIdler);
            _oldEtiketIdListesi = seciliEtiketIdler.ToList();
            _oldSektorIdListesi = _guncelSektorIdListesi.ToList();
            return true;
        } 

        private bool TabloDegisti()
        {
            bool Degisti(BaseTablo tablo)
            {
                var list = tablo?.Tablo.DataController.ListSource;
                if (list == null)
                    return false;

                return list.Cast<IBaseHareketEntity>()
                           .Any(x => x.Insert || x.Update || x.Delete);
            }        
            if (Degisti(_yorumlarTable)) return true;
            if (Degisti(_cariBaglantiTable)) return true;
            return false;
        }

        private void tglSahis_Toggled(object sender, EventArgs e)
        {
            SahisDurumunuAyarla(tglSahis.IsOn);
        }

        private void SahisDurumunuAyarla(bool sahisMi)
        {            
            this.SuspendLayout();

            try
            {
                txtKimlikNo.CausesValidation = false;
                txtAdi.CausesValidation = false;
                txtSoyAdi.CausesValidation = false;
                txtKimlikTuru.CausesValidation = false;
                txtVergiNo.CausesValidation = false;
               
                txtKimlikNo.Enabled = sahisMi;
                txtAdi.Enabled = sahisMi;
                txtSoyAdi.Enabled = sahisMi;
                txtKimlikTuru.Enabled = sahisMi;
                txtVergiNo.Enabled = !sahisMi;

                if (!sahisMi)
                {
                    if (!string.IsNullOrEmpty(txtKimlikNo.Text)) txtKimlikNo.EditValue = null;
                    if (!string.IsNullOrEmpty(txtAdi.Text)) txtAdi.EditValue = null;
                    if (!string.IsNullOrEmpty(txtSoyAdi.Text)) txtSoyAdi.EditValue = null;
                    if (!string.IsNullOrEmpty(txtKimlikTuru.Text)) txtKimlikTuru.EditValue = null;
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtVergiNo.Text)) txtVergiNo.EditValue = null;
                }
            }
            finally
            {
                txtKimlikNo.CausesValidation = true;
                txtAdi.CausesValidation = true;
                txtSoyAdi.CausesValidation = true;
                txtKimlikTuru.CausesValidation = true;
                txtVergiNo.CausesValidation = true;
               
                this.ResumeLayout(false);
                this.PerformLayout();
            }
        }

        #region Sektörler
        private void SektorYukle()
        {
            txtSektor.EditValueChanged -= TxtSektor_EditValueChanged;

            using (var context = new ERPContext())
            {
                var entity = (Cariler)OldEntity;

                var allSektorler = context.Sektor
                    .Select(s => new
                    {
                        Id = s.Id,
                        Sektör = s.Ad,
                        Açıklama = s.Aciklama
                    })
                    .OrderBy(s => s.Sektör)
                    .ToList();

                var seciliIds = context.CariSektorBaglanti
                                       .Where(c => c.KayitId == entity.Id && c.KayitTuru == KayitTuru.Cari)
                                       .Select(c => c.SektorId)
                                       .ToList();

                txtSektor.Properties.DataSource = allSektorler;
                txtSektor.Properties.DisplayMember = "Sektör";
                txtSektor.Properties.ValueMember = "Id";
                txtSektor.Properties.NullText = "Sektör Seçiniz...";

                // 🚀 Otomatik kolon oluşturmayı kapat
                txtSektor.Properties.PopulateColumns();
                foreach (var col in txtSektor.Properties.Columns)
                    ((LookUpColumnInfo)col).Visible = false;

                // 🧩 Manuel olarak sadece görünmesini istediğin kolonları ekle
                txtSektor.Properties.Columns.Add(new LookUpColumnInfo("Sektör", "Sektör"));
                txtSektor.Properties.Columns.Add(new LookUpColumnInfo("Açıklama", "Açıklama"));

                txtSektor.EditValue = seciliIds.ToList();
                _oldSektorIdListesi = seciliIds;
                _guncelSektorIdListesi = seciliIds.ToList();
            }

            txtSektor.EditValueChanged += TxtSektor_EditValueChanged;
        }
        private void TxtSektor_EditValueChanged(object sender, EventArgs e)
        {
            var selectedIds = (txtSektor.EditValue as IEnumerable)?.Cast<long>().ToList() ?? new List<long>();

            if (!_guncelSektorIdListesi.SequenceEqual(selectedIds))
            {
                _guncelSektorIdListesi = selectedIds;
                ButonEnabledDurumu();
            }
        }
        protected override bool EntityUpdate()
        {
            if (BagliTabloHataliGirisKontrol())
                return false;

            GuncelNesneOlustur();

            var result = ((CarilerBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod)
                         && BagliTabloKaydet();

            if (!result)
                return false;

            using (var context = new ERPContext())
            {
                var eskiBaglantilar = context.CariSektorBaglanti
                                             .Where(x => x.KayitId == CurrentEntity.Id && x.KayitTuru == KayitTuru.Cari)
                                             .ToList();
                if (eskiBaglantilar.Any())
                    context.CariSektorBaglanti.RemoveRange(eskiBaglantilar);

                foreach (var sektorId in _guncelSektorIdListesi)
                {
                    context.CariSektorBaglanti.Add(new CariSektorBaglanti
                    {
                        KayitTuru = KayitTuru.Cari,
                        KayitId = CurrentEntity.Id,
                        SektorId = sektorId
                    });
                }

                context.SaveChanges();
                ButonEnabledDurumu();
            }

            if (result && !KayitSonrasiFormuKapat)
                BagliTabloYukle();

            return result;
        }
        #endregion               
    }
}