using AsamaGlobal.ERP.Bll.General.CarilerBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Dto.CariDto.CariSubeDto;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraBars;

namespace AsamaGlobal.ERP.UI.Win.UserControls.UserControl.CariEditFormTable
{
    public partial class CariSubelerTable : BaseTablo
    {
        public CariSubelerTable()
        {
            InitializeComponent();

            Bll = new CariSubelerBll();
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

            var list = ((CariSubelerBll)Bll)
                .List(x => x.CarilerId == OwnerForm.Id)
                .ToBindingList<CariSubelerL>();

            if (Tablo?.GridControl != null)
                Tablo.GridControl.DataSource = list;
        }

        protected internal override bool HataliGiris()
        {
            if (!TableValueChanged) return false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();

            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<CariSubelerL>(i);

                if (!tablo.HasColumnErrors) continue;
                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption} Tablosu");
                return true;
            }

            return false;
        }

        protected override void OpenEntity()
        {
            var entity = tablo.GetRow<CariSubelerL>();
            if (entity == null) return;
            ShowEditForms<CarilerEditForm>.ShowDialogEditForm(KartTuru.Cariler, entity.Id);

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
