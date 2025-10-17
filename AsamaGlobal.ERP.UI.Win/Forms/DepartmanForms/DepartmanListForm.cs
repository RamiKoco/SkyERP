using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.DepartmanForms
{
    public partial class DepartmanListForm : BaseListForm
    {
        public DepartmanListForm()
        {
            InitializeComponent();
            Bll = new DepartmanBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Departman;
            FormShow = new ShowEditForms<DepartmanEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((DepartmanBll)Bll).List(FilterFunctions.Filter<Departman>(AktifKartlariGoster));
        }
    }
}