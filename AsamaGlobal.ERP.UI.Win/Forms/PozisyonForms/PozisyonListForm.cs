using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.PozisyonForms
{
    public partial class PozisyonListForm : BaseListForm
    {
        public PozisyonListForm()
        {
            InitializeComponent();
            Bll = new PozisyonBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Pozisyon;
            FormShow = new ShowEditForms<PozisyonEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((PozisyonBll)Bll).List(FilterFunctions.Filter<Pozisyon>(AktifKartlariGoster));
        }
    }
}