using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Forms.IlceForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;
using DevExpress.XtraBars;
namespace AsamaGlobal.ERP.UI.Win.Forms.IlForms
{
    public partial class IlListForm : BaseListForm
    {
        public IlListForm()
        {
            InitializeComponent();
            Bll = new IlBll();
            btnBagliKartlar.Caption = "İlçe Kartları";
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Il;
            FormShow = new ShowEditForms<IlEditForm>();
            Navigator = longNavigator.Navigator;

            if (IsMdiChild)
                ShowItems = new BarItem[] {btnBagliKartlar};
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IlBll) Bll).List(FilterFunctions.Filter<Il>(AktifKartlariGoster));

        }

        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<Il>();
            if (entity == null) return;
            ShowListForms<IlceListForm>.ShowListForm(KartTuru.Ilce,entity.Id,entity.Ad);
        }
    }
}