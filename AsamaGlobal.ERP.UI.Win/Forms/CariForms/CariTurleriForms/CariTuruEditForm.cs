using AsamaGlobal.ERP.Bll.General.CarilerBll.CariTurleriBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariTurleri;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariTurleriForms
{
    public partial class CariTuruEditForm : BaseEditForm
    {
        public CariTuruEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new CariTuruBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.CariTuru;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new CariTuru() : ((CariTuruBll)Bll).Single(FilterFunctions.Filter<CariTuru>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((CariTuruBll)Bll).YeniKodVer();
            txtAd.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (CariTuru)OldEntity;
            txtKod.Text = entity.Kod;
            txtAd.Text = entity.Ad;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new CariTuru
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtAd.Text,              
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();

        }
    }
}