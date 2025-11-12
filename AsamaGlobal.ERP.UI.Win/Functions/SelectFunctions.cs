using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Dto.KisiDto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Dto;
using AsamaGlobal.ERP.Model.Dto.CariDto;
using AsamaGlobal.ERP.Model.Dto.CariDto.CariSubeDto;
using AsamaGlobal.ERP.Model.Dto.PersonelDto;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariGrublari;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariSube;
using AsamaGlobal.ERP.Model.Entities.CariEntity.CariTurleri;
using AsamaGlobal.ERP.Model.Entities.KisiEntity;
using AsamaGlobal.ERP.UI.Win.Forms.AdresTurleriForms;
using AsamaGlobal.ERP.UI.Win.Forms.AvukatForms;
using AsamaGlobal.ERP.UI.Win.Forms.BankaForms;
using AsamaGlobal.ERP.UI.Win.Forms.BankaHesapForms;
using AsamaGlobal.ERP.UI.Win.Forms.BankaSubeForms;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariGruplariForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariSubeForms.CariSubeGrubuForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms.CariTurleriForms;
using AsamaGlobal.ERP.UI.Win.Forms.DepartmanForms;
using AsamaGlobal.ERP.UI.Win.Forms.EtiketForms;
using AsamaGlobal.ERP.UI.Win.Forms.GorevForms;
using AsamaGlobal.ERP.UI.Win.Forms.HizmetTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.IlceForms;
using AsamaGlobal.ERP.UI.Win.Forms.IlForms;
using AsamaGlobal.ERP.UI.Win.Forms.IndirimTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.IsyeriForms;
using AsamaGlobal.ERP.UI.Win.Forms.KasaForms;
using AsamaGlobal.ERP.UI.Win.Forms.KayitKaynakForms;
using AsamaGlobal.ERP.UI.Win.Forms.KimlikTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.KisiForms;
using AsamaGlobal.ERP.UI.Win.Forms.KisiGrubuForms;
using AsamaGlobal.ERP.UI.Win.Forms.KontenjanForms;
using AsamaGlobal.ERP.UI.Win.Forms.KullaniciForms;
using AsamaGlobal.ERP.UI.Win.Forms.KurumTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.MeslekForms;
using AsamaGlobal.ERP.UI.Win.Forms.OdemeTuruForms;
using AsamaGlobal.ERP.UI.Win.Forms.OkulForms;
using AsamaGlobal.ERP.UI.Win.Forms.OzelKodForms;
using AsamaGlobal.ERP.UI.Win.Forms.PersonelForms;
using AsamaGlobal.ERP.UI.Win.Forms.PozisyonForms;
using AsamaGlobal.ERP.UI.Win.Forms.RehberForms;
using AsamaGlobal.ERP.UI.Win.Forms.RenkForms;
using AsamaGlobal.ERP.UI.Win.Forms.SektorForms;
using AsamaGlobal.ERP.UI.Win.Forms.SinifForms;
using AsamaGlobal.ERP.UI.Win.Forms.SinifGrupForms;
using AsamaGlobal.ERP.UI.Win.Forms.SosyalMedyaForms;
using AsamaGlobal.ERP.UI.Win.Forms.SubeForms;
using AsamaGlobal.ERP.UI.Win.Forms.TesvikForms;
using AsamaGlobal.ERP.UI.Win.Forms.UlkeForms;
using AsamaGlobal.ERP.UI.Win.Forms.UyrukForms;
using AsamaGlobal.ERP.UI.Win.Forms.VergiDairesiForms;
using AsamaGlobal.ERP.UI.Win.Forms.YabancıDilForms;
using AsamaGlobal.ERP.UI.Win.Show;
using AsamaGlobal.ERP.UI.Win.UserControls.Controls;
using DevExpress.XtraEditors;
using System;

namespace AsamaGlobal.ERP.UI.Win.Functions
{
    public class SelectFunctions : IDisposable
    {
        #region Variables
        private MyButtonEdit _btnEdit;
        private MyButtonEdit _prmEdit;
        private KartTuru _kartTuru;
        private OdemeTipi _odemeTipi;
        private BankaHesapTuru _hesapTuru;

        #endregion

        public void Sec(MyButtonEdit btnEdit)
        {
            _btnEdit = btnEdit;
            SecimYap();
        }

        public void Sec(MyButtonEdit btnEdit, OdemeTipi odemeTipi)
        {
            _btnEdit = btnEdit;
            _odemeTipi = odemeTipi;
            SecimYap();
        }

        public void Sec(MyButtonEdit btnEdit, KartTuru kartTuru, BankaHesapTuru hesapTuru)
        {
            _btnEdit = btnEdit;
            _kartTuru = kartTuru;
            _hesapTuru = hesapTuru;
            SecimYap();
        }

        public void Sec(MyButtonEdit btnEdit,KartTuru kartTuru)
        {
            _btnEdit = btnEdit;
            _kartTuru= kartTuru;
            SecimYap();
        }

        public void Sec(MyButtonEdit btnEdit, MyButtonEdit prmEdit)
        {
            _btnEdit = btnEdit;
            _prmEdit = prmEdit;
            SecimYap();
        }
        public void SecCariSube(MyButtonEdit subeEdit, MyButtonEdit cariEdit)
        {
            _btnEdit = subeEdit;
            _prmEdit = cariEdit;
            SecimYap();
        }
        private void SecimYap()
        {
            switch (_btnEdit.Name)
            {
                case "txtUlke":
                    {
                        var entity = (Ulke)ShowListForms<UlkeListForm>.ShowDialogListForm(KartTuru.Ulke,
                            _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.UlkeAdi;
                        }
                    }
                    break;

                case "txtIl":
                case "txtAdresIl":
                case "txtEvAdresIl":
                case "txtIsAdresIl":
                case "txtKimlikIl":
                {
                    var entity = (Il) ShowListForms<IlListForm>.ShowDialogListForm(KartTuru.Il, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.IlAdi;
                    }
                }
                    break;

                case "txtIlce":
                case "txtAdresIlce":
                case "txtEvAdresIlce":
                case "txtIsAdresIlce":
                case "txtKimlikIlce":
                    {
                    var entity = (Ilce) ShowListForms<IlceListForm>.ShowDialogListForm(KartTuru.Ilce, _btnEdit.Id,
                        _prmEdit.Id, _prmEdit.Text);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.IlceAdi;
                    }
                }
                    break;

                case "txtGrup":
                {
                    var entity =
                        (SinifGrup) ShowListForms<SinifGrupListForm>.ShowDialogListForm(KartTuru.SinifGrup,
                            _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.GrupAdi;
                    }
                }
                    break;

                case "txtHizmetTuru":
                {
                    var entity =
                        (HizmetTuru) ShowListForms<HizmetTuruListForm>.ShowDialogListForm(KartTuru.HizmetTuru,
                            _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.HizmetTuruAdi;
                    }
                }
                    break;

                case "txtOzelKod1":
                {
                    var entity = (OzelKod) ShowListForms<OzelKodListForm>.ShowDialogListForm(KartTuru.OzelKod,
                        _btnEdit.Id, OzelKodTuru.OzelKod1, _kartTuru);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OzelKodAdi;
                    }
                }
                    break;

                case "txtOzelKod2":
                {
                    var entity = (OzelKod) ShowListForms<OzelKodListForm>.ShowDialogListForm(KartTuru.OzelKod,
                        _btnEdit.Id, OzelKodTuru.OzelKod2, _kartTuru);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OzelKodAdi;
                    }
                }
                    break;

                case "txtOzelKod3":
                {
                    var entity = (OzelKod) ShowListForms<OzelKodListForm>.ShowDialogListForm(KartTuru.OzelKod,
                        _btnEdit.Id, OzelKodTuru.OzelKod3, _kartTuru);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OzelKodAdi;
                    }
                }
                    break;

                case "txtOzelKod4":
                {
                    var entity = (OzelKod) ShowListForms<OzelKodListForm>.ShowDialogListForm(KartTuru.OzelKod,
                        _btnEdit.Id, OzelKodTuru.OzelKod4, _kartTuru);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OzelKodAdi;
                    }
                }
                    break;

                case "txtOzelKod5":
                {
                    var entity = (OzelKod) ShowListForms<OzelKodListForm>.ShowDialogListForm(KartTuru.OzelKod,
                        _btnEdit.Id, OzelKodTuru.OzelKod5, _kartTuru);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OzelKodAdi;
                    }
                }
                    break;
                    
                    
                        case "txtBanka":
                        {
                            var entity = (BankaL) ShowListForms<BankaListForm>.ShowDialogListForm(KartTuru.Banka, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.BankaAdi;
                            }
                        }
                            break;

                        case "txtBankaSube":
                        {
                            var entity = (BankaSube) ShowListForms<BankaSubeListForm>.ShowDialogListForm(KartTuru.BankaSube, _btnEdit.Id, _prmEdit.Id, _prmEdit.Text);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.SubeAdi;
                            }
                        }
                            break;

                case "txtMeslek":
                {
                    var entity = (Meslek)ShowListForms<MeslekListForm>.ShowDialogListForm(KartTuru.Meslek, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.Ad;
                    }
                }
                    break;

                case "txtKayitKaynak":
                    {
                        var entity = (KayitKaynak)ShowListForms<KayitKaynakListForm>.ShowDialogListForm(KartTuru.KayitKaynak, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.KayitKaynakAdi;
                        }
                    }
                    break;

                case "txtKisiGrubu":
                    {
                        var entity = (KisiGrubu)ShowListForms<KisiGrubuListForm>.ShowDialogListForm(KartTuru.KisiGrubu, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtEtiket":
                    {
                        var entity = (EtiketL)ShowListForms<EtiketListForm>.ShowDialogListForm(KartTuru.Etiket, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.EtiketAdi;
                        }
                    }
                    break;
                case "txtVergiDairesi":
                    {
                        var entity = (VergiDairesiL)ShowListForms<VergiDairesiListForm>.ShowDialogListForm(
                            KartTuru.VergiDairesi,
                            _btnEdit.Id,
                            frm =>
                            {
                                frm.ShowYeniButton = false;
                                frm.ShowDuzeltButton = false;
                                frm.ShowSilButton = false;
                               
                            }

                        );

                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtCariTuru":
                    {
                        var entity = (CariTuru)ShowListForms<CariTuruListForm>.ShowDialogListForm(KartTuru.CariTuru, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtCariGrubu":
                    {
                        var entity = (CariGrubuL)ShowListForms<CariGrubuListForm>.ShowDialogListForm(KartTuru.CariGrubu, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;   
                case "txtCariSubeGrubu":
                    {
                        var entity = (CariSubeGrubuL)ShowListForms<CariSubeGrubuListForm>.ShowDialogListForm(KartTuru.CariSubeGrubu, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;   
                    
                case "txtSektor":
                    {
                        var entity = (Sektor)ShowListForms<SektorListForm>.ShowDialogListForm(KartTuru.Sektor, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;                                 

                case "txtRenk":
                    {
                        var entity = (RenkL)ShowListForms<RenkListForm>.ShowDialogListForm(KartTuru.Renk, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.RenkAdi;
                        }
                    }
                    break;

                case "txtAdresTurleri":
                    {
                        var entity = (AdresTurleriL)ShowListForms<AdresTurleriListForm>.ShowDialogListForm(KartTuru.AdresTurleri, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtSosyalMedyaPlatformu":
                    {
                        var entity = (SosyalMedyaPlatformuL)ShowListForms<SosyalMedyaPlatformuListForm>.ShowDialogListForm(KartTuru.SosyalMedyaPlatformu,
                            _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtKayitHesabi":
                    {

                        if (_kartTuru == KartTuru.Kisi)
                        {
                            var entity = (KisiL)ShowListForms<KisiListForm>.ShowDialogListForm(KartTuru.Kisi, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.Ad;
                            }
                        }
                        else if (_kartTuru == KartTuru.Meslek)
                        {
                            var entity = (Meslek)ShowListForms<MeslekListForm>.ShowDialogListForm(KartTuru.Meslek, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.Ad;
                            }
                        }
                        else if (_kartTuru == KartTuru.Personel)
                        {
                            var entity = (PersonelL)ShowListForms<PersonelListForm>.ShowDialogListForm(KartTuru.Personel, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.Ad;
                            }
                        }
                        else if (_kartTuru == KartTuru.Cariler)
                        {
                            var entity = (CarilerL)ShowListForms<CarilerListForm>.ShowDialogListForm(KartTuru.Cariler, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.Unvan;
                            }
                        }
                        else if (_kartTuru == KartTuru.CariSubeler)
                        {
                            var entity = (CariSubelerL)ShowListForms<CariSubelerListForm>.ShowDialogListForm(KartTuru.CariSubeler, _btnEdit.Id);
                            if (entity != null)
                            {
                                _btnEdit.Id = entity.Id;
                                _btnEdit.EditValue = entity.Ad;
                            }
                        }
                        // diğer türler...
                    }
                    break;

                case "txtCariSube":
                {
                        if (_prmEdit == null || _prmEdit.Id == 0)
                        {
                            Messages.UyariMesaji("Lütfen önce cari seçimi yapınız.");
                            return;
                        }

                        var entity = (CariSubelerL)ShowListForms<CariSubelerListForm>.ShowDialogListForm(
                            KartTuru.CariSubeler,
                            _btnEdit?.Id ?? 0,
                            _prmEdit.Id,
                            _prmEdit.Text
                        );

                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                }
                break;

                case "txtIsyeri":
                {
                    var entity = (Isyeri)ShowListForms<IsyeriListForm>.ShowDialogListForm(KartTuru.Isyeri, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.IsyeriAdi;
                    }
                }
                    break;

                case "txtDepartman":
                    {
                        var entity = (Departman)ShowListForms<DepartmanListForm>.ShowDialogListForm(KartTuru.Departman, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtPozisyon":
                    {
                        var entity = (PozisyonL)ShowListForms<PozisyonListForm>.ShowDialogListForm(KartTuru.Pozisyon, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;
                case "txtSorumlu":
                    {
                        var entity = (PersonelL)ShowListForms<PersonelListForm>.ShowDialogListForm(KartTuru.Personel, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtUyruk":
                    {
                        var entity = (UyrukL)ShowListForms<UyrukListForm>.ShowDialogListForm(KartTuru.Uyruk, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtKimlikTuru":
                    {
                        var entity = (KimlikTuruL)ShowListForms<KimlikTuruListForm>.ShowDialogListForm(KartTuru.KimlikTuru, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.KimlikAdi;
                        }
                    }
                    break;
                case "txtKurumTuru":
                    {
                        var entity = (KurumTuruL)ShowListForms<KurumTuruListForm>.ShowDialogListForm(KartTuru.KurumTuru, _btnEdit.Id);
                        if (entity != null)
                        {
                            _btnEdit.Id = entity.Id;
                            _btnEdit.EditValue = entity.Ad;
                        }
                    }
                    break;

                case "txtGorev":
                {
                    var entity = (Gorev)ShowListForms<GorevListForm>.ShowDialogListForm(KartTuru.Gorev, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.GorevAdi;
                    }
                }
                    break;

                case "txtIndirimTuru":
                {
                    var entity = (IndirimTuru)ShowListForms<IndirimTuruListForm>.ShowDialogListForm(KartTuru.IndirimTuru, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.IndirimTuruAdi;
                    }
                }
                    break;

                case "txtSinif":
                {
                    var entity = (SinifL)ShowListForms<SinifListForm>.ShowDialogListForm(KartTuru.Sinif, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.SinifAdi;
                    }
                }
                    break;

                case "txtYabanciDil":
                {
                    var entity = (YabanciDil)ShowListForms<YabanciDilListForm>.ShowDialogListForm(KartTuru.YabanciDil, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.DilAdi;
                    }
                }
                    break;

                case "txtGeldigiOkul":
                {
                    var entity = (OkulL)ShowListForms<OkulListForm>.ShowDialogListForm(KartTuru.Okul, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OkulAdi;
                    }
                }
                    break;

                case "txtKontenjan":
                {
                    var entity = (Kontenjan)ShowListForms<KontenjanListForm>.ShowDialogListForm(KartTuru.Kontenjan, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.KontenjanAdi;
                    }
                }
                    break;

                case "txtTesvik":
                {
                    var entity = (Tesvik)ShowListForms<TesvikListForm>.ShowDialogListForm(KartTuru.Tesvik, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.TesvikAdi;
                    }
                }
                    break;

                case "txtRehber":
                {
                    var entity = (Rehber)ShowListForms<RehberListForm>.ShowDialogListForm(KartTuru.Rehber, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.AdiSoyadi;
                    }
                }
                    break;

                case "txtBankaHesap":
                case "txtDefaultBankaHesap":
                {
                    var entity = (BankaHesapL)ShowListForms<BankaHesapListForm>.ShowDialogListForm(KartTuru.BankaHesap, _btnEdit.Id,_odemeTipi);
                    if (entity != null)
                    {
                        _btnEdit.Tag = entity.BlokeGunSayisi;
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.HesapAdi;
                    }
                }
                    break;

                case "txtOdemeTuru":
                {
                    var entity = (OdemeTuru)ShowListForms<OdemeTuruListForm>.ShowDialogListForm(KartTuru.OdemeTuru, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Tag = entity.OdemeTipi;
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.OdemeTuruAdi;
                    }
                }
                    break;

                case "txtDefaultAvukatHesap":
                {
                    var entity = (AvukatL)ShowListForms<AvukatListForm>.ShowDialogListForm(KartTuru.Avukat, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.AdiSoyadi;
                    }
                }
                    break;

                case "txtDefaultKasaHesap":
                {
                    var entity = (KasaL)ShowListForms<KasaListForm>.ShowDialogListForm(KartTuru.Kasa, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.KasaAdi;
                    }
                }
                    break;

                case "txtSube":
                {
                    var entity = (SubeL)ShowListForms<SubeListForm>.ShowDialogListForm(KartTuru.Sube, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.SubeAdi;
                    }
                }
                    break;

                case "txtRol":
                {
                    var entity = (Rol)ShowListForms<RolListForm>.ShowDialogListForm(KartTuru.Rol, _btnEdit.Id);
                    if (entity != null)
                    {
                        _btnEdit.Id = entity.Id;
                        _btnEdit.EditValue = entity.RolAdi;
                    }
                }
                    break;



                case "txtHesap":
                {
                    switch (_kartTuru)
                    {
                            case KartTuru.Avukat:
                            {
                                var entity = (AvukatL) ShowListForms<AvukatListForm>.ShowDialogListForm(KartTuru.Avukat, _btnEdit.Id);
                                if (entity != null)
                                {
                                    _btnEdit.Id = entity.Id;
                                    _btnEdit.EditValue = entity.AdiSoyadi;
                                }
                                break;
                            }
                            case KartTuru.Kasa:
                            {
                                var entity = (KasaL)ShowListForms<KasaListForm>.ShowDialogListForm(KartTuru.Kasa, _btnEdit.Id);
                                if (entity != null)
                                {
                                    _btnEdit.Id = entity.Id;
                                    _btnEdit.EditValue = entity.KasaAdi;
                                }
                                break;
                            }
                            case KartTuru.BankaHesap:
                            {
                                var entity = (BankaHesapL)ShowListForms<BankaHesapListForm>.ShowDialogListForm(KartTuru.BankaHesap, _btnEdit.Id,_hesapTuru);
                                if (entity != null)
                                {
                                    _btnEdit.Id = entity.Id;
                                    _btnEdit.EditValue = entity.HesapAdi;
                                }
                                break;
                            }

                            case KartTuru.Cari:
                            {
                                var entity = (CariL)ShowListForms<CariListForm>.ShowDialogListForm(KartTuru.Cari, _btnEdit.Id);
                                if (entity != null)
                                {
                                    _btnEdit.Id = entity.Id;
                                    _btnEdit.EditValue = entity.CariAdi;
                                }
                                break;
                            }

                            case KartTuru.Sube:
                                {
                                    var entity = (SubeL)ShowListForms<SubeListForm>.ShowDialogListForm(KartTuru.Sube, _btnEdit.Id, true);
                                    if (entity != null)
                                    {
                                        _btnEdit.Id = entity.Id;
                                        _btnEdit.EditValue = entity.SubeAdi;
                                    }
                                    break;
                                }

                        }
                    }
                    break;

            }
        }
        
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
