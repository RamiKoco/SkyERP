using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars.Ribbon;
using AsamaGlobal.ERP.Common.Enums;
using DevExpress.XtraBars;
using AsamaGlobal.ERP.UI.Win.UserControls.Controls;
using AsamaGlobal.ERP.Bll.Interfaces;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.Common.Message;
using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using AsamaGlobal.ERP.UI.Win.UserControls.Grid;
using AsamaGlobal.ERP.UI.Win.Interfaces;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraVerticalGrid;


namespace AsamaGlobal.ERP.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : RibbonForm
    {
        #region Variables

        private bool _formSablonKayitEdilecek;
        protected MyDataLayoutControl DataLayoutControl;
        protected MyDataLayoutControl[] DataLayoutControls;
        protected IBaseBll Bll;
        protected KartTuru BaseKartTuru;
        protected BaseEntity OldEntity;
        protected BaseEntity CurrentEntity;
        protected bool IsLoaded;
        protected bool KayitSonrasiFormuKapat = true;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;
        protected internal IslemTuru BaseIslemTuru;
        protected internal long Id;
        protected internal bool RefleshYapilacak;
        protected bool FarkliSubeIslemi;
        
        
        #endregion


        public BaseEditForm()
        {
            InitializeComponent();
        }

        protected void EventsLoad()
        {
           
            //Button Events
            foreach (BarItem button in ribbonControl.Items)
                button.ItemClick += Button_ItemClick;

            //Form Events 

            LocationChanged += BaseEditForm_LocationChanged;
            SizeChanged += BaseEditForm_SizeChanged;
            Load += BaseEditForm_Load;
            FormClosing += BaseEditForm_FormClosing;
            Shown += BaseEditForm_Shown;


            void ControlEvents(Control control)
            {
                control.KeyDown += Control_KeyDown;
                control.GotFocus += Control_GotFocus;
                control.Leave += Control_Leave;
                control.Enter += Control_Enter;

                switch (control)
                {
                    case FilterControl edt:
                        edt.FilterChanged += Control_EditValueChanged;
                        break;
                    case ComboBoxEdit edt:
                        edt.EditValueChanged += Control_EditValueChanged;
                        edt.SelectedValueChanged += Control_SelectedValueChanged;
                        break;
                    case MyButtonEdit edt:
                        edt.IdChanged += Control_IdChanged;
                        edt.EnabledChange += Control_EnabledChange;
                        edt.ButtonClick += Control_ButtonClick;
                        edt.DoubleClick += Control_DoubleClick;
                        break;
                    case BaseEdit edt:
                        edt.EditValueChanged += Control_EditValueChanged;
                        break;
                    case TabPane tab:
                        tab.SelectedPageChanged += Control_SelectedPageChanged;
                        break;
                    case PropertyGridControl pGrd:
                        pGrd.CellValueChanged += Control_CellValueChanged;
                        pGrd.FocusedRowChanged += Control_FocusedRowChanged;
                        break;
                    case MyGridControl grd:
                        grd.MainView.GotFocus += Control_GotFocus;
                        break;
                   
                }

            }

            if (DataLayoutControls == null)
            {
                if (DataLayoutControl == null) return;
                foreach (Control ctrl in DataLayoutControl.Controls)
                    ControlEvents(ctrl);
                
            }
            else
                foreach (var layout in DataLayoutControls)
                foreach (Control ctrl in layout.Controls)
                    ControlEvents(ctrl);
                
        }

        private void ButonGizleGoster()
        {

            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
        }
        private void GeriAl()
        {

            if (Messages.HayirSeciliEvetHayir("Yapılan Değişiklikler Geri Alınacaktır. Onaylıyor musunuz?", "Geri Al Onay") != DialogResult.Yes) return;

            if (BaseIslemTuru == IslemTuru.EntityUpdate)
                Yukle();
            else
                Close();


        }
        public virtual bool Kaydet(bool kapanis)
        {
            bool KayitIslemi()
            {
                Cursor.Current = Cursors.WaitCursor;
                switch (BaseIslemTuru)
                {
                    case IslemTuru.EntityInsert:
                        if (EntityInsert())
                            return KayitSonrasiIslemler();
                        break;

                    case IslemTuru.EntityUpdate:
                        if (EntityUpdate())
                            return KayitSonrasiIslemler();
                        break;
                }

                bool KayitSonrasiIslemler()
                {
                    OldEntity = CurrentEntity;
                    RefleshYapilacak = true;
                    ButonEnabledDurumu();

                    if (KayitSonrasiFormuKapat)
                        Close();
                    else
                        BaseIslemTuru = BaseIslemTuru == IslemTuru.EntityInsert ? IslemTuru.EntityUpdate : BaseIslemTuru;

                    return true;
                }

                return false;
            }
            var result = kapanis ? Messages.KapanisMesaj() : Messages.KayitMesaj();

            switch (result)
            {
                case DialogResult.Yes:
                    return KayitIslemi();
                case DialogResult.No:
                    if (kapanis)
                        btnKaydet.Enabled = false;
                    return true;
                case DialogResult.Cancel:
                    return false;
            }

            return false;
        }
        private void SablonYukle()
        {
            Name.FormSablonYukle(this);
        }
        private void FarkliKaydet()
        {
            if (Messages.EvetSeciliEvetHayir("Bu Filtre Referans Alınarak Yeni Bir Filtre Oluşturulacaktır. Onaylıyor musunuz?", "Kayıt Onay") != DialogResult.Yes) return;

            BaseIslemTuru = IslemTuru.EntityInsert;
            Yukle();
            if (Kaydet(true))
                Close();

        }
        protected void SablonKaydet()
        {
            if (_formSablonKayitEdilecek)
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);
        }
        protected virtual void FiltreUygula() { }
        protected virtual void TaksitOlustur() { }
        protected virtual void BaskiOnizleme() { }
        protected virtual void Yazdir() { }
        protected virtual void SecimYap(object sender) { }
        protected virtual bool EntityInsert()
        {
            return ((IBaseGenelBll)Bll).Insert(CurrentEntity);
        }
        protected virtual bool EntityUpdate()
        {
            return ((IBaseGenelBll)Bll).Update(OldEntity, CurrentEntity);
        }
        protected virtual void EntityDelete()
        {

            if (!((IBaseCommonBll)Bll).Delete(OldEntity)) return;
            RefleshYapilacak = true;
            Close();

        }
        protected virtual void NesneyiKontrollereBagla() { }
        protected virtual void TabloYukle() { }
        protected virtual void SifreSifirla() { }
        protected virtual void GuncelNesneOlustur() { }
        public virtual void Yukle() { }
        public virtual void Giris() { }
        protected internal virtual IBaseEntity ReturnEntity() { return null; }
        protected internal virtual void ButonEnabledDurumu()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGerial, btnSil, OldEntity, CurrentEntity);

        }
        
        protected  virtual void BagliTabloYukle() {}

        protected virtual bool BagliTabloKaydet() { return false; }

        protected virtual bool BagliTabloHataliGirisKontrol() { return false; }

        protected virtual void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnYeni)
            {
                if (!BaseKartTuru.YetkiKontrolu(YetkiTuru.Ekleyebilir)) return;
                BaseIslemTuru = IslemTuru.EntityInsert;
                Yukle();
            }

            else if (e.Item == btnKaydet)
                Kaydet(false);

            else if (e.Item == btnFarkliKaydet)
            {
                if (!BaseKartTuru.YetkiKontrolu(YetkiTuru.Ekleyebilir)) return;
                FarkliKaydet();
            }

            else if (e.Item == btnGerial)
                GeriAl();

            else if (e.Item == btnSil)
            {
                if (!BaseKartTuru.YetkiKontrolu(YetkiTuru.Silebilir)) return;
                EntityDelete();

            }

            else if (e.Item == btnUygula)
                FiltreUygula();

            else if (e.Item == btnTaksitOlustur)
                TaksitOlustur();

            else if (e.Item == btnYazdir)
                Yazdir();

            else if (e.Item == btnBaskiOnizleme)
                BaskiOnizleme();

            else if (e.Item == btnSifreSifirla)
                SifreSifirla();

            else if (e.Item == btnGiris)
                Giris();

            else if (e.Item == btnCikis)
                Close();

            Cursor.Current = DefaultCursor;
        }

  
        private void BaseEditForm_LocationChanged(object sender, EventArgs e)
        {
            _formSablonKayitEdilecek = true;
        }
        private void BaseEditForm_SizeChanged(object sender, EventArgs e)
        {
            _formSablonKayitEdilecek = true;
        }
        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            IsLoaded = true;
            GuncelNesneOlustur();
            SablonYukle();
            ButonGizleGoster();


            if(FarkliSubeIslemi)
                Messages.UyariMesaji("İşlem Yapılan Kart Çalışan Şube Veya Dönemde Olmadığı için Yapılan Değişikler Kayıt Edilemez.");
        }
        protected  virtual void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();

            if (btnKaydet.Visibility == BarItemVisibility.Never || !btnKaydet.Enabled) return;

            if (!Kaydet(true))
                e.Cancel = true;

        }
        protected virtual void BaseEditForm_Shown(object sender, EventArgs e) { }
        protected virtual void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();

            if (sender is MyButtonEdit edt)
                switch (e.KeyCode)
                {
                    case Keys.Delete when e.Control && e.Shift:
                        edt.Id = null;
                        edt.EditValue = null;
                        break;

                    case Keys.F4:
                    case Keys.Down when e.Modifiers == Keys.Alt:
                        SecimYap(edt);
                        break;
                }
        }
        private void Control_GotFocus(object sender, EventArgs e)
        {
            var type = sender.GetType();

            if (type == typeof(MyButtonEdit) || type == typeof(MyGridView) || type == typeof(MyPictureEdit) ||
                type == typeof(MyComboBoxEdit) || type == typeof(MyDateEdit) || type == typeof(MyCalcEdit) 
                || type == typeof(MyColorPickEdit))
            {
                statusBarKisaYol.Visibility = BarItemVisibility.Always;
                statusBarKisaYolAciklama.Visibility = BarItemVisibility.Always;

                statusBarAciklama.Caption = ((IStatusBarAciklama) sender).StatusBarAciklama;
                statusBarKisaYol.Caption = ((IStatusBarKisaYol) sender).StatusBarKisaYol;
                statusBarKisaYolAciklama.Caption = ((IStatusBarKisaYol) sender).StatusBarKisaYolAciklama;
            }
            else if (sender is IStatusBarAciklama ctrl)
                statusBarAciklama.Caption = ctrl.StatusBarAciklama;

        }
        private void Control_Leave(object sender, EventArgs e)
        {
            statusBarKisaYol.Visibility = BarItemVisibility.Never;
            statusBarKisaYolAciklama.Visibility = BarItemVisibility.Never;

        }

        protected   virtual void Control_Enter(object sender, EventArgs e) { }

        protected virtual void Control_EditValueChanged(object sender, EventArgs e)
        {

            if (!IsLoaded) return;
            GuncelNesneOlustur();
        }
        protected virtual void Control_SelectedValueChanged(object sender, EventArgs e) { }
        protected virtual void Control_IdChanged(object sender, IdChangedEventArgs e)
        {
            if(!IsLoaded) return;
            GuncelNesneOlustur();
        }
        protected  virtual void Control_EnabledChange(object sender, EventArgs e) { }
        private void Control_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SecimYap(sender);
        }
        private void Control_DoubleClick(object sender, EventArgs e)
        {
            SecimYap(sender);
        }
        protected virtual void Control_SelectedPageChanged(object sender, SelectedPageChangedEventArgs e) { }
        protected virtual void Control_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e) { }
        protected virtual void Control_FocusedRowChanged(object sender, DevExpress.XtraVerticalGrid.Events.FocusedRowChangedEventArgs e) { }

    }
}