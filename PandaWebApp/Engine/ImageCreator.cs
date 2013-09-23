using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PandaDataAccessLayer.Helpers;

namespace PandaWebApp.Engine
{
    public class ImageCreator
    {
        private const string CachePath = "/Content/img/cache/";
        private const string ImgPath = "/Content/img/";
        private const int MaxWidth = 800;
        private const int MaxHeight = 600;

        private static string generatePath(string srcImagePath, int width, int height)
        {
            var ext = Path.GetExtension(srcImagePath);
            return CachePath + Crypt.GetMD5Hash(srcImagePath + width + height) + ext;
        }

        public static string Create(string src, int? width, int? height)
        {
            try
            {
                var sourcePath = HttpContext.Current.Server.MapPath(src);
                if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
                {
                    return string.Empty;
                }
                using (var srcBitmap = new Bitmap(sourcePath))
                {
                    var w = width.HasValue ? width.Value : srcBitmap.Width;
                    var h = height.HasValue ? height.Value : srcBitmap.Height;

                    var imagePath = generatePath(sourcePath, w, h);
                    var mappedImagePath = HttpContext.Current.Server.MapPath(imagePath);
                    if (File.Exists(mappedImagePath))
                    {
                        return imagePath;
                    }

                    using (var destBitmap = new Bitmap(srcBitmap, new Size(w, h)))
                    {
                        destBitmap.Save(mappedImagePath);
                        return imagePath;
                    }
                }
            }
            catch (Exception)
            {
                return src;
            }
        }

        public static void Create(string src, Rectangle crop)
        {
            var sourcePath = HttpContext.Current.Server.MapPath(src);
            if (string.IsNullOrEmpty(sourcePath) || !File.Exists(sourcePath))
            {
                return;
            }
            Bitmap cropped;
            using (var srcBitmap = new Bitmap(sourcePath))
            {
                cropped = srcBitmap.Clone(crop, srcBitmap.PixelFormat);
            }
            cropped.Save(sourcePath);
        }

        public static string SavePhoto(HttpPostedFileBase file)
        {
            var sourcePath = HttpContext.Current.Server.MapPath(ImgPath);
            var fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            using (var srcBitmap = new Bitmap(file.InputStream))
            {
                var aspect = 1.0;
                if (srcBitmap.Width > MaxWidth)
                {
                    aspect = (double)MaxWidth / srcBitmap.Width;
                }
                if (srcBitmap.Height*aspect > MaxHeight)
                {
                    aspect = (double)MaxHeight / srcBitmap.Height;
                }
                using (
                    var destBitmap = new Bitmap(srcBitmap,
                                                new Size((int)(srcBitmap.Width*aspect), (int)(srcBitmap.Height*aspect))))
                {
                    destBitmap.Save(Path.Combine(sourcePath, fileName));
                }
            }
            return ImgPath + fileName;
        }
    }
}