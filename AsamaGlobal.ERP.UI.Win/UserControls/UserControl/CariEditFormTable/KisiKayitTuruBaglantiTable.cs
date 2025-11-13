using AsamaGlobal.ERP.Bll.General.CarilerBll;
using AsamaGlobal.ERP.Bll.General.KisiBll;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Entities.KisiEntity;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.UserControls.UserControl.Base;
using DevExpress.XtraGrid.Views.Base;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.UI.Win.UserControls.UserControl.CariEditFormTable
{
    public partial class KisiKayitTuruBaglantiTable : BaseTablo
    {
        private KayitTuru _kayitTuru;

        public KisiKayitTuruBaglantiTable()
        {
            InitializeComponent();

            Bll = new KisiKayitTuruBaglantiBll();
            Tablo = tablo;
            EventsLoad();
           
        }

        protected internal override void Listele()
        {
            tablo.GridControl.DataSource = ((KisiKayitTuruBaglantiBll)Bll)
                .List(x => x.KayitId == OwnerForm.Id)
                .ToBindingList<KisiKayitTuruBaglantiL>();
        }

        protected override void HareketEkle()
        {
            var source = tablo.DataController.ListSource;

            if (OwnerForm is CarilerEditForm)
                _kayitTuru = KayitTuru.Cari;           
            else
                _kayitTuru = KayitTuru.CariSube; 

            var row = new KisiKayitTuruBaglantiL
            {
                KayitId = OwnerForm.Id,
                KayitTuru = _kayitTuru,
                Insert = true
            };

            source.Add(row);
            tablo.Focus();
            tablo.RefleshDataSource();
            tablo.FocusedRowHandle = tablo.DataRowCount - 1;
            tablo.FocusedColumn = colKisiAdi;
            ButonEnabledDurumu(true);
        }

        protected override void Tablo_CellValueChanged(object sender, CellValueChangedEventArgs e)
        {
            base.Tablo_CellValueChanged(sender, e);

            if (e.Column != colKisiId) return;

            var entity = tablo.GetRow<KisiKayitTuruBaglantiL>();
            if (entity == null) return;

            var list = tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;
            if (list == null) return;

            if (entity.KisiId != null && list.Any(x => x.KisiId == entity.KisiId && !ReferenceEquals(x, entity)))
            {
                Messages.UyariMesaji("Bu kişi zaten listede mevcut! Satır iptal edildi.");

                tablo.CloseEditor();
                tablo.CancelUpdateCurrentRow();
                tablo.HideEditor();

                try { entity.KisiAdi = null; } catch { }

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

            if (entity.KisiId == null) return;


            using (var bll = new KisiBll())
            {
                var kisi = (Kisi)bll.Single(x => x.Id == entity.KisiId);
                if (kisi == null) return;

                if (entity.KayitTuru == KayitTuru.Cari)
                {
                    entity.Kod = kisi.Kod;
                    entity.KisiAdi = kisi.Ad;
                }
                else
                {
                    entity.Kod = kisi.Kod;
                    entity.KisiAdi = kisi.Ad + " " + kisi.Soyad;
                }
            }

            tablo.RefleshDataSource();
        }

        protected override void Tablo_FocusedColumnChanged(object sender, FocusedColumnChangedEventArgs e)
        {
            base.Tablo_FocusedColumnChanged(sender, e);

            if (e.FocusedColumn == colKisiAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryKisi, colKisiId);

            if (e.FocusedColumn == colPozisyonAdi)
                e.FocusedColumn.Sec(tablo, insUptNavigator.Navigator, repositoryPozisyon, colPozisyonId);
        }

        public bool KaydetKontrollu()
        {
            if (!(tablo.DataController.ListSource is IList<KisiKayitTuruBaglantiL> list) || !list.Any())
                return true;

            var invalidRows = list.Where(x =>
                string.IsNullOrWhiteSpace(x.KisiAdi) ||
                x.KayitId == 0
            ).ToList();

            if (invalidRows.Any())
            {
                string message = $"Toplam {invalidRows.Count} kayıt hatalı.\n" +
                                 "Kişi seçimi yapılmamış kayıtlar kaydedilemez.";
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
                if (row.Id == 0 || row.Insert)
                {
                    list.Remove(row); // henüz kaydedilmemiş satır
                }
                else
                {
                    row.Delete = true; // veritabanında silinecek
                }

                Tablo.RefleshDataSource();
                ButonEnabledDurumu(true);
            }
        }
   
    }
}