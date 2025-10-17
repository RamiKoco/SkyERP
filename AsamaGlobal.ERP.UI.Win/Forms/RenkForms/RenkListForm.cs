using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;
using AsamaGlobal.ERP.UI.Win.UserControls.Navigators;
using DevExpress.Utils.FormShadow;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.UI.Win.Forms.RenkForms
{
    public partial class RenkListForm : BaseListForm
    {
        public RenkListForm()
        {
            InitializeComponent();
            Bll = new RenkBll();
            //tablo.RowCellStyle += tablo_RowCellStyle; // <-- bu satırı ekle          
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Renk;
            FormShow = new ShowEditForms<RenkEditForm>();
            Navigator = longNavigator.Navigator;
            GridRenkAyarla();
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((RenkBll)Bll).List(FilterFunctions.Filter<Renk>(AktifKartlariGoster));

        }
        private void GridRenkAyarla()
        {
            var colorEdit = new RepositoryItemColorEdit
            {
                ReadOnly = true,
                ShowColorDialog = false,
                TextEditStyle = TextEditStyles.DisableTextEditor
            };

            colForeColor.ColumnEdit = colorEdit;

            // Sayısal değeri gizle, sadece renk kutusu göster
            tablo.CustomColumnDisplayText += (s, e) =>
            {
                if (e.Column.FieldName == "ForeColor")
                    e.DisplayText = "";
            };
        }

        ///////// Yazıları etkileyen Renk kodu//////////
        //private void tablo_RowCellStyle(object sender, RowCellStyleEventArgs e)
        //{
        //    if (e.Column.FieldName != "RenkAdi") return;

        //    var view = sender as GridView;
        //    var renk = view.GetRowCellValue(e.RowHandle, "ForeColor");

        //    if (renk != null && int.TryParse(renk.ToString(), out int argb))
        //        e.Appearance.ForeColor = Color.FromArgb(argb);
        //}
    }
}