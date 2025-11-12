using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.UI.Win.Forms.KisiForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;

namespace AsamaGlobal.ERP.UI.Win.UserControls.UserControl.KisiEditFormTable
{
    public partial class AdreslerTable : BaseTablo
    {
        public AdreslerTable()
        {
            InitializeComponent();

            Bll = new GenelAdresBll();
            Tablo = tablo;
            EventsLoad();
            TabloEventsYukle();
            HideItems = new BarItem[] { btnBelgeHareketleri };            
            insUptNavigator.Navigator.Buttons.Append.Visible = false;
            insUptNavigator.Navigator.Buttons.Remove.Visible = false;
            insUptNavigator.Navigator.Buttons.Edit.Visible = false;

        }
        protected internal override void Listele()
        {

            var list = ((GenelAdresBll)Bll)
                .List(x => x.KayitId == OwnerForm.Id)
                .ToBindingList<GenelAdresL>();

            if (Tablo?.GridControl != null)
                Tablo.GridControl.DataSource = list;

        }
        protected internal override bool HataliGiris()
        {
            if (!TableValueChanged) return false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();

            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<GenelAdresL>(i);

                if (!tablo.HasColumnErrors) continue;
                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption} Tablosu");
                return true;
            }

            return false;
        }     
        protected override void OpenEntity()
        {
            var entity = tablo.GetRow<GenelAdresL>();
            if (entity == null) return;
            ShowEditForms<KisiEditForm>.ShowDialogEditForm(KartTuru.Kisi, entity.Id);

        }
        protected virtual void TabloEventsYukle()
        {
            if (Tablo == null) return;

            Tablo.DoubleClick -= Tablo_DoubleClick;
            Tablo.KeyDown -= Tablo_KeyDown;
            Tablo.MouseUp -= Tablo_MouseUp;
            
            Tablo.KeyDown += Tablo_KeyDown;
        }    

    }
}
