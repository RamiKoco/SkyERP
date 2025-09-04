using System.Drawing;
using System.IO;

namespace AsamaGlobal.ERP.UI.Win.Functions
{
    public static class ImageHelper
    {
        public static bool ByteArrayEqual(byte[] a, byte[] b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a == null || b == null || a.Length != b.Length) return false;
            if (a.Length != b.Length) return false;
            for (int i = 0; i < a.Length; i++)
                if (a[i] != b[i]) return false;
            return true;
        }

        public static byte[] GetBytesFromEditValue(object editValue)
        {
            if (editValue == null) return null;
            if (editValue is byte[] bytes) return bytes;
            if (editValue is Image img) return ToBytes(img);
            return null;
        }

        public static Image ToImage(byte[] data)
        {
            var ms = new MemoryStream(data);
            return Image.FromStream(ms);
        }

        public static byte[] ToBytes(Image img)
        {
            var ms = new MemoryStream();
            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        public static Bitmap ResizeHighQuality(Image image, int w, int h)
        {
            var dest = new Bitmap(w, h);
            using (var g = Graphics.FromImage(dest))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
                g.DrawImage(image, new Rectangle(0, 0, w, h));
            }
            return dest;
        }

    }
}
