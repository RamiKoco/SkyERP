using DevExpress.Utils;
using DevExpress.XtraEditors.Mask;
using System;
using System.ComponentModel;

namespace AsamaGlobal.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MySGKSicilNoTextEdit : MyTextEdit
    {
        public MySGKSicilNoTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.AutoComplete = AutoCompleteType.None;
            Properties.Mask.MaskType = MaskType.RegEx;
            Properties.Mask.EditMask = @"\d{11}";  // 11 rakamdan oluşmalı
            Properties.Mask.PlaceHolder = ' ';
            Properties.Mask.UseMaskAsDisplayFormat = true;
            StatusBarAciklama = "SGK Sicil No Giriniz. Örn: 12345678912";
            Enter += (s, e) =>
            {
                BeginInvoke(new Action(() => Select(0, 0))); // imleç başa gelir
            };
        }
    }
}
