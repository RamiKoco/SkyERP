using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.General.KisiBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.KisiEntity;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;

namespace AsamaGlobal.ERP.UI.Win.Forms.KisiGrubuForms
{
    public partial class KisiGrubuEditForm : BaseEditForm
    {
        public KisiGrubuEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KisiGrubuBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.KisiGrubu;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new KisiGrubu() : ((KisiGrubuBll)Bll).Single(FilterFunctions.Filter<KisiGrubu>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KisiGrubuBll)Bll).YeniKodVer();
            txtKisiGrubuAdi.Focus();
        }

        protected override void NesneyiKontrollereBagla()
        {
            var entity = (KisiGrubu)OldEntity;

            txtKod.Text = entity.Kod;
            txtKisiGrubuAdi.Text = entity.GrupAdi;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new KisiGrubu
            {
                Id = Id,
                Kod = txtKod.Text,
                GrupAdi = txtKisiGrubuAdi.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();
        }
    }
}