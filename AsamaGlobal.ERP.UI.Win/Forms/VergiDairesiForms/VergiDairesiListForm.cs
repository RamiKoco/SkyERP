using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.VergiDairesiForms
{
    public partial class VergiDairesiListForm : BaseListForm
    {  

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

        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((VergiDairesiBll)Bll).List(FilterFunctions.Filter<VergiDairesi>(AktifKartlariGoster));
        }
        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<VergiDairesi>();
            if (entity == null) return;
        }
    }
}