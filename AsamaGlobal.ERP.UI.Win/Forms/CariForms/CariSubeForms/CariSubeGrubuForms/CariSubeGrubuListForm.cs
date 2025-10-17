using AsamaGlobal.ERP.Bll.General.CarilerBll.CariSubeBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariSube;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms.CariSubeGrubuForms
{
    public partial class CariSubeGrubuListForm : BaseListForm
    {      
        public CariSubeGrubuListForm()
        {
            InitializeComponent();
            Bll = new CariSubeGrubuBll();
        }       
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.CariSubeGrubu;
            FormShow = new ShowEditForms<CariSubeGrubuEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((CariSubeGrubuBll)Bll).List(FilterFunctions.Filter<CariSubeGrubu>(AktifKartlariGoster));
        }
    }
}