using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms
{
    public partial class GenelIletisimListForm : BaseListForm
    {
        #region Variables
        private readonly long _cariId;
        private readonly string _cariAdi;
        #endregion
        public GenelIletisimListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new GenelIletisimBll();

            _cariId = (long)prm[0];
            _cariAdi = prm[1].ToString();

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.GenelIletisim;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_cariAdi} )";
            tablo.ViewCaption = Text;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GenelIletisimBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.CarilerId == _cariId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<GenelIletisimEditForm>.ShowDialogEditForm(KartTuru.GenelIletisim, id, _cariId, _cariAdi);
            ShowEditFormDefault(result);

        }
    }
}