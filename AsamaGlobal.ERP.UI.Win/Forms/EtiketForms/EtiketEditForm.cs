using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Functions;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using DevExpress.XtraEditors;
using System.Drawing;

namespace AsamaGlobal.ERP.UI.Win.Forms.EtiketForms
{
    public partial class EtiketEditForm : BaseEditForm
    {
        public EtiketEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new EtiketBll(myDataLayoutControl);
            BaseKartTuru = KartTuru.Etiket;
            EventsLoad();
            txtKayitTuru.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<KayitTuru>());
        } 

        public override void Yukle()
        {
            OldEntity = BaseIslemTuru == IslemTuru.EntityInsert ? new EtiketS() : ((EtiketBll)Bll).Single(FilterFunctions.Filter<Etiket>(Id));
            NesneyiKontrollereBagla();
            TabloYukle();
            if (BaseIslemTuru != IslemTuru.EntityInsert) return;
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((EtiketBll)Bll).YeniKodVer();
            txtKod.Focus();
        }
        protected override void NesneyiKontrollereBagla()
        {
            var entity = (EtiketS)OldEntity;

            txtKod.Text = entity.Kod;
            txtEtiketAdi.Text = entity.EtiketAdi;
            txtKayitTuru.SelectedItem = entity.KayitTuru.ToName();
            txtAciklama.Text = entity.Aciklama;
            txtRenk.Id = entity.RenkId;
            txtRenk.Text = entity.RenkAdi;

            if (entity.YaziRgbKodu != 0)
                txtYaziRgbKodu.Color = Color.FromArgb(entity.YaziRgbKodu);
            else
                txtYaziRgbKodu.Color = Color.Black;

            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Etiket
            {
                Id = Id,
                Kod = txtKod.Text,
                EtiketAdi = txtEtiketAdi.Text,
                KayitTuru = txtKayitTuru.Text.GetEnum<KayitTuru>(),
                Aciklama = txtAciklama.Text,
                RenkId = txtRenk.Id,
                YaziRgbKodu = txtYaziRgbKodu.Color.ToArgb(),
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
                if (sender == txtRenk)
                    sec.Sec(txtRenk);
                else if (sender == txtOzelKod1)
                    sec.Sec(txtOzelKod1, KartTuru.Etiket);
                else if (sender == txtOzelKod2)
                    sec.Sec(txtOzelKod2, KartTuru.Etiket);

        }
    }
}