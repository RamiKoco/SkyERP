using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
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
            Bll = new IletisimlerBll();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Iletisimler;
            FormShow = new ShowEditForms<IletisimlerEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IletisimlerBll)Bll).List(FilterFunctions.Filter<Iletisimler>(AktifKartlariGoster));
        }
    }
}