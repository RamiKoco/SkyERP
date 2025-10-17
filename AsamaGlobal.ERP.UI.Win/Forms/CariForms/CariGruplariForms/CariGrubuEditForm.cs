using AsamaGlobal.ERP.Bll.General.CarilerBll.CariGruplariBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariGrublari;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariGruplariForms
{
    public partial class CariGrubuEditForm : BaseEditForm
    {
        public CariGrubuEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new CariGrubuBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.CariGrubu;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new CariGrubuS() : ((CariGrubuBll)Bll).Single(FilterFunctions.Filter<CariGrubu>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((CariGrubuBll)Bll).YeniKodVer();
            txtAd.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (CariGrubuS)OldEntity;
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
            CurrentEntity = new CariGrubu
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
                    sec.Sec(txtOzelKod1, KartTuru.CariGrubu);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.CariGrubu);
        }
    }
}