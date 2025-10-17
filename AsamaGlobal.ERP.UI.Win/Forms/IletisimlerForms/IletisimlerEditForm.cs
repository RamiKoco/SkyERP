using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Dto.IletisimlerDto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Functions;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Linq;

namespace AsamaGlobal.ERP.UI.Win.Forms.IletisimlerForms
{
    public partial class IletisimlerEditForm : BaseEditForm
    {
        public IletisimlerEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new IletisimlerBll(myDataLayoutControl);
            txtKayitTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<KayitTuru>());
            txtIletisimTurleri.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimTuru>());
            txtIzinDurumu.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimDurumu>());
            txtKanallar.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<IletisimKanalTipi>()
                        .Cast<string>()
                        .Select(x => new CheckedListBoxItem(x))
                        .ToArray());

            BaseKartTuru = KartTuru.Iletisimler;
            txtKayitTuru.SelectedIndexChanged += (s, e) =>
            {
                txtKayitHesabi.Id = 0;
                txtKayitHesabi.Text = "";
            };
            txtIletisimTurleri.EditValueChanged += TxtIletisimTurleri_EditValueChanged;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert
                ? new IletisimlerS()
                : ((IletisimlerBll)Bll).Single(FilterFunctions.Filter<Iletisimler>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((IletisimlerBll)Bll).YeniKodVer();
            txtBaslik.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (IletisimlerS)OldEntity;
            txtKod.Text = entity.Kod;
            txtBaslik.Text = entity.Baslik;
            txtIlgili.Text = entity.Ilgili;
            txtWeb.Text = entity.Web;
            txtKayitTuru.SelectedItem = entity.KayitTuru.ToName();
            if (entity.KayitTuru == KayitTuru.Kisi)
                txtKayitHesabi.Id = entity.KisiId ?? 0;
            else if (entity.KayitTuru == KayitTuru.Personel)
                txtKayitHesabi.Id = entity.PersonelId ?? 0;
            else if (entity.KayitTuru == KayitTuru.Meslek)
                txtKayitHesabi.Id = entity.MeslekId ?? 0;
            else
                txtKayitHesabi.Id = 0;
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
            txtVarsayilanMi.IsOn = entity.VarsayilanMi;
            tglDurum.IsOn = entity.Durum;
            ButonEnabledDurumu();
        }

        protected override void GuncelNesneOlustur()
        {
            var kayitTuru = txtKayitTuru.SelectedItem?.ToString().GetEnum<KayitTuru>() ?? KayitTuru.Kisi;

            var kisiId = kayitTuru == KayitTuru.Kisi ? txtKayitHesabi.Id : null;
            var meslekId = kayitTuru == KayitTuru.Meslek ? txtKayitHesabi.Id : null;
            var personelId = kayitTuru == KayitTuru.Personel ? txtKayitHesabi.Id : null;
            CurrentEntity = new Iletisimler
            {
                Id = Id,
                Kod = txtKod.Text,
                Baslik = txtBaslik.Text,
                Ilgili = txtIlgili.Text,
                Oncelik = (short)txtOncelik.Value,
                Web = txtWeb.Text,
                KayitTuru = kayitTuru,
                KisiId = kisiId,
                PersonelId = personelId,
                MeslekId = meslekId,
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
                VarsayilanMi = txtVarsayilanMi.IsOn,
                VoipMi = tglVoip.IsOn,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
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

            switch (iletisimTuru)
            {
                case IletisimTuru.Telefon:
                    txtEPosta.Enabled = false;
                    txtSosyalMedyaPlatformu.Enabled = false;
                    txtWeb.Enabled = false;
                    txtSosyalMedyaUrl.Enabled = false;
                    txtKullaniciAdi.Enabled = false;
                    break;

                case IletisimTuru.EPosta:
                    txtUlkeKodu.Enabled = false;
                    txtTelefonVeFax.Enabled = false;
                    txtDahili.Enabled = false;
                    txtSosyalMedyaPlatformu.Enabled = false;
                    txtWeb.Enabled = false;
                    txtSosyalMedyaUrl.Enabled = false;
                    txtKullaniciAdi.Enabled = false;
                    txtSIPKullaniciAdi.Enabled = false;
                    txtSIPServer.Enabled = false;
                    tglVoip.Enabled = false;
                    break;

                case IletisimTuru.Web:
                    txtUlkeKodu.Enabled = false;
                    txtTelefonVeFax.Enabled = false;
                    txtDahili.Enabled = false;
                    txtEPosta.Enabled = false;
                    txtSosyalMedyaPlatformu.Enabled = false;
                    txtSosyalMedyaUrl.Enabled = false;
                    txtKullaniciAdi.Enabled = false;
                    txtSIPKullaniciAdi.Enabled = false;
                    txtSIPServer.Enabled = false;
                    tglVoip.Enabled = false;
                    break;

                case IletisimTuru.SosyalMedya:
                    txtUlkeKodu.Enabled = false;
                    txtTelefonVeFax.Enabled = false;
                    txtDahili.Enabled = false;
                    txtEPosta.Enabled = false;
                    txtWeb.Enabled = false;
                    txtSIPKullaniciAdi.Enabled = false;
                    txtSIPServer.Enabled = false;
                    tglVoip.Enabled = false;
                    break;

                case IletisimTuru.Fax:
                    txtEPosta.Enabled = false;
                    txtSosyalMedyaPlatformu.Enabled = false;
                    txtWeb.Enabled = false;
                    txtSosyalMedyaUrl.Enabled = false;
                    txtKullaniciAdi.Enabled = false;
                    txtSIPKullaniciAdi.Enabled = false;
                    txtSIPServer.Enabled = false;
                    tglVoip.Enabled = false;
                    break;
            }
        }
        private void TxtIletisimTurleri_EditValueChanged(object sender, EventArgs e)
        {
            ButonEnabledDurumu();
        }

        private void txtKayitTuru_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtKayitHesabi.Id = 0;
            txtKayitHesabi.Text = string.Empty;
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Iletisim);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Iletisim);
                else if (sender == txtSosyalMedyaPlatformu)
                    sec.Sec(txtSosyalMedyaPlatformu, KartTuru.SosyalMedyaPlatformu);
                else if (sender == txtKayitHesabi)
                {
                    var kayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>();
                    if (kayitTuru == KayitTuru.Kisi)
                        sec.Sec(txtKayitHesabi, KartTuru.Kisi);
                    else if (kayitTuru == KayitTuru.Personel)
                        sec.Sec(txtKayitHesabi, KartTuru.Personel);
                    else if (kayitTuru == KayitTuru.Meslek)
                        sec.Sec(txtKayitHesabi, KartTuru.Meslek);
                    else
                        sec.Sec(txtKayitHesabi);
                }

        }
        public override bool Kaydet(bool kapanis)
        {
            if (!kapanis)
            {
                if (string.IsNullOrWhiteSpace(txtKayitHesabi.Text))
                {
                    Messages.HataliVeriMesaji("Lütfen Kayıt Hesabı giriniz.");
                    txtKayitHesabi.Focus();
                    return false;
                }
            }

            var sonuc = base.Kaydet(kapanis);

            if (!sonuc) return false;

            var kayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>();

            var kisiId = kayitTuru == KayitTuru.Kisi ? txtKayitHesabi.Id : null;
            var personelId = kayitTuru == KayitTuru.Personel ? txtKayitHesabi.Id : null;

            if (kayitTuru == KayitTuru.Kisi && kisiId.HasValue && kisiId > 0)
            {
                var iletisimEntity = CurrentEntity as Iletisimler;
                if (iletisimEntity == null) return false;

                var entity = new IletisimBilgi
                {
                    KisiId = kisiId.Value,
                    IletisimlerId = iletisimEntity.Id,
                    Veli = true,
                    IletisimTuru = iletisimEntity.IletisimTuru
                };

                using (var context = new ERPContext())
                {
                    // Aynı iletişim kaydına bağlı olan tüm kayıtları bul (yani IletisimId eşleşenler)
                    var mevcutKayitlar = context.IletisimBilgi
                        .Where(x => x.IletisimlerId == iletisimEntity.Id)
                        .ToList();

                    // Eğer varsa hepsini sil
                    if (mevcutKayitlar.Any())
                    {
                        foreach (var kayit in mevcutKayitlar)
                        {
                            context.IletisimBilgi.Remove(kayit);
                        }
                        context.SaveChanges();
                    }

                    // Yeni kaydı ekle
                    var yeniKayit = new IletisimBilgi
                    {
                        KisiId = kisiId.Value,
                        IletisimlerId = iletisimEntity.Id,
                        Veli = true,
                        IletisimTuru = iletisimEntity.IletisimTuru
                    };

                    context.IletisimBilgi.Add(yeniKayit);
                    context.SaveChanges();
                }
            }
            if (kayitTuru == KayitTuru.Personel && personelId.HasValue && personelId > 0)
            {
                var iletisimEntity = CurrentEntity as Iletisimler;
                if (iletisimEntity == null) return false;

                var entity = new IletisimBilgi
                {
                    PersonelId = personelId.Value,
                    IletisimlerId = iletisimEntity.Id,
                    Veli = true,
                    IletisimTuru = iletisimEntity.IletisimTuru
                };

                using (var context = new ERPContext())
                {
                    // Aynı iletişim kaydına bağlı olan tüm kayıtları bul (yani IletisimId eşleşenler)
                    var mevcutKayitlar = context.IletisimBilgi
                        .Where(x => x.IletisimlerId == iletisimEntity.Id)
                        .ToList();

                    // Eğer varsa hepsini sil
                    if (mevcutKayitlar.Any())
                    {
                        foreach (var kayit in mevcutKayitlar)
                        {
                            context.IletisimBilgi.Remove(kayit);
                        }
                        context.SaveChanges();
                    }

                    // Yeni kaydı ekle
                    var yeniKayit = new IletisimBilgi
                    {
                        PersonelId = personelId.Value,
                        IletisimlerId = iletisimEntity.Id,
                        Veli = true,
                        IletisimTuru = iletisimEntity.IletisimTuru
                    };

                    context.IletisimBilgi.Add(yeniKayit);
                    context.SaveChanges();
                }
            }
            return true;
        }

    }
}