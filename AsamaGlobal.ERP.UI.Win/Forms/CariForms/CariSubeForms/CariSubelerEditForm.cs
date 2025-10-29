using AbcYazilim.OgrenciTakip.Common.Enums;
using AsamaGlobal.ERP.Bll.General.CarilerBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Dto.CariDto.CariSubeDto;
using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariSube;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.CariSubelerEditFormTable;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;
namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms
{
    public partial class CariSubelerEditForm : BaseEditForm
    {
        #region Variables
        private readonly long _carilerId;
        private readonly string _carilerAdi;
        private BaseTablo _yorumlarTable;
        private List<long> _oldEtiketIdListesi = new List<long>();
        private List<long> _guncelEtiketIdListesi = new List<long>();
        private EtiketHelper _etiketHelper;
        #endregion
        public CariSubelerEditForm(params object[] prm)
        {
            InitializeComponent();
            _carilerId = (long)prm[0];
            _carilerAdi = prm[1].ToString();

            DataLayoutControls = new[] { DataLayoutGenel, DataLayoutGenelBilgiler };
            Bll = new CariSubelerBll(DataLayoutGenelBilgiler);
            BaseKartTuru = KartTuru.CariSubeler;
            EventsLoad();
            _etiketHelper = new EtiketHelper();
            _etiketHelper.EtiketleriYukle(txtContainer.TokenEditControl, KayitTuru.CariSube);
            txtContainer.TokenEditControl.EditValueChanged += (s, e) =>
            {
                _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue) ?? new List<long>();
                ButonEnabledDurumu();
            };

            Text = Text + $" - ( {_carilerAdi} )";
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new CariSubelerS() : ((CariSubelerBll)Bll).Single(FilterFunctions.Filter<CariSubeler>(Id));          
            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((CariSubelerBll)Bll).YeniKodVer(x => x.CarilerId == _carilerId);
            txtCariSubeAdi.Focus();
        }       
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (CariSubelerS)OldEntity;
            txtKod.Text = entity.Kod;
            txtCariSubeAdi.Text = entity.CariSubeAdi;
            txtCariSubeGrubu.Id = entity.CariSubeGrubuId;
            txtCariSubeGrubu.Text = entity.CariSubeGrubuAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
            KisiyeAitEtiketleriYukle();
            BagliTabloYukle();
            ButonEnabledDurumu();
        }
        protected override void GuncelNesneOlustur()
        {
            _guncelEtiketIdListesi = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);

            CurrentEntity = new CariSubeler
            {
                Id = Id,
                Kod = txtKod.Text,
                CariSubeAdi = txtCariSubeAdi.Text,
                CariSubeGrubuId= txtCariSubeGrubu.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                CarilerId = BaseIslemTuru == IslemTuru.EntityInsert ? _carilerId : ((CariSubelerS)OldEntity).CarilerId,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            
            ButonEnabledDurumu();
        }
        private void KisiyeAitEtiketleriYukle()
        {
            using (var db = new ERPContext())
            {
                var seciliEtiketler = db.EtiketKayitTuruBaglanti
                    .Where(x => x.KayitTuru == KayitTuru.CariSube && x.KayitId == Id)
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
                    sec.Sec(txtOzelKod1, KartTuru.CariSubeler);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.CariSubeler);
                else if (sender == txtCariSubeGrubu)
                    sec.Sec(txtCariSubeGrubu, KartTuru.CariSubeGrubu);
        }      
        protected override void BagliTabloYukle()
        {
            if (_yorumlarTable != null && TabloDegisti())
                _yorumlarTable.Yukle();
        }
        protected override bool BagliTabloHataliGirisKontrol()
        {
            if (_yorumlarTable != null && _yorumlarTable.HataliGiris())
            {
                tabUst.SelectedPage = pageYorumlar;
                _yorumlarTable.Tablo.GridControl.Focus();
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
            if (_yorumlarTable != null && !_yorumlarTable.Kaydet()) return false;

            var seciliEtiketIdler = _etiketHelper.EtiketIdleriniAl(txtContainer.TokenEditControl.EditValue);
            _etiketHelper.BaglantilariGuncelle(KayitTuru.CariSube, Id, seciliEtiketIdler);
            _oldEtiketIdListesi = seciliEtiketIdler.ToList();

            return true;
        }
        protected override void Control_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e)
        {
            if (e.Page == pageGenelBilgiler)
            {
                txtCariSubeAdi.Focus();
                txtCariSubeAdi.SelectAll();
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

            return false;
        }
    }
}