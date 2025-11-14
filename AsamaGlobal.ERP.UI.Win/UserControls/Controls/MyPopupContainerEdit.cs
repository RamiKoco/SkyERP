using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.UI.Win.Interfaces;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AsamaGlobal.ERP.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyPopupContainerEdit : PopupContainerEdit, IStatusBarAciklama
    {
        private readonly PopupContainerControl _popupContainer;
        private readonly MyTokenEdit txtEtiket;
        private Dictionary<long, string> _etiketAdlari = new Dictionary<long, string>();
        public MyPopupContainerEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AutoHeight = false;
            _popupContainer = new PopupContainerControl
            {
                Size = new Size(200, 90),
                BackColor = Color.White
            };
            txtEtiket = new MyTokenEdit
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyles.Simple,
                Margin = new Padding(10)
            };
            _popupContainer.Controls.Add(txtEtiket);
            Properties.PopupControl = _popupContainer;
            Properties.ShowDropDown = ShowDropDown.SingleClick;
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.QueryPopUp += (s, e) => txtEtiket.Focus();            
            Properties.QueryResultValue += (sender, e) =>
            {
                string[] values = null;

                if (txtEtiket.EditValue is string text)
                    values = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                else if (txtEtiket.EditValue is string[])
                    values = (string[])txtEtiket.EditValue;

                else if (txtEtiket.EditValue is IEnumerable<string>)
                    values = ((IEnumerable<string>)txtEtiket.EditValue).ToArray();

                else if (txtEtiket.EditValue is IEnumerable<TokenEditToken>)
                {
                    var tokens = (IEnumerable<TokenEditToken>)txtEtiket.EditValue;
                    values = tokens.Select(t => t.Value != null ? t.Value.ToString() : "").ToArray();
                }
                else
                    values = Array.Empty<string>();

                e.Value = string.Join(",", values);
            };

            QueryDisplayText += (sender, e) =>
            {
                string[] values;

                if (txtEtiket.EditValue is string text)
                    values = text.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                else
                    values = Array.Empty<string>();
                var displayNames = values
                                    .Select(v =>
                                    {
                                        if (long.TryParse(v, out var id) && txtEtiket.EtiketAdlari.TryGetValue(id, out var name))
                                            return name; // sadece isim
                                        return null; // sözlükte yoksa null
                                    })
                                    .Where(x => !string.IsNullOrEmpty(x))
                                    .ToArray();

                e.DisplayText = string.Join(", ", displayNames);
            };
        }
        public void EtiketAdlariniYukle(Dictionary<long, string> etiketAdlari)
        {
            _etiketAdlari = etiketAdlari;
        }
        public void EtiketleriYukle(List<Etiket> etiketListesi)
        {
            txtEtiket.Properties.Tokens.Clear();
            foreach (var etiket in etiketListesi)
            {
                var token = new TokenEditToken(etiket.Ad, etiket.Id.ToString());
                txtEtiket.Properties.Tokens.Add(token);
            }
        }
        public List<long> SeciliEtiketIdleriGetir()
        {
            string[] values = null;

            if (txtEtiket.EditValue is string[])
                values = (string[])txtEtiket.EditValue;
            else if (txtEtiket.EditValue is IEnumerable<string>)
                values = ((IEnumerable<string>)txtEtiket.EditValue).ToArray();
            else if (txtEtiket.EditValue is IEnumerable<TokenEditToken>)
            {
                var tokens = (IEnumerable<TokenEditToken>)txtEtiket.EditValue;
                values = tokens.Select(t => t.Value != null ? t.Value.ToString() : "").ToArray();
            }
            else
                values = new string[0];

            return values
                .Select(x => long.TryParse(x, out var id) ? id : 0)
                .Where(x => x > 0)
                .ToList();
        }
        public MyTokenEdit TokenEditControl => txtEtiket; 
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
    }
}
