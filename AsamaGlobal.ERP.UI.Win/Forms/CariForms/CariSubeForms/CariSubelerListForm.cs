using AsamaGlobal.ERP.Bll.General.CarilerBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Dto.CariDto.CariSubeDto;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using System;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms
{
    public partial class CariSubelerListForm : BaseListForm
    {
        #region Variables
        private long? _carilerId;
        private string _carilerAdi;
        public long? CarilerId
        {
            get => _carilerId;
            set => _carilerId = value;
        }
        #endregion
        public CariSubelerListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new CariSubelerBll();

            //_carilerId = (long)prm[0];
            //_carilerAdi = prm[1].ToString();
            //if (prm.Length > 0 && prm[0] != null)
            //    _carilerId = Convert.ToInt64(prm[0]); // safe cast

            //_carilerAdi = prm.Length > 1 && prm[1] != null ? prm[1].ToString() : string.Empty;
            if (prm.Length > 0 && prm[0] != null)
                _carilerId = (long)prm[0];

            if (prm.Length > 1 && prm[1] != null)
                _carilerAdi = prm[1].ToString();

            btnAdresKartlari.Caption = "Şube Adres Kartı";
            btnIletisimKartlari.Caption = "Şube İletişim Kartı";
            btnAdresKartlari.ItemClick += BarItem_ItemClick;
            btnIletisimKartlari.ItemClick += BarItem_ItemClick;
        }   
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.CariSubeler;
            Navigator = longNavigator.Navigator;
            tablo.ViewCaption = Text+ $" - ( {_carilerAdi} )";
            if (IsMdiChild)
                ShowItems = new BarItem[] { btnAdresKartlari, btnIletisimKartlari };
        }
        protected override void Listele()
        {    
            if (_carilerId.HasValue) // filtre uygulanacak
                Tablo.GridControl.DataSource = ((CariSubelerBll)Bll)
                    .List(x => x.Durum == AktifKartlariGoster && x.CarilerId == _carilerId.Value);
            else // filtre uygulanmayacak, tüm şubeler
                Tablo.GridControl.DataSource = ((CariSubelerBll)Bll)
                    .List(x => x.Durum == AktifKartlariGoster);
        }

        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<CariSubelerEditForm>.ShowDialogEditForm(KartTuru.CariSubeler, id, _carilerId, _carilerAdi);
            ShowEditFormDefault(result);

        }
        private void BarItem_ItemClick(object sender, ItemClickEventArgs e)
        {
            BagliKartAc(e.Item);
        }
        protected override void BagliKartAc(BarItem barItem)
        {
            var entity = Tablo.GetRow<CariSubelerL>();
            if (entity == null) return;

            if (barItem == btnAdresKartlari)
            {
                ShowListForms<GenelAdresListForm>.ShowListForm(KartTuru.CariSubeAdres, entity.Id, entity.Ad);
            }
            else if (barItem == btnIletisimKartlari)
            {
                ShowListForms<GenelIletisimListForm>.ShowListForm(KartTuru.GenelIletisim, entity.Id, entity.Ad);
            }
        }
    }
}