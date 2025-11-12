using AsamaGlobal.ERP.Bll.General.CarilerBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Entities.CariEntity;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariSube;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraGrid.Views.Base;
using System.Collections.Generic;
using System.Linq;

namespace AsamaGlobal.ERP.UI.Win.UserControls.UserControl.KisiEditFormTable
{
    public partial class CariKayitTuruBaglantiTable : BaseTablo
    {
        public CariKayitTuruBaglantiTable()
        {
            InitializeComponent();

            Bll = new KisiKayitTuruBaglantiBll();
            Tablo = tablo;
            EventsLoad();

            repositoryKayitTuru.Items.Clear();

            repositoryKayitTuru.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                KayitTuru.Cari.GetEnumDescription(), KayitTuru.Cari));

            repositoryKayitTuru.Items.Add(new DevExpress.XtraEditors.Controls.ImageComboBoxItem(
                KayitTuru.CariSube.GetEnumDescription(), KayitTuru.CariSube));           

            repositoryKayitTuru.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KisiKayitTuruBaglantiBll)Bll)
                .List(x => x.KisiId == OwnerForm.Id)
                .ToBindingList<KisiKayitTuruBaglantiL>();
        }

        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;

            var row = new KisiKayitTuruBaglantiL
            {
                KisiId = OwnerForm.Id,
                Insert = true
            };

            source.Add(row);
            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colKayitTuru;
            ButonEnabledDurumu(true);
        }

        protected override void Tablo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.Tablo_CellValueChanged(sender, e);

            if (e.Column != colKayitId) return;

            var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
            if (entity == null) return;

            var list = tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;
            if (list == null) return;
           
            if (entity.KayitId != null && list.Any(x => x.KayitId == entity.KayitId && !ReferenceEquals(x, entity)))
            {
                Messages.UyariMesaji("Bu kişi zaten listede mevcut! Satır iptal edildi.");

                tablo.CloseEditor();
                tablo.CancelUpdateCurrentRow();
                tablo.HideEditor();

                try { entity.KayitHesabi = null; } catch { }

                tablo.BeginUpdate();
                if (list.Contains(entity))
                    list.Remove(entity);
                tablo.EndUpdate();

                tablo.RefleshDataSource();
                tablo.RefreshData();
                tablo.ClearSelection();
                tablo.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle;

                return;
            }

            if (entity.KayitId == null) return;
            
            if (OwnerForm is CarilerEditForm)
                entity.KayitTuru = KayitTuru.Cari;
            else
                entity.KayitTuru = KayitTuru.Kisi;

            using (var bll = new CarilerBll())
            {
                var kisi = (Cariler)bll.Single(x => x.Id == entity.KayitId);
                var sube = (CariSubeler)bll.Single(x => x.Id == entity.KayitId);
                if (kisi == null) return;
                
                if (entity.KayitTuru == KayitTuru.Cari)
                {
                    entity.KodKisi = kisi.Kod;
                    entity.KayitHesabi = kisi.Unvan;
                }

                else
                {
                    entity.KodKisi = sube.Kod;
                    entity.KayitHesabi = sube.Ad;
                }
            }

            tablo.RefleshDataSource();
        }

        protected override void Tablo_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            base.Tablo_FocusedColumnChanged(sender, e);

            if (e.FocusedColumn == colKayitHesabi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryCariler, colKayitId);

            if (e.FocusedColumn == colPozisyonAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryPozisyon, colPozisyonId);
        }

        private void RepositoryKayitTuru_Format(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is KayitTuru kayitTuru)
                e.Value = kayitTuru.GetEnumDescription();
        }

        private void RepositoryKayitTuru_ParseEditValue(object sender, DevExpress.XtraEditors.Controls.ConvertEditValueEventArgs e)
        {
            if (e.Value is string text)
            {
                if (text.Contains("Cari Şube"))
                    e.Value = KayitTuru.CariSube;
                else
                    e.Value = KayitTuru.Cari;
            }
        }
    }
}