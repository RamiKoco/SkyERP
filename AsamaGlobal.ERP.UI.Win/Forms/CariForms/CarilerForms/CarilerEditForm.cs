using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.General.CarilerBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using AsamaGlobal.ERP.Model.Entities.CariEntity;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Forms.VergiDairesiForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.TahakkukEditFormTable;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System;
using System.ComponentModel;
using System.Linq;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CarilerForms
{
    public partial class CarilerEditForm : BaseEditForm
    {
        private BaseTablo _bilgiNotlariTable;
        public CarilerEditForm()
        {
            InitializeComponent();
            DataLayoutControls = new[] { DataLayoutGenel, DataLayoutGenelBilgiler };
            Bll = new CarilerBll(DataLayoutGenelBilgiler);
            BaseKartTuru = KartTuru.Cariler;
            EventsLoad();
            txtKimlikNo.Validating += TxtKimlikNo_Validating;
            txtKimlikTuru.EditValueChanged += TxtKimlikTuru_EditValueChanged;
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new CarilerS() : ((CarilerBll)Bll).Single(FilterFunctions.Filter<Cariler>(Id));
            NesneyiKontrollereBagla();
            BagliTabloYukle();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((CarilerBll)Bll).YeniKodVer();
            txtAdi.Focus();

        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (CarilerS)OldEntity;

            txtKod.Text = entity.Kod;
            txtCariAdi.Text = entity.CariAdi;
            txtKimlikNo.Text = entity.KimlikNo;
            txtAdi.Text = entity.Ad;
            txtSoyAdi.Text = entity.Soyad;
            //txtVergiDairesi.Text = entity.VergiDairesi;
            txtVergiNo.Text = entity.VergiNo;
            txtVergiKodu.Text = entity.VergiKodu;
            txtHesapKodu.Text = entity.HesapKodu;
            txtYetkiKodu.Text = entity.YetkiKodu;
            txtProjeKodu.Text = entity.ProjeKodu;
            txtUnvan.Text = entity.Unvan;
            tglSahis.IsOn = entity.Sahis;
            txtKimlikTuru.Id = entity.KimlikTuruId;
            TxtKimlikTuru_IdChanged(txtKimlikTuru, EventArgs.Empty);
            txtKimlikTuru.Text = entity.KimlikTuruAdi;
            txtVergiDairesi.Id = entity.VergiDairesiId;
            txtVergiDairesi.Text = entity.VergiDairesiAdi;
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
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Cariler
            {
                Id = Id,
                Kod = txtKod.Text,
                CariAdi = txtCariAdi.Text,
                KimlikNo = txtKimlikNo.Text,
                Ad = txtAdi.Text,
                Soyad = txtSoyAdi.Text,
                Unvan = txtUnvan.Text,
                //VergiDairesi = txtVergiDairesi.Text,
                VergiNo = txtVergiNo.Text,
                VergiKodu = txtVergiKodu.Text,
                HesapKodu = txtHesapKodu.Text,
                YetkiKodu = txtYetkiKodu.Text,
                ProjeKodu = txtProjeKodu.Text,
                KimlikTuruId = txtKimlikTuru.Id,   
                VergiDairesiId= txtVergiDairesi.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                OzelKod3Id = txtOzelKod3.Id,
                OzelKod4Id = txtOzelKod4.Id,
                OzelKod5Id = txtOzelKod5.Id,
                Aciklama = txtAciklama.Text,
                Sahis = tglSahis.IsOn,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
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
                        var bll = new Bll.General.KimlikTuruBll();
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

        }
        private void TxtKimlikTuru_IdChanged(object sender, EventArgs e)
        {
            if (txtKimlikTuru.Id == null)
                return;

            var bll = new Bll.General.KimlikTuruBll();
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

            var bll = new Bll.General.KimlikTuruBll();

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

            var bll = new Bll.General.KimlikTuruBll();
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
            bool TableValueChanged(BaseTablo tablo)
            {
                return tablo.Tablo.DataController.ListSource.Cast<IBaseHareketEntity>()
                    .Any(x => x.Insert || x.Update || x.Delete);
            }

            if (_bilgiNotlariTable != null && TableValueChanged(_bilgiNotlariTable))
                _bilgiNotlariTable.Yukle();

        }
        protected override bool EntityInsert()
        {
            
            if (BagliTabloHataliGirisKontrol()) return false;
            var result = ((CarilerBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod) && BagliTabloKaydet();

            if (result && !KayitSonrasiFormuKapat)
                BagliTabloYukle();

            return result;
        }
        protected override bool EntityUpdate()
        {          
            if (BagliTabloHataliGirisKontrol()) return false;
            var result = ((CarilerBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod) && BagliTabloKaydet();

            if (result && !KayitSonrasiFormuKapat)
                BagliTabloYukle();

            return result;
        }
        protected override bool BagliTabloHataliGirisKontrol()
        { 
            if (_bilgiNotlariTable != null && _bilgiNotlariTable.HataliGiris())
            {
                tabUst.SelectedPage = pageNotlar;
                _bilgiNotlariTable.Tablo.GridControl.Focus();
                return true;
            }

            return false;
        }
        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;

            bool TableValueChanged()
            {               
                if (_bilgiNotlariTable != null && _bilgiNotlariTable.TableValueChanged) return true;               

                return false;
            }          

            if (FarkliSubeIslemi)
                Functions.GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil);
            else
                Functions.GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, OldEntity, CurrentEntity,
                     TableValueChanged());

        }
        protected override bool BagliTabloKaydet()
        {           
            if (_bilgiNotlariTable != null && !_bilgiNotlariTable.Kaydet()) return false;   

            return true;
        }
        protected override void Control_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
            if (e.Page == pageGenelBilgiler)
            {
                txtCariAdi.Focus();
                txtKimlikNo.SelectAll();
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
        }
    }
}