using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.General.PersonelBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Functions;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Dto.PersonelDto;
using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using AsamaGlobal.ERP.Model.Entities.PersonelEntity;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.UserControls.Controls;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.PersonelEditFormTable;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
namespace AsamaGlobal.ERP.UI.Win.Forms.PersonelForms
{
    public partial class PersonelEditForm : BaseEditForm
    {
        private BaseTablo _adreslerTable;
        private BaseTablo _bilgiNotlariTable;
        private BaseTablo _iletisimBilgileriTable;
        private BaseTablo _personelBelgeTable;
        private List<long> _oldEtiketIdListesi = new List<long>();
        private List<long> _guncelEtiketIdListesi = new List<long>();
        private EtiketHelper _etiketHelper;
        public PersonelEditForm()
        {
            InitializeComponent();

            DataLayoutControls = new[] { DataLayoutGenel, DataLayoutGenelBilgiler, DataLayoutControlKisiselBilgiler };
            Bll = new PersonelBll(DataLayoutGenelBilgiler);
            BaseKartTuru = KartTuru.Personel;
            EventsLoad();
            txtCinsiyet.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<Cinsiyet>());
            txtKanGrubu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<KanGrubu>());
            txtAskerlikDurumu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<AskerlikDurumu>());
            txtMedeniDurum.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<MedeniDurum>());
            txtCinsiyet.EditValueChanged += TxtCinsiyet_EditValueChanged;

            _etiketHelper = new EtiketHelper();
            _etiketHelper.EtiketleriYukle(txtContainer.TokenEditControl, KayitTuru.Personel);
            txtContainer.TokenEditControl.EditValueChanged += (s, e) =>
            {
                _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue) ?? new List<long>();
                ButonEnabledDurumu();
            };
        }  
        private void TxtKimlikTuru_EditValueChanged(object sender, EventArgs e)
        {
            KimlikTuruAyarla(txtKimlikTuru.Id);
        }    
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new PersonelS() : ((PersonelBll)Bll).Single(FilterFunctions.Filter<Personel>(Id));
            NesneyiKontrollereBagla();  
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((PersonelBll)Bll).YeniKodVer();
            txtAdi.Focus();
        }
        private byte[] _oldResim;
        private bool _resimDegisti;
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (PersonelS)OldEntity;
            _oldResim = entity.Resim;          // orijinal bytes
            _resimDegisti = false;
            txtKod.Text = entity.Kod;
            txtKimlikNo.Text = entity.KimlikNo;
            txtAdi.Text = entity.Ad;
            txtSoyAdi.Text = entity.Soyad;
            txtAnaAdi.Text = entity.AnaAdi;
            txtBabaAdi.Text = entity.BabaAdi;
            txtSGKSicilNo.Text = entity.SGKSicilNo;
            txtCinsiyet.SelectedItem = entity.Cinsiyet.ToName();
            txtKanGrubu.SelectedItem = entity.KanGrubu.ToName();
            txtAskerlikDurumu.SelectedItem = entity.AskerlikDurumu.ToName();
            txtMedeniDurum.SelectedItem = entity.MedeniDurum.ToName();
            txtDogumTarihi.EditValue = entity.DogumTarihi;
            imgResim.EditValueChanged -= ImgResim_EditValueChanged;
            imgResim.EditValue = entity.Resim; // sadece gösterim
            imgResim.EditValueChanged += ImgResim_EditValueChanged;
            txtAciklama.Text = entity.Aciklama;
            txtDepartman.Id = entity.DepartmanId;
            txtDepartman.Text = entity.DepartmanAdi;
            TxtCinsiyet_EditValueChanged(null, null);
            txtMeslek.Id = entity.MeslekId;
            txtMeslek.Text = entity.MeslekAdi;
            txtUyruk.Id = entity.UyrukId;
            txtUyruk.Text = entity.UyrukAdi;
            txtPozisyon.Id = entity.PozisyonId;
            txtPozisyon.Text = entity.PozisyonAdi;
            txtKimlikTuru.Id = entity.KimlikTuruId;
            txtKimlikTuru.Text = entity.KimlikTuruAdi;
            KimlikTuruAyarla(entity.KimlikTuruId);
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            tglDurum.IsOn = entity.Durum;

            KisiyeAitEtiketleriYukle();
        }
        private void ImgResim_EditValueChanged(object sender, EventArgs e)
        {
            _resimDegisti = true;
        }
        protected override void GuncelNesneOlustur()
        {
            _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);

            var oldBytes = ((Personel)OldEntity).Resim;
            var currentBytes = ImageHelper.GetBytesFromEditValue(imgResim.EditValue);
            byte[] resimBytes;

            if (currentBytes == null && oldBytes == null)
                resimBytes = null;
            else if (ImageHelper.ByteArrayEqual(currentBytes, oldBytes))
                resimBytes = oldBytes;  // değişiklik yok
            else
            {
                var img = ImageHelper.ToImage(currentBytes);
                var resized = ImageHelper.ResizeHighQuality(img, 250, 250);
                resimBytes = ImageHelper.ToBytes(resized);
            }

            CurrentEntity = new Personel
            {
                Id = Id,
                Kod = txtKod.Text,
                KimlikNo = txtKimlikNo.Text,
                Ad = txtAdi.Text,
                Soyad = txtSoyAdi.Text,
                BabaAdi = txtBabaAdi.Text,
                AnaAdi = txtAnaAdi.Text,
                SGKSicilNo = txtSGKSicilNo.Text,
                Cinsiyet = txtCinsiyet.Text.GetEnum<Cinsiyet>(),
                KanGrubu = txtKanGrubu.Text.GetEnum<KanGrubu>(),
                MedeniDurum = txtMedeniDurum.Text.GetEnum<MedeniDurum>(),
                AskerlikDurumu = txtAskerlikDurumu.Text.GetEnum<AskerlikDurumu>(),
                DogumTarihi = (DateTime?)txtDogumTarihi.EditValue,
                Resim = resimBytes, // ← SADECE BURAYI KULLAN!
                Aciklama = txtAciklama.Text,
                DepartmanId = txtDepartman.Id,
                UyrukId = txtUyruk.Id,
                KimlikTuruId = txtKimlikTuru.Id,
                MeslekId = txtMeslek.Id,
                PozisyonId = txtPozisyon.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Durum = tglDurum.IsOn
            };
            BagliTabloYukle();
            ButonEnabledDurumu();
        }  
        private void TxtCinsiyet_EditValueChanged(object sender, EventArgs e)
        {
            // Eğer kız seçiliyse askerlik durumu görünmesin, değilse görünsün
            if (txtCinsiyet.EditValue != null && txtCinsiyet.EditValue.ToString() == Cinsiyet.Kiz.ToName())
            {               
                txtAskerlikDurumu.SelectedItem = null;
                txtAskerlikDurumu.EditValue = null;
                AskerlikDurumuLbl.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            }
            else
                txtAskerlikDurumu.Visible = true;
        }  
        private void KisiyeAitEtiketleriYukle()
        {
            using (var db = new ERPContext())
            {
                var seciliEtiketler = db.EtiketKayitTuruBaglanti
                    .Where(x => x.KayitTuru == KayitTuru.Personel && x.KayitId == Id)
                    .Select(x => x.EtiketId)
                    .ToList();

                // Sözlüğü yükle
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
            if (txtKimlikTuru.Id != null)
            {
                var bll = new KimlikTuruBll();
                var secilen = bll.Single(x => x.Id == (long)txtKimlikTuru.Id) as KimlikTuru;
                int istenenUzunluk = secilen?.Uzunluk ?? 0;
                string karakterTipi = secilen?.KarakterTipi;
                string girilen = txtKimlikNo.Text?.Trim();

                // MASK boşluklarını temizle (örn: ____)
                girilen = girilen?.Replace("_", "");

                // Uzunluk kontrolü
                if (girilen.Length != istenenUzunluk)
                {
                    Messages.UyariMesaji($"Kimlik numarası tam {istenenUzunluk} karakter olmalıdır.");
                    return false;
                }

                // Karakter tipi kontrolü
                if (karakterTipi == "Numeric" && !System.Text.RegularExpressions.Regex.IsMatch(girilen, @"^\d+$"))
                {
                    Messages.UyariMesaji("Kimlik numarası sadece sayılardan oluşmalıdır.");
                    return false;
                }

                if (karakterTipi == "AlphaNumeric" && !System.Text.RegularExpressions.Regex.IsMatch(girilen, @"^[a-zA-Z0-9]+$"))
                {
                    Messages.UyariMesaji("Kimlik numarası sadece harf ve rakamlardan oluşmalıdır.");
                    return false;
                }
            }

            //GuncelNesneOlustur();

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
                if (sender == txtDepartman)
                    sec.Sec(txtDepartman);
                else if (sender == txtPozisyon)
                    sec.Sec(txtPozisyon);
                else if (sender == txtUyruk)
                    sec.Sec(txtUyruk);
                else if (sender == txtKimlikTuru)
                {
                    sec.Sec(txtKimlikTuru);
                    KimlikTuruAyarla(txtKimlikTuru.Id);
                }              
                else if (sender == txtMeslek)
                    sec.Sec(txtMeslek);
                else if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Personel);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Personel);

        }
        protected override void Control_Enter(object sender, EventArgs e)
        {
            if (!(sender is MyPictureEdit resim)) return;
            resim.Sec(resimMenu);

        }
        protected override void BagliTabloYukle()
        {           
            if (_adreslerTable != null && TabloDegisti())
                _adreslerTable.Yukle();
            if (_bilgiNotlariTable != null && TabloDegisti())
                _bilgiNotlariTable.Yukle();
            if (_iletisimBilgileriTable != null && TabloDegisti())
                _iletisimBilgileriTable.Yukle();            
            if (_personelBelgeTable != null && TabloDegisti())
                _personelBelgeTable.Yukle();
        }
        protected override bool BagliTabloHataliGirisKontrol()
        {
            if (_adreslerTable != null && _adreslerTable.HataliGiris())
            {
                tabUst.SelectedPage = pageAdresBilgileri;
                _adreslerTable.Tablo.GridControl.Focus();
                return true;
            }
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
        
            if (_personelBelgeTable != null && _personelBelgeTable.HataliGiris())
            {
                tabUst.SelectedPage = pageBelgeler;
                _personelBelgeTable.Tablo.GridControl.Focus();
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
            if (_adreslerTable != null && !_adreslerTable.Kaydet()) return false;
            if (_bilgiNotlariTable != null && !_bilgiNotlariTable.Kaydet()) return false;
            if (_iletisimBilgileriTable != null && !_iletisimBilgileriTable.Kaydet()) return false;
            if (_personelBelgeTable != null && !_personelBelgeTable.Kaydet()) return false;

            var seciliEtiketIdler = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);
            _etiketHelper.BaglantilariGuncelle(KayitTuru.Personel, Id, seciliEtiketIdler);
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
            else if (e.Page == pageBelgeler)
            {
                // Yeni kayıttaysa tabloyu hiç oluşturma!
                if (BaseIslemTuru == IslemTuru.EntityInsert)
                    return;

                if (pageBelgeler.Controls.Count == 0)
                {
                    _personelBelgeTable = new PersonelBelgeTable().AddTable(this);
                    pageBelgeler.Controls.Add(_personelBelgeTable);
                    _personelBelgeTable.Yukle();
                }

                _personelBelgeTable.Tablo.GridControl.Focus();
            }
        }
        private void KimlikTuruAyarla(long? kimlikTuruId)
        {
            if (kimlikTuruId == null) return;

            var bll = new KimlikTuruBll();
            var secilen = bll.Single(x => x.Id == kimlikTuruId) as KimlikTuru;
            if (secilen == null) return;

            int yeniUzunluk = secilen.Uzunluk;
            string karakterTipi = secilen.KarakterTipi;

            // MaxLength
            txtKimlikNo.Properties.MaxLength = yeniUzunluk;

            // Maske ayarı
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

            // Uzun girişi kırp
            if (txtKimlikNo.Text.Length > yeniUzunluk)
                txtKimlikNo.Text = txtKimlikNo.Text.Substring(0, yeniUzunluk);
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
            // _iletisimBilgileriTable IBaseHareketEntity değil, o yüzden atla
            // if (Degisti(_iletisimBilgileriTable)) return true;
            //if (Degisti(_adreslerTable)) return true;

            return false;
        }
    }
}