using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Data.Contexts;
using AsamaGlobal.ERP.Model.Entities;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.UI.Win.Forms.DonemForms;
using AsamaGlobal.ERP.UI.Win.Forms.KullaniciForms;
using AsamaGlobal.ERP.UI.Win.Forms.SubeForms;
using AsamaGlobal.ERP.UI.Win.Forms.VergiDairesiForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.GenelForms;
using AsamaGlobal.ERP.UI.Win.Show;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using System.Security;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.UI.Yonetim.Forms.GenelForms
{
    public partial class AnaForm : RibbonForm
    {
        #region Variables

        private readonly string _server;
        private readonly SecureString _kullaniciAdi;
        private readonly SecureString _sifre;
        private readonly YetkilendirmeTuru _yetkilendirmeTuru;
        private readonly KurumBll _bll; 
        
        #endregion
        public AnaForm(params object[] prm)
        {
            InitializeComponent();

            longNavigator.Navigator.NavigatableControl = tablo.GridControl;
            EventsLoad();
            ButonEnabledDurumu();
            
            _server = prm[0].ToString();
            _kullaniciAdi = (SecureString)prm[1];
            _sifre = (SecureString)prm[2];
            _yetkilendirmeTuru = (YetkilendirmeTuru)prm[3];
            _bll = new KurumBll();

        }

        private void EventsLoad()
        {
            //Button Events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;

            //Table Events
            tablo.DoubleClick += Tablo_DoubleClick;
            tablo.KeyDown += Tablo_KeyDown;
            tablo.MouseUp += Tablo_MouseUp;
            tablo.RowCountChanged += Tablo_RowCountChanged;

            //Form Events
            FormClosing += AnaForm_FormClosing;
            Load += AnaForm_Load;
        }


        protected internal void Listele()
        {
            tablo.GridControl.DataSource = _bll.List(null);

        }
        protected virtual void ShowEditForm(long id)
        {
            
            GeneralFunctions.CreateConnectionString("AsamaGlobal_ERP_Yonetim",_server,_kullaniciAdi,_sifre,_yetkilendirmeTuru);
            
            //if (id < -1) return; //Kart seçme hatası sonrası hata verdiği için eklendi udemy soru cevaptan
            var result = ShowEditForms<KurumEditForm>.ShowDialogEditForm(id, _server, _kullaniciAdi, _sifre,_yetkilendirmeTuru);
            if (result <= 0) return;
            Listele();
            tablo.RowFocus("Id",result);
        }
        private void ButonEnabledDurumu()
        {
            foreach (BarItem button in ribbonControl.Items)
            {
                if (!(button is BarButtonItem item)) continue;
                if (item != btnYeni)
                    item.Enabled = tablo.DataRowCount > 0;

            }
        }

        private void EntityDelete(BaseEntity entity)
        {
            GeneralFunctions.CreateConnectionString(entity.Kod, _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            if (!Functions.GeneralFunctions.DeleteDatabase<ERPYonetimContext>()) return;

            GeneralFunctions.CreateConnectionString("AsamaGlobal_ERP_Yonetim", _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);
            _bll.Delete(entity);
            tablo.DeleteSelectedRows();
            tablo.RowFocus(tablo.FocusedRowHandle);

        }

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnYeni || e.Item == btnDuzelt)
            {
                if(e.Item == btnYeni)
                    ShowEditForm(-1);
                else if (e.Item == btnDuzelt)
                    ShowEditForm(tablo.GetRowId());
            }
            else
            {
                var entity = tablo.GetRow<Kurum>();
                if (entity == null) return;
                GeneralFunctions.CreateConnectionString(entity.Kod, _server, _kullaniciAdi, _sifre, _yetkilendirmeTuru);

                if(e.Item == btnSil)
                    EntityDelete(entity);
                else if (e.Item == btnEmailParametreleri)
                    ShowEditForms<EmailParametreEditForm>.ShowDialogEditForm();
                else if (e.Item == btnSubeKartlari)
                    ShowListForms<SubeListForm>.ShowDialogListForm();
                else if (e.Item == btnDonemKartlari)
                    ShowListForms<DonemListForm>.ShowDialogListForm();
                else if (e.Item == btnKurumBilgileri)
                    ShowEditForms<KurumBilgileriEditForm>.ShowDialogEditForm(null,entity.Kod,entity.KurumAdi);
                else if (e.Item == btnRolKartlari)
                    ShowListForms<RolListForm>.ShowDialogListForm();
                else if (e.Item == btnVergiDairesiKartlari)
                {                   
                        // Formu aç, btnYeni görünür olsun
                        ShowListForms<VergiDairesiListForm>.ShowDialogListForm(
                            KartTuru.VergiDairesi,
                            null, // seciliId yok
                            frm => { 
                                frm.ShowYeniButton = true;
                                frm.ShowDuzeltButton = true;
                                frm.ShowSilButton = true;
                            }
                        );                   
                }                  
                else if (e.Item == btnKullaniciKartlari)
                    ShowListForms<KullaniciListForm>.ShowDialogListForm();
                else if (e.Item == btnKullaniciBirimYetkileri)
                    ShowEditForms<KullaniciBirimYetkileriEditForm>.ShowDialogEditForm();


            }

            Cursor.Current = DefaultCursor;

        }
        private void Tablo_DoubleClick(object sender, System.EventArgs e)
        {
            if (tablo.FocusedRowHandle < 0) return;
            ShowEditForm(tablo.GetRowId());

        }
        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            if (tablo.FocusedRowHandle < 0) return;

            switch (e.KeyCode)
            {
                case Keys.Enter:
                    ShowEditForm(tablo.GetRowId());
                    break;

                case Keys.Escape:
                    Close();
                    break;
            }
        }
        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            e.SagMenuGoster(sagMenu);
            
        }
        private void Tablo_RowCountChanged(object sender, System.EventArgs e)
        {
            ButonEnabledDurumu();
        }
        private void AnaForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Messages.HayirSeciliEvetHayir("Programdan Çıkmak İstiyor Musunuz?", "Çıkış Onay") == DialogResult.Yes)
                Application.ExitThread();
            else
                e.Cancel = true;

        }
        private void AnaForm_Load(object sender, System.EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Listele();
            tablo.Focus();
            Cursor.Current = Cursors.Default;
        }

    }
}

