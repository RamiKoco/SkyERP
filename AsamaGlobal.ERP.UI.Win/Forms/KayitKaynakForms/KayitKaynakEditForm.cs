using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;


namespace AsamaGlobal.ERP.UI.Win.Forms.KayitKaynakForms
{
    public partial class KayitKaynakEditForm : BaseEditForm
    {
        public KayitKaynakEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KayitKaynakBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.KayitKaynak;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new KayitKaynak() : ((KayitKaynakBll)Bll).Single(FilterFunctions.Filter<KayitKaynak>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KayitKaynakBll)Bll).YeniKodVer();
            txtKayitKaynakAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KayitKaynak)OldEntity;

            txtKod.Text = entity.Kod;
            txtKayitKaynakAdi.Text = entity.KayitKaynakAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new KayitKaynak
            {
                Id = Id,
                Kod = txtKod.Text,
                KayitKaynakAdi = txtKayitKaynakAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}