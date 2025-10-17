using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.UlkeForms
{
    public partial class UlkeListForm : BaseListForm
    {
        public UlkeListForm()
        {
            InitializeComponent();
            Bll = new UlkeBll();
            //btnBagliKartlar.Caption = "İl Kartları";
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Ulke;
            FormShow = new ShowEditForms<UlkeEditForm>();
            Navigator = longNavigator.Navigator;

            //if (IsMdiChild)
            //    ShowItems = new BarItem[] { btnBagliKartlar };
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((UlkeBll)Bll).List(FilterFunctions.Filter<Ulke>(AktifKartlariGoster));

        }

        protected override void BagliKartAc()
        {
            var entity = Tablo.GetRow<Ulke>();
            //if (entity == null) return;
            //ShowListForms<IlListForm>.ShowListForm(KartTuru.Il, entity.Id, entity.UlkeAdi);
        }
    }
}