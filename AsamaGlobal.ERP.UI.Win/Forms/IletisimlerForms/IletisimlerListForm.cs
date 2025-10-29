using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.IletisimlerForms
{
    public partial class IletisimlerListForm : BaseListForm
    {
        public IletisimlerListForm()
        {
            InitializeComponent();
            Bll = new GenelIletisimBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.GenelIletisim;
            FormShow = new ShowEditForms<IletisimlerEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GenelIletisimBll)Bll).List(FilterFunctions.Filter<GenelIletisim>(AktifKartlariGoster));
        }
    }
}