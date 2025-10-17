namespace AsamaGlobal.ERP.UI.Win.Forms.KisiForms
{
    partial class KisiListForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KisiListForm));
            this.longNavigator = new AsamaGlobal.ERP.UI.Win.UserControls.Navigators.LongNavigator();
            this.grid = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridControl();
            this.tablo = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridView();
            this.colKod = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colAd = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colSoyad = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colCinsiyet = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colDogumTarihi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colKisiGrubuAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colPersonelAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colMeslekAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colKayitKaynakAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colOzelKod1Adi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colOzelKod2Adi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colAciklama = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Size = new System.Drawing.Size(1058, 135);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // btnGonder
            // 
            this.btnGonder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGonder.ImageOptions.Image")));
            this.btnGonder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnGonder.ImageOptions.LargeImage")));
            // 
            // btnYeniMakbuz
            // 
            this.btnYeniMakbuz.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYeniMakbuz.ImageOptions.Image")));
            this.btnYeniMakbuz.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnYeniMakbuz.ImageOptions.LargeImage")));
            // 
            // btnYeniRapor
            // 
            this.btnYeniRapor.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnYeniRapor.ImageOptions.Image")));
            this.btnYeniRapor.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnYeniRapor.ImageOptions.LargeImage")));
            // 
            // barSubItem8
            // 
            this.barSubItem8.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSubItem8.ImageOptions.Image")));
            // 
            // longNavigator
            // 
            this.longNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator.Location = new System.Drawing.Point(0, 434);
            this.longNavigator.Name = "longNavigator";
            this.longNavigator.Size = new System.Drawing.Size(1058, 24);
            this.longNavigator.TabIndex = 2;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 135);
            this.grid.MainView = this.tablo;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1058, 299);
            this.grid.TabIndex = 3;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tablo});
            // 
            // tablo
            // 
            this.tablo.Appearance.BandPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.BandPanel.ForeColor = System.Drawing.Color.DarkBlue;
            this.tablo.Appearance.BandPanel.Options.UseFont = true;
            this.tablo.Appearance.BandPanel.Options.UseForeColor = true;
            this.tablo.Appearance.BandPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.BandPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.FooterPanel.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tablo.Appearance.FooterPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.FooterPanel.Options.UseFont = true;
            this.tablo.Appearance.FooterPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.tablo.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.tablo.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tablo.Appearance.ViewCaption.ForeColor = System.Drawing.Color.Maroon;
            this.tablo.Appearance.ViewCaption.Options.UseForeColor = true;
            this.tablo.BandPanelRowHeight = 40;
            this.tablo.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand3,
            this.gridBand2,
            this.gridBand4});
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colId,
            this.colKod,
            this.colAd,
            this.colSoyad,
            this.colCinsiyet,
            this.colDogumTarihi,
            this.colAciklama,
            this.colKisiGrubuAdi,
            this.colPersonelAdi,
            this.colMeslekAdi,
            this.colKayitKaynakAdi,
            this.colOzelKod1Adi,
            this.colOzelKod2Adi});
            this.tablo.GridControl = this.grid;
            this.tablo.Name = "tablo";
            this.tablo.OptionsMenu.EnableColumnMenu = false;
            this.tablo.OptionsMenu.EnableFooterMenu = false;
            this.tablo.OptionsMenu.EnableGroupPanelMenu = false;
            this.tablo.OptionsNavigation.EnterMoveNextColumn = true;
            this.tablo.OptionsPrint.AutoWidth = false;
            this.tablo.OptionsPrint.PrintFooter = false;
            this.tablo.OptionsPrint.PrintGroupFooter = false;
            this.tablo.OptionsView.ColumnAutoWidth = false;
            this.tablo.OptionsView.HeaderFilterButtonShowMode = DevExpress.XtraEditors.Controls.FilterButtonShowMode.Button;
            this.tablo.OptionsView.RowAutoHeight = true;
            this.tablo.OptionsView.ShowAutoFilterRow = true;
            this.tablo.OptionsView.ShowGroupPanel = false;
            this.tablo.OptionsView.ShowViewCaption = true;
            this.tablo.StatusBarAciklama = null;
            this.tablo.StatusBarKisaYol = null;
            this.tablo.StatusBarKisaYolAciklama = null;
            this.tablo.ViewCaption = "Kişi Kartları";
            // 
            // colKod
            // 
            this.colKod.AppearanceCell.Options.UseTextOptions = true;
            this.colKod.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colKod.Caption = "Kod";
            this.colKod.FieldName = "Kod";
            this.colKod.Name = "colKod";
            this.colKod.OptionsColumn.AllowEdit = false;
            this.colKod.Visible = true;
            this.colKod.Width = 80;
            // 
            // colAd
            // 
            this.colAd.Caption = "Adı";
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.OptionsColumn.AllowEdit = false;
            this.colAd.StatusBarAciklama = null;
            this.colAd.StatusBarKisaYol = null;
            this.colAd.StatusBarKisaYolAciklama = null;
            this.colAd.Visible = true;
            this.colAd.Width = 100;
            // 
            // colSoyad
            // 
            this.colSoyad.Caption = "Soyadı";
            this.colSoyad.FieldName = "Soyad";
            this.colSoyad.Name = "colSoyad";
            this.colSoyad.OptionsColumn.AllowEdit = false;
            this.colSoyad.StatusBarAciklama = null;
            this.colSoyad.StatusBarKisaYol = null;
            this.colSoyad.StatusBarKisaYolAciklama = null;
            this.colSoyad.Visible = true;
            this.colSoyad.Width = 100;
            // 
            // colCinsiyet
            // 
            this.colCinsiyet.AppearanceCell.Options.UseTextOptions = true;
            this.colCinsiyet.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCinsiyet.Caption = "Cinsiyet";
            this.colCinsiyet.FieldName = "Cinsiyet";
            this.colCinsiyet.Name = "colCinsiyet";
            this.colCinsiyet.OptionsColumn.AllowEdit = false;
            this.colCinsiyet.StatusBarAciklama = null;
            this.colCinsiyet.StatusBarKisaYol = null;
            this.colCinsiyet.StatusBarKisaYolAciklama = null;
            this.colCinsiyet.Visible = true;
            this.colCinsiyet.Width = 80;
            // 
            // colDogumTarihi
            // 
            this.colDogumTarihi.AppearanceCell.Options.UseTextOptions = true;
            this.colDogumTarihi.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDogumTarihi.Caption = "Doğum Tarihi";
            this.colDogumTarihi.FieldName = "DogumTarihi";
            this.colDogumTarihi.Name = "colDogumTarihi";
            this.colDogumTarihi.OptionsColumn.AllowEdit = false;
            this.colDogumTarihi.StatusBarAciklama = null;
            this.colDogumTarihi.StatusBarKisaYol = null;
            this.colDogumTarihi.StatusBarKisaYolAciklama = null;
            this.colDogumTarihi.Visible = true;
            this.colDogumTarihi.Width = 80;
            // 
            // colKisiGrubuAdi
            // 
            this.colKisiGrubuAdi.Caption = "Grup";
            this.colKisiGrubuAdi.FieldName = "KisiGrubuAdi";
            this.colKisiGrubuAdi.Name = "colKisiGrubuAdi";
            this.colKisiGrubuAdi.OptionsColumn.AllowEdit = false;
            this.colKisiGrubuAdi.StatusBarAciklama = null;
            this.colKisiGrubuAdi.StatusBarKisaYol = null;
            this.colKisiGrubuAdi.StatusBarKisaYolAciklama = null;
            this.colKisiGrubuAdi.Visible = true;
            this.colKisiGrubuAdi.Width = 100;
            // 
            // colPersonelAdi
            // 
            this.colPersonelAdi.Caption = "Sorumlusu";
            this.colPersonelAdi.FieldName = "PersonelAdi";
            this.colPersonelAdi.Name = "colPersonelAdi";
            this.colPersonelAdi.OptionsColumn.AllowEdit = false;
            this.colPersonelAdi.StatusBarAciklama = null;
            this.colPersonelAdi.StatusBarKisaYol = null;
            this.colPersonelAdi.StatusBarKisaYolAciklama = null;
            this.colPersonelAdi.Visible = true;
            this.colPersonelAdi.Width = 100;
            // 
            // colMeslekAdi
            // 
            this.colMeslekAdi.Caption = "Meslek";
            this.colMeslekAdi.FieldName = "MeslekAdi";
            this.colMeslekAdi.Name = "colMeslekAdi";
            this.colMeslekAdi.OptionsColumn.AllowEdit = false;
            this.colMeslekAdi.StatusBarAciklama = null;
            this.colMeslekAdi.StatusBarKisaYol = null;
            this.colMeslekAdi.StatusBarKisaYolAciklama = null;
            this.colMeslekAdi.Visible = true;
            this.colMeslekAdi.Width = 100;
            // 
            // colKayitKaynakAdi
            // 
            this.colKayitKaynakAdi.Caption = "Kaynak";
            this.colKayitKaynakAdi.FieldName = "KayitKaynakAdi";
            this.colKayitKaynakAdi.Name = "colKayitKaynakAdi";
            this.colKayitKaynakAdi.OptionsColumn.AllowEdit = false;
            this.colKayitKaynakAdi.StatusBarAciklama = null;
            this.colKayitKaynakAdi.StatusBarKisaYol = null;
            this.colKayitKaynakAdi.StatusBarKisaYolAciklama = null;
            this.colKayitKaynakAdi.Visible = true;
            this.colKayitKaynakAdi.Width = 100;
            // 
            // colOzelKod1Adi
            // 
            this.colOzelKod1Adi.Caption = "Özel Kod-1";
            this.colOzelKod1Adi.FieldName = "OzelKod1Adi";
            this.colOzelKod1Adi.Name = "colOzelKod1Adi";
            this.colOzelKod1Adi.OptionsColumn.AllowEdit = false;
            this.colOzelKod1Adi.StatusBarAciklama = null;
            this.colOzelKod1Adi.StatusBarKisaYol = null;
            this.colOzelKod1Adi.StatusBarKisaYolAciklama = null;
            this.colOzelKod1Adi.Visible = true;
            this.colOzelKod1Adi.Width = 100;
            // 
            // colOzelKod2Adi
            // 
            this.colOzelKod2Adi.Caption = "Özel Kod-2";
            this.colOzelKod2Adi.FieldName = "OzelKod2Adi";
            this.colOzelKod2Adi.Name = "colOzelKod2Adi";
            this.colOzelKod2Adi.OptionsColumn.AllowEdit = false;
            this.colOzelKod2Adi.StatusBarAciklama = null;
            this.colOzelKod2Adi.StatusBarKisaYol = null;
            this.colOzelKod2Adi.StatusBarKisaYolAciklama = null;
            this.colOzelKod2Adi.Visible = true;
            this.colOzelKod2Adi.Width = 100;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.OptionsColumn.AllowEdit = false;
            this.colAciklama.StatusBarAciklama = null;
            this.colAciklama.StatusBarKisaYol = null;
            this.colAciklama.StatusBarKisaYolAciklama = null;
            this.colAciklama.Visible = true;
            this.colAciklama.Width = 350;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Kişisel Bilgiler";
            this.gridBand1.Columns.Add(this.colKod);
            this.gridBand1.Columns.Add(this.colAd);
            this.gridBand1.Columns.Add(this.colSoyad);
            this.gridBand1.Columns.Add(this.colCinsiyet);
            this.gridBand1.Columns.Add(this.colDogumTarihi);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 440;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Kart Bilgileri";
            this.gridBand3.Columns.Add(this.colKisiGrubuAdi);
            this.gridBand3.Columns.Add(this.colPersonelAdi);
            this.gridBand3.Columns.Add(this.colMeslekAdi);
            this.gridBand3.Columns.Add(this.colKayitKaynakAdi);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            this.gridBand3.Width = 400;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Özel Kodlar";
            this.gridBand2.Columns.Add(this.colOzelKod1Adi);
            this.gridBand2.Columns.Add(this.colOzelKod2Adi);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 200;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Ek Bilgiler";
            this.gridBand4.Columns.Add(this.colAciklama);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 350;
            // 
            // KisiListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 482);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.longNavigator);
            this.IconOptions.ShowIcon = false;
            this.Name = "KisiListForm";
            this.Text = "Kişi Kartları";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.longNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Navigators.LongNavigator longNavigator;
        private UserControls.Grid.MyBandedGridControl grid;
        private UserControls.Grid.MyBandedGridView tablo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colId;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKod;
        private UserControls.Grid.MyBandedGridColumn colAd;
        private UserControls.Grid.MyBandedGridColumn colSoyad;
        private UserControls.Grid.MyBandedGridColumn colCinsiyet;
        private UserControls.Grid.MyBandedGridColumn colDogumTarihi;
        private UserControls.Grid.MyBandedGridColumn colOzelKod1Adi;
        private UserControls.Grid.MyBandedGridColumn colOzelKod2Adi;
        private UserControls.Grid.MyBandedGridColumn colAciklama;
        private UserControls.Grid.MyBandedGridColumn colMeslekAdi;
        private UserControls.Grid.MyBandedGridColumn colKayitKaynakAdi;
        private UserControls.Grid.MyBandedGridColumn colKisiGrubuAdi;
        private UserControls.Grid.MyBandedGridColumn colPersonelAdi;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
    }
}