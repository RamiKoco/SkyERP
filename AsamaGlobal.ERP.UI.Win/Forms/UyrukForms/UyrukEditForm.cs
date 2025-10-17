using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;

namespace AsamaGlobal.ERP.UI.Win.Forms.UyrukForms
{
    public partial class UyrukEditForm : BaseEditForm
    {
        public UyrukEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new UyrukBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Uyruk;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new UyrukS() : ((UyrukBll)Bll).Single(FilterFunctions.Filter<Uyruk>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((UyrukBll)Bll).YeniKodVer();
            txtUyrukAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (UyrukS)OldEntity;
            txtKod.Text = entity.Kod;
            txtUyrukAdi.Text = entity.Ad;
            txtUlke.Id = entity.UlkeId;
            txtUlke.Text = entity.UlkeAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Uyruk
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtUyrukAdi.Text,
                UlkeId = txtUlke.Id,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtUlke)
                    sec.Sec(txtUlke, KartTuru.Uyruk);

        }
    }
}