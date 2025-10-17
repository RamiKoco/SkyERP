using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.EtiketForms
{
    public partial class EtiketListForm : BaseListForm
    {
        public EtiketListForm()
        {
            InitializeComponent();
            Bll = new EtiketBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Etiket;
            FormShow = new ShowEditForms<EtiketEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((EtiketBll)Bll).List(FilterFunctions.Filter<Etiket>(AktifKartlariGoster));
        }     
    }
}