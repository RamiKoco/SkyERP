using AsamaGlobal.ERP.Common.Enums;
using AsamaGlobal.ERP.Model.Entities.Base;
using AsamaGlobal.ERP.Model.Entities.Base.Interfaces;
using AsamaGlobal.ERP.UI.Win.Forms.BaseForms;
using AsamaGlobal.ERP.UI.Win.Forms.CariForms;
using AsamaGlobal.ERP.UI.Win.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
                configure?.Invoke(frm);

                // Çağıranın CarilerEditForm olup olmadığını tespit et
                var active = Form.ActiveForm;
                bool callerIsCarilerEditForm =
                    // 1) TForm doğrudan CarilerEditForm ise (nadiren true olur)
                    typeof(TForm) == typeof(CarilerEditForm)
                    // 2) aktif form CarilerEditForm ya da türevi ise
                    || (active != null && (active.GetType() == typeof(CarilerEditForm) || active.GetType().IsSubclassOf(typeof(CarilerEditForm))))
                    // 3) fallback: açık formlar arasında herhangi bir CarilerEditForm varsa (daha gevşek ama işe yarar)
                    || Application.OpenForms.Cast<Form>().OfType<CarilerEditForm>().Any();

                if (callerIsCarilerEditForm)
                {
                    // CarilerEditForm için gereken davranış
                    frm.AktifPasifButonGoster = false;
                    frm.Yukle();

                    if (!frm.IsDisposed)
                        frm.ShowDialog();

                    return frm.DialogResult == DialogResult.OK
                        ? frm.SelectedEntity
                        : null;
                }
                else
                {
                    // Ribbon / normal list formlar için davranış
                    frm.AktifPasifButonGoster = true;
                    frm.Yukle();
                    frm.ShowDialog();

                    return frm.DialogResult == DialogResult.OK
                           && frm.SelectedEntities != null
                           && frm.SelectedEntities.Count > 0
                        ? frm.SelectedEntities[0]
                        : null;
                }
            }
        }

    }
}

