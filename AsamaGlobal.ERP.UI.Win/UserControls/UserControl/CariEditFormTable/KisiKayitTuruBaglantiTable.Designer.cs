namespace AsamaGlobal.ERP.UI.Win.UserControls.UserControl.CariEditFormTable
{
    partial class KisiKayitTuruBaglantiTable
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

            #region Component Designer generated code

            /// <summary> 
            /// Required method for Designer support - do not modify 
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
            this.grid = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridControl();
            this.tablo = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colKodKisi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colKisiAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.repositoryKisi = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colPozisyonAdi = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.repositoryPozisyon = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colAciklama = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colKisiId = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            this.colPozisyonId = new AsamaGlobal.ERP.UI.Win.UserControls.Grid.MyBandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryKisi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryPozisyon)).BeginInit();
            this.SuspendLayout();
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 0);
            this.grid.MainView = this.tablo;
            this.grid.Name = "grid";
            this.grid.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryKisi,
            this.repositoryPozisyon});
            this.grid.Size = new System.Drawing.Size(706, 370);
            this.grid.TabIndex = 5;
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
            this.gridBand2,
            this.gridBand3});
            this.tablo.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colKodKisi,
            this.colKisiId,
            this.colKisiAdi,
            this.colPozisyonId,
            this.colPozisyonAdi,
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
            this.tablo.ViewCaption = "Bağlantılar";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "Kişiler";
            this.gridBand1.Columns.Add(this.colKodKisi);
            this.gridBand1.Columns.Add(this.colKisiAdi);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 320;
            // 
            // colKodKisi
            // 
            this.colKodKisi.Caption = "Kod";
            this.colKodKisi.FieldName = "KodKisi";
            this.colKodKisi.Name = "colKodKisi";
            this.colKodKisi.OptionsColumn.AllowEdit = false;
            this.colKodKisi.StatusBarAciklama = null;
            this.colKodKisi.StatusBarKisaYol = null;
            this.colKodKisi.StatusBarKisaYolAciklama = null;
            this.colKodKisi.Visible = true;
            this.colKodKisi.Width = 130;
            // 
            // colKisiAdi
            // 
            this.colKisiAdi.Caption = "Kişi";
            this.colKisiAdi.ColumnEdit = this.repositoryKisi;
            this.colKisiAdi.FieldName = "KisiAdi";
            this.colKisiAdi.Name = "colKisiAdi";
            this.colKisiAdi.StatusBarAciklama = null;
            this.colKisiAdi.StatusBarKisaYol = null;
            this.colKisiAdi.StatusBarKisaYolAciklama = null;
            this.colKisiAdi.Visible = true;
            this.colKisiAdi.Width = 190;
            // 
            // repositoryKisi
            // 
            this.repositoryKisi.AutoHeight = false;
            this.repositoryKisi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryKisi.Name = "repositoryKisi";
            this.repositoryKisi.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gridBand2
            // 
            this.gridBand2.Caption = "Pozisyon Bilgileri";
            this.gridBand2.Columns.Add(this.colPozisyonAdi);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 1;
            this.gridBand2.Width = 190;
            // 
            // colPozisyonAdi
            // 
            this.colPozisyonAdi.Caption = "Pozisyon";
            this.colPozisyonAdi.ColumnEdit = this.repositoryPozisyon;
            this.colPozisyonAdi.FieldName = "PozisyonAdi";
            this.colPozisyonAdi.Name = "colPozisyonAdi";
            this.colPozisyonAdi.StatusBarAciklama = null;
            this.colPozisyonAdi.StatusBarKisaYol = null;
            this.colPozisyonAdi.StatusBarKisaYolAciklama = null;
            this.colPozisyonAdi.Visible = true;
            this.colPozisyonAdi.Width = 190;
            // 
            // repositoryPozisyon
            // 
            this.repositoryPozisyon.AutoHeight = false;
            this.repositoryPozisyon.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryPozisyon.Name = "repositoryPozisyon";
            this.repositoryPozisyon.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            // 
            // gridBand3
            // 
            this.gridBand3.Caption = "Açıklama";
            this.gridBand3.Columns.Add(this.colAciklama);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 2;
            this.gridBand3.Width = 300;
            // 
            // colAciklama
            // 
            this.colAciklama.Caption = "Açıklama";
            this.colAciklama.FieldName = "Aciklama";
            this.colAciklama.Name = "colAciklama";
            this.colAciklama.StatusBarAciklama = null;
            this.colAciklama.StatusBarKisaYol = null;
            this.colAciklama.StatusBarKisaYolAciklama = null;
            this.colAciklama.Visible = true;
            this.colAciklama.Width = 300;
            // 
            // colKisiId
            // 
            this.colKisiId.Caption = "KisiId";
            this.colKisiId.FieldName = "KisiId";
            this.colKisiId.Name = "colKisiId";
            this.colKisiId.OptionsColumn.AllowEdit = false;
            this.colKisiId.StatusBarAciklama = null;
            this.colKisiId.StatusBarKisaYol = null;
            this.colKisiId.StatusBarKisaYolAciklama = null;
            this.colKisiId.Visible = true;
            // 
            // colPozisyonId
            // 
            this.colPozisyonId.Caption = "PozisyonId";
            this.colPozisyonId.FieldName = "PozisyonId";
            this.colPozisyonId.Name = "colPozisyonId";
            this.colPozisyonId.OptionsColumn.AllowEdit = false;
            this.colPozisyonId.StatusBarAciklama = null;
            this.colPozisyonId.StatusBarKisaYol = null;
            this.colPozisyonId.StatusBarKisaYolAciklama = null;
            this.colPozisyonId.Visible = true;
            // 
            // KisiKayitTuruBaglantiTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grid);
            this.Name = "KisiKayitTuruBaglantiTable";
            this.Controls.SetChildIndex(this.insUptNavigator, 0);
            this.Controls.SetChildIndex(this.grid, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tablo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryKisi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryPozisyon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

            }

        #endregion

        private Grid.MyBandedGridControl grid;
        private Grid.MyBandedGridView tablo;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private Grid.MyBandedGridColumn colKodKisi;
        private Grid.MyBandedGridColumn colKisiAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryKisi;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private Grid.MyBandedGridColumn colPozisyonAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryPozisyon;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private Grid.MyBandedGridColumn colAciklama;
        private Grid.MyBandedGridColumn colKisiId;
        private Grid.MyBandedGridColumn colPozisyonId;
    }
}