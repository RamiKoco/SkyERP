using AbcYazilim.OgrenciTakip.Common.Enums;
using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Functions;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms
{
    public partial class GenelIletisimEditForm : BaseEditForm
    {
        #region Variables
        private readonly long _cariId;
        private readonly string _cariAdi;
        #endregion
        public GenelIletisimEditForm(params object[] prm)
        {
            InitializeComponent();
            _cariId = (long)prm[0];
            _cariAdi = prm[1].ToString();

            DataLayoutControl = myDataLayoutControl;
            Bll = new GenelIletisimBll(myDataLayoutControl);
            txtIletisimTurleri.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimTuru>());
            txtIzinDurumu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimDurumu>());
            txtKanallar.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimKanalTipi>()
                        .Cast<string>()
                        .Select(x => new CheckedListBoxItem(x))
                        .ToArray());
            BaseKartTuru = KartTuru.GenelIletisim;// Kontrol Et
            txtIletisimTurleri.EditValueChanged += TxtIletisimTurleri_EditValueChanged;
            tglVoip.EditValueChanged += tglVoip_EditValueChanged;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new GenelIletisimS() : ((GenelIletisimBll)Bll).Single(FilterFunctions.Filter<GenelIletisim>(Id));
            NesneyiKontrollereBagla();
            Text = Text + $" - ( {_cariAdi} )";

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((GenelIletisimBll)Bll).YeniKodVer(x => x.CarilerId == _cariId);
            txtBaslik.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {

            var entity = (GenelIletisimS)OldEntity;
            txtKod.Text = entity.Kod;
            txtBaslik.Text = entity.Baslik;
            txtIletisimTurleri.EditValue = entity.IletisimTuru.ToName();
            entity.KayitTuru = KayitTuru.Cari;
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
            tglVarsayilanYap.IsOn = entity.VarsayilanYap;
            tglVoip.IsOn = entity.VoipMi;
            tglDurum.IsOn = entity.Durum;
            tglVarsayilanYap.IsOn = entity.VarsayilanYap;
        }
        protected override void GuncelNesneOlustur()
        {
            var eskiEntity = OldEntity as GenelIletisimS; // Burada cast ediyoruz.

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
            CurrentEntity = new GenelIletisim
            {
                Id = Id,
                Kod = txtKod.Text,
                Baslik = txtBaslik.Text,
                Oncelik = (short)txtOncelik.Value,
                Web = txtWeb.Text,
                KayitTuru = KayitTuru.Cari,
                IletisimTuru = txtIletisimTurleri.Text.GetEnum<IletisimTuru>(),
                IzinDurumu = txtIzinDurumu.Text.GetEnum<IletisimDurumu>(),
                Kanallar = txtKanallar.EditValue?.ToString(),
                Arama = yeniArama,
                Sms = yeniSms,
                Whatsapp = yeniWhatsapp,
                EPBool = yeniEposta,
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
                CarilerId = BaseIslemTuru == IslemTuru.EntityInsert ? _cariId : ((GenelIletisimS)OldEntity).CarilerId,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Aciklama = txtAciklama.Text,
                KayitHesabiAdi = ((GenelIletisimS)OldEntity).KayitHesabiAdi,
                VarsayilanYap = tglVarsayilanYap.IsOn,
                VoipMi = tglVoip.IsOn,
                Durum = tglDurum.IsOn
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

            // Telefon gibi diğer türlerde seçimleri temizlemek için:
            if (tur != IletisimTuru.EPosta)
            {
                txtKanallar.SetEditValue(null); // Önceki seçimleri temizle
            }
            else
            {
                // E-Posta için default seçili zaten ayarlandı, ekstra işlem yok
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
            return ((GenelIletisimBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.CarilerId == _cariId);
        }
        protected override bool EntityUpdate()
        {
            return ((GenelIletisimBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.CarilerId == _cariId);
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.CariIletisim);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.CariIletisim);
                else if (sender == txtSosyalMedyaPlatformu)
                    sec.Sec(txtSosyalMedyaPlatformu, KartTuru.SosyalMedyaPlatformu);
        }
    }
}