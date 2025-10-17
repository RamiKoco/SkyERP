using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.UserControls.Controls;

namespace AsamaGlobal.ERP.UI.Win.Forms.DepartmanForms
{
    public partial class DepartmanEditForm : BaseEditForm
    {
        public DepartmanEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new DepartmanBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Departman;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new Departman() : ((DepartmanBll)Bll).Single(FilterFunctions.Filter<Departman>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((DepartmanBll)Bll).YeniKodVer();
            txtDepartmanAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (Departman)OldEntity;

            txtKod.Text = entity.Kod;
            txtDepartmanAdi.Text = entity.Ad;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Departman
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtDepartmanAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}