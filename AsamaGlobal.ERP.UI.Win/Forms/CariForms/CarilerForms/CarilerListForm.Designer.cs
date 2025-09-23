using AsamaGlobal.ERP.UI.Win.Forms.CariForms;
using AsamaGlobal;
using AsamaGlobal.ERP;
using AsamaGlobal.ERP.UI;
using AsamaGlobal.ERP.UI.Win;
using AsamaGlobal.ERP.UI.Win.Forms;

namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms.CarilerForms
{
    partial class CarilerListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CarilerListForm));
            this.grid = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridControl();
            this.tablo = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colKod = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colUnvan = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colCariAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colKimlikNo = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colAd = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colSoyad = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.VergiKodu = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colVergiDairesiAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colVergiNo = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colOzelKod1Adi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colOzelKod2Adi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colOzelKod3Adi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colOzelKod4Adi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colOzelKod5Adi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colAciklama = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.longNavigator = new AsamaGlobal.ERP.UI.Win.UserControls.Navigators.LongNavigator();
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
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 135);
            this.grid.MainView = this.tablo;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1058, 299);
            this.grid.TabIndex = 2;
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
            this.gridBand4,
            this.gridBand3,
            this.gridBand2,
            this.gridBand5});
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colId,
            this.colKod,
            this.colAd,
            this.colSoyad,
            this.colAciklama,
            this.colCariAdi,
            this.colUnvan,
            this.colKimlikNo,
            this.colVergiDairesiAdi,
            this.colVergiNo,
            this.VergiKodu,
            this.colOzelKod1Adi,
            this.colOzelKod2Adi,
            this.colOzelKod3Adi,
            this.colOzelKod4Adi,
            this.colOzelKod5Adi});
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
            this.tablo.ViewCaption = "Cari Bilgiler";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Genel Bilgiler";
            this.gridBand1.Columns.Add(this.colKod);
            this.gridBand1.Columns.Add(this.colUnvan);
            this.gridBand1.Columns.Add(this.colCariAdi);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 292;
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
            this.colKod.Width = 114;
            // 
            // colUnvan
            // 
            this.colUnvan.Caption = "Unvan";
            this.colUnvan.FieldName = "Unvan";
            this.colUnvan.Name = "colUnvan";
            this.colUnvan.OptionsColumn.AllowEdit = false;
            this.colUnvan.StatusBarAciklama = null;
            this.colUnvan.StatusBarKisaYol = null;
            this.colUnvan.StatusBarKisaYolAciklama = null;
            this.colUnvan.Visible = true;
            this.colUnvan.Width = 87;
            // 
            // colCariAdi
            // 
            this.colCariAdi.Caption = "Cari Adı";
            this.colCariAdi.FieldName = "CariAdi";
            this.colCariAdi.Name = "colCariAdi";
            this.colCariAdi.OptionsColumn.AllowEdit = false;
            this.colCariAdi.StatusBarAciklama = null;
            this.colCariAdi.StatusBarKisaYol = null;
            this.colCariAdi.StatusBarKisaYolAciklama = null;
            this.colCariAdi.Visible = true;
            this.colCariAdi.Width = 91;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Kişisel Bilgiler";
            this.gridBand4.Columns.Add(this.colKimlikNo);
            this.gridBand4.Columns.Add(this.colAd);
            this.gridBand4.Columns.Add(this.colSoyad);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 1;
            this.gridBand4.Width = 269;
            // 
            // colKimlikNo
            // 
            this.colKimlikNo.Caption = "Kimlik No";
            this.colKimlikNo.FieldName = "KimlikNo";
            this.colKimlikNo.Name = "colKimlikNo";
            this.colKimlikNo.OptionsColumn.AllowEdit = false;
            this.colKimlikNo.StatusBarAciklama = null;
            this.colKimlikNo.StatusBarKisaYol = null;
            this.colKimlikNo.StatusBarKisaYolAciklama = null;
            this.colKimlikNo.Visible = true;
            this.colKimlikNo.Width = 89;
            // 
            // colAd
            // 
            this.colAd.Caption = "Ad";
            this.colAd.FieldName = "Ad";
            this.colAd.Name = "colAd";
            this.colAd.OptionsColumn.AllowEdit = false;
            this.colAd.StatusBarAciklama = null;
            this.colAd.StatusBarKisaYol = null;
            this.colAd.StatusBarKisaYolAciklama = null;
            this.colAd.Visible = true;
            this.colAd.Width = 89;
            // 
            // colSoyad
            // 
            this.colSoyad.Caption = "Soyad";
            this.colSoyad.FieldName = "Soyad";
            this.colSoyad.Name = "colSoyad";
            this.colSoyad.OptionsColumn.AllowEdit = false;
            this.colSoyad.StatusBarAciklama = null;
            this.colSoyad.StatusBarKisaYol = null;
            this.colSoyad.StatusBarKisaYolAciklama = null;
            this.colSoyad.Visible = true;
            this.colSoyad.Width = 91;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Vergi Bilgileri";
            this.gridBand3.Columns.Add(this.VergiKodu);
            this.gridBand3.Columns.Add(this.colVergiDairesiAdi);
            this.gridBand3.Columns.Add(this.colVergiNo);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 311;
            // 
            // VergiKodu
            // 
            this.VergiKodu.Caption = "Vergi Kodu";
            this.VergiKodu.FieldName = "VergiKodu";
            this.VergiKodu.Name = "VergiKodu";
            this.VergiKodu.OptionsColumn.AllowEdit = false;
            this.VergiKodu.StatusBarAciklama = null;
            this.VergiKodu.StatusBarKisaYol = null;
            this.VergiKodu.StatusBarKisaYolAciklama = null;
            this.VergiKodu.Visible = true;
            this.VergiKodu.Width = 103;
            // 
            // colVergiDairesiAdi
            // 
            this.colVergiDairesiAdi.Caption = "Vergi Dairesi";
            this.colVergiDairesiAdi.FieldName = "VergiDairesiAdi";
            this.colVergiDairesiAdi.Name = "colVergiDairesiAdi";
            this.colVergiDairesiAdi.OptionsColumn.AllowEdit = false;
            this.colVergiDairesiAdi.StatusBarAciklama = null;
            this.colVergiDairesiAdi.StatusBarKisaYol = null;
            this.colVergiDairesiAdi.StatusBarKisaYolAciklama = null;
            this.colVergiDairesiAdi.Visible = true;
            this.colVergiDairesiAdi.Width = 103;
            // 
            // colVergiNo
            // 
            this.colVergiNo.Caption = "Vergi No";
            this.colVergiNo.FieldName = "VergiNo";
            this.colVergiNo.Name = "colVergiNo";
            this.colVergiNo.OptionsColumn.AllowEdit = false;
            this.colVergiNo.StatusBarAciklama = null;
            this.colVergiNo.StatusBarKisaYol = null;
            this.colVergiNo.StatusBarKisaYolAciklama = null;
            this.colVergiNo.Visible = true;
            this.colVergiNo.Width = 105;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Özel Kod";
            this.gridBand2.Columns.Add(this.colOzelKod1Adi);
            this.gridBand2.Columns.Add(this.colOzelKod2Adi);
            this.gridBand2.Columns.Add(this.colOzelKod3Adi);
            this.gridBand2.Columns.Add(this.colOzelKod4Adi);
            this.gridBand2.Columns.Add(this.colOzelKod5Adi);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 3;
            this.gridBand2.Width = 400;
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
            this.colOzelKod1Adi.Width = 79;
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
            this.colOzelKod2Adi.Width = 79;
            // 
            // colOzelKod3Adi
            // 
            this.colOzelKod3Adi.Caption = "Özel Kod-3";
            this.colOzelKod3Adi.FieldName = "OzelKod3Adi";
            this.colOzelKod3Adi.Name = "colOzelKod3Adi";
            this.colOzelKod3Adi.OptionsColumn.AllowEdit = false;
            this.colOzelKod3Adi.StatusBarAciklama = null;
            this.colOzelKod3Adi.StatusBarKisaYol = null;
            this.colOzelKod3Adi.StatusBarKisaYolAciklama = null;
            this.colOzelKod3Adi.Visible = true;
            this.colOzelKod3Adi.Width = 79;
            // 
            // colOzelKod4Adi
            // 
            this.colOzelKod4Adi.Caption = "Özel Kod-4";
            this.colOzelKod4Adi.FieldName = "OzelKod4Adi";
            this.colOzelKod4Adi.Name = "colOzelKod4Adi";
            this.colOzelKod4Adi.OptionsColumn.AllowEdit = false;
            this.colOzelKod4Adi.StatusBarAciklama = null;
            this.colOzelKod4Adi.StatusBarKisaYol = null;
            this.colOzelKod4Adi.StatusBarKisaYolAciklama = null;
            this.colOzelKod4Adi.Visible = true;
            this.colOzelKod4Adi.Width = 79;
            // 
            // colOzelKod5Adi
            // 
            this.colOzelKod5Adi.Caption = "Özel Kod-5";
            this.colOzelKod5Adi.FieldName = "OzelKod5Adi";
            this.colOzelKod5Adi.Name = "colOzelKod5Adi";
            this.colOzelKod5Adi.OptionsColumn.AllowEdit = false;
            this.colOzelKod5Adi.StatusBarAciklama = null;
            this.colOzelKod5Adi.StatusBarKisaYol = null;
            this.colOzelKod5Adi.StatusBarKisaYolAciklama = null;
            this.colOzelKod5Adi.Visible = true;
            this.colOzelKod5Adi.Width = 84;
            // 
            // gridBand5
            // 
            this.gridBand5.Caption = "Ek Bilgiler";
            this.gridBand5.Columns.Add(this.colAciklama);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 4;
            this.gridBand5.Width = 204;
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
            this.colAciklama.Width = 204;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // longNavigator
            // 
            this.longNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.longNavigator.Location = new System.Drawing.Point(0, 434);
            this.longNavigator.Name = "longNavigator";
            this.longNavigator.Size = new System.Drawing.Size(1058, 24);
            this.longNavigator.TabIndex = 3;
            // 
            // CarilerListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 482);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.longNavigator);
            this.IconOptions.ShowIcon = false;
            this.Name = "CarilerListForm";
            this.Text = "Cari Kartları";
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

        private UserControls.Grid.MyBandedGridControl grid;
        private UserControls.Grid.MyBandedGridView tablo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colId;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKod;
        private UserControls.Navigators.LongNavigator longNavigator;
        private UserControls.Grid.MyBandedGridColumn colAciklama;
        private UserControls.Grid.MyBandedGridColumn colAd;
        private UserControls.Grid.MyBandedGridColumn colSoyad;
        private UserControls.Grid.MyBandedGridColumn colCariAdi;
        private UserControls.Grid.MyBandedGridColumn colUnvan;
        private UserControls.Grid.MyBandedGridColumn colKimlikNo;
        private UserControls.Grid.MyBandedGridColumn colVergiDairesiAdi;
        private UserControls.Grid.MyBandedGridColumn colVergiNo;
        private UserControls.Grid.MyBandedGridColumn VergiKodu;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private UserControls.Grid.MyBandedGridColumn colOzelKod1Adi;
        private UserControls.Grid.MyBandedGridColumn colOzelKod2Adi;
        private UserControls.Grid.MyBandedGridColumn colOzelKod3Adi;
        private UserControls.Grid.MyBandedGridColumn colOzelKod4Adi;
        private UserControls.Grid.MyBandedGridColumn colOzelKod5Adi;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
    }
}