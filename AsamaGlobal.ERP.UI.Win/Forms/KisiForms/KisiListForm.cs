using AbcYazilim.OgrenciTakip.Model.Dto.KisiDto;
using AsamaGlobal.ERP.Bll.General.KisiBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.KisiEntity;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;
using DevExpress.XtraBars;

namespace AsamaGlobal.ERP.UI.Win.Forms.KisiForms
{
    public partial class KisiListForm : BaseListForm
    {
        public KisiListForm()
        {
            InitializeComponent();
            Bll = new KisiBll();

            btnAdresKartlari.Caption = "Adres Kartları";
            btnIletisimKartlari.Caption = "İletişim Kartları";

            btnIletisimKartlari.ItemClick += BarItem_ItemClick;
            btnAdresKartlari.ItemClick += BarItem_ItemClick;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Kisi;
            FormShow = new ShowEditForms<KisiEditForm>();
            Navigator = longNavigator.Navigator;

            if (IsMdiChild)
                ShowItems = new BarItem[] { btnIletisimKartlari, btnAdresKartlari };
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((KisiBll)Bll).List(FilterFunctions.Filter<Kisi>(AktifKartlariGoster));
        }
        private void BarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            BagliKartAc(e.Item);
        }
        protected override void BagliKartAc(BarItem barItem)
        {
            var entity = Tablo.GetRow<KisiL>();
            if (entity == null) return;

            if (barItem == btnIletisimKartlari)
            {
                ShowListForms<GenelIletisimListForm>.ShowListForm(KartTuru.KisiIletisim, entity.Id, entity.Ad, entity.Soyad);
            }
            else if (barItem == btnAdresKartlari)
            {
                ShowListForms<GenelAdresListForm>.ShowListForm(KartTuru.KisiAdres, entity.Id, entity.Ad, entity.Soyad);
            }
        }
    }
}