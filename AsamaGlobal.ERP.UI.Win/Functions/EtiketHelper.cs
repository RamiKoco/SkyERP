using AbcYazilim.OgrenciTakip.Bll.General;
using AbcYazilim.OgrenciTakip.Common.Enums;
using AbcYazilim.OgrenciTakip.Model.Dto;
using AbcYazilim.OgrenciTakip.Model.Entities;
using AsamaGlobal.ERP.Data.Contexts;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace AsamaGlobal.ERP.UI.Win.Functions
{
    public class EtiketHelper
    {
        private List<EtiketL> _tumEtiketler;
        public void EtiketleriYukle(TokenEdit txtEtiket, KayitTuru kayitTuru)
        {
            var etiketBll = new EtiketBll();
            _tumEtiketler = etiketBll
            .List(x => x.Durum && x.KayitTuru == kayitTuru)
            .Cast<EtiketL>()
            .ToList();

            txtEtiket.Properties.DataSource = _tumEtiketler;
            txtEtiket.Properties.DisplayMember = "EtiketAdi";
            txtEtiket.Properties.ValueMember = "Id";

            txtEtiket.Properties.CustomDrawTokenBackground -= TxtEtiket_CustomDrawTokenBackground;
            txtEtiket.Properties.CustomDrawTokenBackground += TxtEtiket_CustomDrawTokenBackground;

            txtEtiket.Properties.CustomDrawTokenText -= TxtEtiket_CustomDrawTokenText;
            txtEtiket.Properties.CustomDrawTokenText += TxtEtiket_CustomDrawTokenText;
        }     
        private void TxtEtiket_CustomDrawTokenBackground(object sender, TokenEditCustomDrawTokenBackgroundEventArgs e)
        {
            try
            {
                if (e?.Info == null) { e.Handled = false; return; }

                var id = ResolveEtiketId(e.Value);
                Color? back = null;

                if (id.HasValue)
                {
                    var etiket = _tumEtiketler?.FirstOrDefault(x => x.Id == id.Value);
                    if (etiket != null)
                    {
                        try
                        {
                            if (!string.IsNullOrEmpty(etiket.RenkRGB))
                                back = ColorTranslator.FromHtml(etiket.RenkRGB);
                            else if (etiket.RenkForeColor.HasValue)
                                back = Color.FromArgb(etiket.RenkForeColor.Value);
                        }
                        catch
                        {
                            back = Color.LightGray;
                        }
                    }
                }

                var text = e.Info.Description ?? _tumEtiketler?.FirstOrDefault(x => x.Id == id)?.EtiketAdi ?? "";
                var g = e.Cache.Graphics;
                var font = e.Info.PaintAppearance?.Font ?? SystemFonts.DefaultFont;
                var textSize = g.MeasureString(text, font);

                // Token genişliğini text boyutuna göre ayarla
                var rect = new Rectangle(
                    e.Info.Bounds.X,
                    e.Info.Bounds.Y,
                    Math.Max(e.Info.Bounds.Width, (int)Math.Ceiling(textSize.Width) + 20), // +20 X butonu için padding
                    e.Info.Bounds.Height
                );

                if (back.HasValue)
                {
                    using (var brush = new SolidBrush(back.Value))
                    {
                        g.FillRectangle(brush, rect);
                    }
                }

                e.Handled = true;
            }
            catch
            {
                e.Handled = false;
            }
        }
        private void TxtEtiket_CustomDrawTokenText(object sender, TokenEditCustomDrawTokenTextEventArgs e)
        {
            if (e?.Info == null) { e.Handled = false; return; }

            var rect = e.Info.Bounds;
            string text = e.Info.Description;
            if (string.IsNullOrEmpty(text))
            {
                var id = ResolveEtiketId(e.Value);
                text = _tumEtiketler?.FirstOrDefault(x => x.Id == id)?.EtiketAdi ?? string.Empty;
            }
            if (string.IsNullOrEmpty(text)) { e.Handled = false; return; }

            Color? back = null;
            var id2 = ResolveEtiketId(e.Value);
            var etiket = id2.HasValue ? _tumEtiketler?.FirstOrDefault(x => x.Id == id2) : null;

            if (etiket != null && !string.IsNullOrEmpty(etiket.RenkRGB))
                back = ColorTranslator.FromHtml(etiket.RenkRGB);
            
            Color fore = (etiket != null && etiket.YaziRgbKodu != 0)
                ? Color.FromArgb(etiket.YaziRgbKodu)
                : GetContrastColor(back ?? Color.White);

            using (var brush = new SolidBrush(fore))
            {
                var g = e.Cache.Graphics;
                var font = e.Info.PaintAppearance?.Font ?? SystemFonts.DefaultFont;

                var padding = 2;
                var fitRect = new RectangleF(rect.X +15, rect.Y, rect.Width - padding * 4, rect.Height);            
                var size = g.MeasureString(text, font);
                float minFont = 7f;
                if (size.Width > fitRect.Width)
                {
                    float newSize = Math.Max(font.Size * fitRect.Width / size.Width, minFont);
                    font = new Font(font.FontFamily, newSize, font.Style);
                }

                var sf = new StringFormat { LineAlignment = StringAlignment.Center, Alignment = StringAlignment.Near };
                g.DrawString(text, font, brush, fitRect, sf);
            }

            e.Handled = true;
        }
        private long? ResolveEtiketId(object value)
        {
            if (value == null) return null;
            if (value is long l) return l;
            if (value is int i) return i;
            if (value is short s) return (long)s;
            if (value is string str && long.TryParse(str, out var parsed)) return parsed;
            var prop = value.GetType().GetProperty("Id");
            if (prop != null)
            {
                var val = prop.GetValue(value);
                if (val is long ll) return ll;
                if (val is int ii) return ii;
                if (val is short ss) return ss;
            }
            return null;
        }
        private static Color GetContrastColor(Color c)
        {
            var yiq = (c.R * 299 + c.G * 587 + c.B * 114) / 1000;
            return yiq >= 128 ? Color.Black : Color.White;
        }
        public void BaglantilariGuncelle(KayitTuru kayitTuru, long kayitId, IEnumerable<long> seciliEtiketIdler)
        {
            var db = new ERPContext();

            var eskiBaglantilar = db.EtiketKayitTuruBaglanti
                .Where(x => x.KayitTuru == kayitTuru && x.KayitId == kayitId)
                .ToList();

            db.EtiketKayitTuruBaglanti.RemoveRange(eskiBaglantilar);

            foreach (var etiketId in seciliEtiketIdler)
            {
                db.EtiketKayitTuruBaglanti.Add(new EtiketKayitTuruBaglanti
                {
                    EtiketId = etiketId,
                    KayitTuru = kayitTuru,
                    KayitId = kayitId
                });
            }

            db.SaveChanges();
        }
        public List<long> EtiketIdleriniAl(object editValue)
        {
            if (editValue == null) return new List<long>();

            if (editValue is string str)
                return str.Split(',')
                          .Select(x => long.TryParse(x, out var val) ? val : 0)
                          .Where(x => x > 0)
                          .ToList();

            if (editValue is IEnumerable<long> longList)
                return longList.ToList();

            if (editValue is long singleLong)
                return new List<long> { singleLong };

            return new List<long>();
        }
    }
}