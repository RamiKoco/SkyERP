using AsamaGlobal.ERP.Bll.Functions;
using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.AdresBilgileriForms;
using AsamaGlobal.ERP.UI.Win.Forms.AdresTurleriForms;
using AsamaGlobal.ERP.UI.Win.Forms.AileBilgiForms;
using AsamaGlobal.ERP.UI.Win.Forms.AvukatForms;
using AsamaGlobal.ERP.UI.Win.Forms.BankaForms;
using AsamaGlobal.ERP.UI.Win.Forms.BankaHesapForms;
using AsamaGlobal.ERP.UI.Win.Forms.BelgeTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariGruplariForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms.CariSubeGrubuForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariTurleriForms;
using AsamaGlobal.ERP.UI.Win.Forms.DepartmanForms;
using AsamaGlobal.ERP.UI.Win.Forms.EtiketForms;
using AsamaGlobal.ERP.UI.Win.Forms.EvrakForms;
using AsamaGlobal.ERP.UI.Win.Forms.FaturaForms;
using AsamaGlobal.ERP.UI.Win.Forms.GorevForms;
using AsamaGlobal.ERP.UI.Win.Forms.HizmetForms;
using AsamaGlobal.ERP.UI.Win.Forms.HizmetTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.IletisimForms;
using AsamaGlobal.ERP.UI.Win.Forms.IletisimlerForms;
using AsamaGlobal.ERP.UI.Win.Forms.IlForms;
using AsamaGlobal.ERP.UI.Win.Forms.IndirimForms;
using AsamaGlobal.ERP.UI.Win.Forms.IndirimTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.IptalNedeniForms;
using AsamaGlobal.ERP.UI.Win.Forms.IsyeriForms;
using AsamaGlobal.ERP.UI.Win.Forms.KasaForms;
using AsamaGlobal.ERP.UI.Win.Forms.KayitKaynakForms;
using AsamaGlobal.ERP.UI.Win.Forms.KimlikTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.KisiForms;
using AsamaGlobal.ERP.UI.Win.Forms.KisiGrubuForms;
using AsamaGlobal.ERP.UI.Win.Forms.KontenjanForms;
using AsamaGlobal.ERP.UI.Win.Forms.KullaniciForms;
using AsamaGlobal.ERP.UI.Win.Forms.KurumlarForms;
using AsamaGlobal.ERP.UI.Win.Forms.KurumTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.MakbuzForms;
using AsamaGlobal.ERP.UI.Win.Forms.MeslekForms;
using AsamaGlobal.ERP.UI.Win.Forms.OdemeTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.OgrenciForms;
using AsamaGlobal.ERP.UI.Win.Forms.OkulForms;
using AsamaGlobal.ERP.UI.Win.Forms.PersonelForms;
using AsamaGlobal.ERP.UI.Win.Forms.PozisyonForms;
using AsamaGlobal.ERP.UI.Win.Forms.PromosyonForms;
using AsamaGlobal.ERP.UI.Win.Forms.RehberForms;
using AsamaGlobal.ERP.UI.Win.Forms.RenkForms;
using AsamaGlobal.ERP.UI.Win.Forms.SektorForms;
using AsamaGlobal.ERP.UI.Win.Forms.ServisForms;
using AsamaGlobal.ERP.UI.Win.Forms.SinifForms;
using AsamaGlobal.ERP.UI.Win.Forms.SinifGrupForms;
using AsamaGlobal.ERP.UI.Win.Forms.SosyalMedyaForms;
using AsamaGlobal.ERP.UI.Win.Forms.TahakkukForms;
using AsamaGlobal.ERP.UI.Win.Forms.TesvikForms;
using AsamaGlobal.ERP.UI.Win.Forms.UlkeForms;
using AsamaGlobal.ERP.UI.Win.Forms.UyrukForms;
using AsamaGlobal.ERP.UI.Win.Forms.VergiDairesiForms;
using AsamaGlobal.ERP.UI.Win.Forms.YabancıDilForms;
using AsamaGlobal.ERP.UI.Win.Forms.YakinlikForms;
using AsamaGlobal.ERP.UI.Win.Reports.FormReports;
using AsamaGlobal.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon.Gallery;
using DevExpress.XtraTabbedMdi;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.UI.Win.GenelForms
{
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static string KurumAdi;
        public static long KullaniciId;
        public static string KullaniciAdi;
        public static long KullaniciRolId;
        public static string KullaniciRolAdi;


        public static long DonemId;
        public static string DonemAdi = "Dönem Bilgisi Bekleniyor...";
        public static long SubeId;
        public static string SubeAdi = "Şube Bilgisi Bekleniyor...";
        public static List<long> YetkiliOlunanSubeler;
        public static DonemParametre DonemParametreleri;
        public static KullaniciParametreS KullaniciParametreleri = new KullaniciParametreS();
        public static IEnumerable<RolYetkileriL> RolYetkileri;

        public AnaForm()
        {
            InitializeComponent();
            EventsLoad();

            imgArkaPlanResim.EditValue = KullaniciParametreleri.ArkaPlanResim;
        }

        private void EventsLoad()
        {
            Load += AnaForm_Load;
            FormClosing += AnaForm_FormClosing;
            KeyDown += Control_KeyDown;

            foreach (var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case SkinRibbonGalleryBarItem btn:
                        btn.GalleryItemClick += GallleryItem_GalleryItemClick;
                        break;

                    case SkinPaletteRibbonGalleryBarItem btn:
                        btn.GalleryItemClick += GallleryItem_GalleryItemClick;
                        break;


                    case BarButtonItem btn:
                        btn.ItemClick += Butonlar_ItemClick;
                        break;
                }
                    
            }

            foreach (Control control in Controls)
                control.KeyDown += Control_KeyDown;

            xtraTabbedMdiManager.PageAdded += XtraTabbedMdiManager_PageAdded;
            xtraTabbedMdiManager.PageRemoved += XtraTabbedMdiManager_PageRemoved;
        }

        private void SubeDonemSecimi(bool subeSecimButonunaBasildi)
        {
            ShowEditForms<SubeDonemSecimiEditForm>.ShowDialogEditForm(null, KullaniciId, subeSecimButonunaBasildi,
                SubeId, DonemId);
            barDonem.Caption = DonemAdi;
            btnSube.Caption = SubeAdi;
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void AnaForm_Load(object sender, System.EventArgs e)
        {
            barKullanici.Caption = $"{KullaniciAdi} ( {KullaniciRolAdi} )";
            barKurum.Caption = KurumAdi;
            SubeDonemSecimi(false);

            if (DonemParametreleri == null)
            {
                Messages.HataMesaji("Dönem Parametreleri Girilmemiş. Lütfen Sistem Yöneticinize Başvurunuz.");
                Application.ExitThread();
                return;
            }

            if (!DonemParametreleri.YetkiKontroluAnlikYapilacak)
                using (var bll = new RolYetkileriBll())
                    RolYetkileri = bll.List(x => x.RolId == KullaniciRolId).EntityListConvert<RolYetkileriL>();

        }

        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Messages.HayirSeciliEvetHayir("Programdan Çıkmak İstiyor Musunuz.", "Çıkış Onay") == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;
        }


        private void GallleryItem_GalleryItemClick(object sender, DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs e)
        {
            var gallery = sender as InRibbonGallery;
            var key = "";

            if (gallery.OwnerItem.GetType() == typeof(SkinRibbonGalleryBarItem))
                key = "Skin";
            else if (gallery.OwnerItem.GetType() == typeof(SkinPaletteRibbonGalleryBarItem))
                key = "Palette";

          Functions.GeneralFunctions.AppSettingsWrite(key, e.Item.Caption);
        }

        private void Butonlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item==btnOkulKartlari)
                ShowListForms<OkulListForm>.ShowListForm(KartTuru.Okul);
            else if (e.Item == btnAdresKartlari)
                ShowListForms<AdresBilgileriListForm>.ShowListForm(KartTuru.AdresBilgileri);
            else if (e.Item == btnAdresTurleriKartlari)
                ShowListForms<AdresTurleriListForm>.ShowListForm(KartTuru.AdresTurleri);
            else if (e.Item == btnUlkeKartlari)
                ShowListForms<UlkeListForm>.ShowListForm(KartTuru.Ulke);
            else if (e.Item == btnIlKartlari)
                ShowListForms<IlListForm>.ShowListForm(KartTuru.Il);
            else if (e.Item == btnAileBilgiKartlari)
                ShowListForms<AileBilgiListForm>.ShowListForm(KartTuru.AileBilgi);
            else if (e.Item == btnIptalNedeniKartlari)
                ShowListForms<IptalNedeniListForm>.ShowListForm(KartTuru.IptalNedeni);
            else if (e.Item == btnYabanciDilKartlari)
                ShowListForms<YabanciDilListForm>.ShowListForm(KartTuru.YabanciDil);
            else if (e.Item == btnTesvikKartlari)
                ShowListForms<TesvikListForm>.ShowListForm(KartTuru.Tesvik);
            else if (e.Item == btnKontenjanKartlari)
                ShowListForms<KontenjanListForm>.ShowListForm(KartTuru.Kontenjan);
            else if (e.Item == btnRehberKartlari)
                ShowListForms<RehberListForm>.ShowListForm(KartTuru.Rehber);
            else if(e.Item == btnSinifGrupKartlari)
                ShowListForms<SinifGrupListForm>.ShowListForm(KartTuru.SinifGrup);
            else if (e.Item == btnMeslekKartlari)
                ShowListForms<MeslekListForm>.ShowListForm(KartTuru.Meslek);
            else if (e.Item == btnYakinlikKartlari)
                ShowListForms<YakinlikListForm>.ShowListForm(KartTuru.Yakinlik);
            else if(e.Item == btnIsyeriKartlari)
                ShowListForms<IsyeriListForm>.ShowListForm(KartTuru.Isyeri);
            else if(e.Item == btnGorevKartlari)
                ShowListForms<GorevListForm>.ShowListForm(KartTuru.Gorev);
            else if (e.Item == btnIndirimTuruKartlari)
                ShowListForms<IndirimTuruListForm>.ShowListForm(KartTuru.IndirimTuru);
            else if (e.Item == btnEvrakKartlari)
                ShowListForms<EvrakListForm>.ShowListForm(KartTuru.Evrak);
            else if (e.Item == btnPromosyonKartlari)
                ShowListForms<PromosyonListForm>.ShowListForm(KartTuru.Promosyon);
            else if (e.Item == btnServisYeriKartlari)
                ShowListForms<ServisListForm>.ShowListForm(KartTuru.Servis);
            else if (e.Item == btnSinifKartlari)
                ShowListForms<SinifListForm>.ShowListForm(KartTuru.Sinif);
            else if (e.Item == btnHizmetTuruKartlari)
                ShowListForms<HizmetTuruListForm>.ShowListForm(KartTuru.HizmetTuru);
            else if (e.Item == btnHizmetKartlari)
                ShowListForms<HizmetListForm>.ShowListForm(KartTuru.Hizmet);
            else if (e.Item == btnKasaKartlari)
                ShowListForms<KasaListForm>.ShowListForm(KartTuru.Kasa);
            else if (e.Item == btnKayitKaynakKartlari)
                ShowListForms<KayitKaynakListForm>.ShowListForm(KartTuru.KayitKaynak);
            else if (e.Item == btnKisiGrubuKartlari)
                ShowListForms<KisiGrubuListForm>.ShowListForm(KartTuru.KisiGrubu);
            else if (e.Item == btnKisiKartlari)
                ShowListForms<KisiListForm>.ShowListForm(KartTuru.Kisi);
            else if (e.Item == btnRenkKartlari)
                ShowListForms<RenkListForm>.ShowListForm(KartTuru.Renk);
            else if (e.Item == btnEtiketKartlari)
                ShowListForms<EtiketListForm>.ShowListForm(KartTuru.Etiket);
            else if (e.Item == btnSosyalMedyaKartlari)
                ShowListForms<SosyalMedyaPlatformuListForm>.ShowListForm(KartTuru.SosyalMedyaPlatformu);
            else if (e.Item == btnDepartmanKartlari)
                ShowListForms<DepartmanListForm>.ShowListForm(KartTuru.Departman);
            else if (e.Item == btnKimlikTuruKartlari)
                ShowListForms<KimlikTuruListForm>.ShowListForm(KartTuru.KimlikTuru);
            else if (e.Item == btnUyrukKartlari)
                ShowListForms<UyrukListForm>.ShowListForm(KartTuru.Uyruk);
            else if (e.Item == btnPozisyonKartlari)
                ShowListForms<PozisyonListForm>.ShowListForm(KartTuru.Pozisyon);
            else if (e.Item == btnPersonelKartlari)
                ShowListForms<PersonelListForm>.ShowListForm(KartTuru.Personel);
            else if (e.Item == btnBelgeTuruKartlari)
                ShowListForms<BelgeTuruListForm>.ShowListForm(KartTuru.BelgeTuru);
            else if (e.Item == btnKurumTuruKartlari)
                ShowListForms<KurumTuruListForm>.ShowListForm(KartTuru.KurumTuru);
            else if (e.Item == btnKurumlarKartlari)
                ShowListForms<KurumlarListForm>.ShowListForm(KartTuru.Kurumlar);
            else if (e.Item == btnCarilerKartlari)
                ShowListForms<CarilerListForm>.ShowListForm(KartTuru.Cariler);

            else if (e.Item == btnBankaKartlari)
                ShowListForms<BankaListForm>.ShowListForm(KartTuru.Banka);
            else if (e.Item == btnAvukatKartlari)
                ShowListForms<AvukatListForm>.ShowListForm(KartTuru.Avukat);
            else if(e.Item == btnCariKartlar)
                ShowListForms<CariListForm>.ShowListForm(KartTuru.Cari);
            else if(e.Item == btnOdemeTuruKartlari)
                ShowListForms<OdemeTuruListForm>.ShowListForm(KartTuru.OdemeTuru);
            else if(e.Item == btnBankaHesapKartlari)
                ShowListForms<BankaHesapListForm>.ShowListForm(KartTuru.BankaHesap);
            else if (e.Item == btnIletisimKartlari)
                ShowListForms<IletisimListForm>.ShowListForm(KartTuru.Iletisim);
            else if (e.Item == btnCariTuruKartlari)
                ShowListForms<CariTuruListForm>.ShowListForm(KartTuru.CariTuru);
            else if (e.Item == btnCariGrubuKartlari)
                ShowListForms<CariGrubuListForm>.ShowListForm(KartTuru.CariGrubu);
            else if (e.Item == btnSektorKartlari)
                ShowListForms<SektorListForm>.ShowListForm(KartTuru.Sektor);

            else if (e.Item == btnIletisimlerKartlari)
                ShowListForms<IletisimlerListForm>.ShowListForm(KartTuru.Iletisimler);

            else if (e.Item == btnOgrenciKartlari)
                ShowListForms<OgrenciListForm>.ShowListForm(KartTuru.Ogrenci);
            else if (e.Item == btnIndirimKartlari)
                ShowListForms<IndirimListForm>.ShowListForm(KartTuru.Indirim);
            else if (e.Item == btnTahakkukKartlari)
                ShowListForms<TahakkukListForm>.ShowListForm(KartTuru.Tahakkuk);
            else if (e.Item == btnMakbuzKartlari)
                ShowListForms<MakbuzListForm>.ShowListForm(KartTuru.Makbuz);
            else if (e.Item == btnFaturaKartlari)
                ShowListForms<FaturaPlaniListForm>.ShowListForm(KartTuru.Fatura);
            else if (e.Item == btnFaturaTahakkukKarti)
                ShowEditForms<FaturaTahakkukEditForm>.ShowDialogEditForm(KartTuru.Fatura);
            else if (e.Item == btnGenelAmacliRapor)
                ShowEditReports<GenelAmacliRapor>.ShowEditReport(KartTuru.GenelAmacliRapor);
            else if (e.Item == btnSinifRaporlari)
                ShowEditReports<SinifRaporlari>.ShowEditReport(KartTuru.SinifRaporlari);
            else if (e.Item == btnHizmetAlimRaporu)
                ShowEditReports<HizmetAlimRaporu>.ShowEditReport(KartTuru.HizmetAlimRaporu);
            else if (e.Item == btnNetUcretRaporu)
                ShowEditReports<NetUcretRaporu>.ShowEditReport(KartTuru.NetUcretRaporu);
            else if (e.Item == btnUcretVeOdemeRaporu)
                ShowEditReports<UcretVeOdemeRaporu>.ShowEditReport(KartTuru.UcretVeOdemeRaporu);
            else if (e.Item == btnIndirimDagilimRaporu)
                ShowEditReports<IndirimDagilimRaporu>.ShowEditReport(KartTuru.IndirimDagilimRaporu);
            else if (e.Item == btnMesleklereGoreKayitRaporu)
                ShowEditReports<MesleklereGoreKayitRaporu>.ShowEditReport(KartTuru.MesleklereGoreKayitRaporu);
            else if (e.Item == btnAylikKayitRaporu)
                ShowEditReports<AylikKayitRaporu>.ShowEditReport(KartTuru.AylikKayitRaporu);
            else if (e.Item == btnGelirDagilimRaporu)
                ShowEditReports<GelirDagilimRaporu>.ShowEditReport(KartTuru.GelirDagilimRaporu);
            else if (e.Item == btnUcretOrtalamalariRaporu)
                ShowEditReports<UcretOrtalamalariRaporu>.ShowEditReport(KartTuru.UcretOrtalamalariRaporu);
            else if (e.Item == btnOdemeBelgeleriRaporu)
                ShowEditReports<OdemeBelgeleriRaporu>.ShowEditReport(KartTuru.OdemeBelgeleriRaporu);
            else if (e.Item == btnTahsilatRaporu)
                ShowEditReports<TahsilatRaporu>.ShowEditReport(KartTuru.TahsilatRaporu);
            else if (e.Item == btnGecikenAlacaklarRaporu)
                ShowEditReports<OdemesiGecikenAlacaklarRaporu>.ShowEditReport(KartTuru.OdemesiGecikenAlacaklarRaporu);
            else if (e.Item == btnKullaniciParametreleri)
            {
                var entity = ShowEditForms<KullaniciParametreEditForm>.ShowDialogEditForm<KullaniciParametreS>(KullaniciId);
                if (entity == null) return;
                KullaniciParametreleri = entity;
                imgArkaPlanResim.EditValue = entity.ArkaPlanResim;
            }
            else if (e.Item == btnHesapMakinesi)
                try
                {
                    Process.Start("calc.exe");
                }
                catch
                {
                    Messages.HataMesaji("Hesap Makinesi Bulunamadı.");
                }
            else if (e.Item == btnSube)
            {
                for (int i = 0; i < Application.OpenForms.Count; i++)
                {
                    if (Application.OpenForms[i] is GirisForm || Application.OpenForms[i] is AnaForm) continue;
                    Application.OpenForms[i].Close();
                    i--;
                }
                SubeDonemSecimi(true);
            }
            else if (e.Item == btnSifreDegistir)
                ShowEditForms<SifreDegistirEditForm>.ShowDialogEditForm(IslemTuru.EntityUpdate);

            Cursor.Current = Cursors.Default;
        }
        private void XtraTabbedMdiManager_PageAdded(object sender,MdiTabPageEventArgs e)
        {
            imgArkaPlanResim.SendToBack();
            
        }
        private void XtraTabbedMdiManager_PageRemoved(object sender,MdiTabPageEventArgs e)
        {
            if (((XtraTabbedMdiManager)sender).Pages.Count == 0)
                imgArkaPlanResim.BringToFront();
            
        }
    }
}