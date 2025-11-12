using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AsamaGlobal.ERP.UI.Win.Forms.VergiDairesiForms
{
    public partial class VergiDairesiListForm : BaseListForm
    {
        public bool ShowYeniButton { get; set; } = false;
        public bool ShowDuzeltButton { get; set; } = false;
        public bool ShowSilButton { get; set; } = false;

        private readonly Expression<Func<VergiDairesi, bool>> _filter;

        public VergiDairesiListForm()
        {
            InitializeComponent();
            Bll = new VergiDairesiBll();
            _filter = x => x.Durum == AktifKartlariGoster;

        }
        public VergiDairesiListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;

        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.VergiDairesi;
            FormShow = new ShowEditForms<VergiDairesiEditForm>();
            Navigator = longNavigator.Navigator;

            btnYeni.Visibility = ShowYeniButton ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnDuzelt.Visibility = ShowDuzeltButton ? BarItemVisibility.Always : BarItemVisibility.Never;
            btnSil.Visibility = ShowSilButton ? BarItemVisibility.Always : BarItemVisibility.Never;
        }
        protected override void Listele()
        {           
            var list = ((VergiDairesiBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;

            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
 
    }
}