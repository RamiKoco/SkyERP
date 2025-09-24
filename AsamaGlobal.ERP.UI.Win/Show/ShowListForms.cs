using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Functions;

namespace AsamaGlobal.ERP.UI.Win.Show
{
    public class ShowListForms<TForm> where TForm : BaseListForm
    {

        public static void ShowListForm(KartTuru kartTuru)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return;

            var frm = (TForm) Activator.CreateInstance(typeof(TForm));
            frm.MdiParent = Form.ActiveForm;

            frm.Yukle();
            frm.Show();
        }
        public static void ShowListForm(KartTuru kartTuru,params object[] prm)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return;

            var frm = (TForm)Activator.CreateInstance(typeof(TForm),prm);
            frm.MdiParent = Form.ActiveForm;

            frm.Yukle();
            frm.Show();
        }

 

        public static BaseEntity ShowDialogListForm(KartTuru kartTuru, long? seciliGelecekId, params object[] prm)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return null;

            using (var frm = (TForm) Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.SeciliGelecekId = seciliGelecekId;
                frm.Yukle();
                
                if (!frm.IsDisposed)
                frm.ShowDialog();

                return frm.DialogResult == DialogResult.OK ? frm.SelectedEntity : null;
            }
        }

        public static void ShowDialogListForm()
        {

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.AktifPasifButonGoster = true;
                frm.Yukle();
                frm.ShowDialog();
            }
        }


        public static IEnumerable<IBaseEntity> ShowDialogListForm(KartTuru kartTuru, IList<long> ListeDisiTutulacakKayitlar, bool multiSelect, params object[] prm)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return null;


            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm),prm))
            {
                frm.ListeDisiTutulacakKayitlar = ListeDisiTutulacakKayitlar;
                frm.MultiSelect = multiSelect;
                frm.Yukle();
                frm.RowSelect = new SelectRowFunctions(frm.Tablo);

                if (frm.EklenebilecekEntityVar)
                    frm.ShowDialog();

                return frm.DialogResult == DialogResult.OK ? frm.SelectedEntities : null;

            }

        }
        public static IEnumerable<IBaseEntity> ShowDialogListForm(IList<long> ListeDisiTutulacakKayitlar, bool multiSelect, params object[] prm)
        {


            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.ListeDisiTutulacakKayitlar = ListeDisiTutulacakKayitlar;
                frm.MultiSelect = multiSelect;
                frm.Yukle();
                frm.RowSelect = new SelectRowFunctions(frm.Tablo);

                if (frm.EklenebilecekEntityVar)
                    frm.ShowDialog();

                return frm.DialogResult == DialogResult.OK ? frm.SelectedEntities : null;

            }

        }

        public static IEnumerable<IBaseEntity> ShowDialogListForm(KartTuru kartTuru, bool multiSelect, params object[] prm)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return null;


            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.MultiSelect = multiSelect;
                frm.Yukle();
                frm.RowSelect = new SelectRowFunctions(frm.Tablo);
                frm.ShowDialog();

                return frm.DialogResult == DialogResult.OK ? frm.SelectedEntities : null;

            }

        }       

        public static BaseEntity ShowDialogListForm(KartTuru kartTuru, long? seciliGelecekId, Action<TForm> configure = null, params object[] prm)
        {
            if (!kartTuru.YetkiKontrolu(YetkiTuru.Gorebilir)) return null;

            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.SeciliGelecekId = seciliGelecekId;

                // Lambda önce uygulanmalı
                configure?.Invoke(frm);

                // Sonra form yüklenmeli
                frm.Yukle();
                if (!frm.IsDisposed)
                    frm.ShowDialog();

                return frm.DialogResult == DialogResult.OK ? frm.SelectedEntity : null;
            }
        }
    }
}

