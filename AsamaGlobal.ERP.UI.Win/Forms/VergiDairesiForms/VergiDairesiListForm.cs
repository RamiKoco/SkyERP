using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;
using DevExpress.XtraBars;

namespace AsamaGlobal.ERP.UI.Win.Forms.VergiDairesiForms
{
    public partial class VergiDairesiListForm : BaseListForm
    {
        public bool ShowYeniButton { get; set; } = false;
        public bool ShowDuzeltButton { get; set; } = false;
        public bool ShowSilButton { get; set; } = false;
        public VergiDairesiListForm()
        {
            InitializeComponent();
            Bll = new VergiDairesiBll();
          
        }    
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.VergiDairesi;
            FormShow = new ShowEditForms<VergiDairesiEditForm>();
            Navigator = longNavigator.Navigator;           
            btnYeni.Visibility = ShowYeniButton ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnDuzelt.Visibility = ShowDuzeltButton ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnSil.Visibility = ShowSilButton ? BarItemVisibility.Always : BarItemVisibility.Never;
            
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((VergiDairesiBll)Bll).List(FilterFunctions.Filter<VergiDairesi>(AktifKartlariGoster));
        }
      
    }
}