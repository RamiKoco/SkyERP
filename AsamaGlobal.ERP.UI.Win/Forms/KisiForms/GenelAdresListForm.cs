using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.KisiForms
{
    public partial class GenelAdresListForm : BaseListForm
    {
        #region Variables
        private readonly long _kisiId;
        private readonly string _kisiAdi;
        private readonly string _kisiSoyadi;
        #endregion
        public GenelAdresListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new GenelAdresBll();

            _kisiId = (long)prm[0];
            _kisiAdi = prm[1].ToString();
            _kisiSoyadi = prm[2].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.GenelAdres;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_kisiAdi} {_kisiSoyadi} )";
            tablo.ViewCaption = Text;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GenelAdresBll)Bll)
                  .List(x => x.Durum == AktifKartlariGoster && x.KayitId == _kisiId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<GenelAdresEditForm>.ShowDialogEditForm(KartTuru.GenelAdres, id, _kisiId, _kisiAdi, _kisiSoyadi);
            ShowEditFormDefault(result);

        }
    }
}