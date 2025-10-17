using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.PersonelForms
{
    public partial class GenelIletisimListForm : BaseListForm
    {
        #region Variables
        private readonly long _personelId;
        private readonly string _personelAdi;
        private readonly string _personelSoyadi;
        #endregion
        public GenelIletisimListForm(params object[] prm)
        {
            InitializeComponent();
            InitializeComponent();
            Bll = new GenelIletisimBll();

            _personelId = (long)prm[0];
            _personelAdi = prm[1].ToString();
            _personelSoyadi = prm[2].ToString();
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.GenelIletisim;
            Navigator = longNavigator.Navigator;
            Text = Text + $" - ( {_personelAdi} {_personelSoyadi})";
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((GenelIletisimBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.PersonelId == _personelId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<GenelIletisimEditForm>.ShowDialogEditForm(KartTuru.GenelIletisim, id, _personelId, _personelAdi, _personelSoyadi);
            ShowEditFormDefault(result);
        }
    }
}