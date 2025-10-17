using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms
{
    public partial class GenelAdresListForm : BaseListForm
    {
        #region Variables
        private readonly long _cariId;
        private readonly string _cariAdi;
        #endregion
        public GenelAdresListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new GenelAdresBll();

            _cariId = (long)prm[0];
            _cariAdi = prm[1].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.GenelAdres;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_cariAdi} )";
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GenelAdresBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.CarilerId == _cariId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<GenelAdresEditForm>.ShowDialogEditForm(KartTuru.GenelAdres, id, _cariId, _cariAdi);
            ShowEditFormDefault(result);

        }
    }
}