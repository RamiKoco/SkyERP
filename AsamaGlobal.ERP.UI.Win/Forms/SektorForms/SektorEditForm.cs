using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;

namespace AsamaGlobal.ERP.UI.Win.Forms.SektorForms
{
    public partial class SektorEditForm : BaseEditForm
    {
        public SektorEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new SektorBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Sektor;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Sektor() : ((SektorBll)Bll).Single(FilterFunctions.Filter<Sektor>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((SektorBll)Bll).YeniKodVer();
            txtAd.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Sektor)OldEntity;
            txtKod.Text = entity.Kod;
            txtAd.Text = entity.Ad;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Sektor
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