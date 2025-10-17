using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.KimlikTuruForms
{
    public partial class KimlikTuruListForm : BaseListForm
    {
        public KimlikTuruListForm()
        {
            InitializeComponent();
            Bll = new KimlikTuruBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.KimlikTuru;
            FormShow = new ShowEditForms<KimlikTuruEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((KimlikTuruBll)Bll).List(FilterFunctions.Filter<KimlikTuru>(AktifKartlariGoster));
        }
    }
}