using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.PersonelForms
{
    public partial class GenelAdresListForm : BaseListForm
    {
        #region Variables
        private readonly long _personelId;
        private readonly string _personelAdi;
        private readonly string _personelSoyadi;
        #endregion
        public GenelAdresListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new GenelAdresBll();

            _personelId = (long)prm[0];
            _personelAdi = prm[1].ToString();
            _personelSoyadi = prm[2].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.GenelAdres;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_personelAdi} {_personelSoyadi} )";
            tablo.ViewCaption = Text;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GenelAdresBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.PersonelId == _personelId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<GenelAdresEditForm>.ShowDialogEditForm(KartTuru.GenelAdres, id, _personelId, _personelAdi, _personelSoyadi);
            ShowEditFormDefault(result);

        }
    }
}