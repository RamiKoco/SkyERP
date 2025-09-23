using AsamaGlobal.ERP.Bll.General.CarilerBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Entities.CariEntity;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;
using DevExpress.XtraBars;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CarilerForms
{
    public partial class CarilerListForm : BaseListForm
    {
        public CarilerListForm()
        {
            InitializeComponent();
            Bll = new CarilerBll();

            btnBagliKartlar.Caption = "Cari Şube";
            btnIletisimKartlari.Caption = "Cari İletişim";
            btnAdresKartlari.Caption = "Cari Adres";

            btnBagliKartlar.ItemClick += BarItem_ItemClick;
            btnIletisimKartlari.ItemClick += BarItem_ItemClick;
            btnAdresKartlari.ItemClick += BarItem_ItemClick;

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Cariler;
            FormShow = new ShowEditForms<CarilerForms.CarilerEditForm>();
            Navigator = longNavigator.Navigator;

            if (IsMdiChild)
                ShowItems = new BarItem[] { btnBagliKartlar, btnIletisimKartlari, btnAdresKartlari };
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((CarilerBll)Bll).List(FilterFunctions.Filter<Cariler>(AktifKartlariGoster));           
        }
        private void BarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            BagliKartAc(e.Item);
        }
        protected override void BagliKartAc(BarItem barItem)
        {
            var entity = Tablo.GetRow<CarilerL>();
            if (entity == null) return;           

            if (barItem == btnBagliKartlar)
            {
                ShowListForms<CariSubeForms.CariSubelerListForm>.ShowListForm(KartTuru.CariSubeler, entity.Id, entity.CariAdi);
            }

            else if (barItem == btnIletisimKartlari)
            {
                ShowListForms<CarilerForms.GenelIletisimListForm>.ShowListForm(KartTuru.GenelIletisim, entity.Id, entity.CariAdi);
            }
            else if (barItem == btnAdresKartlari)
            {
                ShowListForms<CarilerForms.GenelAdresListForm>.ShowListForm(KartTuru.GenelAdres, entity.Id, entity.CariAdi);
            }
        }
    }
}