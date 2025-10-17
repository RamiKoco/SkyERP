using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Bll.General.CarilerBll.CariGruplariBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariGrublari;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariGruplariForms;
using AsamaGlobal.ERP.UI.Win.Show;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AsamaGlobal.ERP.UI.Win.Forms.SektorForms
{
    public partial class SektorListForm :BaseListForm
    {
        #region Variables

        private readonly Expression<Func<Sektor, bool>> _filter;

        #endregion
        public SektorListForm()
        {
            InitializeComponent();
            Bll = new SektorBll();
            _filter = x => x.Durum == AktifKartlariGoster;
        }
        public SektorListForm(params object[] prm) : this()
        {
            _filter = x => !ListeDisiTutulacakKayitlar.Contains(x.Id) && x.Durum == AktifKartlariGoster;
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Sektor;
            FormShow = new ShowEditForms<SektorEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {

            var list = ((SektorBll)Bll).List(_filter);
            Tablo.GridControl.DataSource = list;
            if (!MultiSelect) return;
            if (list.Any())
                EklenebilecekEntityVar = true;
            else
                Messages.KartBulunamadiMesaji("Kart");
        }
    }
}