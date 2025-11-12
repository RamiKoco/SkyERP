using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Functions;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.UI.Win.Forms.IletisimlerForms
{
    public partial class IletisimlerEditForm : BaseEditForm
    {
        private long? _anaKayitId;
        private long? _kayitId;
        private readonly KayitTuru _kayitTuru;
        public IletisimlerEditForm()
        {
            InitializeComponent();
        
            DataLayoutControl = myDataLayoutControl;
            Bll = new GenelIletisimBll(myDataLayoutControl);
            txtKayitTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<KayitTuru>());
            txtIletisimTurleri.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimTuru>());
            txtIzinDurumu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimDurumu>());
            txtKanallar.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimKanalTipi>()
                        .Cast<string>()
                        .Select(x => new CheckedListBoxItem(x))
                        .ToArray());
            BaseKartTuru = KartTuru.GenelIletisim;
            txtKayitTuru.SelectedIndexChanged += (s, e) =>
            {               
                txtKayitHesabi.Id = 0;
                txtKayitHesabi.Text = "";
            };
            txtIletisimTurleri.EditValueChanged += TxtIletisimTurleri_EditValueChanged;
            tglVoip.EditValueChanged += tglVoip_EditValueChanged;
            EventsLoad();
        }      
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert
                ? new GenelIletisimS()
                : ((GenelIletisimBll)Bll).Single(FilterFunctions.Filter<GenelIletisim>(Id));
   
            if (BaseIslemTuru != IslemTuru.EntityInsert)
            {
                var old = (GenelIletisimS)OldEntity;
                if (_kayitId == null)
                    _kayitId = old.KayitId;
                if (_anaKayitId == null)
                    _anaKayitId = old.AnaKayitId;
            }
            NesneyiKontrollereBagla();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            //txtKod.Text = ((GenelIletisimBll)Bll).YeniKodVer();
            Expression<Func<GenelIletisim, bool>> filter = null;

            switch (_kayitTuru)
            {
                case KayitTuru.Kisi:
                    filter = x => x.KisiId == _anaKayitId;
                    break;
                case KayitTuru.Personel:
                    filter = x => x.PersonelId == _anaKayitId;
                    break;
                case KayitTuru.Meslek:
                    filter = x => x.MeslekId == _anaKayitId;
                    break;
                case KayitTuru.Cari:
                    filter = x => x.CarilerId == _anaKayitId;
                    break;
                case KayitTuru.CariSube:
                    filter = x => x.CariSubelerId == _anaKayitId;
                    break;
            }

            txtKod.Text = ((GenelIletisimBll)Bll).YeniKodVer(filter);
            txtBaslik.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (GenelIletisimS)OldEntity;
            
            txtKayitTuru.SelectedIndexChanged -= txtKayitTuru_SelectedIndexChanged;
            txtKod.Text = entity.Kod;
            txtBaslik.Text = entity.Baslik;
            txtWeb.Text = entity.Web;
            txtKayitTuru.SelectedItem = entity.KayitTuru.ToName();
            if (entity.KayitTuru == KayitTuru.Kisi)
                txtKayitHesabi.Id = entity.KisiId ?? null;
            else if (entity.KayitTuru == KayitTuru.Personel)
                txtKayitHesabi.Id = entity.PersonelId ?? null;
            else if (entity.KayitTuru == KayitTuru.Meslek)
                txtKayitHesabi.Id = entity.MeslekId ?? null;
            else if (entity.KayitTuru == KayitTuru.Cari)
                txtKayitHesabi.Id = entity.CarilerId ?? null;
            else if (entity.KayitTuru == KayitTuru.CariSube)
                txtCariSube.Id = entity.CariSubelerId ?? null;
            else
                txtKayitHesabi.Id = null;

            if (entity.KayitTuru == KayitTuru.CariSube)
            {
                txtKayitHesabi.Id = entity.CarilerId;
                txtKayitHesabi.Text = entity.KayitHesabiAdi;        
                txtCariSube.Id = entity.CariSubelerId;
                txtCariSube.Text = entity.AnaKayitHesabiAdi;                
            }
            else
            {

                txtKayitHesabi.Id =
                   entity.KayitTuru == KayitTuru.Kisi ? entity.KisiId :
                   entity.KayitTuru == KayitTuru.Personel ? entity.PersonelId :
                   entity.KayitTuru == KayitTuru.Meslek ? entity.MeslekId :
                   entity.KayitTuru == KayitTuru.Cari ? entity.CarilerId :
                   (long?)null;
                txtKayitHesabi.Text = entity.KayitHesabiAdi;
            }
            txtKayitHesabi.Text = entity.KayitHesabiAdi;
            txtIletisimTurleri.EditValue = entity.IletisimTuru.ToName();
            txtKanallar.SetEditValue(entity.Kanallar);
            txtIzinDurumu.SelectedItem = entity.IzinDurumu.ToName();
            txtIzinTarihi.EditValue = entity.IzinTarihi;
            txtOncelik.Value = entity.Oncelik;
            txtWeb.Text = entity.Web;
            txtUlkeKodu.Text = entity.UlkeKodu;
            txtTelefonVeFax.Text = entity.Numara;
            txtDahili.Text = entity.DahiliNo;
            txtEPosta.Text = entity.EPosta;
            txtKullaniciAdi.Text = entity.KullaniciAdi;
            txtSIPKullaniciAdi.Text = entity.SIPKullaniciAdi;
            txtSIPServer.Text = entity.SIPServer;
            txtSosyalMedyaUrl.Text = entity.SosyalMedyaUrl;
            txtSosyalMedyaPlatformu.Id = entity.SosyalMedyaPlatformuId;
            txtSosyalMedyaPlatformu.Text = entity.SosyalMedyaPlatformuAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglVoip.IsOn = entity.VoipMi;
            tglVarsayilanYap.IsOn = entity.VarsayilanYap;
            tglDurum.IsOn = entity.Durum;
            _kayitId = entity.KayitId != null ? entity.KayitId : txtKayitHesabi.Id;
            _anaKayitId = entity.AnaKayitId != null ? entity.AnaKayitId : txtKayitHesabi.Id;
            txtKayitTuru.SelectedIndexChanged += txtKayitTuru_SelectedIndexChanged;
            ButonEnabledDurumu();
        }
        protected override void GuncelNesneOlustur()
        {           
            var kayitTuru = txtKayitTuru.SelectedItem?.ToString().GetEnum<KayitTuru>() ?? KayitTuru.Kisi;
            var kisiId = kayitTuru == KayitTuru.Kisi
             ? (txtKayitHesabi.Id == 0 ? null : txtKayitHesabi.Id)
             : null;
            var meslekId = kayitTuru == KayitTuru.Meslek ? txtKayitHesabi.Id : null;
            var personelId = kayitTuru == KayitTuru.Personel ? txtKayitHesabi.Id : null;
            var carilerId = kayitTuru == KayitTuru.Cari ? txtKayitHesabi.Id : null;
            var cariSubeId = kayitTuru == KayitTuru.CariSube ? txtCariSube.Id : null;
            long? anaKayitId = null;
            long? kayitId = null;

            var eskiEntity = OldEntity as GenelIletisimS;

            var kanalListesi = (txtKanallar.EditValue?.ToString() ?? "")
                               .Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
                               .Select(x => x.Trim())
                               .ToList();

            bool eskiArama = eskiEntity?.Arama ?? false;
            bool eskiSms = eskiEntity?.Sms ?? false;
            bool eskiWhatsapp = eskiEntity?.Whatsapp ?? false;
            bool eskiEposta = eskiEntity?.EPBool ?? false;

            bool yeniArama = kanalListesi.Any() ? kanalListesi.Contains("Arama") : eskiArama;
            bool yeniSms = kanalListesi.Any() ? kanalListesi.Contains("SMS") : eskiSms;
            bool yeniWhatsapp = kanalListesi.Any() ? kanalListesi.Contains("Whatsapp") : eskiWhatsapp;
            bool yeniEposta = kanalListesi.Any() ? kanalListesi.Contains("E-Posta") : eskiEposta;

            if (kayitTuru == KayitTuru.CariSube)
            {              
                var yeniKayitId = txtCariSube.Id != 0 ? txtCariSube.Id : null;                
                var yeniAnaKayitId = txtKayitHesabi.Id != 0 ? txtKayitHesabi.Id : null;             
                kayitId = yeniKayitId ?? _kayitId;
                anaKayitId = yeniAnaKayitId ?? _anaKayitId;

                if ((anaKayitId == null || anaKayitId == kayitId) && _anaKayitId != null)
                    anaKayitId = _anaKayitId;
             
                if (anaKayitId == null && txtKayitHesabi.Id != 0)
                    anaKayitId = txtKayitHesabi.Id;
            }

            else if (kayitTuru == KayitTuru.Kisi ||
                     kayitTuru == KayitTuru.Personel ||
                     kayitTuru == KayitTuru.Meslek ||
                     kayitTuru == KayitTuru.Cari)
                        {
                            kayitId = txtKayitHesabi.Id != 0 ? txtKayitHesabi.Id : _kayitId;
                            anaKayitId = (_anaKayitId != null && _anaKayitId != 0)
                                ? _anaKayitId
                                : kayitId;
                        }
          
            else
            {
                kayitId = _kayitId ?? txtKayitHesabi.Id;
                anaKayitId = _anaKayitId ?? kayitId;
            }

            if (kayitId == 0) kayitId = null;
            if (anaKayitId == 0) anaKayitId = null;

            CurrentEntity = new GenelIletisim
            {
                Id = Id,
                Kod = txtKod.Text,
                Baslik = txtBaslik.Text,
                Oncelik = (short)txtOncelik.Value,
                Web = txtWeb.Text,
                KayitTuru = kayitTuru,
                KisiId = kisiId,
                PersonelId = personelId,
                MeslekId = meslekId,
                CarilerId = carilerId,
                CariSubelerId = cariSubeId,
                Arama = yeniArama,
                Sms = yeniSms,
                Whatsapp = yeniWhatsapp,
                EPBool = yeniEposta,
                IletisimTuru = txtIletisimTurleri.Text.GetEnum<IletisimTuru>(),
                IzinDurumu = txtIzinDurumu.Text.GetEnum<IletisimDurumu>(),
                Kanallar = txtKanallar.EditValue?.ToString(),
                IzinTarihi = (DateTime?)txtIzinTarihi.EditValue,
                UlkeKodu = txtUlkeKodu.Text,
                Numara = txtTelefonVeFax.Text,
                DahiliNo = txtDahili.Text,
                EPosta = txtEPosta.Text,
                KullaniciAdi = txtKullaniciAdi.Text,
                SIPServer = txtSIPServer.Text,
                SIPKullaniciAdi = txtSIPKullaniciAdi.Text,
                SosyalMedyaUrl = txtSosyalMedyaUrl.Text,
                SosyalMedyaPlatformuId = txtSosyalMedyaPlatformu.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Aciklama = txtAciklama.Text,              
                VarsayilanYap = tglVarsayilanYap.IsOn,
                VoipMi = tglVoip.IsOn,
                Durum = tglDurum.IsOn,
                AnaKayitId = anaKayitId,
                KayitId = kayitId,
                KayitHesabiAdi = txtKayitHesabi.Text,
                AnaKayitHesabiAdi = kayitTuru == KayitTuru.CariSube ? txtCariSube.Text : null
            };         
                
            if (tglVarsayilanYap.IsOn)
            {
                using (var context = new ERPContext())
                {
                    var digerKayitlar = context.GenelIletisim
                                        .Where(x => x.VarsayilanYap && x.Id != CurrentEntity.Id)
                                        .ToList();

                    foreach (var kayit in digerKayitlar)
                        kayit.VarsayilanYap = false;

                    context.SaveChanges();
                }
            }

            ButonEnabledDurumu();
        }
        private void tglVoip_EditValueChanged(object sender, EventArgs e)
        {
            bool isVoip = Convert.ToBoolean(tglVoip.EditValue);

            txtSIPKullaniciAdi.Enabled = isVoip;
            txtSIPServer.Enabled = isVoip;
        }
        protected internal override void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;       
            var tempOld = OldEntity as GenelIletisimS;
            var tempCurrent = CurrentEntity as GenelIletisim;           
            base.ButonEnabledDurumu();

            if (txtIletisimTurleri.EditValue == null) return;
            IletisimTuru iletisimTuru;

            try
            {
                iletisimTuru = EnumFunctions.GetValueFromDescription<IletisimTuru>(txtIletisimTurleri.EditValue.ToString());
            }
            catch
            {
                return;
            }
        }
        private void SetKanallarByIletisimTuru(IletisimTuru tur)
        {
            txtKanallar.Properties.Items.Clear();
            ICollection<string> kanalListesi;
            switch (tur)
            {
                case IletisimTuru.Telefon:
                    kanalListesi = EnumFunctions.GetEnumDescriptionList<IletisimKanalTipi>().Cast<string>().ToList();
                    break;
                case IletisimTuru.EPosta:
                    kanalListesi = EnumFunctions.GetEnumDescriptionList<IletisimKanalTipiEposta>().Cast<string>().ToList();
                    break;
                default:
                    kanalListesi = new List<string>();
                    break;
            }

            foreach (var item in kanalListesi)
            {
                var listItem = new CheckedListBoxItem(item);

                if (tur == IletisimTuru.EPosta && item == "E-Posta")
                {
                    listItem.CheckState = CheckState.Checked;
                }
                else
                {
                    listItem.CheckState = CheckState.Unchecked;
                }

                txtKanallar.Properties.Items.Add(listItem);
            }
            if (tur != IletisimTuru.EPosta)
            {
                txtKanallar.SetEditValue(null);
            }
            else
            {
                // E-Posta için default seçili zaten ayarlandı,
            }

        }
        private void TxtIletisimTurleri_EditValueChanged(object sender, EventArgs e)
        {
            if (txtIletisimTurleri.EditValue == null) return;

            IletisimTuru iletisimTuru;

            try
            {
                iletisimTuru = EnumFunctions.GetValueFromDescription<IletisimTuru>(txtIletisimTurleri.EditValue.ToString());
            }
            catch
            {
                return;
            }

            txtUlkeKodu.Enabled = true;
            txtTelefonVeFax.Enabled = true;
            txtDahili.Enabled = true;
            txtEPosta.Enabled = true;
            txtWeb.Enabled = true;
            txtSosyalMedyaPlatformu.Enabled = true;
            txtSosyalMedyaUrl.Enabled = true;
            txtKullaniciAdi.Enabled = true;
            txtSIPKullaniciAdi.Enabled = true;
            txtSIPServer.Enabled = true;
            tglVoip.Enabled = true;
            txtIzinDurumu.Enabled = true;
            txtIzinTarihi.Enabled = true;
            txtKanallar.Enabled = true;
            tglVoip.Enabled = true;
            txtSIPServer.Enabled = true;
            txtSIPKullaniciAdi.Enabled = true;
            switch (iletisimTuru)
            {
                case IletisimTuru.Telefon:
                    txtEPosta.Enabled = false;
                    txtEPosta.Text = "";
                    txtSosyalMedyaPlatformu.Enabled = false;
                    txtSosyalMedyaPlatformu.Id = null;
                    txtSosyalMedyaPlatformu.Text = "";
                    txtWeb.Enabled = false;
                    txtWeb.Text = "";
                    txtSosyalMedyaUrl.Enabled = false;
                    txtSosyalMedyaUrl.Text = "";
                    txtKullaniciAdi.Enabled = false;
                    txtKullaniciAdi.Text = "";
                    tglVoip.EditValue = false;
                    txtSIPKullaniciAdi.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    txtSIPServer.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    SetKanallarByIletisimTuru(IletisimTuru.Telefon);
                    break;

                case IletisimTuru.EPosta:
                    txtUlkeKodu.Enabled = false;
                    txtUlkeKodu.Text = "";
                    txtTelefonVeFax.Enabled = false;
                    txtTelefonVeFax.Text = "";
                    txtDahili.Enabled = false;
                    txtDahili.Text = "";
                    SetKanallarByIletisimTuru(IletisimTuru.EPosta);
                    txtWeb.Enabled = false;
                    txtWeb.Text = "";
                    txtSosyalMedyaPlatformu.Enabled = false;
                    txtSosyalMedyaPlatformu.Id = null;
                    txtSosyalMedyaPlatformu.Text = "";
                    txtSosyalMedyaUrl.Enabled = false;
                    txtSosyalMedyaUrl.Text = "";
                    txtKullaniciAdi.Enabled = false;
                    txtKullaniciAdi.Text = "";
                    tglVoip.EditValue = false;
                    tglVoip.Enabled = false;
                    txtSIPKullaniciAdi.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    txtSIPKullaniciAdi.Text = "";
                    txtSIPServer.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    txtSIPServer.Text = "";
                    break;

                case IletisimTuru.Web:
                    txtUlkeKodu.Enabled = false;
                    txtUlkeKodu.Text = "";
                    txtTelefonVeFax.Enabled = false;
                    txtTelefonVeFax.Text = "";
                    txtDahili.Enabled = false;
                    txtDahili.Text = "";
                    txtEPosta.Enabled = false;
                    txtEPosta.Text = "";
                    txtKanallar.Enabled = false;
                    txtKanallar.Text = "";
                    txtIzinDurumu.Enabled = false;
                    txtIzinDurumu.Text = null;
                    txtIzinTarihi.Enabled = false;
                    txtIzinTarihi.Text = null;
                    txtSosyalMedyaPlatformu.Enabled = false;
                    txtSosyalMedyaPlatformu.Id = null;
                    txtSosyalMedyaPlatformu.Text = "";
                    txtSosyalMedyaUrl.Enabled = false;
                    txtSosyalMedyaUrl.Text = "";
                    txtKullaniciAdi.Enabled = false;
                    txtKullaniciAdi.Text = "";
                    tglVoip.EditValue = false;
                    tglVoip.Enabled = false;
                    txtSIPKullaniciAdi.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    txtSIPKullaniciAdi.Text = "";
                    txtSIPServer.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    txtSIPServer.Text = "";
                    break;

                case IletisimTuru.SosyalMedya:
                    txtUlkeKodu.Enabled = false;
                    txtUlkeKodu.Text = "";
                    txtTelefonVeFax.Enabled = false;
                    txtTelefonVeFax.Text = "";
                    txtDahili.Enabled = false;
                    txtDahili.Text = "";
                    txtEPosta.Enabled = false;
                    txtEPosta.Text = "";
                    txtKanallar.Enabled = false;
                    txtKanallar.Text = "";
                    txtWeb.Enabled = false;
                    txtWeb.Text = "";
                    tglVoip.EditValue = false;
                    tglVoip.Enabled = false;
                    txtSIPKullaniciAdi.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    txtSIPKullaniciAdi.Text = "";
                    txtSIPServer.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    txtSIPServer.Text = "";
                    break;

                case IletisimTuru.Fax:
                    txtDahili.Enabled = false;
                    txtDahili.Text = "";
                    txtEPosta.Enabled = false;
                    txtEPosta.Text = "";
                    txtKanallar.Enabled = false;
                    txtKanallar.Text = "";
                    txtIzinDurumu.Enabled = false;
                    txtIzinDurumu.Text = null;
                    txtIzinTarihi.Enabled = false;
                    txtIzinTarihi.Text = null;
                    txtWeb.Enabled = false;
                    txtWeb.Text = "";
                    txtSosyalMedyaPlatformu.Enabled = false;
                    txtSosyalMedyaPlatformu.Id = null;
                    txtSosyalMedyaPlatformu.Text = "";
                    txtSosyalMedyaUrl.Enabled = false;
                    txtSosyalMedyaUrl.Text = "";
                    txtKullaniciAdi.Enabled = false;
                    txtKullaniciAdi.Text = "";
                    tglVoip.EditValue = false;
                    tglVoip.Enabled = false;
                    txtSIPKullaniciAdi.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    txtSIPKullaniciAdi.Text = "";
                    txtSIPServer.Enabled = Convert.ToBoolean(tglVoip.EditValue);
                    txtSIPServer.Text = "";
                    break;

            }
        }          
        protected override bool EntityInsert()
        {
            return ((GenelIletisimBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod);
        }
        protected override bool EntityUpdate()
        {
            return ((GenelIletisimBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod);
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
            {
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.GenelIletisim);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.GenelIletisim);
                else if (sender == txtSosyalMedyaPlatformu)
                    sec.Sec(txtSosyalMedyaPlatformu, KartTuru.SosyalMedyaPlatformu);
                else if (sender == txtKayitHesabi)
                {
                    var kayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>();

                    if (kayitTuru == KayitTuru.Kisi)
                    {
                        sec.Sec(txtKayitHesabi, KartTuru.Kisi);
                        _kayitId = txtKayitHesabi.Id;
                        _anaKayitId = null;
                    }
                    else if (kayitTuru == KayitTuru.Personel)
                    {
                        sec.Sec(txtKayitHesabi, KartTuru.Personel);
                        _kayitId = txtKayitHesabi.Id;
                        _anaKayitId = null;
                    }
                    else if (kayitTuru == KayitTuru.Cari)
                    {
                        sec.Sec(txtKayitHesabi, KartTuru.Cariler);
                        _kayitId = txtKayitHesabi.Id;
                        _anaKayitId = null;
                    }
                    else if (kayitTuru == KayitTuru.CariSube)
                    {
                        sec.Sec(txtKayitHesabi, KartTuru.Cariler);

                        if (txtKayitHesabi.Id == null || txtKayitHesabi.Id == 0)
                        {
                            Messages.UyariMesaji("Cari seçilmeden şube seçimi yapılamaz.");
                            return;
                        }

                        txtKayitHesabi.ControlEnabledChange(txtCariSube);
                        sec.Sec(txtCariSube, txtKayitHesabi);

                        _anaKayitId = txtKayitHesabi.Id; // Ana cari
                        _kayitId = txtCariSube.Id;       // Şube
                    }
                    else if (kayitTuru == KayitTuru.Meslek)
                    {
                        sec.Sec(txtKayitHesabi, KartTuru.Meslek);
                        _kayitId = txtKayitHesabi.Id;
                        _anaKayitId = null;
                    }
                    else
                    {
                        sec.Sec(txtKayitHesabi);
                        _kayitId = txtKayitHesabi.Id;
                        _anaKayitId = null;
                    }
                }
                else if (sender == txtCariSube)
                    sec.Sec(txtCariSube, txtKayitHesabi);
            }
        }
        private void txtKayitTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            layoutControlItem6.Visibility = LayoutVisibility.Never;
            txtKayitHesabi.Id = 0;
            txtKayitHesabi.Text = string.Empty;
            var kayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>();
            txtCariSube.Enabled = kayitTuru == KayitTuru.CariSube;      
        }
        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtKayitHesabi)
                return;
            else if(sender == txtKayitHesabi)
            {
                var kayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>();
                if (kayitTuru == KayitTuru.CariSube)
                    txtKayitHesabi.ControlEnabledChange(txtCariSube);
            }           
        }
       
    }
}