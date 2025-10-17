using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;


namespace AsamaGlobal.ERP.UI.Win.Forms.SosyalMedyaForms
{
    public partial class SosyalMedyaPlatformuEditForm : BaseEditForm
    {
        public SosyalMedyaPlatformuEditForm()
        {
            InitializeComponent();


            DataLayoutControl = myDataLayoutControl;
            Bll = new SosyalMedyaPlatformuBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.SosyalMedyaPlatformu;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new SosyalMedyaPlatformuS() : ((SosyalMedyaPlatformuBll)Bll).Single(FilterFunctions.Filter<SosyalMedyaPlatformu>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((SosyalMedyaPlatformuBll)Bll).YeniKodVer();
            txtAd.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (SosyalMedyaPlatformuS)OldEntity;
            txtKod.Text = entity.Kod;
            txtAd.Text = entity.Ad;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new SosyalMedyaPlatformu
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtAd.Text,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
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
                    sec.Sec(txtOzelKod1, KartTuru.SosyalMedyaPlatformu);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.SosyalMedyaPlatformu);
        }
    }
}