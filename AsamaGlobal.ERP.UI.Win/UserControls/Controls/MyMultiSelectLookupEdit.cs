using AsamaGlobal.ERP.UI.Win.Interfaces;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;

namespace AsamaGlobal.ERP.UI.Win.UserControls.Controls
{
     [ToolboxItem(true)]
    public class MyMultiSelectLookupEdit : LookUpEdit, IStatusBarKisaYol
    {
        //private const int MinColumnWidth = 25; // Minimum kolon genişliği
        private const int MinPopupWidth = 260; // İhtiyaca göre değiştir
        public MyMultiSelectLookupEdit()
        {           
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            // Multi-select ayarları
            Properties.EditValueType = LookUpEditValueType.ValueList;
            Properties.EnableEditValueCollectionEditing = DefaultBoolean.True;
            Properties.NullValuePrompt = "Seçiniz...";
            Properties.SearchMode = SearchMode.AutoSearch;
            Properties.PopupFilterMode = PopupFilterMode.Contains;
            Properties.TextEditStyle = TextEditStyles.Standard;
            Properties.PopupWidth = MinPopupWidth; // <--- Popup genişliğini ayarlar
            EnterMoveNextControl = true;      
        }

        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }

        public override bool EnterMoveNextControl { get; set; }  

        [Browsable(false)]
        public HashSet<long> SelectedIds
        {
            get
            {
                if (EditValue == null) return new HashSet<long>();
                var asEnum = EditValue as IEnumerable;
                if (asEnum == null) return new HashSet<long>();
                var list = new List<long>();
                foreach (var o in asEnum)
                {
                    if (o == null) continue;
                    try { list.Add(Convert.ToInt64(o)); }
                    catch { }
                }
                return new HashSet<long>(list);
            }
        }       
        public void SetSelectedIds(IEnumerable<long> ids)
        {
            if (ids == null) { EditValue = null; return; }
            // **ÖNEMLİ:** sabit boyutlu array yerine List<object>
            var mutable = ids.Select(i => (object)i).ToList();
            EditValue = mutable;
            this.Refresh();
        }
    }
}