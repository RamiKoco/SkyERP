using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.AdresBilgileriForms
{
    public partial class AdresBilgileriListForm : BaseListForm
    {
        public AdresBilgileriListForm()
        {
            InitializeComponent();
            Bll = new GenelAdresBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.GenelAdres;
            FormShow = new ShowEditForms<AdresBilgileriEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GenelAdresBll)Bll).List(FilterFunctions.Filter<GenelAdres>(AktifKartlariGoster));
        }
    }
}