using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;

namespace AsamaGlobal.ERP.UI.Win.Forms.PozisyonForms
{
    public partial class PozisyonEditForm : BaseEditForm
    {
        public PozisyonEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new PozisyonBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Pozisyon;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new PozisyonS() : ((PozisyonBll)Bll).Single(FilterFunctions.Filter<Pozisyon>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((PozisyonBll)Bll).YeniKodVer();
            txtPozisyonAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (PozisyonS)OldEntity;
            txtKod.Text = entity.Kod;
            txtPozisyonAdi.Text = entity.Ad;
            txtRenk.Id = entity.RenkId;
            txtRenk.Text = entity.RenkAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Pozisyon
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtPozisyonAdi.Text,
                RenkId = txtRenk.Id,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
                if (sender == txtRenk)
                    sec.Sec(txtRenk, KartTuru.Pozisyon);

        }
    }
}