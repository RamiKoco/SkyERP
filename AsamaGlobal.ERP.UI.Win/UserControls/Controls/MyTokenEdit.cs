using AsamaGlobal.ERP.UI.Win.Interfaces;
using DevExpress.XtraEditors;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace AsamaGlobal.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyTokenEdit : TokenEdit, IStatusBarAciklama
    {
        private Dictionary<long, string> _etiketAdlari = new Dictionary<long, string>();
        public MyTokenEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AutoHeight = false;
        }
        public void EtiketAdlariniYukle(Dictionary<long, string> etiketAdlari)
        {
            _etiketAdlari = etiketAdlari;
        }
        public Dictionary<long, string> EtiketAdlari => _etiketAdlari;
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; } 
    }
}