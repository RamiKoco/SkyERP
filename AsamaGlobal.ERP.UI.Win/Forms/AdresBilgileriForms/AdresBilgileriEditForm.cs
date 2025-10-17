using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Functions;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;
using System;
using System.Linq;

namespace AsamaGlobal.ERP.UI.Win.Forms.AdresBilgileriForms
{
    public partial class AdresBilgileriEditForm : BaseEditForm
    {
        public AdresBilgileriEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new AdresBilgileriBll(myDataLayoutControl);
            txtKayitTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<KayitTuru>());
            txtAdresTipi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<AdresTipi>());
            BaseKartTuru = KartTuru.AdresBilgileri;
            txtKayitTuru.SelectedIndexChanged += (s, e) =>
            {
                txtKayitHesabi.Id = 0;
                txtKayitHesabi.Text = "";
            };
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new AdresBilgileriS() : ((AdresBilgileriBll)Bll).Single(FilterFunctions.Filter<AdresBilgileri>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((AdresBilgileriBll)Bll).YeniKodVer();
            txtBaslik.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (AdresBilgileriS)OldEntity;
            txtKod.Text = entity.Kod;
            txtBaslik.Text = entity.Baslik;
            txtAdresNotu.Text = entity.AdresNotu;
            txtKayitTuru.SelectedItem = entity.KayitTuru.ToName();
            txtAdresTipi.SelectedItem = entity.AdresTipi.ToName();

            if (entity.KayitTuru == KayitTuru.Kisi)
                txtKayitHesabi.Id = entity.KisiId ?? 0;
            else if (entity.KayitTuru == KayitTuru.Personel)
                txtKayitHesabi.Id = entity.PersonelId ?? 0;
            else if (entity.KayitTuru == KayitTuru.Meslek)
                txtKayitHesabi.Id = entity.MeslekId ?? 0;
            else
                txtKayitHesabi.Id = 0;

            txtKayitHesabi.Text = entity.KayitHesabiAdi;
            txtUlke.Id = entity.UlkeId;
            txtUlke.Text = entity.UlkeAdi;
            txtIl.Id = entity.IlId;
            txtIl.Text = entity.IlAdi;
            txtIlce.Id = entity.IlceId;
            txtIlce.Text = entity.IlceAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAdresTurleri.Id = entity.AdresTurleriId;
            txtAdresTurleri.Text = entity.AdresTurleriAdi;
            txtPostaKodu.Text = entity.PostaKodu;
            txtAdres.Text = entity.Adres;
            txtEnlem.EditValue = entity.Enlem ?? 0m;
            txtBoylam.EditValue = entity.Boylam ?? 0m;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            decimal.TryParse(txtEnlem.EditValue?.ToString(), out var enlem);
            decimal.TryParse(txtBoylam.EditValue?.ToString(), out var boylam);
            var kayitTuru = txtKayitTuru.SelectedItem?.ToString().GetEnum<KayitTuru>() ?? KayitTuru.Kisi;

            var kisiId = kayitTuru == KayitTuru.Kisi ? txtKayitHesabi.Id : null;
            var personelId = kayitTuru == KayitTuru.Personel ? txtKayitHesabi.Id : null;
            var meslekId = kayitTuru == KayitTuru.Meslek ? txtKayitHesabi.Id : null;

            CurrentEntity = new AdresBilgileri
            {
                Id = Id,
                Kod = txtKod.Text,
                Baslik = txtBaslik.Text,
                AdresNotu = txtAdresNotu.Text,
                KayitTuru = kayitTuru,
                AdresTipi = txtAdresTipi.Text.GetEnum<AdresTipi>(),
                KisiId = kisiId,
                PersonelId = personelId,
                MeslekId = meslekId,
                UlkeId = txtUlke.Id,
                IlId = txtIl.Id,
                IlceId = txtIlce.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                AdresTurleriId = txtAdresTurleri.Id,
                PostaKodu = txtPostaKodu.Text,
                Adres = txtAdres.Text,
                Enlem = enlem,
                Boylam = boylam,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
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
                if (sender == txtUlke)
                    sec.Sec(txtUlke);
                else if (sender == txtIl)
                    sec.Sec(txtIl);
                else if (sender == txtIlce)
                    sec.Sec(txtIlce, txtIl);
                else if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.AdresBilgileri);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.AdresBilgileri);
                else if (sender == txtAdresTurleri)
                    sec.Sec(txtAdresTurleri, KartTuru.AdresTurleri);
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
        protected override void Control_EnabledChange(object sender, EventArgs e)
        {
            if (sender != txtIl) return;
            txtIl.ControlEnabledChange(txtIlce);
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
            var personelId = kayitTuru == KayitTuru.Personel ? txtKayitHesabi.Id : 0;


            if (kayitTuru == KayitTuru.Kisi && kisiId.HasValue && kisiId > 0)
            {
                var adresEntity = CurrentEntity as AdresBilgileri;
                if (adresEntity == null) return false;

                using (var context = new ERPContext())
                {
                    // Daha önce kaydedilmiş aynı adres kaydını sil
                    var mevcutKayitlar = context.AdresHareketleri
                        .Where(x => x.AdresBilgileriId == adresEntity.Id)
                        .ToList();

                    if (mevcutKayitlar.Any())
                    {
                        foreach (var kayit in mevcutKayitlar)
                        {
                            context.AdresHareketleri.Remove(kayit);
                        }
                        context.SaveChanges();
                    }

                    // Yeni kaydı oluştur ve ekle
                    var yeniKayit = new AdresHareketleri
                    {
                        KisiId = kisiId.Value,
                        AdresBilgileriId = adresEntity.Id
                    };

                    context.AdresHareketleri.Add(yeniKayit);
                    context.SaveChanges();
                }
            }
            if (kayitTuru == KayitTuru.Personel && personelId.HasValue && personelId > 0)
            {
                var adresEntity = CurrentEntity as AdresBilgileri;
                if (adresEntity == null) return false;

                using (var context = new ERPContext())
                {
                    // Daha önce kaydedilmiş aynı adres kaydını sil
                    var mevcutKayitlar = context.AdresHareketleri
                        .Where(x => x.AdresBilgileriId == adresEntity.Id)
                        .ToList();

                    if (mevcutKayitlar.Any())
                    {
                        foreach (var kayit in mevcutKayitlar)
                        {
                            context.AdresHareketleri.Remove(kayit);
                        }
                        context.SaveChanges();
                    }

                    // Yeni kaydı oluştur ve ekle
                    var yeniKayit = new AdresHareketleri
                    {
                        PersonelId = personelId.Value,
                        AdresBilgileriId = adresEntity.Id
                    };

                    context.AdresHareketleri.Add(yeniKayit);
                    context.SaveChanges();
                }
            }

            return true;
        }
    }
}