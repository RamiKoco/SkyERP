using AsamaGlobal.ERP.Bll.General.CarilerBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Entities.CariEntity;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariSube;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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

            repositoryKayitTuru.Items.Add(new ImageComboBoxItem(
                KayitTuru.Cari.GetEnumDescription(), KayitTuru.Cari));

            repositoryKayitTuru.Items.Add(new ImageComboBoxItem(
                KayitTuru.CariSube.GetEnumDescription(), KayitTuru.CariSube));           

            repositoryKayitTuru.TextEditStyle = TextEditStyles.DisableTextEditor;

            tablo.CellValueChanging += Tablo_CellValueChanging;
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KisiKayitTuruBaglantiBll)Bll)
                .List(x => x.KisiId == OwnerForm.Id)
                .ToBindingList<KisiKayitTuruBaglantiL>();
        }

        protected override void HareketEkle()
        {    
            var currentKayitTuru = KayitTuru.Cari;
            if (currentKayitTuru == 0) return; 

            var source = tablo.DataController.ListSource;
            var row = new KisiKayitTuruBaglantiL
            {
                KisiId = OwnerForm.Id,
                Insert = true,
                KayitTuru = currentKayitTuru,
                KayitHesabi = string.Empty,
                Kod=string.Empty
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

            var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
            if (entity == null) return;

            var list = tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;
            if (list == null) return;
             
            if (e.Column == colKayitTuru)
            {
                entity.KayitId = 0;
                entity.KayitHesabi = null;
                entity.Kod = null;
                tablo.RefleshDataSource();
                return; 
            }
           
            if (e.Column == colKayitId && entity.KayitId != 0)
            {
                
                if (list.Any(x => x.KayitId == entity.KayitId && !ReferenceEquals(x, entity)))
                {
                    Messages.UyariMesaji("Bu kayıt zaten listede mevcut! Satır iptal edildi.");

                    tablo.CancelUpdateCurrentRow();

                    entity.KayitId = 0;
                    entity.KayitHesabi = null;
                    entity.Kod = null;

                    tablo.RefleshDataSource();
                    return;
                }
                
                if (entity.KayitTuru == KayitTuru.Cari)
                {
                    using (var bll = new CarilerBll())
                    {
                        var cari = (Cariler)bll.Single(x => x.Id == entity.KayitId);
                        if (cari != null)
                        {
                            entity.Kod = cari.Kod;
                            entity.KayitHesabi = cari.Unvan;
                        }
                    }
                }
                else if (entity.KayitTuru == KayitTuru.CariSube)
                {
                    using (var bll = new CarilerBll())
                    {
                        var sube = (CariSubeler)bll.Single(x => x.Id == entity.KayitId);
                        if (sube != null)
                        {
                            entity.Kod = sube.Kod;
                            entity.KayitHesabi = sube.Ad;
                        }
                    }
                }

                tablo.RefleshDataSource();
            }
        }

        protected override void Tablo_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            base.Tablo_FocusedColumnChanged(sender, e);

            if (e.FocusedColumn == colKayitHesabi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryCariler, colKayitId);

            if (e.FocusedColumn == colPozisyonAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryPozisyon, colPozisyonId);
        }

        private void RepositoryKayitTuru_Format(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value is KayitTuru kayitTuru)
                e.Value = kayitTuru.GetEnumDescription();
        }

        private void RepositoryKayitTuru_ParseEditValue(object sender, ConvertEditValueEventArgs e)
        {
            if (e.Value is string text)
            {
                if (text.Contains("Cari Şube"))
                    e.Value = KayitTuru.CariSube;
                else
                    e.Value = KayitTuru.Cari;
            }

        }
 
        public bool KaydetKontrollu()
        {
            if (!(tablo.DataController.ListSource is IList<KisiKayitTuruBaglantiL> list) || !list.Any())
                return true;

            var invalidRows = list.Where(x =>
                x.KayitTuru != 0 &&
                (x.KayitId == 0 || string.IsNullOrWhiteSpace(x.KayitHesabi))
            ).ToList();

            if (invalidRows.Any())
            {
                string message = $"Toplam {invalidRows.Count} kayıt hatalı.\n" +
                                 "Kayıt türü değiştirilen ancak kaydı seçilmeyen satırlar kaydedilemez.";
                Messages.UyariMesaji(message);

                foreach (var row in invalidRows)
                {
                    int index = list.IndexOf(row);
                    if (index >= 0)
                        tablo.FocusedRowHandle = index;
                }

                return false;
            }

            return this.Kaydet();
        }
        protected override void HareketSil()
        {
            if (Tablo.DataRowCount == 0) return;
            if (Messages.SilMesaj("İşlem Satırı") != DialogResult.Yes) return;

            var list = Tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;
            var row = Tablo.GetRow<KisiKayitTuruBaglantiL>();

            if (row != null)
            {
                if (row.KayitId == 0)
                {                    
                    list.Remove(row);
                }
                else
                {
                    row.Delete = true;
                }

                Tablo.RefleshDataSource();
                ButonEnabledDurumu(true);
            }
        }

        private void Tablo_CellValueChanging(object sender, CellValueChangedEventArgs e)
        {
            if (e.Column == colKayitTuru)
            {
                var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
                if (entity == null) return;
               
                entity.KayitId = 0;
                entity.KayitHesabi = string.Empty;
                entity.Kod = string.Empty;

                tablo.RefleshDataSource();
                ButonEnabledDurumu(false);
            }
        }

    }
}