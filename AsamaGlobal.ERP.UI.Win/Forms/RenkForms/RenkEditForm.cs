using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;
using System.Drawing;


namespace AsamaGlobal.ERP.UI.Win.Forms.RenkForms
{
    public partial class RenkEditForm : BaseEditForm
    {
        public RenkEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new RenkBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Renk;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new RenkS() : ((RenkBll)Bll).Single(FilterFunctions.Filter<Renk>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((RenkBll)Bll).YeniKodVer();
            txtRenkAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (RenkS)OldEntity;

            txtKod.Text = entity.Kod;
            txtRenkAdi.Text = entity.RenkAdi;
            txtRGB.Text = entity.RGB;
            txtForeColor.Color = Color.FromArgb(entity.ForeColor);
            //txtRenkAdi.ForeColor = Color.FromArgb(entity.ForeColor); // <- BURASI!
            txtAciklama.Text = entity.Aciklama;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Renk
            {
                Id = Id,
                Kod = txtKod.Text,
                RenkAdi = txtRenkAdi.Text,
                RGB = txtForeColor.Text,
                ForeColor = txtForeColor.Color.ToArgb(),
                Aciklama = txtAciklama.Text,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id = txtOzelKod2.Id,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }

        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())

                if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Renk);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Renk);

        }
    }
}