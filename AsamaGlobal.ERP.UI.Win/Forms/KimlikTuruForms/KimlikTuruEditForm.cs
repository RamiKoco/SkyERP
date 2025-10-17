using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;

namespace AsamaGlobal.ERP.UI.Win.Forms.KimlikTuruForms
{
    public partial class KimlikTuruEditForm : BaseEditForm
    {
        public KimlikTuruEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new KimlikTuruBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.KimlikTuru;
            EventsLoad();
            txtKarakterTipi.Properties.Items.Clear();
            txtKarakterTipi.Properties.Items.AddRange(new[] { "Numeric", "AlphaNumeric" });
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new KimlikTuruS() : ((KimlikTuruBll)Bll).Single(FilterFunctions.Filter<KimlikTuru>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KimlikTuruBll)Bll).YeniKodVer();
            txtKimlikTuruAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KimlikTuruS)OldEntity;
            txtKod.Text = entity.Kod;
            txtKimlikTuruAdi.Text = entity.KimlikAdi;
            txtUlke.Id = entity.UlkeId;
            txtUlke.Text = entity.UlkeAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
            txtKarakterTipi.Text = entity.KarakterTipi;
            txtUzunluk.EditValue = entity.Uzunluk;
        }

        protected override void GuncelNesneOlustur()
        {
            int uzunluk = 0;
            int.TryParse(txtUzunluk.Text, out uzunluk);
            CurrentEntity = new KimlikTuru
            {
                Id = Id,
                Kod = txtKod.Text,
                KimlikAdi = txtKimlikTuruAdi.Text,
                UlkeId = txtUlke.Id,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                KarakterTipi = txtKarakterTipi.SelectedItem?.ToString() ?? "",
                Uzunluk = uzunluk,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.KimlikTuru);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.KimlikTuru);
                else if (sender == txtUlke)
                    sec.Sec(txtUlke, KartTuru.KimlikTuru);


        }
    }
}