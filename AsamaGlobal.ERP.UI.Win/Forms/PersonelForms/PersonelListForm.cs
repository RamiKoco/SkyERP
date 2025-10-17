using AsamaGlobal.ERP.Bll.General.PersonelBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Dto.PersonelDto;
using AsamaGlobal.ERP.Model.Entities.PersonelEntity;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;
using DevExpress.XtraBars;

namespace AsamaGlobal.ERP.UI.Win.Forms.PersonelForms
{
    public partial class PersonelListForm : BaseListForm
    {
        public PersonelListForm()
        {
            InitializeComponent();
            Bll = new PersonelBll();

            btnIletisimKartlari.Caption = "İletişim Kartları";
            btnAdresKartlari.Caption = "Adres Kartları";

            btnIletisimKartlari.ItemClick += BarItem_ItemClick;
            btnAdresKartlari.ItemClick += BarItem_ItemClick;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Personel;
            FormShow = new ShowEditForms<PersonelEditForm>();
            Navigator = longNavigator.Navigator;

            if (IsMdiChild)
                ShowItems = new BarItem[] { btnIletisimKartlari, btnAdresKartlari };
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((PersonelBll)Bll).List(FilterFunctions.Filter<Personel>(AktifKartlariGoster));
        }
        private void BarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            BagliKartAc(e.Item);
        }
        protected override void BagliKartAc(BarItem barItem)
        {
            var entity = Tablo.GetRow<PersonelL>();
            if (entity == null) return;

            else if (barItem == btnIletisimKartlari)
            {
                ShowListForms<GenelIletisimListForm>.ShowListForm(KartTuru.GenelIletisim, entity.Id, entity.Ad, entity.Soyad);
            }
            else if (barItem == btnAdresKartlari)
            {
                ShowListForms<GenelAdresListForm>.ShowListForm(KartTuru.PersonelAdres, entity.Id, entity.Ad, entity.Soyad);
            }
        }
    }
}