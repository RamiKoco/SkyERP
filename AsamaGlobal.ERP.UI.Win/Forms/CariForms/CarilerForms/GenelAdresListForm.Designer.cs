namespace AsamaGlobal.ERP.UI.Win.Forms.CariForms
{
    partial class GenelAdresListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GenelAdresListForm));
            this.longNavigator = new AsamaGlobal.ERP.UI.Win.UserControls.Navigators.LongNavigator();
            this.grid = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridControl();
            this.tablo = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colKod = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colBaslik = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colAdresNotu = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colAdresTurleriAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colAdresTipi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colUlkeAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colIlAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colIlceAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colAdres = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colPostaKodu = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colEnlem = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colBoylam = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colOzelKod1Adi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colOzelKod2Adi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.gridBand7 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colAciklama = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colId = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
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
            this.longNavigator.TabIndex = 3;
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 135);
            this.grid.MainView = this.tablo;
            this.grid.MenuManager = this.ribbonControl;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1058, 299);
            this.grid.TabIndex = 4;
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
            this.gridBand2,
            this.gridBand3,
            this.gridBand6,
            this.gridBand7});
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colId,
            this.colKod,
            this.colBaslik,
            this.colAdresNotu,
            this.colAdresTurleriAdi,
            this.colAdresTipi,
            this.colUlkeAdi,
            this.colIlAdi,
            this.colIlceAdi,
            this.colPostaKodu,
            this.colAdres,
            this.colEnlem,
            this.colBoylam,
            this.colOzelKod1Adi,
            this.colOzelKod2Adi,
            this.colAciklama});
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
            this.tablo.ViewCaption = "Adres Kartları";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Adres Başlıkları";
            this.gridBand1.Columns.Add(this.colKod);
            this.gridBand1.Columns.Add(this.colBaslik);
            this.gridBand1.Columns.Add(this.colAdresNotu);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 248;
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
            this.colKod.Width = 82;
            // 
            // colBaslik
            // 
            this.colBaslik.Caption = "Başlık";
            this.colBaslik.FieldName = "Baslik";
            this.colBaslik.Name = "colBaslik";
            this.colBaslik.OptionsColumn.AllowEdit = false;
            this.colBaslik.StatusBarAciklama = null;
            this.colBaslik.StatusBarKisaYol = null;
            this.colBaslik.StatusBarKisaYolAciklama = null;
            this.colBaslik.Visible = true;
            this.colBaslik.Width = 82;
            // 
            // colAdresNotu
            // 
            this.colAdresNotu.Caption = "Adres Notu";
            this.colAdresNotu.FieldName = "AdresNotu";
            this.colAdresNotu.Name = "colAdresNotu";
            this.colAdresNotu.OptionsColumn.AllowEdit = false;
            this.colAdresNotu.StatusBarAciklama = null;
            this.colAdresNotu.StatusBarKisaYol = null;
            this.colAdresNotu.StatusBarKisaYolAciklama = null;
            this.colAdresNotu.Visible = true;
            this.colAdresNotu.Width = 84;
            // 
            // gridBand4
            // 
            this.gridBand4.Caption = "Adres Türü Bilgileri";
            this.gridBand4.Columns.Add(this.colAdresTurleriAdi);
            this.gridBand4.Columns.Add(this.colAdresTipi);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 1;
            this.gridBand4.Width = 177;
            // 
            // colAdresTurleriAdi
            // 
            this.colAdresTurleriAdi.Caption = "Adres Türü";
            this.colAdresTurleriAdi.FieldName = "AdresTurleriAdi";
            this.colAdresTurleriAdi.Name = "colAdresTurleriAdi";
            this.colAdresTurleriAdi.OptionsColumn.AllowEdit = false;
            this.colAdresTurleriAdi.StatusBarAciklama = null;
            this.colAdresTurleriAdi.StatusBarKisaYol = null;
            this.colAdresTurleriAdi.StatusBarKisaYolAciklama = null;
            this.colAdresTurleriAdi.Visible = true;
            this.colAdresTurleriAdi.Width = 88;
            // 
            // colAdresTipi
            // 
            this.colAdresTipi.Caption = "Adres Tipi";
            this.colAdresTipi.FieldName = "AdresTipi";
            this.colAdresTipi.Name = "colAdresTipi";
            this.colAdresTipi.OptionsColumn.AllowEdit = false;
            this.colAdresTipi.StatusBarAciklama = null;
            this.colAdresTipi.StatusBarKisaYol = null;
            this.colAdresTipi.StatusBarKisaYolAciklama = null;
            this.colAdresTipi.Visible = true;
            this.colAdresTipi.Width = 89;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Adres Bilgileri";
            this.gridBand2.Columns.Add(this.colUlkeAdi);
            this.gridBand2.Columns.Add(this.colIlAdi);
            this.gridBand2.Columns.Add(this.colIlceAdi);
            this.gridBand2.Columns.Add(this.colAdres);
            this.gridBand2.Columns.Add(this.colPostaKodu);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 452;
            // 
            // colUlkeAdi
            // 
            this.colUlkeAdi.Caption = "Ülke";
            this.colUlkeAdi.FieldName = "UlkeAdi";
            this.colUlkeAdi.Name = "colUlkeAdi";
            this.colUlkeAdi.OptionsColumn.AllowEdit = false;
            this.colUlkeAdi.StatusBarAciklama = null;
            this.colUlkeAdi.StatusBarKisaYol = null;
            this.colUlkeAdi.StatusBarKisaYolAciklama = null;
            this.colUlkeAdi.Visible = true;
            this.colUlkeAdi.Width = 87;
            // 
            // colIlAdi
            // 
            this.colIlAdi.Caption = "İl";
            this.colIlAdi.FieldName = "IlAdi";
            this.colIlAdi.Name = "colIlAdi";
            this.colIlAdi.OptionsColumn.AllowEdit = false;
            this.colIlAdi.StatusBarAciklama = null;
            this.colIlAdi.StatusBarKisaYol = null;
            this.colIlAdi.StatusBarKisaYolAciklama = null;
            this.colIlAdi.Visible = true;
            this.colIlAdi.Width = 87;
            // 
            // colIlceAdi
            // 
            this.colIlceAdi.Caption = "İlçe";
            this.colIlceAdi.FieldName = "IlceAdi";
            this.colIlceAdi.Name = "colIlceAdi";
            this.colIlceAdi.OptionsColumn.AllowEdit = false;
            this.colIlceAdi.StatusBarAciklama = null;
            this.colIlceAdi.StatusBarKisaYol = null;
            this.colIlceAdi.StatusBarKisaYolAciklama = null;
            this.colIlceAdi.Visible = true;
            // 
            // colAdres
            // 
            this.colAdres.Caption = "Adres";
            this.colAdres.FieldName = "Adres";
            this.colAdres.Name = "colAdres";
            this.colAdres.OptionsColumn.AllowEdit = false;
            this.colAdres.StatusBarAciklama = null;
            this.colAdres.StatusBarKisaYol = null;
            this.colAdres.StatusBarKisaYolAciklama = null;
            this.colAdres.Visible = true;
            this.colAdres.Width = 114;
            // 
            // colPostaKodu
            // 
            this.colPostaKodu.Caption = "Posta Kodu";
            this.colPostaKodu.FieldName = "PostaKodu";
            this.colPostaKodu.Name = "colPostaKodu";
            this.colPostaKodu.OptionsColumn.AllowEdit = false;
            this.colPostaKodu.StatusBarAciklama = null;
            this.colPostaKodu.StatusBarKisaYol = null;
            this.colPostaKodu.StatusBarKisaYolAciklama = null;
            this.colPostaKodu.Visible = true;
            this.colPostaKodu.Width = 89;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Koordinat Bilgileri";
            this.gridBand3.Columns.Add(this.colEnlem);
            this.gridBand3.Columns.Add(this.colBoylam);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 3;
            this.gridBand3.Width = 171;
            // 
            // colEnlem
            // 
            this.colEnlem.Caption = "Enlem";
            this.colEnlem.FieldName = "Enlem";
            this.colEnlem.Name = "colEnlem";
            this.colEnlem.OptionsColumn.AllowEdit = false;
            this.colEnlem.StatusBarAciklama = null;
            this.colEnlem.StatusBarKisaYol = null;
            this.colEnlem.StatusBarKisaYolAciklama = null;
            this.colEnlem.Visible = true;
            this.colEnlem.Width = 84;
            // 
            // colBoylam
            // 
            this.colBoylam.Caption = "Boylam";
            this.colBoylam.FieldName = "Boylam";
            this.colBoylam.Name = "colBoylam";
            this.colBoylam.OptionsColumn.AllowEdit = false;
            this.colBoylam.StatusBarAciklama = null;
            this.colBoylam.StatusBarKisaYol = null;
            this.colBoylam.StatusBarKisaYolAciklama = null;
            this.colBoylam.Visible = true;
            this.colBoylam.Width = 87;
            // 
            // gridBand6
            // 
            this.gridBand6.Caption = "Özel Kod";
            this.gridBand6.Columns.Add(this.colOzelKod1Adi);
            this.gridBand6.Columns.Add(this.colOzelKod2Adi);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 4;
            this.gridBand6.Width = 184;
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
            this.colOzelKod1Adi.Width = 92;
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
            this.colOzelKod2Adi.Width = 92;
            // 
            // gridBand7
            // 
            this.gridBand7.Caption = "Ek Bilgiler";
            this.gridBand7.Columns.Add(this.colAciklama);
            this.gridBand7.Name = "gridBand7";
            this.gridBand7.VisibleIndex = 5;
            this.gridBand7.Width = 244;
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
            this.colAciklama.Width = 244;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.OptionsColumn.AllowEdit = false;
            this.colId.OptionsColumn.ShowInCustomizationForm = false;
            // 
            // GenelAdresListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1058, 482);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.longNavigator);
            this.IconOptions.ShowIcon = false;
            this.Name = "GenelAdresListForm";
            this.Text = "Adres Kartları";
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
            private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colKod;
            private UserControls.Grid.MyBandedGridColumn colBaslik;
            private UserControls.Grid.MyBandedGridColumn colAdresNotu;
            private UserControls.Grid.MyBandedGridColumn colAdresTurleriAdi;
            private UserControls.Grid.MyBandedGridColumn colAdresTipi;
            private UserControls.Grid.MyBandedGridColumn colUlkeAdi;
            private UserControls.Grid.MyBandedGridColumn colIlAdi;
            private UserControls.Grid.MyBandedGridColumn colIlceAdi;
            private UserControls.Grid.MyBandedGridColumn colPostaKodu;
            private UserControls.Grid.MyBandedGridColumn colAdres;
            private UserControls.Grid.MyBandedGridColumn colEnlem;
            private UserControls.Grid.MyBandedGridColumn colBoylam;
            private UserControls.Grid.MyBandedGridColumn colOzelKod1Adi;
            private UserControls.Grid.MyBandedGridColumn colOzelKod2Adi;
            private UserControls.Grid.MyBandedGridColumn colAciklama;
            private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colId;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand7;
    }
}