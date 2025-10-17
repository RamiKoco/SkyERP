using AsamaGlobal.ERP.Bll.General.CarilerBll.CariSubeBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Dto.CariDto.CariSubeDto;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariSube;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms.CariSubeGrubuForms
{
    public partial class CariSubeGrubuEditForm : BaseEditForm
    {       
        public CariSubeGrubuEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new CariSubeGrubuBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.CariSubeGrubu;
            EventsLoad();
        }
        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new CariSubeGrubuS() : ((CariSubeGrubuBll)Bll).Single(FilterFunctions.Filter<CariSubeGrubu>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((CariSubeGrubuBll)Bll).YeniKodVer();
            txtCariSubeGrubuAdi.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (CariSubeGrubuS)OldEntity;

            txtKod.Text = entity.Kod;
            txtCariSubeGrubuAdi.Text = entity.Ad;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new CariSubeGrubu
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtCariSubeGrubuAdi.Text,
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
                    sec.Sec(txtOzelKod1, KartTuru.CariSubeGrubu);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.CariSubeGrubu);
        }
    }
}