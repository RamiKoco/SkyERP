using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyKoordinatTextEdit : MyTextEdit
    {
        public MyKoordinatTextEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = HorzAlignment.Center;
            Properties.Mask.MaskType = MaskType.RegEx;
            Properties.Mask.EditMask = @"\d{0,3}(\.\d{0,6})?";
            Properties.Mask.PlaceHolder = ' ';
            Properties.Mask.UseMaskAsDisplayFormat = true;
            Properties.Mask.AutoComplete = AutoCompleteType.None;

            StatusBarAciklama = "Koordinat Giriniz. Örn: 28.654321";

            Enter += (s, e) =>
            {
                BeginInvoke(new Action(() => Select(0, 0)));
            };

            Leave += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(Text))
                {
                    if (!System.Text.RegularExpressions.Regex.IsMatch(Text, @"^\d{1,3}(\.\d{1,6})?$"))
                    {
                        XtraMessageBox.Show("Geçersiz koordinat! Virgülden önce en fazla 3, sonra en fazla 6 hane olmalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        Text = "";
                    }
                }
            }; ;
        }
    }
}
