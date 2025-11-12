using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms
{
    public partial class GenelAdresListForm : BaseListForm
    {
        #region Variables
        private readonly long _cariSubeId;
        private readonly string _cariSubeAdi;
        #endregion
        public GenelAdresListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new GenelAdresBll();

            _cariSubeId = (long)prm[0];
            _cariSubeAdi = prm[1].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.GenelAdres;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_cariSubeAdi} )";
            tablo.ViewCaption = Text;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GenelAdresBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.CariSubelerId == _cariSubeId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<GenelAdresEditForm>.ShowDialogEditForm(KartTuru.GenelAdres, id, _cariSubeId, _cariSubeAdi);
            ShowEditFormDefault(result);
        }
    }
}