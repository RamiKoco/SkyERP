using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;
using System;

namespace AsamaGlobal.ERP.UI.Win.Forms.VergiDairesiForms
{
    public partial class VergiDairesiEditForm : BaseEditForm
    {
        public VergiDairesiEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new VergiDairesiBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.VergiDairesi;
            EventsLoad();
        }

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new VergiDairesiS() : ((VergiDairesiBll)Bll).Single(FilterFunctions.Filter<VergiDairesi>(Id));
            NesneyiKontrollereBagla();

            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Focus();
        }    
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (VergiDairesiS)OldEntity;

            txtKod.Text = entity.Kod;
            txtVergiDairesiAdi.Text = entity.Ad;
            txtIl.Id = entity.IlId;
            txtIl.Text = entity.IlAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new VergiDairesi
            {
                Id = Id,
                Kod = txtKod.Text,
                Ad = txtVergiDairesiAdi.Text,
                IlId = Convert.ToInt64(txtIl.Id),
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };
            ButonEnabledDurumu();

        }


        protected override void SecimYap(object sender)
        {
            if (!(sender is ButtonEdit)) return;

            using (var sec = new SelectFunctions())
            {
                if (sender == txtIl)
                    sec.Sec(txtIl);
            }

        }
    }
}