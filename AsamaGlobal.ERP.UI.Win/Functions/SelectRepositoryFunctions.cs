using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Dto.KisiDto;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Functions;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Dto.CariDto.CariSubeDto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.UI.Win.Forms.BankaForms;
using AsamaGlobal.ERP.UI.Win.Forms.BankaHesapForms;
using AsamaGlobal.ERP.UI.Win.Forms.BankaSubeForms;
using AsamaGlobal.ERP.UI.Win.Forms.BelgeTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms;
using AsamaGlobal.ERP.UI.Win.Forms.IptalNedeniForms;
using AsamaGlobal.ERP.UI.Win.Forms.KasaForms;
using AsamaGlobal.ERP.UI.Win.Forms.KisiForms;
using AsamaGlobal.ERP.UI.Win.Forms.KurumlarForms;
using AsamaGlobal.ERP.UI.Win.Forms.OkulForms;
using AsamaGlobal.ERP.UI.Win.Forms.PozisyonForms;
using AsamaGlobal.ERP.UI.Win.Forms.YakinlikForms;
using AsamaGlobal.ERP.UI.Win.Show;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.UI.Win.Functions
{
    public static class SelectRepositoryFunctions
    {
        #region Variables
        private static GridView _tablo;
        private static ControlNavigator _navigator;
        private static RepositoryItemButtonEdit _buttonEdit;
        private static GridColumn _idColumn;
        private static GridColumn _nameColumn;
        private static GridColumn _prmidColumn;
        private static GridColumn _prmnameColumn;


        #endregion


        private static void RemoveEvent()
        {
            if (_buttonEdit == null) return;


            _buttonEdit.ButtonClick -= ButtonEdit_ButtonClick;
            _buttonEdit.KeyDown -= ButtonEdit_KeyDown;
            _buttonEdit.DoubleClick -= ButtonEdit_DoubleClick;
            _tablo.KeyDown -= Tablo_KeyDown;

        }

        public static void Sec(this GridColumn nameColumn, GridView tablo, ControlNavigator navigator, RepositoryItemButtonEdit buttonEdit, GridColumn idColumn)
        {
            RemoveEvent();

            _tablo = tablo;
            _navigator = navigator;
            _buttonEdit = buttonEdit;
            _idColumn = idColumn;
            _nameColumn = nameColumn;

            _buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
            _buttonEdit.KeyDown += ButtonEdit_KeyDown;
            _buttonEdit.DoubleClick += ButtonEdit_DoubleClick;
            _tablo.KeyDown += Tablo_KeyDown;
        }

        public static void Sec(this GridColumn nameColumn, GridView tablo, ControlNavigator navigator, RepositoryItemButtonEdit buttonEdit, GridColumn idColumn, GridColumn prmIdColumn,GridColumn prmNameColumn)
        {
            RemoveEvent();

            _tablo = tablo;
            _navigator = navigator;
            _buttonEdit = buttonEdit;
            _idColumn = idColumn;
            _nameColumn = nameColumn;
            _prmidColumn = prmIdColumn;
            _prmnameColumn = prmNameColumn;

            _buttonEdit.ButtonClick += ButtonEdit_ButtonClick;
            _buttonEdit.KeyDown += ButtonEdit_KeyDown;
            _buttonEdit.DoubleClick += ButtonEdit_DoubleClick;
            _tablo.KeyDown += Tablo_KeyDown;
        }

        private static void ButtonEdit_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SecimYap();
        }

        
        private static void ButtonEdit_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Delete when e.Control && e.Shift:
                    _tablo.SetFocusedRowCellValue(_idColumn, null);
                    _tablo.SetFocusedRowCellValue(_nameColumn,null);
                    _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                    break;

                case Keys.F4:
                case Keys.Down when e.Alt:
                    SecimYap();
                    break;

            }
        }

        private static void ButtonEdit_DoubleClick(object sender, EventArgs e)
        {
            SecimYap();
        }
        
        private static void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            if (_tablo.FocusedColumn.ColumnEdit == null) return;

            var type = _tablo.FocusedColumn.ColumnEdit.GetType();
            if (type != typeof(RepositoryItemButtonEdit)) return;

            switch (e.KeyCode)
            {
                case Keys.Delete when e.Control && e.Shift: 
                    _tablo.SetFocusedRowCellValue(_idColumn,null);
                    _tablo.SetFocusedRowCellValue(_nameColumn ,null);
                    _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                    break;

                case Keys.F4:
                case Keys.Down when e.Alt:
                    SecimYap();
                    break;
            }

        }

        private static void SecimYap()
        {
            switch (_buttonEdit.Name)
            {
                case "repositoryYakinlik":
                {
                    var id = _tablo.GetRowCellId(_idColumn);
                    var entity = (Yakinlik) ShowListForms<YakinlikListForm>.ShowDialogListForm(KartTuru.Yakinlik, id);
                    if (entity != null)
                    {
                        _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                        _tablo.SetFocusedRowCellValue(_nameColumn, entity.YakinlikAdi);
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);

                    }
                }
                    break;


                case "repositoryBanka":
                {
                    if (!_nameColumn.OptionsColumn.AllowEdit) return;

                        var id = _tablo.GetRowCellId(_idColumn);
                    var entity = (BankaL)ShowListForms<BankaListForm>.ShowDialogListForm(KartTuru.Banka, id);
                    if (entity != null)
                    {
                        _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                        _tablo.SetFocusedRowCellValue(_nameColumn, entity.BankaAdi);
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);

                    }
                }
                    break;


                case "repositoryBankaSube":
                {
                    if (!_nameColumn.OptionsColumn.AllowEdit) return;

                    var id = _tablo.GetRowCellId(_idColumn);
                    var bankaId = _tablo.GetRowCellId(_prmidColumn);
                    var bankaAdi = _tablo.GetFocusedRowCellValue(_prmnameColumn).ToString();

                    var entity = (BankaSube)ShowListForms<BankaSubeListForm>.ShowDialogListForm(KartTuru.BankaSube, id,bankaId,bankaAdi);
                    if (entity != null)
                    {
                        _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                        _tablo.SetFocusedRowCellValue(_nameColumn, entity.SubeAdi);
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);

                    }
                }
                    break;

                case "repositoryBankaHesap":
                {
                    if (!_nameColumn.OptionsColumn.AllowEdit) return;

                    var id = _tablo.GetRowCellId(_idColumn);
                    var odemeTipi = _tablo.GetFocusedRowCellValue("OdemeTipi").ToString().GetEnum<OdemeTipi>();

                    var entity = (BankaHesapL)ShowListForms<BankaHesapListForm>.ShowDialogListForm(KartTuru.BankaHesap, id,odemeTipi );
                    if (entity != null)
                    {
                        _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                        _tablo.SetFocusedRowCellValue(_nameColumn, entity.HesapAdi);
                        _tablo.SetFocusedRowCellValue("BlokeGunSayisi",entity.BlokeGunSayisi);
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);

                    }
                }
                    break;


                case "repositoryIptalNedeni":
                {
                    if (!_nameColumn.OptionsColumn.AllowEdit) return;

                    var id = _tablo.GetRowCellId(_idColumn);
                    var entity = (IptalNedeni)ShowListForms<IptalNedeniListForm>.ShowDialogListForm(KartTuru.IptalNedeni, id);
                    if (entity != null)
                    {
                        _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                        _tablo.SetFocusedRowCellValue(_nameColumn, entity.IptalNedeniAdi);
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);

                    }
                }
                    break;


                case "repositoryGittigiOkul":
                {
                    if (!_nameColumn.OptionsColumn.AllowEdit) return;

                    var id = _tablo.GetRowCellId(_idColumn);
                    var entity = (OkulL)ShowListForms<OkulListForm>.ShowDialogListForm(KartTuru.Okul, id);
                    if (entity != null)
                    {
                        _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                        _tablo.SetFocusedRowCellValue(_nameColumn, entity.OkulAdi);
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);

                    }
                }
                    break;

                case "repositoryHesap":
                {

                    var id = _tablo.GetRowCellId(_idColumn);

                    switch (_tablo.GetRow<GeriOdemeBilgileriL>().HesapTuru)
                    {
                        case GeriOdemeHesapTuru.Banka:
                        {

                            var entity = (BankaHesapL) ShowListForms<BankaHesapListForm>.ShowDialogListForm(KartTuru.BankaHesap, id, OdemeTipi.Elden);
                            if (entity == null) return;
                            _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                            _tablo.SetFocusedRowCellValue(_nameColumn, entity.HesapAdi);
                            _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                            break;
                        }
                        case GeriOdemeHesapTuru.Kasa:
                        {
                            var entity = (KasaL) ShowListForms<KasaListForm>.ShowDialogListForm(KartTuru.Kasa, id);
                            if (entity == null) return;
                            _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                            _tablo.SetFocusedRowCellValue(_nameColumn, entity.KasaAdi);
                            _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                            break;
                        }
                    }

                }
                break;


                case "repositoryKurum":
                    {
                        var id = _tablo.GetRowCellId(_idColumn);
                        var entity = (KurumlarL)ShowListForms<KurumlarListForm>.ShowDialogListForm(KartTuru.Kurumlar, id);
                        if (entity == null) return;
                        _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                        _tablo.SetFocusedRowCellValue(_nameColumn, entity.Ad);
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                    }
                    break;

                case "repositoryBelge":
                    {

                        var id = _tablo.GetRowCellId(_idColumn);
                        var entity = (BelgeTuruL)ShowListForms<BelgeTuruListForm>.ShowDialogListForm(KartTuru.BelgeTuru, id);
                        if (entity == null) return;
                        _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                        _tablo.SetFocusedRowCellValue(_nameColumn, entity.BelgeAdi);
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);

                    }
                 break;

                case "repositoryPozisyon":
                    {

                        var id = _tablo.GetRowCellId(_idColumn);
                        var entity = (PozisyonL)ShowListForms<PozisyonListForm>.ShowDialogListForm(KartTuru.Pozisyon, id);
                        if (entity == null) return;
                        _tablo.SetFocusedRowCellValue(_idColumn, entity.Id);
                        _tablo.SetFocusedRowCellValue(_nameColumn, entity.Ad);
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);

                    }
                 break;

                case "repositoryKisi":
                    {
                        var id = _tablo.GetRowCellId(_idColumn);
                        var entity = (KisiL)ShowListForms<KisiListForm>.ShowDialogListForm(KartTuru.Kisi, id);
                        if (entity == null) return;

                        var current = _tablo.GetRow(_tablo.FocusedRowHandle) as KisiKayitTuruBaglantiL;
                        var list = _tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;

                        if (list == null)
                            list = _tablo.DataController.ListSource.Cast<KisiKayitTuruBaglantiL>().ToList();
                     
                        bool exists = list.Any(x => x.KisiId == entity.Id && !ReferenceEquals(x, current));

                        if (exists)
                        {
                            Messages.UyariMesaji("Bu kişi zaten listede mevcut!");

                            _tablo.CancelUpdateCurrentRow();
                            _tablo.HideEditor();

                            if (current != null && list.Contains(current))
                                list.Remove(current);

                            _tablo.RefleshDataSource();
                            _tablo.RefreshData();

                            _tablo.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle;

                            _navigator.Buttons.DoClick(_navigator.Buttons.CancelEdit);

                            return;
                        }

                        _tablo.SetFocusedRowCellValue(_idColumn, entity.Id); // bu _idColumn mu? KisiId veya genel Id'ne göre ayarla
                        _tablo.SetFocusedRowCellValue(_nameColumn, entity.Ad + " " + entity.Soyad);
                        _tablo.SetFocusedRowCellValue("KodKisi", entity.Kod);    // yeni alan
                        _tablo.SetFocusedRowCellValue("KodCari", null);         // temizle
                        _tablo.SetFocusedRowCellValue("KayitTuru", KayitTuru.Kisi);
                        _tablo.SetFocusedRowCellValue("KayitHesabi", entity.KayitTuru);     // eğer mantık gerektiriyorsa
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                    }
                    break;

                case "repositoryCariler":
                    {
                        var id = _tablo.GetRowCellId(_idColumn);
                        var current = _tablo.GetRow(_tablo.FocusedRowHandle) as KisiKayitTuruBaglantiL;
                        var list = _tablo.DataController.ListSource as IList<KisiKayitTuruBaglantiL>;

                        if (current == null) return;
                        if (list == null)
                            list = _tablo.DataController.ListSource.Cast<KisiKayitTuruBaglantiL>().ToList();

                        BaseEntity entity = null;

                        if (current.KayitTuru == KayitTuru.Cari)
                        {
                            entity = ShowListForms<CarilerListForm>.ShowDialogListForm(KartTuru.Cariler, seciliGelecekId: null);
                            if (entity == null) return;
                            var sube = (CarilerL)entity;
                            current.KayitId = sube.Id;                           
                            current.KayitHesabi = sube.Unvan;
                            current.Kod = sube.Kod;

                            _tablo.SetFocusedRowCellValue(_tablo.Columns["Kod"], current.Kod);
                            _tablo.SetFocusedRowCellValue(_tablo.Columns["KayitHesabi"], current.KayitHesabi);
                            _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                        }

                        else if (current.KayitTuru == KayitTuru.CariSube)
                        {
                            entity = ShowListForms<CariSubelerListForm>.ShowDialogListForm(
                                KartTuru.CariSubeler, seciliGelecekId: null);

                            if (entity == null) return;

                            var sube = (CariSubelerL)entity;
                            current.KayitId = sube.Id;
                            current.KayitHesabi = sube.Ad;
                            current.Kod = sube.Kod;

                            _tablo.SetFocusedRowCellValue(_tablo.Columns["Kod"], current.Kod);
                            _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);

                        }
                        else
                        {
                            Messages.UyariMesaji("Lütfen önce geçerli bir kayıt türü seçin (Cari veya Cari Şube).");
                            return;
                        }

                        if (entity == null) return;

                        bool exists = list.Any(x => x.KayitId == entity.Id && !ReferenceEquals(x, current));
                        if (exists)
                        {
                            Messages.UyariMesaji("Bu kayıt zaten listede mevcut! Satır iptal edildi.");
                            _tablo.CloseEditor();
                            _tablo.CancelUpdateCurrentRow();
                            _tablo.HideEditor();

                            try
                            {
                                current.Kod = null;
                                current.KayitHesabi = null;
                            }
                            catch { }

                            _tablo.BeginUpdate();
                            if (list.Contains(current))
                                list.Remove(current);
                            _tablo.EndUpdate();

                            _tablo.RefleshDataSource();
                            _tablo.RefreshData();
                            _tablo.ClearSelection();
                            _tablo.FocusedRowHandle = DevExpress.XtraGrid.GridControl.InvalidRowHandle;
                            _navigator.Buttons.DoClick(_navigator.Buttons.CancelEdit);
                            return;
                        }

                        if (current.KayitTuru == KayitTuru.Cari)
                        {
                            var cari = (CarilerL)entity;
                            current.KayitId = cari.Id;
                            current.KayitHesabi = cari.Unvan;
                            current.Kod = cari.Kod;
                        }
                        else if (current.KayitTuru == KayitTuru.CariSube)
                        {
                            var sube = (CariSubelerL)entity;
                            current.KayitId = sube.Id;
                            current.KayitHesabi = sube.Ad;
                            current.Kod = sube.Kod;
                        }

                        _tablo.RefleshDataSource();
                        _navigator.Buttons.DoClick(_navigator.Buttons.EndEdit);
                    }
                    break;
            }
        }
    }
}
