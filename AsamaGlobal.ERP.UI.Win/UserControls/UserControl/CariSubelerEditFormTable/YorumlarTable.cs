using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using System;


namespace AsamaGlobal.ERP.UI.Win.UserControls.UserControl.CariSubelerEditFormTable
{
    public partial class YorumlarTable : BaseTablo
    {
        public YorumlarTable()
        {
            InitializeComponent();
            Bll = new YorumlarBll();
            Tablo = tablo;
            EventsLoad();
        }
        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((YorumlarBll)Bll).List(x => x.CariSubelerId == OwnerForm.Id).ToBindingList<YorumlarL>();
        }

        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;
            var row = new YorumlarL
            {
                CariSubelerId = OwnerForm.Id,
                Tarih = DateTime.Now,
                Insert = true
            };
            source.Add(row);
            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colBilgiNotu;
            ButonEnabledDurumu(true);
        }
        protected internal override bool HataliGiris()
        {
            if (!TableValueChanged) return false;
            if (tablo.HasColumnErrors) tablo.ClearColumnErrors();

            for (int i = 0; i < tablo.DataRowCount; i++)
            {
                var entity = tablo.GetRow<YorumlarL>(i);
                if (string.IsNullOrEmpty(entity.BilgiNotu))
                {
                    tablo.FocusedRowHandle = i;
                    tablo.FocusedColumn = colBilgiNotu;
                    tablo.SetColumnError(colBilgiNotu, "Not Alanına Geçerli Bir Değer Giriniz");

                }

                if (!tablo.HasColumnErrors) continue;
                Messages.TabloEksikBilgiMesaji($"{tablo.ViewCaption} Tablosu");
                return true;
            }

            return false;
        }
    }
}
