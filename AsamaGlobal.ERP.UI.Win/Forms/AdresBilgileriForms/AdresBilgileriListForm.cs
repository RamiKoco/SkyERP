using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
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
            Bll = new AdresBilgileriBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.AdresBilgileri;
            FormShow = new ShowEditForms<AdresBilgileriEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((AdresBilgileriBll)Bll).List(FilterFunctions.Filter<AdresBilgileri>(AktifKartlariGoster));
        }
    }
}