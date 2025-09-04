using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Bll.General;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using AsamaGlobal.ERP.UI.Win.Show;

namespace AsamaGlobal.ERP.UI.Win.Forms.EtiketForms
{
    public partial class EtiketListForm : BaseListForm
    {
        public EtiketListForm()
        {
            InitializeComponent();
            Bll = new EtiketBll();
            //tablo.RowCellStyle += Tablo_RowCellStyle; // tablo = GridView’in
        }
        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = KartTuru.Etiket;
            FormShow = new ShowEditForms<EtiketEditForm>();
            Navigator = longNavigator.Navigator;
        }
        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((EtiketBll)Bll).List(FilterFunctions.Filter<Etiket>(AktifKartlariGoster));
        }
        //private void Tablo_RowCellStyle(object sender, RowCellStyleEventArgs e)
        //{
        //    var view = sender as GridView;
        //    if (view == null) return;

        //    // YaziRgbKodu alanını güvenli şekilde çek
        //    object argbObj = view.GetRowCellValue(e.RowHandle, "YaziRgbKodu");
        //    if (argbObj == null || argbObj == DBNull.Value) return;

        //    int argb;
        //    try
        //    {
        //        argb = argbObj is int i ? i : Convert.ToInt32(argbObj);
        //    }
        //    catch
        //    {
        //        return;
        //    }

        //    if (argb == 0) return; // 0 = boş/transparan varsayıyoruz

        //    var color = Color.FromArgb(argb);

        //    // Tüm satırı renklendir (istersen sadece belirli kolonlara uygula)
        //    e.Appearance.BackColor = color;
        //    e.Appearance.Options.UseBackColor = true;

        //    // Otomatik kontrast: açık zemin ise siyah, koyu zemin ise beyaz yazı
        //    double luminance = 0.2126 * color.R + 0.7152 * color.G + 0.0722 * color.B;
        //    e.Appearance.ForeColor = luminance < 140 ? Color.White : Color.Black;
        //    e.Appearance.Options.UseForeColor = true;
        //}
    }
}