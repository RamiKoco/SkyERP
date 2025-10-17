using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms
{
    public partial class GenelIletisimListForm : BaseListForm
    {
        #region Variables
        private readonly long _cariSubeId;
        private readonly string _cariSubeAdi;
        #endregion
        public GenelIletisimListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new GenelIletisimBll();

            _cariSubeId = (long)prm[0];
            _cariSubeAdi = prm[1].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.GenelIletisim;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_cariSubeAdi} )";
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GenelIletisimBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.CariSubelerId == _cariSubeId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<GenelIletisimEditForm>.ShowDialogEditForm(KartTuru.GenelIletisim, id, _cariSubeId, _cariSubeAdi);
            ShowEditFormDefault(result);
        }
    }
}